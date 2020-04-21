using System;
using static AutoYahtzee.Business.Consts;

namespace AutoYahtzee.Business.DTO
{
    public class ThrowDto
    {
        private string _imageUrl;
        private string _videoUrl;

        public Guid Id { get; set; }
        public string Result { get; set; }
        public string ImageUrl 
        { 
            get
            {
                return $"https://{STORAGE_ACCOUNT}.blob.core.windows.net/{IMAGE_CONTAINER}/{_imageUrl}";
            }
            set
            {
                _imageUrl = value;
            }
        }
        public string VideoUrlWebm
        {
            get
            {
                return $"https://{STORAGE_ACCOUNT}.blob.core.windows.net/{VIDEO_CONTAINER_WEBM}/{_videoUrl}";
            }
            set
            {
                _videoUrl = value;
            }
        }

        public string VideoUrlMp4
        {
            get
            {
                return $"https://{STORAGE_ACCOUNT}.blob.core.windows.net/{VIDEO_CONTAINER_MP4}/{_videoUrl.Replace(".webm", ".mp4")}";
            }
            set
            {
                _videoUrl = value;
            }
        }

        public DateTime Date { get; set; }

        public int RollNumber { get; set; }
    }
}
