#!/bin/bash

SCRIPT_NAME="subdomain_scanner.py"
ALIAS_NAME="subdomain-scanner"
INSTALL_PATH="/usr/local/bin"

if [ ! -f "$SCRIPT_NAME" ]; then
    echo "[ERROR] $SCRIPT_NAME not found in the current directory!"
    exit 1
fi

echo "[INFO] Installing Python dependencies..."
python3 -m venv venv
source venv/bin/activate
pip install -r requirements.txt
deactivate
echo "[INFO] Dependencies installed successfully."

echo "[INFO] Making the script executable..."
chmod +x "$SCRIPT_NAME"

echo "[INFO] Moving the script to $INSTALL_PATH/$ALIAS_NAME..."
sudo mv "$SCRIPT_NAME" "$INSTALL_PATH/$ALIAS_NAME"

echo "[INFO] Setting up an alias for $ALIAS_NAME..."
if [ -n "$SHELL" ] && [[ "$SHELL" == *"bash"* ]]; then
    echo "alias $ALIAS_NAME='$INSTALL_PATH/$ALIAS_NAME'" >> ~/.bashrc
    source ~/.bashrc
elif [ -n "$SHELL" ] && [[ "$SHELL" == *"zsh"* ]]; then
    echo "alias $ALIAS_NAME='$INSTALL_PATH/$ALIAS_NAME'" >> ~/.zshrc
    source ~/.zshrc
elif [ -n "$SHELL" ] && [[ "$SHELL" == *"fish"* ]]; then
    echo "alias $ALIAS_NAME='$INSTALL_PATH/$ALIAS_NAME'" >> ~/.config/fish/config.fish
    source ~/.config/fish/config.fish
else
    echo "[WARNING] Could not detect shell configuration file. Alias not set."
fi

echo "[SUCCESS] $ALIAS_NAME has been installed and configured. Use '$ALIAS_NAME' to run the scanner."
