import argparse
import socket
import requests

def resolve_subdomain(domain, subdomain):
    try:
        return socket.gethostbyname(f"{subdomain}.{domain}")
    except socket.gaierror:
        return None

def is_wildcard(domain):
    test_subdomains = [f"random-{i}" for i in range(3)]
    resolved_ips = set()
    
    for sub in test_subdomains:
        ip = resolve_subdomain(domain, sub)
        if ip:
            resolved_ips.add(ip)
    
    return len(resolved_ips) == 1

def check_http(domain, subdomain, https, port, verbose):
    protocol = "https" if https else "http"
    url = f"{protocol}://{subdomain}.{domain}:{port}"
    try:
        response = requests.get(url, timeout=5)
        if verbose:
            print(f"[*] Trying: {url}")
        if response.status_code == 200:
            print(f"[+] Found: {url}")
    except requests.ConnectionError:
        if verbose:
            print(f"[-] Failed: {url}")
    except requests.exceptions.RequestException as e:
        if verbose:
            print(f"[!] Error for {url}: {e}")

def scan_subdomains(domain, subdomains_file, ports, verbose, https):
    print(f"\n[INFO] Checking for wildcard DNS on {domain}...")
    if is_wildcard(domain):
        print(f"[WARNING] Wildcard DNS detected! Results may include false positives.\n")
    else:
        print(f"[INFO] No wildcard DNS detected. Proceeding with scan.\n")

    with open(subdomains_file, 'r') as file:
        subdomains = file.read().splitlines()
    
    print(f"[INFO] Scanning for subdomains of {domain}...\n")
    for subdomain in subdomains:
        ip = resolve_subdomain(domain, subdomain)
        if ip:
            print(f"[+] Resolved: {subdomain}.{domain} -> {ip}")
            for port in ports or [80, 443]:
                check_http(domain, subdomain, https=(port == 443 or https), port=port, verbose=verbose)
        elif verbose:
            print(f"[-] Could not resolve: {subdomain}.{domain}")

if __name__ == "__main__":
    parser = argparse.ArgumentParser()
    parser.add_argument("-d", "--domain", required=True, help="The target domain to scan")
    parser.add_argument("-w", "--wordlist", required=True, help="File containing a list of potential subdomains")
    parser.add_argument("-p", "--ports", nargs="*", type=int, default=[80, 443], help="Ports to scan (default: 80 and 443)")
    parser.add_argument("--https", action="store_true", help="Use HTTPS for all ports")
    parser.add_argument("-v", "--verbose", action="store_true", help="Enable verbose output")
    args = parser.parse_args()

    try:
        scan_subdomains(args.domain, args.wordlist, args.ports, args.verbose, args.https)
    except KeyboardInterrupt:
        print("\n[!] Scan interrupted by user.")
