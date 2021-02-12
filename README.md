# Footage Tool
The Footage Tool time stamps any points of interest within a .mp4 video file. It aims to shorten down the lengthy process of finding the time(s) of interest and rendering that specific short snippet into its own .mp4 video file.


## Installation
The Footage Tool is a C# .NET Windows Forms App program, meaning it will only run on Windows and not Mac and Linux.

Follow steps below for installation:
* Clone this repository:
    ```console
    git clone https://github.com/charmockridge/FootageTool.git
    ```

* Then open the solution file FootageTool.sln in Visual Studio and install the NuGet package "HtmlAgilityPack".

* Build the solution by pressing **Ctrl+Shift+B** or **Build** > **Build Solution** on the toolbar.

* Install FFmpeg from this link [here](https://www.gyan.dev/ffmpeg/builds/ffmpeg-git-essentials.7z).

* Extract the files from the .7z zip archive and locate ffmpeg.exe and ffprobe.exe both located in **ffmpeg-[date]-git-[string of characters and numbers]-essentials_build/bin**

* Finally, drag both files into the project's debug directory located at **FootageTool/FootageTool/bin/Debug** where FootageTool.exe is also located.


## Usage
Upon pressing capturing or watching your footage, you should put the Footage Tool on top - or beside - of your capture or media playing software. When something happens within your footage that you would like to mark you, simply press the “Mark Time” button, this will save the timestamp. Once you are satisfied with your times of interest, you should exit out of your capture or media player and press the "Stop Time" button in the Footage Tool. Next you should press the “Export” button on the Footage Tool which will display a message box if you have not created any timestamps. If you have marked some times of interest you will be prompted with a file dialogue and you should save the file accordingly. A .txt file will be written containing the time of interest so you can review it.

From there, you should navigate over to the "Render" tab where you should press the button that says "Pick Video File". You will be prompted with another file dialogue and should choose the .mp4 file, and it must be a .mp4 file, that you would like to cut snippets from. Next press on the "Pick Time File" button and select the .txt file containing all of the timestamps that you exported. From the radio buttons below choose the time you would like to cushion your times of interest with. Note that whatever time cushion you choose, it will be that selected time either way from the point of interest, and all times of interest will have the same cushion, so pick carefully! For example if you have stamped the time 00:04:30 (4 minutes and 30 seconds) and decide to cushion the time by 30 seconds, the start time of the clip would be 00:04:00 and the end time would be 00:05:00, this would be the same with the other timestamps. Once you have selected your times, press the "Render" button. You will be asked to save a .mp4 file to a location and name of your choice. Depending on how many timestamps you have marked, there will be a number at the end of the file name that increments for every clip, therefore another name change after rendering may be needed. The video will be rendered at native quality.


## Updates, Fixes and Patch Notes
* Updated README.md
* FFmpeg and FFprobe path change
* Minor update to the program's UI
* Changed program language from Python 3.7.3 to C# .NET Framework 4.7.2 Windows Forms Application, therefore no longer using the Tkinter module
* Changed the module used for rendering from PyMovie to FFmpeg


## Future Implements and Updates
Within the near future expect to see the following fixes and changes:

* Display quality details of inputted .mp4 file
* Display quality details of rendered video
* Enter custom time cushion as opposed to predetermined times
* Select timestamps and give them individual time cushions
* & more


# Developer
Charlie Mockridge<br>
Last updated: 2020-07-12 17:37:05
<p>Version: 2.0.2</p>
