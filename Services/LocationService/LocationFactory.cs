using GPSTraking.Core;
using GPSTraking.MongoDataProvider;
using GPSTrakingService;

namespace LocationService
{
    // use DI (like Unity) at some point
    public class LocationFactory
    {
        public static ILocationService GetLocationService()
        {
            // initialize the location service 
            return new GPSLocationService(new MongoDataProvider());
        }
    }
}