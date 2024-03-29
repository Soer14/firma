﻿namespace GasStationApp
{
    public class GasStationResponseDto
    {
        public List<GasStationDto> Data { get; set; }
        public int TotalCount { get; set; }
    }

    public class GasStationDto
    {
        public int StationNumber { get; set; }
        public string StationName { get; set; }
        public string Country { get; set; }
        public string Comments { get; set; }
        public string Currency { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string CompanyName { get; set; }
        public double ServiceSurcharge { get; set; }
        public bool ZeroServiceFee { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public bool OmrStation { get; set; }
        public bool HotSpot { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public string PriceZone { get; set; }
    }

}
