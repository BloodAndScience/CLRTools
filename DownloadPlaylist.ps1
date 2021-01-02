# To get only info about playlist
--flat-playlist
#if you downloading playlist
--yes-playlist
# to download video only
-f "webm"
# to download audio onlie
-x --audio-format "mp3"
# Download audio from playlist
youtube-dl			-x --audio-format "mp3"

# Getting file names
 youtube-dl --get-filename -o '%(playlist_index)s - %(title)s' $link

# Create Folder
$folder = youtube-dl --get-filename --playlist-items 1  -o '%(playlist)s' $link
mkdir $folder
cd $folder

 # Download all webm
youtube-dl -o '%(playlist_index)s - %(title)s.webm' -f 'webm' $link
# Download all m4a
youtube-dl -o '%(playlist_index)s - %(title)s.m4a' -f 'm4a'  $link

# ffmpeg
## Copy audio without rencoding
```powershell
ffmpeg -i video.mp4 -i audio.wav -c copy output.mkv
```


