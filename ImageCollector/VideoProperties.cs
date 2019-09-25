using AForge.Video.DirectShow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageCollector
{
    public static class VideoProperties
    {
        public static int Exposure { get; set; }

        public static CameraControlFlags ExposureFlag { get; set; }
    }
}
