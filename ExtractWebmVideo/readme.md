ExtractWebmVideo
================

This small utility can extract videos from Just Dance 4 Autodance files by searching for the video header and moving the content that follows it to an individual file.

## Usage

```
ExtractWebmVideo c:\directory\to\search
```

## Import for Xbox 360 Autodance files

To use this utility to extract your videos from saved autodances on Xbox 360 you first have to connect the Xbox-hard-drive to your computer as described here: https://www.makeuseof.com/tag/how-to-connect-your-xbox-360-hard-drive-to-your-pc/
and then download the Just Dance content to your local HD using https://fatxplorer.eaton-works.com/ 

## Playback errors

In my experience, the resulting videos have some encoding errors on the container level, in case the file can't be played because of the errors you can fix the container by repackaging the using ngvtoolnix https://mkvtoolnix.download/downloads.html#windows 

The command-line for repackaging all files in a directory: 
```
FOR %I in (c:\justdance\output\*.webm) DO mkvmerge -o %~dI%~pIfixed\%~nI%~xI --webm %~fI
```

To analyze your video files you can use ngvtoolnix (linked above) or https://www.videohelp.com/software/MediaInfo
