using System;
using System.Collections.Generic;
using static AutoYahtzee.Business.Consts;

namespace AutoYahtzee.Business.DTO
{
    public class ThrowDto
    {
        private Guid _id;

        public Guid Id {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            } 
        }
        public string Result { get; set; }
        public string ImageUrl 
        { 
            get
            {
                return $"https://{STORAGE_ACCOUNT}.blob.core.windows.net/{IMAGE_CONTAINER}/{_id}.jpg";
            }
        }
        public string VideoUrlWebm
        {
            get
            {
                return $"https://{STORAGE_ACCOUNT}.blob.core.windows.net/{VIDEO_CONTAINER_WEBM}/{_id}.webm";
            }
        }

        public string VideoUrlMp4
        {
            get
            {
                return $"https://{STORAGE_ACCOUNT}.blob.core.windows.net/{VIDEO_CONTAINER_MP4}/{_id}.mp4";
            }
        }

        public DateTime Date { get; set; }

        public int RollNumber { get; set; }

        public List<PredictionDto> Predictions { get; set; }
    }
}
