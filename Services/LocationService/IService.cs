using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using GPSTraking.Core;

namespace LocationService
{    
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        Guid StartSession(GPSSession session);

        [OperationContract]
        void EndSession(Guid sessionKey);

        [OperationContract]
        void AddLocation(GPSPoint point);

        [OperationContract]
        void AddLocations(IList<GPSPoint> point);

        [OperationContract]
        GPSPoint GetLastLocation(Guid userKey);

        [OperationContract]
        IList<GPSPoint> GetLastLocations(Guid userKey, TimeSpan timeSpan, long limit = 1000);

        [OperationContract]
        IList<GPSSession> GetSessions(Guid userKey);

        [OperationContract]
        IList<GPSPoint> GetSessionLocations(Guid sessionKey);

        [OperationContract]
        GPSUser RegisterUser(GPSUser user);
    }
}
