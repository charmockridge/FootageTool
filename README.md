# Elgato Tool
The Elgato Tool time stamps any points of interest within a gameplay recording. It aims to shorten down the simple yet lengthy process of finding the time(s) of interest and rendering that specific short snippet into a video file.


## Installation
This program is designed and developed for Windows. The use of this program on a Linux or Mac OS could and would result in an aesthetically unpleasing design and faulty code!

Follow steps below for installation:
* Run the following command in command prompt:
    ```console
    pip3 install moviepy
    ```
* Clone this repository
* Then either double click on the .py file or run the following command in command prompt:
    ```console
    python main.py
    ```


## Usage
Upon pressing record within your Elgato Game Capture software, you should put the Elgato Tool on top - or beside - of your running programs. When something happens within your gameplay, that you would like to mark you, simply press the “Mark Time” option which will create a timestamp. Once you are satisfied with your recording, you should end your recording within the Elgato Game Capture software and then press the "Stop Time" button in the Elgato Tool. Next you should press the “Export” button on the Elgato Tool which will display a message box if you have not created any timestamps. If you have marked some times of interest you will be prompted with a file dialogue and you should save the file accordingly. A .txt file will be written containing the time of interest so you can review it.

From there, you should navigate over to the "Render" tab where you should press the button that says "Pick Video File". You will be prompted with another file dialogue and should choose the .mp4 file, and it must be a .mp4 file, that you would like to cut snippets from. Next press on the "Pick Time File" button and select the .txt file containing all of the timestamps that you exported. If both files have been loaded successfully the label underneath the buttons will become green and display "File Loaded". From the radio buttons below choose the time you would like to cushion your times of interest with. Note that whatever time cushion you choose, it will be that selected time either way from the point of interest, and all times of interest will have the same cushion, so pick carefully! For example if you have stamped the time 00:04:30 (4 minutes and 30 seconds) and decide to cushion the time by 30 seconds, the start time of the clip would be 00:04:00 and the end time would be 00:05:00, this would be the same with the other timestamps. Once you have selected your times, press the "Render" button. You will be asked to save a .mp4 file to a location and name of your choice. Depending on how many timestamps you have marked, there will be a number at the end of the file name that increments for every clip, therefore another name change after rendering may be needed. The video will be rendered as the same quality as the input file.


## Updates, Fixes and Patch Notes
* Updated README.md


## Future Implements and Updates
Within the near future expect to see the following fixes and changes (priority in descending order):

* Automatic check for updates one program is opened
* Render in with user-defined resolution, fps and audio bitrate
* Display quality details of inputted .mp4 file
* Display quality details of rendered video
* The ability to see marked times whilst recording
* Enter custom time cushion as opposed to predetermined times
* Select timestamps and give them individual time cushions
* Settings tab


# Developer
Charlie Mockridge<br>
Last updated: 2020-05-05 17:09:46
<p>Version: 1.0.0</p>
