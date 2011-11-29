using System;

namespace Ketl.GpsTracking.Model
{
    public class GpsLocation : GpsData
    {
        public GpsPoint Coordinates { get; set; }
        public Guid SessionKey { get; set; }
    }
}
