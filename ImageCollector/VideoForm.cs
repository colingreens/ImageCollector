using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using Accord.Video.FFMPEG;
using System.Drawing.Imaging;
using System.IO;
using System.Text.RegularExpressions;

namespace ImageCollector
{
    public partial class VideoForm : Form
    {
       
        private VideoCaptureDevice videoSource = new VideoCaptureDevice();
        FilterInfoCollection videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
        
        private string _myPicturesPath = Properties.Settings.Default.DefaultSaveFolder;
        private string _savePath;
        private string _dateTimeStamp = DateTime.Now.ToString("yyyyMMddHHmmss");
        private int _timeMagnitude = 60000;
        private Image _webCamShot;
        private bool _isRecording;

        public VideoForm()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (FilterInfo device in videoDevices)
            {
                comboBoxCams.Items.Add(device.Name);
            }

            if (comboBoxCams.Items.Count > 0)
            {
                comboBoxCams.SelectedIndex = 0;
            }
            textBox1.Text = _myPicturesPath;
            _savePath = textBox1.Text;
            LoadVideoSettings();

        }

        private void GetExposureSetting()
        {
            int exposure;
            CameraControlFlags exposureFlag;
            videoSource.GetCameraProperty(CameraControlProperty.Exposure,
                                          out exposure,
                                          out exposureFlag);
            VideoProperties.Exposure = exposure;
            VideoProperties.ExposureFlag = exposureFlag;
        }

        private void btnStream_Click(object sender, EventArgs e)
        {
            if (videoSource.IsRunning)
            {
                videoSource.Stop();
                pictureBoxStream.Image = null;
                pictureBoxStream.Invalidate();
                timeLapseTimer.Stop();                
            }
            else if (comboBoxSettings.SelectedItem != null)
            {
                videoSource.NewFrame += videoSource_NewFrame;
                videoSource.VideoResolution = videoSource.VideoCapabilities[comboBoxSettings.SelectedIndex];
                videoSource.Start();
            }
        }

        private void videoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            var oldImage = pictureBoxStream.Image;
            Bitmap image = (Bitmap)eventArgs.Frame.Clone();
            
                _webCamShot = image;
                pictureBoxStream.Image = image;
                oldImage?.Dispose();
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {

            SeeWhichButtonIsChecked();
            timeLapseIntervalLabel.Text = trackBar1.Value.ToString();

            timeLapseTimer.Interval = trackBar1.Value * _timeMagnitude;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            _folderBrowserDialogMethod.SelectedPath = _myPicturesPath;
            if (_folderBrowserDialogMethod.ShowDialog() == DialogResult.OK)
            {
               textBox1.Text = _folderBrowserDialogMethod.SelectedPath;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            _savePath = textBox1.Text;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            _dateTimeStamp = DateTime.Now.ToString("yyyyHHddHHmmss");
            if (true)
            {

            }
            _webCamShot.Save(_savePath + "\\" + _dateTimeStamp + "imageTest.jpg", ImageFormat.Jpeg);
            SetPhotoCountVideoEstimate();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (videoSource.IsRunning)
            {
                videoSource.Stop();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CompileFoldertoVid();
        }

        private void LoadVideoSettings()
        {
            videoSource = new VideoCaptureDevice(videoDevices[comboBoxCams.SelectedIndex].MonikerString);
            comboBoxSettings.Items.Clear();
            for (var i = 0; i < videoSource.VideoCapabilities.Length; i++)
            {
                comboBoxSettings.Items.Add(videoSource.VideoCapabilities[i].FrameSize.ToString());
            }
        }

        private void CompileFoldertoVid()
        {
            if (comboBoxSettings.SelectedItem == null)
            {
                MessageBox.Show("Resolution Not Selected");
            }
            else
            {
               Match match = Regex.Match((string)comboBoxSettings.SelectedItem, @"\d{3,4}");
               int width = Int32.Parse(match.Value);
               int height = Int32.Parse(match.NextMatch().Value);
               var imagesCollection = Directory.GetFiles(_savePath,"*.jpg", SearchOption.TopDirectoryOnly).OrderBy(p => new FileInfo(p).LastWriteTime).ToList();

                using (VideoFileWriter writer = new VideoFileWriter())
                {
                    var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                    writer.Open($@"{desktop}\test1.avi", width, height,15, VideoCodec.MPEG4, 15000000);

                    foreach (var frame in imagesCollection)
                    {
                        using (Bitmap bmp = Bitmap.FromFile(frame) as Bitmap)
                            writer.WriteVideoFrame(bmp);
                    }
                    writer.Close();
                    MessageBox.Show("Images Converted to AVI");
                }
            }

        }

        private void SetPhotoCountVideoEstimate()
        {
            int fileNumber = Directory.GetFiles(_savePath, "*.jpg", SearchOption.TopDirectoryOnly).Length;

            Action action = () => label5.Text = (fileNumber / 15) + " seconds";
            this.Invoke(action);
        }

        private void SeeWhichButtonIsChecked()
        {
            if (radioButton1.Checked)
            {
                _timeMagnitude = 1000;
            }
            else if (radioButton2.Checked)
            {
                _timeMagnitude = 60000;
            }
            else if (radioButton3.Checked)
            {
                _timeMagnitude = 3600000;
            }
        }

        private void comboBoxCams_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadVideoSettings();
        }

        private void checkBoxRecord_CheckedChanged(object sender, EventArgs e)
        {
            if (_isRecording == false)
            {
                _isRecording = true;
                checkBoxRecord.Text = "Recording";
                checkBoxRecord.BackColor = Color.Crimson;
                StartRecording();

            }
            else if (_isRecording)
            {
                _isRecording = false;
                checkBoxRecord.Text = "Stopped Recording";
                checkBoxRecord.BackColor = DefaultBackColor;
                timeLapseTimer.Stop();
            }
        }

        private void StartRecording()
        {
            _webCamShot.Save(_savePath + "\\" + _dateTimeStamp + "image.jpg", ImageFormat.Jpeg);

            if (radioButtonTimeLapse.Checked && comboBoxSettings.SelectedItem != null)
            {
                timeLapseTimer.Start();
            }
            else
            {
                MessageBox.Show("Make Sure Camera is Selected or TimeLapse is Checked");
                _isRecording = false;
                checkBoxRecord.Text = "Stopped Recording";
                checkBoxRecord.BackColor = DefaultBackColor;

            }
        }
    }
}
