#!/bin/bash

find personal-menus -name '*.mp4' -print0 -or -name '*.mov' -print0 -or -name '*.avi' -print0 -or -name '*.mpg' -print0 -or -name '*.wmv' -print0 | xargs -0 -n1 ./make-preview.sh
