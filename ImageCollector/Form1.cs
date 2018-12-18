using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using Accord.Video.FFMPEG;
using System.Drawing.Imaging;
using System.IO;

namespace ImageCollector
{
    public partial class Form1 : Form
    {
        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource;        
        private string _myPicturesPath = @"D:\Colin\Pictures\Camera Roll";
        private string _savePath;
        private string _dateTimeStamp = DateTime.Now.ToString("yyyyMMddHHmmss");
        private int _timeMagnitude = 60000;
        private Image _webCamShot;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo device in videoDevices)
            {
                comboBoxCams.Items.Add(device.Name);
            }
            videoSource = new VideoCaptureDevice();

            if (comboBoxCams.Items.Count > 0)
            {
                comboBoxCams.SelectedIndex = 0;
            }
            textBox1.Text = _myPicturesPath;
            _savePath = textBox1.Text;
                        
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
            else
            {
                videoSource = new VideoCaptureDevice(videoDevices[comboBoxCams.SelectedIndex].MonikerString);
                //set newframe event handler
                videoSource.NewFrame += new NewFrameEventHandler(videoSource_NewFrame);
                var whatsInHere = videoSource.VideoCapabilities;
                for (int i = 0; i < whatsInHere.Length; i++)
                {

                    string resolution = "Resolution Number " + Convert.ToString(i);
                    string resolution_size = videoSource.VideoCapabilities[i].FrameSize.ToString();
                }
                videoSource.VideoResolution = videoSource.VideoCapabilities[16];
                videoSource.Start();
            }
        }

        private void videoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap image = (Bitmap)eventArgs.Frame.Clone();
            _webCamShot = image;
            pictureBoxStream.Image = image;
        }

        private void btnRecord_Click(object sender, EventArgs e)
        {
            _webCamShot.Save(_savePath + "\\" + _dateTimeStamp + "imageTest.jpg", ImageFormat.Jpeg);

            if (radioButtonTimeLapse.Checked)
            {
                timeLapseTimer.Start();
            }            
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
            _webCamShot.Save(_savePath + "\\" + _dateTimeStamp + "imageTest.jpg", ImageFormat.Jpeg);
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

        private void CompileFoldertoVid()
        {
            int width = 1920;
            int height = 1080;

            var imagesCollection = Directory.GetFiles(_savePath, "*.jpg", SearchOption.TopDirectoryOnly).ToList();
            using (VideoFileWriter writer = new VideoFileWriter())
            {
                var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                writer.Open($@"{desktop}\test1.avi", width, height, 10, VideoCodec.MPEG4, 10000000);

                foreach (var frame in imagesCollection)
                {
                    using (Bitmap bmp = Bitmap.FromFile(frame) as Bitmap)
                    writer.WriteVideoFrame(bmp);
                }
                writer.Close();
                MessageBox.Show("Images Converted to AVI");
            }

        }

        private void SetPhotoCountVideoEstimate()
        {
            //int fileNumber = Directory.GetFiles(_savePath, "*.jpg", SearchOption.TopDirectoryOnly).Length;
            //label3.Text = fileNumber.ToString();
            //label5.Text = (fileNumber / 25).ToString() + " s";
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
    }
}
