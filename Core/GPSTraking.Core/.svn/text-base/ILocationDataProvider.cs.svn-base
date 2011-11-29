using System;
using System.Collections.Generic;
using Ketl.GpsTracking.Model;

namespace Ketl.GpsTracking.Core
{
    public interface ILocationDataProvider
    {
        Guid AddSession(GpsSession session);
        void UpdateSession(GpsSession session);
        IList<GpsSession> GetSessions(Guid userKey);

        void AddLocation(GpsLocation point);
        GpsLocation GetLastLocation(Guid userKey, TimeSpan timeSpan, long limit = 1000);
        IList<GpsLocation> GetLocationsBySession(Guid sessionKey);

        GpsUser InsertUser(GpsUser user);
        void UpdateUser(GpsUser user);
        void DeleteUser(Guid id);
        GpsUser GetUser(string name);
        
    }
}