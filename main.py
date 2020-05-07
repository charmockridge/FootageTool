# Imports
from tkinter import *
from tkinter import ttk
from tkinter import filedialog
from tkinter import messagebox
from tkinter import Radiobutton
from datetime import datetime
from moviepy.editor import *  # pip3/pipenv install moviepy
from bs4 import BeautifulSoup  # pip3/pipenv install beautifulsoup4
import requests  # pip3/pipenv install requests


global count
count = False  # Conditional that determines whether the countdown should start
global stamps
stamps = []  # Contains all of the time stamps


class Root(Tk):
    currentVersion = "1.0.1"

    """
    On press of self.winRecord_resetBtn
    Resets all variables and displays to 0 or null
    """
    def reset(self):
        global count, h, m, s
        count = False
        h = 0  # Hours
        m = 0  # Minutes
        s = 0  # Seconds
        self.time.set("00:00:00")
        self.display = "00:00:00"
        stamps.clear()

    """
    On press of self.winRecord_stopBtn
    Halts countdown by setting boolean variable to False
    """
    def stop(self):
        global count
        count = False

    """
    On press of self.winRecord_startBtn
    Starts countdown by setting boolean variable to True
    """
    def start(self):
        global count
        count = True
        self.start_timer()

    """
    Called by the start() method
    This was needed as countdown wouldn't start
    Find alternative way to reduce lines of code
    """
    def start_timer(self):
        global count
        self.timer()

    """
    Called by the start_timer() method
    Find an alternative and shorter way for the timer
    """
    def timer(self):
        global count, h, m, s

        if count is True:
            self.display = str(self.time.get())
            h, m, s = map(int, self.display.split(":"))
            h = int(h)  # Hours
            m = int(m)  # Minutes
            s = int(s)  # Seconds

            if s < 59:
                s += 1
            elif s == 59:
                s = 0
                if m < 59:
                    m += 1
                elif m == 59:
                    m = 0
                    h += 1

            if h < 10:
                h = str(0) + str(h)
            else:
                h = str(h)
            if m < 10:
                m = str(0) + str(m)
            else:
                m = str(m)
            if s < 10:
                s = str(0) + str(s)
            else:
                s = str(s)

            self.display = h + ":" + m + ":" + s
            self.time.set(self.display)

            if count is True:
                # For every 1 second run method self.start_timer()
                self.after(1000, self.start_timer)

    """
    On press of self.winRecord_markBtn
    Adds the current time to the array 'Stamps'
    """
    def mark(self):
        stamps.append(str(self.display))

    """
    On press of self.winRecord_exportBtn
    Opens file dialog that takes the chosen name and writes to that file
    File will contain all of the time stamps
    """
    def export(self):
        def fileSave():
            file = filedialog.asksaveasfile(
                initialdir="/documents",
                title="Save File",
                defaultextension=".txt",
                filetypes=(
                    ("text documents", "*.txt"),
                    ("all files", "*.*")
                    ),
                mode="w"
                )

            if file is None:
                return

            for mark in stamps:
                file.write(str(mark) + "\n")

            file.close()

        if not stamps:
            lstnull = messagebox.askyesno(
                title="File Empty",
                message="You haven't marked any times." +
                        " Would you still like to export?"
            )
            if lstnull is True:
                fileSave()
            else:
                return
        else:
            fileSave()

    """
    Binded to self.winRecord_linkTxt as on click
    Takes user to the settings tab
    """
    # def onClick_winRecord_linkTxt(self, event):
        # global tabControl
        # tabControl.select(self.tab3)

    """
    On press of self.winRender_videoBtn
    Open file dialog that assigns the file name to a variable
    If file ends in .mp4 self.winRender.lerror displays file loaded in green
    """
    def openMP4(self):
        self.file1 = filedialog.askopenfilename(
            initialdir="/documents",
            title="Open File",
            defaultextension=".mp4",
            filetypes=(
                ("mp4 files", "*.mp4"),
                ("all files", "*.*")
            )
        )

        if self.file1[-4:] == ".mp4":
            self.file1 = self.file1
            self.winRender_lerrorTxt.configure(
                text="File Loaded",
                foreground="green"
            )
        else:
            self.winRender_lerrorTxt.configure(
                text="No .mp4 file loaded",
                foreground="red"
            )
            self.file1 = ""

    """
    On press of self.winRender_textBtn
    Open file dialog that assigns the file name to a variable
    If file ends in .txt self.winRender.rerror displays file loaded in green
    """
    def openTXT(self):
        self.file2 = filedialog.askopenfilename(
            initialdir="/documents",
            title="Open File",
            defaultextension=".txt",
            filetypes=(
                ("text document", "*.txt"),
                ("all files", "*.*")
            )
        )

        if self.file2[-4:] == ".txt":
            self.file2 = self.file2
            self.winRender_rerrorTxt.configure(
                text="File Loaded",
                foreground="green"
            )
        else:
            self.winRender_rerrorTxt.configure(
                text="No .txt file loaded",
                foreground="red"
            )
            self.file2 = ""

    """
    On press of self.winRender_renderBtn
    Uses the module moviepy.editor
    Find a way to close the video file
    """
    def renderVideo(self):
        # End of file name for the video rendered by moviepy.editor
        # Increments for every file made
        c = 1
        # Stores value of selected radio button
        x = self.v.get()
        # Puts data from selected file into this array
        lstStampedTimes = []
        # Nested list
        # Contains the start and end time for cutting of video segment
        lstAnsTimes = []
        # Time cushions around timestamps
        lstSubTime = [
            ("00:00:15"),
            ("00:00:30"),
            ("00:00:45"),
            ("00:01:00"),
            ("00:02:00"),
            ("00:05:00"),
            ("00:10:00"),
            ("00:15:00"),
            ("00:30:00"),
            ("00:45:00"),
            ("01:00:00"),
            ("02:00:00"),
        ]

        fileRender = filedialog.asksaveasfilename(
            initialdir="/documents",
            title="Save File",
            defaultextension=".mp4",
            filetypes=(
                ("mp4 files", "*.mp4"),
                ("all files", "*.*")
            )
        )

        if fileRender[-4:] == ".mp4":
            timeStamps = open(self.file2, "r")
            data = timeStamps.readlines()

            for element in data:
                lstStampedTimes.append(element.strip())

            for time in lstStampedTimes:
                # Iterates through timestamps and stores them
                y = time

                # Formats timestamp in the variable 'y'
                t1 = datetime.strptime(str(y), "%H:%M:%S")
                # Takes selected cushion time from radio button
                """
                Done by indexing the array 'lstSubTime' with value of the selected radio button and formats it
                """
                t2 = datetime.strptime(str(lstSubTime[x]), "%H:%M:%S")
                # This is need for the addition of the two times to work
                t0 = datetime.strptime("00:00:00", "%H:%M:%S")

                # Stores the start time for the clip
                ans1 = t1 - t2
                # Stores the end time for the clip
                ans2 = ((t1 - t0 + t2).time())

                # Nests the list
                lstAnsTimes.append([str(ans1), str(ans2)])

            # Imported with moviepy.editor
            video = VideoFileClip(self.file1)

            for lst in lstAnsTimes:
                # Iterates through the start and end times
                start = lst[0]
                end = lst[1]

                clip = video.subclip((str(start)), (str(end)))
                clip.write_videofile(
                    fileRender[:-4] + str(c) + ".mp4",
                    codec="libx264",
                    audio_bitrate="192k"
                )
                c += 1

            timeStamps.close()
        else:
            return

    def __init__(self):
        super(Root, self).__init__()

        self.title("Elgato Tool")

        # Creates tabControl
        global tabControl
        tabControl = ttk.Notebook(self)

        # Creates the 'Record' tab and frame
        self.tab1 = ttk.Frame(tabControl)
        tabControl.add(
            self.tab1,
            text="Record"
        )

        # Creates the 'Render' tab and frame
        self.tab2 = ttk.Frame(tabControl)
        tabControl.add(
            self.tab2,
            text="Render"
        )

        """
        # Creates the 'Settings' tab and frame
        self.tab3 = ttk.Frame(tabControl)
        tabControl.add(
            self.tab3,
            text="Settings"
        )
        """

        tabControl.pack(
            expand=1,
            fill=BOTH
        )

        # Initialises the widgets for the 'Record' tab
        self.winRecord()
        # Initialises the widgets for the 'Render' tab
        self.winRender()
        # Initialises the widgets for the 'Settings' tab
        # Explore possible features
        # self.winSettings()
        # Uses BeautifulSoup4 to check for updates
        self.checkUpdates()

    def checkUpdates(self):
        try:
            # This will store the text from the website that is being split
            tagPara = []
            # Gets the chosen website's source code
            source = requests.get(
                "https://github.com/charmockridge/ElgatoTool"
            ).text
            soup = BeautifulSoup(source, "lxml")
            # Finds the area of interest
            article = soup.find("article")
            # Finds the area of interest
            para = article.find_all("p")

            # For every paragraph tag in the source code
            for p in para:
                # Prettifies the HTML and appends to array
                tagPara.append(p.prettify())

            # The last paragraph tag is the information of interest
            version = tagPara[-1]
            # Removes unwanted character
            version = version.split("<p>")[1]
            # Removes unwanted character
            version = version.split("</p>")[0]
            # Removes unwanted character
            version = version.split("\n")[1]
            # This is the string that is needed
            version = version[-5:]

            if version == self.currentVersion:
                return
            else:
                messagebox.showinfo(
                    title="Update is available",
                    message="Your program is not up to date and there is a" +
                            " more later version ready for download. It is" +
                            " important that you update as there will be" +
                            " patches, fixes and new implementations to" +
                            " improve the program. Download from :" +
                            " https://github.com/charmockridge/ElgatoTool"
                )
        except Exception:
            messagebox.showerror(
                title="Check for update has failed",
                message="There has been an error whilst checking for an" +
                        " update. Another update check will be run when your" +
                        " application is re-opened at a later date."
            )

    def winRecord(self):
        # Style for buttons
        s = ttk.Style()
        s.configure('my.TButton', font=('Arial', 12))

        # Widget
        self.winRecord_headerTxt = ttk.Label(
            self.tab1,
            text="Record",
            font=("Arial 16")
        )
        self.winRecord_headerTxt.grid(
            column=0,
            row=0,
            columnspan=2
        )

        self.time = StringVar()
        self.time.set("00:00:00")

        # Widget
        self.winRecord_timeTxt = ttk.Label(
            self.tab1,
            textvariable=self.time,
            font=("Arial 28 bold")
        )
        self.winRecord_timeTxt.grid(
            column=0,
            row=1,
            columnspan=2,
            pady=5
        )

        # Widget
        self.winRecord_startBtn = ttk.Button(
            self.tab1,
            text="Start Time",
            style="my.TButton",
            command=self.start
        )
        self.winRecord_startBtn.grid(
            column=0,
            row=2,
            sticky="NESW",
            padx=(0, 2.5)
        )

        # Widget
        self.winRecord_stopBtn = ttk.Button(
            self.tab1,
            text="Stop Time",
            style="my.TButton",
            command=self.stop
        )
        self.winRecord_stopBtn.grid(
            column=1,
            row=2,
            sticky="NESW",
            padx=(2.5, 0)
        )

        # Widget
        self.winRecord_resetBtn = ttk.Button(
            self.tab1,
            text="Reset Time",
            style="my.TButton",
            command=self.reset
        )
        self.winRecord_resetBtn.grid(
            column=0,
            row=3,
            sticky="NESW",
            pady=5,
            padx=(0, 2.5)
        )

        # Widget
        self.winRecord_exportBtn = ttk.Button(
            self.tab1,
            text="Export",
            style="my.TButton",
            command=self.export
        )
        self.winRecord_exportBtn.grid(
            column=1,
            row=3,
            sticky="NESW",
            pady=5,
            padx=(2.5, 0)
        )

        # Widget
        self.winRecord_markBtn = ttk.Button(
            self.tab1,
            text="Mark Time",
            style="my.TButton",
            command=self.mark
        )
        self.winRecord_markBtn.grid(
            column=0,
            row=4,
            columnspan=2,
            sticky="NESW"
        )

        """
        # Widget
        self.winRecord_linkBtn = ttk.Label(
            self.tab1,
            text="Have you checked your export settings?",
            foreground="blue",
            font=("Arial 10 underline")
        )
        self.winRecord_linkBtn.grid(
            column=0,
            row=5,
            columnspan=2,
            pady=(5, 0)
        )
        self.winRecord_linkBtn.bind(
            "<Button-1>",  # Left mouse click
            self.onClick_winRecord_linkTxt  # Calls this method
        )
        """

    def winRender(self):
        self.a = 0  # Column assignment for radio buttons
        self.b = 2  # Row assignment for radio buttons
        self.v = IntVar()
        self.v.set(0)  # Variable for radio buttons
        # Radio button text value
        self.cushion = [
            ("15 Seconds"),
            ("30 Seconds"),
            ("45 Seconds"),
            ("1 Minute"),
            ("2 Minutes"),
            ("5 Minutes"),
            ("10 Minutes"),
            ("15 Minutes"),
            ("30 Minutes"),
            ("45 Minutes"),
            ("1 Hour"),
            ("2 Hours")
        ]

        # Style for buttons
        s = ttk.Style()
        s.configure('my.TButton', font=('Arial', 12))

        # Widget
        self.winRender_headerTxt = ttk.Label(
            self.tab2,
            text="Render",
            font=("Arial 16")
        )
        self.winRender_headerTxt.grid(
            column=0,
            row=0,
            columnspan=2
        )

        # Widget
        self.winRender_videoBtn = ttk.Button(
            self.tab2,
            text="Pick Video File",
            style="my.TButton",
            command=self.openMP4
        )
        self.winRender_videoBtn.grid(
            column=0,
            row=1,
            sticky="NESW",
            padx=(0, 2.5),
            pady=(5, 0)
        )

        # Widget
        self.winRender_textBtn = ttk.Button(
            self.tab2,
            text="Pick Time File",
            style="my.TButton",
            command=self.openTXT
        )
        self.winRender_textBtn.grid(
            column=1,
            row=1,
            sticky="NESW",
            padx=(2.5, 0),
            pady=(5, 0)
        )

        # Widget
        self.winRender_lerrorTxt = ttk.Label(
            self.tab2,
            text="No .mp4 file loaded",
            foreground="red",
            font=("Arial 10")
        )
        self.winRender_lerrorTxt.grid(
            column=0,
            row=2,
            pady=(2.5, 5)
        )

        # Widget
        self.winRender_rerrorTxt = ttk.Label(
            self.tab2,
            text="No .txt file loaded",
            foreground="red",
            font=("Arial 10")
        )
        self.winRender_rerrorTxt.grid(
            column=1,
            row=2,
            pady=(2.5, 5)
        )

        # Iterates through list containing text value for radio buttons
        for val, lcushion in enumerate(self.cushion):
            if val % 2 == 0:
                self.a = 0  # If list item has an even index then column=0
                self.b += 1  # If list item has an even index then row=row+1
            else:
                self.a = 1  # If list item has an odd index then column = 1

            # Widget
            self.lcushionRBtn = Radiobutton(
                self.tab2,
                text=lcushion,
                variable=self.v,
                value=val,
                # command=self.debugShow
            )
            self.lcushionRBtn.grid(
                column=self.a,
                row=self.b,
                sticky="w"
            )

        # Widget
        self.winRender_renderBtn = ttk.Button(
            self.tab2,
            text="Render",
            style="my.TButton",
            command=self.renderVideo
        )
        self.winRender_renderBtn.grid(
            column=0,
            row=10,
            columnspan=2,
            pady=(5, 0),
            sticky="NESW"
        )

    """
    def winSettings(self):
        # Widget
        self.winSettings_headerTxt = ttk.Label(
            self.tab3,
            text="Settings",
            font=("Arial 16")
        )
        self.winSettings_headerTxt.grid(
            column=0,
            row=0,
            columnspan=2
        )
    """


if __name__ == "__main__":
    root = Root()
    root.mainloop()
