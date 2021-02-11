namespace FootageTool
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.winRecord = new System.Windows.Forms.TabPage();
            this.lstTimeStamps = new System.Windows.Forms.ListBox();
            this.button3 = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnMark = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblColonFormat2 = new System.Windows.Forms.Label();
            this.lblColonFormat = new System.Windows.Forms.Label();
            this.lblHours = new System.Windows.Forms.Label();
            this.lblSeconds = new System.Windows.Forms.Label();
            this.lblMinutes = new System.Windows.Forms.Label();
            this.lblRecordTitle = new System.Windows.Forms.Label();
            this.winRender = new System.Windows.Forms.TabPage();
            this.btnRender = new System.Windows.Forms.Button();
            this.rbtn30Sec = new System.Windows.Forms.RadioButton();
            this.rbtn2Hour = new System.Windows.Forms.RadioButton();
            this.rbtn1Hour = new System.Windows.Forms.RadioButton();
            this.rbtn45Min = new System.Windows.Forms.RadioButton();
            this.rbtn30Min = new System.Windows.Forms.RadioButton();
            this.rbtn15Min = new System.Windows.Forms.RadioButton();
            this.rbtn10Min = new System.Windows.Forms.RadioButton();
            this.rbtn5Min = new System.Windows.Forms.RadioButton();
            this.rbtn2Min = new System.Windows.Forms.RadioButton();
            this.rbtn1Min = new System.Windows.Forms.RadioButton();
            this.rbtn45Sec = new System.Windows.Forms.RadioButton();
            this.rbtn15Sec = new System.Windows.Forms.RadioButton();
            this.lblRenderTitle = new System.Windows.Forms.Label();
            this.btnLoadTime = new System.Windows.Forms.Button();
            this.btnLoadVideo = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabControl1.SuspendLayout();
            this.winRecord.SuspendLayout();
            this.winRender.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.winRecord);
            this.tabControl1.Controls.Add(this.winRender);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(776, 426);
            this.tabControl1.TabIndex = 0;
            // 
            // winRecord
            // 
            this.winRecord.Controls.Add(this.lstTimeStamps);
            this.winRecord.Controls.Add(this.button3);
            this.winRecord.Controls.Add(this.btnStop);
            this.winRecord.Controls.Add(this.btnMark);
            this.winRecord.Controls.Add(this.btnExport);
            this.winRecord.Controls.Add(this.btnReset);
            this.winRecord.Controls.Add(this.btnStart);
            this.winRecord.Controls.Add(this.lblColonFormat2);
            this.winRecord.Controls.Add(this.lblColonFormat);
            this.winRecord.Controls.Add(this.lblHours);
            this.winRecord.Controls.Add(this.lblSeconds);
            this.winRecord.Controls.Add(this.lblMinutes);
            this.winRecord.Controls.Add(this.lblRecordTitle);
            this.winRecord.Location = new System.Drawing.Point(4, 22);
            this.winRecord.Name = "winRecord";
            this.winRecord.Padding = new System.Windows.Forms.Padding(3);
            this.winRecord.Size = new System.Drawing.Size(768, 400);
            this.winRecord.TabIndex = 0;
            this.winRecord.Text = "Record";
            this.winRecord.UseVisualStyleBackColor = true;
            // 
            // lstTimeStamps
            // 
            this.lstTimeStamps.FormattingEnabled = true;
            this.lstTimeStamps.Location = new System.Drawing.Point(301, 193);
            this.lstTimeStamps.Name = "lstTimeStamps";
            this.lstTimeStamps.Size = new System.Drawing.Size(165, 95);
            this.lstTimeStamps.TabIndex = 5;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(464, 63);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(0, 0);
            this.button3.TabIndex = 4;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(391, 100);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 25);
            this.btnStop.TabIndex = 3;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnMark
            // 
            this.btnMark.Location = new System.Drawing.Point(301, 162);
            this.btnMark.Name = "btnMark";
            this.btnMark.Size = new System.Drawing.Size(165, 25);
            this.btnMark.TabIndex = 3;
            this.btnMark.Text = "Mark";
            this.btnMark.UseVisualStyleBackColor = true;
            this.btnMark.Click += new System.EventHandler(this.btnMark_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(391, 131);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 25);
            this.btnExport.TabIndex = 3;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(301, 131);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 25);
            this.btnReset.TabIndex = 3;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(301, 100);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 25);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblColonFormat2
            // 
            this.lblColonFormat2.AutoSize = true;
            this.lblColonFormat2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColonFormat2.Location = new System.Drawing.Point(409, 50);
            this.lblColonFormat2.Name = "lblColonFormat2";
            this.lblColonFormat2.Size = new System.Drawing.Size(19, 25);
            this.lblColonFormat2.TabIndex = 2;
            this.lblColonFormat2.Text = ":";
            this.lblColonFormat2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblColonFormat
            // 
            this.lblColonFormat.AutoSize = true;
            this.lblColonFormat.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColonFormat.Location = new System.Drawing.Point(340, 50);
            this.lblColonFormat.Name = "lblColonFormat";
            this.lblColonFormat.Size = new System.Drawing.Size(19, 25);
            this.lblColonFormat.TabIndex = 2;
            this.lblColonFormat.Text = ":";
            this.lblColonFormat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHours
            // 
            this.lblHours.AutoSize = true;
            this.lblHours.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHours.Location = new System.Drawing.Point(296, 50);
            this.lblHours.Name = "lblHours";
            this.lblHours.Size = new System.Drawing.Size(38, 25);
            this.lblHours.TabIndex = 1;
            this.lblHours.Text = "00";
            this.lblHours.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSeconds
            // 
            this.lblSeconds.AutoSize = true;
            this.lblSeconds.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeconds.Location = new System.Drawing.Point(434, 50);
            this.lblSeconds.Name = "lblSeconds";
            this.lblSeconds.Size = new System.Drawing.Size(38, 25);
            this.lblSeconds.TabIndex = 1;
            this.lblSeconds.Text = "00";
            this.lblSeconds.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMinutes
            // 
            this.lblMinutes.AutoSize = true;
            this.lblMinutes.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinutes.Location = new System.Drawing.Point(365, 50);
            this.lblMinutes.Name = "lblMinutes";
            this.lblMinutes.Size = new System.Drawing.Size(38, 25);
            this.lblMinutes.TabIndex = 1;
            this.lblMinutes.Text = "00";
            this.lblMinutes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRecordTitle
            // 
            this.lblRecordTitle.AutoSize = true;
            this.lblRecordTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordTitle.Location = new System.Drawing.Point(351, 10);
            this.lblRecordTitle.Name = "lblRecordTitle";
            this.lblRecordTitle.Size = new System.Drawing.Size(67, 20);
            this.lblRecordTitle.TabIndex = 0;
            this.lblRecordTitle.Text = "Record";
            this.lblRecordTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // winRender
            // 
            this.winRender.Controls.Add(this.btnRender);
            this.winRender.Controls.Add(this.rbtn30Sec);
            this.winRender.Controls.Add(this.rbtn2Hour);
            this.winRender.Controls.Add(this.rbtn1Hour);
            this.winRender.Controls.Add(this.rbtn45Min);
            this.winRender.Controls.Add(this.rbtn30Min);
            this.winRender.Controls.Add(this.rbtn15Min);
            this.winRender.Controls.Add(this.rbtn10Min);
            this.winRender.Controls.Add(this.rbtn5Min);
            this.winRender.Controls.Add(this.rbtn2Min);
            this.winRender.Controls.Add(this.rbtn1Min);
            this.winRender.Controls.Add(this.rbtn45Sec);
            this.winRender.Controls.Add(this.rbtn15Sec);
            this.winRender.Controls.Add(this.lblRenderTitle);
            this.winRender.Controls.Add(this.btnLoadTime);
            this.winRender.Controls.Add(this.btnLoadVideo);
            this.winRender.Location = new System.Drawing.Point(4, 22);
            this.winRender.Name = "winRender";
            this.winRender.Padding = new System.Windows.Forms.Padding(3);
            this.winRender.Size = new System.Drawing.Size(768, 400);
            this.winRender.TabIndex = 1;
            this.winRender.Text = "Render";
            this.winRender.UseVisualStyleBackColor = true;
            // 
            // btnRender
            // 
            this.btnRender.Location = new System.Drawing.Point(284, 250);
            this.btnRender.Name = "btnRender";
            this.btnRender.Size = new System.Drawing.Size(200, 25);
            this.btnRender.TabIndex = 3;
            this.btnRender.Text = "Render";
            this.btnRender.UseVisualStyleBackColor = true;
            this.btnRender.Click += new System.EventHandler(this.btnRender_Click);
            // 
            // rbtn30Sec
            // 
            this.rbtn30Sec.AutoSize = true;
            this.rbtn30Sec.Location = new System.Drawing.Point(389, 100);
            this.rbtn30Sec.Name = "rbtn30Sec";
            this.rbtn30Sec.Size = new System.Drawing.Size(82, 17);
            this.rbtn30Sec.TabIndex = 2;
            this.rbtn30Sec.TabStop = true;
            this.rbtn30Sec.Text = "30 Seconds";
            this.rbtn30Sec.UseVisualStyleBackColor = true;
            // 
            // rbtn2Hour
            // 
            this.rbtn2Hour.AutoSize = true;
            this.rbtn2Hour.Location = new System.Drawing.Point(389, 215);
            this.rbtn2Hour.Name = "rbtn2Hour";
            this.rbtn2Hour.Size = new System.Drawing.Size(62, 17);
            this.rbtn2Hour.TabIndex = 2;
            this.rbtn2Hour.TabStop = true;
            this.rbtn2Hour.Text = "2 Hours";
            this.rbtn2Hour.UseVisualStyleBackColor = true;
            // 
            // rbtn1Hour
            // 
            this.rbtn1Hour.AutoSize = true;
            this.rbtn1Hour.Location = new System.Drawing.Point(284, 215);
            this.rbtn1Hour.Name = "rbtn1Hour";
            this.rbtn1Hour.Size = new System.Drawing.Size(57, 17);
            this.rbtn1Hour.TabIndex = 2;
            this.rbtn1Hour.TabStop = true;
            this.rbtn1Hour.Text = "1 Hour";
            this.rbtn1Hour.UseVisualStyleBackColor = true;
            // 
            // rbtn45Min
            // 
            this.rbtn45Min.AutoSize = true;
            this.rbtn45Min.Location = new System.Drawing.Point(389, 192);
            this.rbtn45Min.Name = "rbtn45Min";
            this.rbtn45Min.Size = new System.Drawing.Size(77, 17);
            this.rbtn45Min.TabIndex = 2;
            this.rbtn45Min.TabStop = true;
            this.rbtn45Min.Text = "45 Minutes";
            this.rbtn45Min.UseVisualStyleBackColor = true;
            // 
            // rbtn30Min
            // 
            this.rbtn30Min.AutoSize = true;
            this.rbtn30Min.Location = new System.Drawing.Point(284, 192);
            this.rbtn30Min.Name = "rbtn30Min";
            this.rbtn30Min.Size = new System.Drawing.Size(77, 17);
            this.rbtn30Min.TabIndex = 2;
            this.rbtn30Min.TabStop = true;
            this.rbtn30Min.Text = "30 Minutes";
            this.rbtn30Min.UseVisualStyleBackColor = true;
            // 
            // rbtn15Min
            // 
            this.rbtn15Min.AutoSize = true;
            this.rbtn15Min.Location = new System.Drawing.Point(389, 169);
            this.rbtn15Min.Name = "rbtn15Min";
            this.rbtn15Min.Size = new System.Drawing.Size(77, 17);
            this.rbtn15Min.TabIndex = 2;
            this.rbtn15Min.TabStop = true;
            this.rbtn15Min.Text = "15 Minutes";
            this.rbtn15Min.UseVisualStyleBackColor = true;
            // 
            // rbtn10Min
            // 
            this.rbtn10Min.AutoSize = true;
            this.rbtn10Min.Location = new System.Drawing.Point(284, 169);
            this.rbtn10Min.Name = "rbtn10Min";
            this.rbtn10Min.Size = new System.Drawing.Size(77, 17);
            this.rbtn10Min.TabIndex = 2;
            this.rbtn10Min.TabStop = true;
            this.rbtn10Min.Text = "10 Minutes";
            this.rbtn10Min.UseVisualStyleBackColor = true;
            // 
            // rbtn5Min
            // 
            this.rbtn5Min.AutoSize = true;
            this.rbtn5Min.Location = new System.Drawing.Point(389, 146);
            this.rbtn5Min.Name = "rbtn5Min";
            this.rbtn5Min.Size = new System.Drawing.Size(71, 17);
            this.rbtn5Min.TabIndex = 2;
            this.rbtn5Min.TabStop = true;
            this.rbtn5Min.Text = "5 Minutes";
            this.rbtn5Min.UseVisualStyleBackColor = true;
            // 
            // rbtn2Min
            // 
            this.rbtn2Min.AutoSize = true;
            this.rbtn2Min.Location = new System.Drawing.Point(284, 146);
            this.rbtn2Min.Name = "rbtn2Min";
            this.rbtn2Min.Size = new System.Drawing.Size(71, 17);
            this.rbtn2Min.TabIndex = 2;
            this.rbtn2Min.TabStop = true;
            this.rbtn2Min.Text = "2 Minutes";
            this.rbtn2Min.UseVisualStyleBackColor = true;
            // 
            // rbtn1Min
            // 
            this.rbtn1Min.AutoSize = true;
            this.rbtn1Min.Location = new System.Drawing.Point(389, 123);
            this.rbtn1Min.Name = "rbtn1Min";
            this.rbtn1Min.Size = new System.Drawing.Size(66, 17);
            this.rbtn1Min.TabIndex = 2;
            this.rbtn1Min.TabStop = true;
            this.rbtn1Min.Text = "1 Minute";
            this.rbtn1Min.UseVisualStyleBackColor = true;
            // 
            // rbtn45Sec
            // 
            this.rbtn45Sec.AutoSize = true;
            this.rbtn45Sec.Location = new System.Drawing.Point(284, 123);
            this.rbtn45Sec.Name = "rbtn45Sec";
            this.rbtn45Sec.Size = new System.Drawing.Size(82, 17);
            this.rbtn45Sec.TabIndex = 2;
            this.rbtn45Sec.TabStop = true;
            this.rbtn45Sec.Text = "45 Seconds";
            this.rbtn45Sec.UseVisualStyleBackColor = true;
            // 
            // rbtn15Sec
            // 
            this.rbtn15Sec.AutoSize = true;
            this.rbtn15Sec.Location = new System.Drawing.Point(284, 100);
            this.rbtn15Sec.Name = "rbtn15Sec";
            this.rbtn15Sec.Size = new System.Drawing.Size(82, 17);
            this.rbtn15Sec.TabIndex = 2;
            this.rbtn15Sec.TabStop = true;
            this.rbtn15Sec.Text = "15 Seconds";
            this.rbtn15Sec.UseVisualStyleBackColor = true;
            // 
            // lblRenderTitle
            // 
            this.lblRenderTitle.AutoSize = true;
            this.lblRenderTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRenderTitle.Location = new System.Drawing.Point(350, 10);
            this.lblRenderTitle.Name = "lblRenderTitle";
            this.lblRenderTitle.Size = new System.Drawing.Size(68, 20);
            this.lblRenderTitle.TabIndex = 1;
            this.lblRenderTitle.Text = "Render";
            this.lblRenderTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnLoadTime
            // 
            this.btnLoadTime.Location = new System.Drawing.Point(389, 50);
            this.btnLoadTime.Name = "btnLoadTime";
            this.btnLoadTime.Size = new System.Drawing.Size(95, 25);
            this.btnLoadTime.TabIndex = 0;
            this.btnLoadTime.Text = "Pick Time File";
            this.btnLoadTime.UseVisualStyleBackColor = true;
            this.btnLoadTime.Click += new System.EventHandler(this.btnLoadTime_Click);
            // 
            // btnLoadVideo
            // 
            this.btnLoadVideo.Location = new System.Drawing.Point(284, 50);
            this.btnLoadVideo.Name = "btnLoadVideo";
            this.btnLoadVideo.Size = new System.Drawing.Size(95, 25);
            this.btnLoadVideo.TabIndex = 0;
            this.btnLoadVideo.Text = "Pick Video File";
            this.btnLoadVideo.UseVisualStyleBackColor = true;
            this.btnLoadVideo.Click += new System.EventHandler(this.btnLoadVideo_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Footage Tool";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.winRecord.ResumeLayout(false);
            this.winRecord.PerformLayout();
            this.winRender.ResumeLayout(false);
            this.winRender.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage winRecord;
        private System.Windows.Forms.Label lblColonFormat2;
        private System.Windows.Forms.Label lblColonFormat;
        private System.Windows.Forms.Label lblHours;
        private System.Windows.Forms.Label lblSeconds;
        private System.Windows.Forms.Label lblMinutes;
        private System.Windows.Forms.Label lblRecordTitle;
        private System.Windows.Forms.TabPage winRender;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnMark;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ListBox lstTimeStamps;
        private System.Windows.Forms.RadioButton rbtn30Sec;
        private System.Windows.Forms.RadioButton rbtn2Hour;
        private System.Windows.Forms.RadioButton rbtn1Hour;
        private System.Windows.Forms.RadioButton rbtn45Min;
        private System.Windows.Forms.RadioButton rbtn30Min;
        private System.Windows.Forms.RadioButton rbtn15Min;
        private System.Windows.Forms.RadioButton rbtn10Min;
        private System.Windows.Forms.RadioButton rbtn5Min;
        private System.Windows.Forms.RadioButton rbtn2Min;
        private System.Windows.Forms.RadioButton rbtn1Min;
        private System.Windows.Forms.RadioButton rbtn45Sec;
        private System.Windows.Forms.RadioButton rbtn15Sec;
        private System.Windows.Forms.Label lblRenderTitle;
        private System.Windows.Forms.Button btnLoadTime;
        private System.Windows.Forms.Button btnLoadVideo;
        private System.Windows.Forms.Button btnRender;
    }
}

