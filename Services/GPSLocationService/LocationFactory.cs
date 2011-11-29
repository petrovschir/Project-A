using Ketl.GpsTracking.Core;
using Ketl.GpsTracking.DataProvider;
using Ketl.GpsTracking.Manager;
using System.Configuration;

namespace Ketl.GpsTracking.Service.Factory
{
    // use DI (like Unity) at some point
    public class LocationFactory
    {
        public static LocationServiceBase GetLocationService()
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["DBMongo"].ConnectionString;
            // initialize the location service 
            return new GpsLocationManager(new MongoDataProvider(ConnectionString));
        }
    }
}