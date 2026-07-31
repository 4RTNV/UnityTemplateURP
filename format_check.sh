#!/usr/bin/env sh
set -eu

SCRIPT_DIR=$(CDPATH= cd -- "$(dirname -- "$0")" && pwd)
cd "$SCRIPT_DIR"
GIT_ROOT=$(pwd -W 2>/dev/null || pwd)
if [ -x /mingw64/bin/git.exe ]; then
  GIT_CMD=/mingw64/bin/git.exe
else
  GIT_CMD=$(command -v git.exe 2>/dev/null || command -v git)
fi

dotnet tool restore

dotnet tool run dotnet-format -- UnityTemplateURP.sln --include Assets/_Project/Scripts
cd "$SCRIPT_DIR"
unset GIT_DIR
unset GIT_WORK_TREE

changed_files=$("$GIT_CMD" -c safe.directory="$GIT_ROOT" -C "$GIT_ROOT" diff --name-only -- Assets/_Project/Scripts)

if [ -n "$changed_files" ]; then
  printf '\nFormat check failed. Files with formatting differences after dotnet-format:\n'
  printf '%s\n' "$changed_files" | while IFS= read -r file; do
    printf 'Changed: %s\n' "$file"
  done
  printf '\n'
  "$GIT_CMD" -c safe.directory="$GIT_ROOT" -C "$GIT_ROOT" diff -- Assets/_Project/Scripts
  exit 1
fi

printf 'Formatting check passed.\n'
