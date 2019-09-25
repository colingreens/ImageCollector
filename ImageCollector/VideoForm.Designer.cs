namespace ImageCollector
{
    partial class VideoForm
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
            this.pictureBoxStream = new System.Windows.Forms.PictureBox();
            this.comboBoxCams = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxRecord = new System.Windows.Forms.CheckBox();
            this.comboBoxSettings = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.button4 = new System.Windows.Forms.Button();
            this.timeLapseIntervalLabel = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButtonTimeLapse = new System.Windows.Forms.RadioButton();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this._folderBrowserDialogMethod = new System.Windows.Forms.FolderBrowserDialog();
            this.timeLapseTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStream)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxStream
            // 
            this.pictureBoxStream.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxStream.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.pictureBoxStream.Location = new System.Drawing.Point(7, 31);
            this.pictureBoxStream.Name = "pictureBoxStream";
            this.pictureBoxStream.Size = new System.Drawing.Size(621, 444);
            this.pictureBoxStream.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxStream.TabIndex = 0;
            this.pictureBoxStream.TabStop = false;
            // 
            // comboBoxCams
            // 
            this.comboBoxCams.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBoxCams.Cursor = System.Windows.Forms.Cursors.Default;
            this.comboBoxCams.FormattingEnabled = true;
            this.comboBoxCams.Location = new System.Drawing.Point(7, 486);
            this.comboBoxCams.Name = "comboBoxCams";
            this.comboBoxCams.Size = new System.Drawing.Size(303, 21);
            this.comboBoxCams.TabIndex = 1;
            this.comboBoxCams.SelectedIndexChanged += new System.EventHandler(this.comboBoxCams_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(7, 514);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(303, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Start/Stop";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnStream_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.checkBoxRecord);
            this.groupBox1.Controls.Add(this.comboBoxSettings);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.timeLapseIntervalLabel);
            this.groupBox1.Controls.Add(this.trackBar1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.radioButtonTimeLapse);
            this.groupBox1.Location = new System.Drawing.Point(634, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(176, 527);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Control Box";
            // 
            // checkBoxRecord
            // 
            this.checkBoxRecord.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBoxRecord.AutoSize = true;
            this.checkBoxRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxRecord.Location = new System.Drawing.Point(0, 489);
            this.checkBoxRecord.Name = "checkBoxRecord";
            this.checkBoxRecord.Size = new System.Drawing.Size(159, 35);
            this.checkBoxRecord.TabIndex = 16;
            this.checkBoxRecord.Text = "Not Recording";
            this.checkBoxRecord.UseVisualStyleBackColor = true;
            this.checkBoxRecord.CheckedChanged += new System.EventHandler(this.checkBoxRecord_CheckedChanged);
            // 
            // comboBoxSettings
            // 
            this.comboBoxSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBoxSettings.Cursor = System.Windows.Forms.Cursors.Default;
            this.comboBoxSettings.FormattingEnabled = true;
            this.comboBoxSettings.Location = new System.Drawing.Point(11, 239);
            this.comboBoxSettings.Name = "comboBoxSettings";
            this.comboBoxSettings.Size = new System.Drawing.Size(126, 21);
            this.comboBoxSettings.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(63, 411);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 25);
            this.label5.TabIndex = 13;
            this.label5.Text = "0 s";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(18, 373);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 20);
            this.label4.TabIndex = 12;
            this.label4.Text = "Est Video Length";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radioButton3);
            this.panel1.Controls.Add(this.radioButton2);
            this.panel1.Controls.Add(this.radioButton1);
            this.panel1.Location = new System.Drawing.Point(22, 158);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(102, 75);
            this.panel1.TabIndex = 9;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(3, 49);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(53, 17);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Hours";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(3, 26);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(62, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Minutes";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(4, 3);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(67, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Seconds";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Location = new System.Drawing.Point(0, 460);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(159, 23);
            this.button4.TabIndex = 8;
            this.button4.Text = "Make Video";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // timeLapseIntervalLabel
            // 
            this.timeLapseIntervalLabel.AutoSize = true;
            this.timeLapseIntervalLabel.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeLapseIntervalLabel.Location = new System.Drawing.Point(63, 68);
            this.timeLapseIntervalLabel.Name = "timeLapseIntervalLabel";
            this.timeLapseIntervalLabel.Size = new System.Drawing.Size(22, 25);
            this.timeLapseIntervalLabel.TabIndex = 6;
            this.timeLapseIntervalLabel.Text = "0";
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(9, 107);
            this.trackBar1.Maximum = 30;
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(145, 45);
            this.trackBar1.TabIndex = 5;
            this.trackBar1.Value = 1;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Time Between Shots";
            // 
            // radioButtonTimeLapse
            // 
            this.radioButtonTimeLapse.AutoSize = true;
            this.radioButtonTimeLapse.Location = new System.Drawing.Point(41, 19);
            this.radioButtonTimeLapse.Name = "radioButtonTimeLapse";
            this.radioButtonTimeLapse.Size = new System.Drawing.Size(73, 17);
            this.radioButtonTimeLapse.TabIndex = 1;
            this.radioButtonTimeLapse.TabStop = true;
            this.radioButtonTimeLapse.Text = "Timelapse";
            this.radioButtonTimeLapse.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(322, 514);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(305, 22);
            this.button2.TabIndex = 4;
            this.button2.Text = "Open Image Folder Save/Convert";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(324, 486);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(303, 20);
            this.textBox1.TabIndex = 5;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // timeLapseTimer
            // 
            this.timeLapseTimer.Interval = 600000;
            this.timeLapseTimer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // VideoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 544);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBoxCams);
            this.Controls.Add(this.pictureBoxStream);
            this.Name = "VideoForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CamCapture";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStream)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxStream;
        private System.Windows.Forms.ComboBox comboBoxCams;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.FolderBrowserDialog _folderBrowserDialogMethod;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButtonTimeLapse;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label timeLapseIntervalLabel;
        private System.Windows.Forms.Timer timeLapseTimer;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxSettings;
        private System.Windows.Forms.CheckBox checkBoxRecord;
    }
}

