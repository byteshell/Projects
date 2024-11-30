import os
import hashlib
import json 
import argparse

def calculate_hash(file_path, algorithm="sha256"):
    hash_function = getattr(hashlib, algorithm)()

    try:
        with open(file_path, "rb") as file:
            while chunk := file.read(8192):
                hash_function.update(chunk)

        return hash_function.hexdigest()
    except(FileNotFoundError, PermissionError) as error:
        print(f"[ERROR] Cannot read file {file_path}: {error}")

        return None
    
def scan_directory(directory, algorithm="sha256"):
    file_hashes = {}

    for root, _, files in os.walk(directory):
        for file in files:
            file_path = os.path.join(root, file)
            file_hash = calculate_hash(file_path, algorithm)

            if file_hash:
                file_hashes[file_path] = file_hash

    return file_hashes

def save_hashes(file_hashes, output_file):
    with open(output_file, "w") as file:
        json.dump(file_hashes, file, indent=4) 

    print(f"[INFO] Hashes saved to {output_file}")

def load_hashes(hash_file):
    try:
        with open(hash_file, "r") as file:
            return json.load(file)
    except FileNotFoundError:
        print(f"[ERROR] Hash file {hash_file} not found!")
        return {}

def compare_hashes(current_hashes, stored_hashes):
    added = []
    modified = []
    deleted = []

    for file, hash_value in current_hashes.items():
        if file not in stored_hashes:
            added.append(file)
        elif stored_hashes[file] != hash_value:
            modified.append(file)

    for file in stored_hashes:
        if file not in current_hashes:
            deleted.append(file)

    return added, modified, deleted                

def main():
    parser = argparse.ArgumentParser(description="File Integrity Checker")
    parser.add_argument('-d', '--directory', required=True, help="Directory to scan")
    parser.add_argument('-o', '--output', required=True, help="File to save/load hashes")
    parser.add_argument('-a', '--algorithm', default='sha256', choices=hashlib.algorithms_available, help="Hashing algorithm to use")
    parser.add_argument('--scan', action='store_true', help="Scan directory and save hashes")
    parser.add_argument('--check', action='store_true', help="Check integrity using saved hashes")

    args = parser.parse_args()

    if args.scan:
        print(f"[INFO] Scanning directory {args.directory} using {args.algorithm}...")
        hashes = scan_directory(args.directory, args.algorithm)
        save_hashes(hashes, args.output)

    elif args.check:
        print(f"[INFO] Checking integrity of {args.directory} using hashes in {args.output}...")
        stored_hashes = load_hashes(args.output)
        current_hashes = scan_directory(args.directory, args.algorithm)
        added, modified, deleted = compare_hashes(current_hashes, stored_hashes)

        print("\n--- Integrity Check Report ---")
        print(f"Added files: {len(added)}")
        for file in added:
            print(f"  [+] {file}")
        print(f"Modified files: {len(modified)}")
        for file in modified:
            print(f"  [*] {file}")
        print(f"Deleted files: {len(deleted)}")
        for file in deleted:
            print(f"  [-] {file}")

    else:
        print("[ERROR] Please specify either --scan or --check.")


if __name__ == "__main__":
    main()                           
