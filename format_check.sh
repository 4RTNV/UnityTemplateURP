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

if ! dotnet tool run dotnet-format -- Assets/_Project/Scripts --folder --check --include Assets/_Project/Scripts; then
  printf '\nFormat check failed. Run this command locally to see and fix formatting issues:\n'
  printf 'dotnet tool run dotnet-format -- Assets/_Project/Scripts --folder --include Assets/_Project/Scripts\n'
  exit 1
fi

if [ ! -f UnityTemplateURP.sln ]; then
  printf 'UnityTemplateURP.sln was not found. Generate Unity project files before running the full code style check.\n'
  printf 'In CI this is done by Unity before this script runs. Locally, open the project in Unity/Rider or run Unity project-file generation.\n'
  exit 1
fi

mkdir -p Temp/ReSharperCaches Temp/ReSharperAppData Temp/ReSharperLocalAppData
export APPDATA="$SCRIPT_DIR/Temp/ReSharperAppData"
export LOCALAPPDATA="$SCRIPT_DIR/Temp/ReSharperLocalAppData"
cleanup_log="$SCRIPT_DIR/Temp/resharper-cleanup.log"

if ! dotnet tool run jb -- cleanupcode UnityTemplateURP.sln \
  --profile="Scitalis: Reformat Code" \
  --settings="UnityTemplateURP.sln.DotSettings" \
  --include="Assets/_Project/Scripts/**/*.cs" \
  --exclude="Assets/_Project/Scripts/**/*.asmdef" \
  --verbosity=ERROR \
  --no-build \
  --caches-home="Temp/ReSharperCaches" \
  --no-updates > "$cleanup_log" 2>&1; then
  printf '\nReSharper cleanup failed. Tool output:\n'
  cat "$cleanup_log"
  exit 1
fi

cd "$SCRIPT_DIR"
unset GIT_DIR
unset GIT_WORK_TREE

changed_files=$("$GIT_CMD" -c safe.directory="$GIT_ROOT" -c core.autocrlf=false -C "$GIT_ROOT" diff --name-only -- "Assets/_Project/Scripts/*.cs" "Assets/_Project/Scripts/**/*.cs")

if [ -n "$changed_files" ]; then
  printf '\nFormat check failed. Files with formatting, import order, or member order differences:\n'
  printf '%s\n' "$changed_files" | while IFS= read -r file; do
    printf 'Changed: %s\n' "$file"
  done
  printf '\n'
  "$GIT_CMD" -c safe.directory="$GIT_ROOT" -c core.autocrlf=false -C "$GIT_ROOT" diff -- "Assets/_Project/Scripts/*.cs" "Assets/_Project/Scripts/**/*.cs"
  exit 1
fi

dotnet build UnityTemplateURP.sln --no-restore --verbosity minimal

printf 'Formatting and code style check passed.\n'
