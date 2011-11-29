using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using GPSTraking.Core;

namespace LocationService
{
    public class Service : IService
    {
        private readonly ILocationService locationService;

        public Service()
        {
            locationService = LocationFactory.GetLocationService();
        }

        #region Implementation of IService

        public Guid StartSession(GPSSession session)
        {
            return  locationService.StartSession(session).Key;
        }

        public void EndSession(Guid sessionKey)
        {
            throw new NotImplementedException();
        }

        public void AddLocation(GPSPoint point)
        {
            throw new NotImplementedException();
        }

        public void AddLocations(IList<GPSPoint> point)
        {
            throw new NotImplementedException();
        }

        public GPSPoint GetLastLocation(Guid userKey)
        {
            throw new NotImplementedException();
        }

        public IList<GPSPoint> GetLastLocations(Guid userKey, TimeSpan timeSpan, long limit = 1000)
        {
            throw new NotImplementedException();
        }

        public IList<GPSSession> GetSessions(Guid userKey)
        {
            throw new NotImplementedException();
        }

        public IList<GPSPoint> GetSessionLocations(Guid sessionKey)
        {
            throw new NotImplementedException();
        }

        public GPSUser RegisterUser(GPSUser user)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
