#!/bin/bash

if [ "$EUID" -ne 0 ]; then
    echo "[ERROR] Please run as root or use sudo."
    exit 1
fi

echo "[INFO] Installing Python dependencies..."
pip install -r requirements.txt

echo "[INFO] Moving script to /usr/local/bin..."
cp file_integrity_checker.py /usr/local/bin/file-integrity-checker
chmod +x /usr/local/bin/file-integrity-checker

echo "[INFO] Creating alias..."
echo "alias file-integrity-checker='python3 /usr/local/bin/file-integrity-checker'" >> ~/.bashrc
source ~/.bashrc

echo "[INFO] Installation complete! Use 'file-integrity-checker' to run the script."
