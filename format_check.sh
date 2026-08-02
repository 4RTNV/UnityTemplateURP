#!/usr/bin/env sh
set -eu

SCRIPT_DIR=$(CDPATH= cd -- "$(dirname -- "$0")" && pwd)
cd "$SCRIPT_DIR"

dotnet tool restore

if ! dotnet tool run dotnet-format -- Assets/_Project/Scripts --folder --check --include Assets/_Project/Scripts; then
  printf '\nFormat check failed. Run this command locally to see and fix formatting issues:\n'
  printf 'dotnet tool run dotnet-format -- Assets/_Project/Scripts --folder --include Assets/_Project/Scripts\n'
  exit 1
fi

printf 'Formatting and code style check passed.\n'
