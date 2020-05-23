using System;
using static AutoYahtzee.Business.Consts;

namespace AutoYahtzee.Business.DTO
{
    public class PredictionDto
    {
        public Guid Id { get; set; }
        public string Image 
        { 
            get
            {
                return $"https://{STORAGE_ACCOUNT}.blob.core.windows.net/{PREDICTION_CONTAINER}/{Id}.jpg";
            }
        }

        public double Confidence { get; set; }
        public byte Prediction { get; set; }
    }
}
