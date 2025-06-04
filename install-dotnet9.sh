#!/usr/bin/env bash
# Installs the .NET 9 SDK locally for running Advent of Code solutions.
# This script downloads Microsoft's dotnet-install script and uses it to
# install the latest .NET 9 preview into ~/.dotnet.
set -e

TEMP_DIR="$(mktemp -d)"
trap 'rm -rf "$TEMP_DIR"' EXIT

curl -sSL https://dot.net/v1/dotnet-install.sh -o "$TEMP_DIR/dotnet-install.sh"
chmod +x "$TEMP_DIR/dotnet-install.sh"
"$TEMP_DIR/dotnet-install.sh" --channel 9.0 --install-dir "$HOME/.dotnet"

echo "\n.NET 9 installed to $HOME/.dotnet"

echo "Add the following line to your shell profile or run it now to use dotnet:"
echo "  export PATH=\"$HOME/.dotnet:$PATH\""
