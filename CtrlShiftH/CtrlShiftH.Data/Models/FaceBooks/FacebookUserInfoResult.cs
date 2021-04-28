using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CtrlShiftH.Data.Models.FaceBooks
{
    public class PictureData
    {
        public int height { get; set; }
        public bool is_silhouette { get; set; }
        public string url { get; set; }
        public int width { get; set; }
    }

    public class Picture
    {
        public PictureData data { get; set; }
    }

    public class FacebookUserInfoResult
    {
        public string name { get; set; }
        public Picture picture { get; set; }
        public string id { get; set; }
    }

}
