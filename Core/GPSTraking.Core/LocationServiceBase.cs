using System;
using System.Collections.Generic;
using Ketl.GpsTracking.Model;
using Ketl.GpsTracking.Core;

namespace Ketl.GpsTracking.Manager
{
    public abstract class LocationServiceBase
    {
        private readonly ILocationDataProvider dataProvider;

        private LocationServiceBase() { }

        public LocationServiceBase(ILocationDataProvider dataProvider)
        {
            this.dataProvider = dataProvider;
        }

        public virtual Guid AddSession(GpsSession session)
        {
            return dataProvider.AddSession(session);
        }

        //public override void EndSession(Guid sessionKey)
        //{
        //    throw new NotImplementedException();
        //}

        public virtual void AddLocation(GpsLocation location)
        {
            dataProvider.AddLocation(location);
        }

        public virtual void AddLocations(IList<GpsLocation> point)
        {
            throw new NotImplementedException();
        }

        public virtual GpsLocation GetLastLocation(Guid userKey)
        {
            return dataProvider.GetLastLocation(new Guid(), new TimeSpan());
        }

        public virtual GpsLocation GetLastLocation(Guid userKey, TimeSpan timeSpan, long limit = 1000)
        {
            throw new NotImplementedException();
        }

        public virtual IList<GpsSession> GetSessions(Guid userKey)
        {
            throw new NotImplementedException();
        }

        public virtual IList<GpsLocation> GetLocationsBySession(Guid sessionKey)
        {
            return dataProvider.GetLocationsBySession(sessionKey);
        }

        #region Users

        public virtual GpsUser InsertUser(GpsUser user)
        {
            return dataProvider.InsertUser(user);
        }

        public virtual void UpdateUser(GpsUser user)
        {
            dataProvider.UpdateUser(user);
        }

        public virtual GpsUser GetUser(string name)
        {
            return dataProvider.GetUser(name);
        }

        public virtual void DeleteUser(Guid id)
        {
            dataProvider.DeleteUser(id);
        }

        #endregion

    }
}
