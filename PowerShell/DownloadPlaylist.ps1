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



#Extra from actuall script
#Getting List of Folders
$playL = Get-Content 'B:\Temp\ListOfUnityPlayLists.list' | Select-Object 


foreach($p in $playL) {
    $folderName=""
    $folderName = youtube-dl --get-filename  --playlist-item 1 -o '%(playlist)s' $p
    if($folderName)
    { 
        echo "Not null"
    mkdir $folderName
    cd $folderName
    youtube-dl --yes-playlist -f webm -w -o '%(playlist_index)s - %(title)s.%(ext)s' $p 
    cd ..
    }
}


#Getting PlayList Name
$folderName = youtube-dl -f  136 --get-filename  --playlist-item 1 -o '%(playlist)s' 'https://www.youtube.com/watch?v=EsUGX0FZi5k&list=PLX2vGYjWbI0Qr4X9gfnJiMDKeqfqaNd6h'
#Download Playlist
youtube-dl --yes-playlist -f 136 https://www.youtube.com/playlist?list=PLX2vGYjWbI0QvLHla7C_Z_s3q1Oi461o4
#Correct formula for naming
 youtube-dl -o '%(playlist)s/%(playlist_index)s - %(title)s.%(ext)s' https://www.youtube.com/playlist?list=PLwiyx1dc3P2JR9N8gQaQN_BCvlSlap7re
