using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Net.Http;
using HtmlAgilityPack;

namespace FootageTool
{
    public partial class Form1 : Form
    {
        // Running application version
        private const string appVersion = "2.0.1";
        // URL to github repo.
        private string _url = "https://github.com/charmockridge/FootageTool";
        // Stores the seconds for the stopwatch.
        private int _timeSeconds;
        // Stores the minutes for the stopwatch.
        private int _timeMinutes;
        // Stores the hours for the stopwatch.
        private int _timeHours;
        // Formatted string to display the time in HH:mm:ss format.
        private string _time;
        // Path to text file that contains timestamps.
        private string _timeFilePath;
        // Path to gameplay video file.
        private string _videoFilePath;
        // Path to outputted rendered video(s).
        private string _renderFilePath;
        // Stores timestamps of interest.
        private List<string> _stamps = new List<string>();
        // Used to determine if input video file is loaded for rendering.
        private bool _isVideoLoaded = false;
        // Used to determine if input text file is loaded for rendering, contains timestamps.
        private bool _isTextLoaded = false;
        // Used to determine if time cushion is selected for rendering.
        private bool _isCushionLoaded = false;
        // Selected time cushion that will be used in rendering.
        private DateTime _timeCushion;
        // Nested list for video splitting.
        List<List<string>> _splitTimes = new List<List<string>>();

        // Checks for available updates.
        private void CheckForUpdates()
        {
            if (appVersion != WebVersion())
            {
                DialogResult updateResult = MessageBox.Show(
                    "Your program is not up to date and there is a more later version ready for" +
                    " download. It is important that you update as there will be patches, fixes" +
                    " and new implementations to improve the program. Would you like to install?",
                    "Update available",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information
                );

                if (updateResult == DialogResult.Yes)
                {
                    // Opens github repo where user can download latest version.
                    Process.Start(_url);
                    Application.Exit();
                }
            }
        }

        // Gets latest version number of app from github.
        private string WebVersion()
        {
            // Stores <p> tags from github repo.
            List<string> scrapedHtml = new List<string>();
            HtmlWeb web = new HtmlWeb();
            // Github repo html code.
            var doc = web.Load(_url);

            // Reads the README.md file.
            var node = doc.DocumentNode.SelectSingleNode("//*[@id=\"readme\"]/div[3]/article");

            // Foreach <p> tag in README.md.
            foreach (HtmlNode nNode in node.Descendants("p"))
            {
                // Checks if node type is an html element
                if (nNode.NodeType == HtmlNodeType.Element)
                {
                    // Adds all <p> tags to list
                    scrapedHtml.Add(nNode.InnerHtml.ToString());
                }
            }

            // The version will always be the last <p> tag.
            string scrapedVersion = scrapedHtml[scrapedHtml.Count - 1].ToString();
            // Returns version number.
            return scrapedVersion.Substring(scrapedVersion.Length - 5);
        }

        // Button located on the "Record" page.
        private void btnStart_Click(object sender, EventArgs e)
        {
            // Starts timer that will be used for stopwatch.
            timer1.Enabled = true;
        }

        // Button located on the "Record" page.
        private void btnStop_Click(object sender, EventArgs e)
        {
            // Halts timer
            timer1.Enabled = false;
        }

        // Button located on the "Record" page.
        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetTimer();
        }

        // Called on Form initialisation and "Reset" button pressed.
        // Resets all variables to their original value.
        private void ResetTimer()
        {
            _timeSeconds = 0;
            _timeMinutes = 0;
            _timeHours = 0;

            timer1.Enabled = false;

            lblSeconds.Text = "00";
            lblMinutes.Text = "00";
            lblHours.Text = "00";

            _time = "";
            _stamps.Clear();

            lstTimeStamps.Items.Clear();
        }

        // Used for stopwatch.
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timer1.Enabled == true)
            {
                _timeSeconds++;

                if (_timeSeconds >= 60)
                {
                    _timeMinutes++;
                    _timeSeconds = 0;

                    if (_timeMinutes >= 60)
                    {
                        _timeHours++;
                        _timeMinutes = 0;
                    }
                }
            }

            UpdateTimer();
        }

        // Called by timer.
        private void UpdateTimer()
        {
            // Formats the labels on the "Record" page which displays stopwatch time.
            lblSeconds.Text = String.Format("{0:00}", _timeSeconds);
            lblMinutes.Text = String.Format("{0:00}", _timeMinutes);
            lblHours.Text = String.Format("{0:00}", _timeHours);
        }

        // Button located on the "Record" page.
        private void btnExport_Click(object sender, EventArgs e)
        {
            if (_stamps.Count != 0)
            {
                ExportTimestamps();
            }
            else
            {
                DialogResult exportResult = MessageBox.Show(
                    "You have not marked any times of importance. If you continue to export, the" + 
                    " file will not contain any information. Would you still like to export?",
                    "File empty",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information
                );

                if (exportResult == DialogResult.Yes)
                {
                    ExportTimestamps();
                }
            }
            
        }

        // Called when "Export" button pressed
        private void ExportTimestamps()
        {
            // Creates save file dialog window.
            SaveFileDialog sfd1 = new SaveFileDialog();
            sfd1.InitialDirectory = @"\documents";
            sfd1.RestoreDirectory = true;
            sfd1.FileName = "*.txt";
            sfd1.DefaultExt = "txt";
            sfd1.Filter = "text files (*.txt)|*.txt|all files(*.*)|*.*";

            if (sfd1.ShowDialog() == DialogResult.OK)
            {
                Stream fileStream1 = sfd1.OpenFile();
                var sw1 = new StreamWriter(fileStream1);

                for (var i = 0; i < _stamps.Count; i++)
                {
                    sw1.Write(_stamps[i] + "\n");
                }

                sw1.Close();
                fileStream1.Close();
            }
        }

        // Button located on "Record" page.
        private void btnMark_Click(object sender, EventArgs e)
        {
            // Formats time to HH:mm:ss.
            _time = String.Format("{0:00}", _timeHours) + ":" +
                    String.Format("{0:00}", _timeMinutes) + ":" +
                    String.Format("{0:00}", _timeSeconds);
            _stamps.Add(_time);
            // Adds time to list box located on "Record" page.
            lstTimeStamps.Items.Add(_time);
        }

        // Button located on "Render" page.
        private void btnLoadVideo_Click(object sender, EventArgs e)
        {
            // Creates open file dialog window.
            OpenFileDialog ofd1 = new OpenFileDialog();
            ofd1.InitialDirectory = @"\documents";
            ofd1.RestoreDirectory = true;
            ofd1.FileName = "*.mp4";
            ofd1.DefaultExt = "mp4";
            ofd1.Filter = "mp4 files (*.mp4)|*.mp4|all files (*.*)|*.*";
            ofd1.Multiselect = false;

            if (ofd1.ShowDialog() == DialogResult.OK)
            {
                _videoFilePath = ofd1.FileName;

                // Checks if the selected file ends in ".mp4".
                if (_videoFilePath.Substring(_videoFilePath.Length - 4) == ".mp4")
                {
                    _isVideoLoaded = true;

                    MessageBox.Show(
                        $"The .mp4 file {_videoFilePath} has been successfully loaded!",
                        "Video file loaded",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
                else
                {
                    _isVideoLoaded = false;

                    MessageBox.Show(
                        "Unable to load selected video file as it is not in the .mp4 format!" + 
                        " Please select a correct video file.",
                        "Unable to load video file",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
        }

        // Button located on "Render" page.
        private void btnLoadTime_Click(object sender, EventArgs e)
        {
            // Creates open file dialog window.
            OpenFileDialog ofd2 = new OpenFileDialog();
            ofd2.InitialDirectory = @"\documents";
            ofd2.RestoreDirectory = true;
            ofd2.FileName = "*.txt";
            ofd2.DefaultExt = "txt";
            ofd2.Filter = "text files (*.txt)|*.txt|all files (*.*)|*.*";
            ofd2.Multiselect = false;

            if (ofd2.ShowDialog() == DialogResult.OK)
            {
                _timeFilePath = ofd2.FileName;

                // Checks if the selected file ends in ".txt".
                if (_timeFilePath.Substring(_timeFilePath.Length - 4) == ".txt")
                {
                    _isTextLoaded = true;

                    MessageBox.Show(
                        "The .txt file " + _timeFilePath + " has been successfully loaded!",
                        "Time file loaded",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );                   
                }
                else
                {
                    _isTextLoaded = false;

                    MessageBox.Show(
                        "Unable to load selected text file, that contains the timestamps," + 
                        " as it is not in the .txt format! Please select a correct video file.",
                        "Unable to load time file",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
        }

        // Button located on "Render" page.
        private void btnRender_Click(object sender, EventArgs e)
        {
            // Checks and sets the selected time cushion for rendering.
            if (rbtn15Sec.Checked == true)
            {
                _timeCushion = DateTime.ParseExact("00:00:15", "HH:mm:ss", null);
                _isCushionLoaded = true;
            }
            else if (rbtn30Sec.Checked == true)
            {
                _timeCushion = DateTime.ParseExact("00:00:30", "HH:mm:ss", null);
                _isCushionLoaded = true;
            }
            else if (rbtn45Sec.Checked == true)
            {
                _timeCushion = DateTime.ParseExact("00:00:45", "HH:mm:ss", null);
                _isCushionLoaded = true;
            }
            else if (rbtn1Min.Checked == true)
            {
                _timeCushion = DateTime.ParseExact("00:01:00", "HH:mm:ss", null);
                _isCushionLoaded = true;
            }
            else if (rbtn2Min.Checked == true)
            {
                _timeCushion = DateTime.ParseExact("00:02:00", "HH:mm:ss", null);
                _isCushionLoaded = true;
            }
            else if (rbtn5Min.Checked == true)
            {
                _timeCushion = DateTime.ParseExact("00:05:00", "HH:mm:ss", null);
                _isCushionLoaded = true;
            }
            else if (rbtn10Min.Checked == true)
            {
                _timeCushion = DateTime.ParseExact("00:10:00", "HH:mm:ss", null);
                _isCushionLoaded = true;
            }
            else if (rbtn15Min.Checked == true)
            {
                _timeCushion = DateTime.ParseExact("00:15:00", "HH:mm:ss", null);
                _isCushionLoaded = true;
            }
            else if (rbtn30Min.Checked == true)
            {
                _timeCushion = DateTime.ParseExact("00:30:00", "HH:mm:ss", null);
                _isCushionLoaded = true;
            }
            else if (rbtn45Min.Checked == true)
            {
                _timeCushion = DateTime.ParseExact("00:45:00", "HH:mm:ss", null);
                _isCushionLoaded = true;
            }
            else if (rbtn1Hour.Checked == true)
            {
                _timeCushion = DateTime.ParseExact("01:00:00", "HH:mm:ss", null);
                _isCushionLoaded = true;
            }
            else if (rbtn2Hour.Checked == true)
            {
                _timeCushion = DateTime.ParseExact("02:00:00", "HH:mm:ss", null);
                _isCushionLoaded = true;
            }
            else
            {
                _isCushionLoaded = false;
            }

            // Allows the rendering process to start if all of the requirements are met.
            if (_isVideoLoaded == true && _isTextLoaded == true && _isCushionLoaded == true)
            {
                // Creates save file dialog window
                SaveFileDialog sfd2 = new SaveFileDialog();
                sfd2.InitialDirectory = @"\documents";
                sfd2.RestoreDirectory = true;
                sfd2.FileName = "*.mp4";
                sfd2.DefaultExt = "mp4";
                sfd2.Filter = "mp4 files (*.mp4)|*.mp4|all files(*.*)|*.*";

                if (sfd2.ShowDialog() == DialogResult.OK)
                {
                    _renderFilePath = sfd2.FileName;

                    // Checks if the render file ends with ".mp4".
                    if (_renderFilePath.Substring(_renderFilePath.Length - 4) == ".mp4")
                    {
                        DialogResult renderResult = MessageBox.Show(
                            "Your video(s) will be rendered at native quality." + 
                            " The rendering process will take a few minutes." +
                            " Whilst rendering, the application will be unresponsive." +
                            " Would you like to start rendering?",
                            "Render video",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Information
                        );

                        if (renderResult == DialogResult.Yes)
                        {
                            CalculateSplitTimes();
                            Render();
                            ResetVars();
                        }
                    }
                    else
                    {
                        MessageBox.Show(
                            "Unable to start rendering the video because you have chosen the wrong format! Please try saving the video file as .mp4",
                            " Unable to render",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }
                }
            }
            else
            {
                MessageBox.Show(
                    "Unable to start rendering the video because you have not loaded the video file (mp4), the time file (txt) and or selected a time cushion! Please fix and try again.",
                    " Unable to render",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void CalculateSplitTimes()
        {
            try
            {
                var fileStream2 = new FileStream(_timeFilePath, FileMode.Open, FileAccess.Read);

                using (var streamReader = new StreamReader(fileStream2, Encoding.UTF8))
                {
                    // Will store line read from text file
                    string line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        // Converts line read from file to DateTime.
                        var timestamp = DateTime.ParseExact(line, "HH:mm:ss", null);
                        // Subtracts the selected cushion time from the timestamp read from file.
                        var sub = timestamp.Subtract(_timeCushion.TimeOfDay);
                        // Adds the selected cushion time to the timestamp read from file.
                        var add = timestamp.Add(_timeCushion.TimeOfDay);

                        // Checks if subtracted timestamp is negative.
                        // You cannot split a video file from -00:00:03
                        // if the video starts at 00:00:00.
                        // Uses day of the month to check if sub < 00:00:00.
                        if (timestamp.ToString("dd") != sub.ToString("dd"))
                        {
                            sub = DateTime.ParseExact("00:00:00", "HH:mm:ss", null);
                        }

                        // Checks if the added timestamp is longer than video duration.
                        if (add > GetDuration())
                        {
                            add = GetDuration();
                        }

                        // Appends list containing start and end times to _splitTimes list.
                        _splitTimes.Add(new List<string> { sub.ToString("HH:mm:ss"),
                                                            add.ToString("HH:mm:ss") }
                        );
                    }
                }

                fileStream2.Close();
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Unable to start rendering the video because the timefile is in an" +
                    " unreadable format!",
                    "Unable to render",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private DateTime GetDuration()
        {
            // Creates ffprobe process
            var ffprobe = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    FileName = AppDomain.CurrentDomain.BaseDirectory +
                               "\\ffmpeg\\ffmpeg\\bin\\ffprobe.exe",
                    WindowStyle = ProcessWindowStyle.Hidden,
                    Arguments = "-v error -show_entries format=duration -of" + 
                                " default=noprint_wrappers=1:nokey=1 -sexagesimal" + 
                                $" \"{_videoFilePath}\"",
                    RedirectStandardOutput = true
                }
            };

            // Runs ffprobe process
            ffprobe.Start();
            // Stores ffprobe output, duration of video file
            string output = ffprobe.StandardOutput.ReadToEnd();
            ffprobe.WaitForExit();

            return DateTime.Parse(output);
        }

        private void Render()
        {
            // File counter incase of multiple renders.
            var counter = 1;

            try
            {
                // Nested list containing start and end time for rendering.
                foreach (List<string> pair in _splitTimes)
                {
                    // Stores timestamp of where to start the split.
                    string start = pair[0];
                    // Stores timestamp of where to end the split.
                    string end = pair[1];

                    // Creates ffmpeg process.
                    var ffmpeg = new Process
                    {
                        StartInfo = new ProcessStartInfo
                        {
                            CreateNoWindow = false,
                            UseShellExecute = false,
                            FileName = AppDomain.CurrentDomain.BaseDirectory +
                                       "\\ffmpeg\\ffmpeg\\bin\\ffmpeg.exe",
                            WindowStyle = ProcessWindowStyle.Maximized,
                            Arguments = $"-i \"{_videoFilePath}\" -ss {start} -to {end}" + 
                                $" \"{_renderFilePath.Substring(0, _renderFilePath.Length - 4)}" +
                                $"{counter}.mp4\""
                        }
                    };

                    // Runs ffmpeg process.
                    ffmpeg.Start();
                    ffmpeg.WaitForExit();
                    counter++;
                }
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "An error has occured whilst rendering. Please try again!",
                    " Unable to render",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // Resets all variables used in the rendering process.
        public void ResetVars()
        {
            foreach (List<string> innerItem in _splitTimes)
            {
                innerItem.Clear();
            }

            _splitTimes.Clear();
            _videoFilePath = null;
            _timeFilePath = null;
            _renderFilePath = null;
            rbtn10Min.Checked = false;
            rbtn15Min.Checked = false;
            rbtn15Sec.Checked = false;
            rbtn1Hour.Checked = false;
            rbtn1Min.Checked = false;
            rbtn2Hour.Checked = false;
            rbtn2Min.Checked = false;
            rbtn30Min.Checked = false;
            rbtn30Sec.Checked = false;
            rbtn45Min.Checked = false;
            rbtn45Sec.Checked = false;
            rbtn5Min.Checked = false;
            _isCushionLoaded = false;
            _isTextLoaded = false;
            _isVideoLoaded = false;

            MessageBox.Show(
                "If you wish to render again, please re-select your time and video file as well" +
                " as your time cushion!",
                "Render information",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ResetTimer();
            CheckForUpdates();
        }
    }
}
