#!/bin/bash

F=`basename "$1"`
D=`dirname "$1"`


if [ -x  /opt/multitouch-libav2/bin/avconv ]
  then
    FFMPEG=/opt/multitouch-libav2/bin/avconv
fi

if [ -x  /opt/multitouch-ffmpeg/bin/ffmpeg ]
  then
    FFMPEG=/opt/multitouch-ffmpeg/bin/ffmpeg
fi

if [ -x  /opt/multitouch/bin/ffmpeg ]
  then
    FFMPEG=/opt/multitouch/bin/ffmpeg
fi

echo $FFMPEG

$FFMPEG -itsoffset -5 -i "$1" -vcodec png -vframes 1 -an -f image2 "$D/icon-$F.png"
