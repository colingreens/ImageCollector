using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using Accord.Video.FFMPEG;
using System.Drawing.Imaging;
using System.IO;
using System.Drawing.Drawing2D;

namespace ImageCollector
{
    public partial class Form1 : Form
    {
        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource;
        private string _myPicturesPath = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
        private string _savePath;
        private string _dateTimeStamp = DateTime.Now.ToString("yyyyMMddHHmmss");
        private int _timeMagnitude = 60000;

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
                videoSource.Start();
            }
        }

        private void videoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap image = (Bitmap)eventArgs.Frame.Clone();
            pictureBoxStream.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxStream.Image = image;
            SetPhotoCountVideoEstimate();
        }

        private void btnRecord_Click(object sender, EventArgs e)
        {

            pictureBoxStream.Image.Save(_savePath + "\\" + _dateTimeStamp + "imageTest.jpg", ImageFormat.Jpeg);

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
            pictureBoxStream.Image.Save(_savePath + "\\" + _dateTimeStamp + "imageTest.jpg", ImageFormat.Jpeg);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (videoSource.IsRunning)
            {
                videoSource.Stop();
            }
        }

        private void CompileFoldertoVid()
        {
            int width = 640;
            int height = 480;

            var imagesCollection = Directory.GetFiles(_savePath, "*Test.jpg", SearchOption.AllDirectories).ToList();
            VideoFileWriter writer = new VideoFileWriter();

            writer.Open(@"C:\Users\cbenson\Desktop\test.avi", width, height, 25, VideoCodec.MPEG4);

            foreach (var frame in imagesCollection)
            {
                var bmp = new Bitmap(frame);
                bmp = ResizeImage(bmp, width, height);
                writer.WriteVideoFrame(bmp);
            }
            writer.Close();
            MessageBox.Show("Images Converted to AVI");
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CompileFoldertoVid();
        }

        private Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
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
