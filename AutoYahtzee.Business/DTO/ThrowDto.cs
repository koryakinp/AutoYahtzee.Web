using System;
using static AutoYahtzee.Business.Consts;

namespace AutoYahtzee.Business.DTO
{
    public class ThrowDto
    {
        private string _imageUrl;
        public string _videoUrl;

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
        public string VideoUrl
        {
            get
            {
                return $"https://{STORAGE_ACCOUNT}.blob.core.windows.net/{VIDEO_CONTAINER}/{_videoUrl}";
            }
            set
            {
                _videoUrl = value;
            }
        }
        public DateTime Date { get; set; }
    }
}
