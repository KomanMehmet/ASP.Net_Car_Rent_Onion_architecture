﻿namespace CarRent.Dto.CarFeatureDtos
{
    public class ResultCarFeatureByCarIdDto
    {
        public int CarFeatureID { get; set; }

        public int FeatureID { get; set; }

        public string FeatureName { get; set; }

        public bool Avaliable { get; set; }
    }
}
