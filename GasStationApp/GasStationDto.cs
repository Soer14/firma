using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GasStationApp
{
    public class GasStationResponseDto
    {
        public List<GasStationDto> GasStations { get; set; }
        public int TotalCount { get; set; }
    }

    public class GasStationDto
    {
        public int StationNumber { get; set; }
        public string StationName { get; set; }
        public string Country { get; set; }
        public string Currency { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string CompanyName { get; set; }
        public double ServiceSurcharge { get; set; }
        public bool ZeroServiceFee { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public string PriceZone { get; set; }
    }

}
