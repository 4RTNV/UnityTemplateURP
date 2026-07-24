#!/usr/bin/env sh
set -eu

SCRIPT_DIR=$(CDPATH= cd -- "$(dirname -- "$0")" && pwd)
cd "$SCRIPT_DIR"

dotnet format UnityTemplateURP.sln --verify-no-changes --no-restore --include Assets/_Project/Scripts
