using System;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using Ketl.GpsTracking.Core;
using Ketl.GpsTracking.Model;
using Ketl.GpsTracking.Manager;
using Ketl.GpsTracking.Service.Factory;
using System.Collections.Generic;

namespace Ketl.GpsTracking.Service
{
    // Start the service and browse to http://<machine_name>:<port>/Service1/help to view the service's generated help page
    // NOTE: By default, a new instance of the service is created for each call; change the InstanceContextMode to Single if you want
    // a single instance of the service to process all calls.	
    [ServiceContract]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    // NOTE: If the service is renamed, remember to update the global.asax.cs file
    public class GpsRestLocationService
    {
        
        private readonly LocationServiceBase locationService;

        public GpsRestLocationService(){
            locationService = LocationFactory.GetLocationService(); 
        }

        [WebGet(UriTemplate = "User/{name}", ResponseFormat = WebMessageFormat.Json)]
        public GpsUser GetUser(string name)
        {
            return locationService.GetUser(name);
        }

        [WebGet(UriTemplate = "Location/{session}", ResponseFormat = WebMessageFormat.Json)]
        public IList<GpsLocation> GetLocationsBySession(string session)
        {
            return locationService.GetLocationsBySession(new Guid(session));
        }

        [WebGet(UriTemplate = "Location", ResponseFormat = WebMessageFormat.Json)]
        public GpsLocation GetLastLocation()
        {
            return locationService.GetLastLocation(new Guid());
        }

        [WebGet(UriTemplate = "Session", ResponseFormat = WebMessageFormat.Json)]
        public GpsLocation GetSession()
        {
            return locationService.GetLastLocation(new Guid());
        }

        [WebInvoke(UriTemplate = "User", Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        public GpsUser InsertUser(string name)
        {
            GpsUser _newUser = new GpsUser(){ Name = name};
            return locationService.InsertUser(_newUser);
        }

        [WebInvoke(UriTemplate = "Location", Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        public void AddLocation(double latitude, double longitude, string session, string data)
        {
            locationService.AddLocation(
                new GpsLocation
                    {
                        Coordinates = new GpsPoint { Latitude = latitude, Longitude = longitude },
                        Data = (string)data,
                        SessionKey = new Guid(session)//ece4bad0-a40e-421c-b761-2d691982a128
                    });
        }

        [WebInvoke(UriTemplate = "Session", Method = "POST", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        public Guid AddSession(string session)
        {
            return locationService.AddSession(
                new GpsSession{
                    UserKey = new Guid(session)
                });
        }

        //[WebInvoke(UriTemplate = "GpsUser/{name}/{address}", Method = "POST")]
        //public GpsUser RegisterUserWithExtra(string name, string address)
        //{
        //    GpsUser _newUser = new GpsUser()
        //    {
        //        CreatedDate = DateTime.UtcNow,
        //        Name = name,
        //        Data = new BsonDocument("address", address).ToJson()
        //    };
        //    return locationService.RegisterUser(_newUser);
        //}

        ////[WebInvoke(UriTemplate = "{GpsUser}", Method = "PUT", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        ////public GpsUser Update(string id, GpsUser instance)
        ////{
        ////    // TODO: Update the given instance of GpsUser in the collection
        ////    throw new NotImplementedException();
        ////}

        //[WebInvoke(UriTemplate = "GpsUser/{id}", Method = "DELETE")]
        //public void Delete(string id)
        //{
        //    locationService.DeleteUser(new Guid(id));
        //}
    }

}
