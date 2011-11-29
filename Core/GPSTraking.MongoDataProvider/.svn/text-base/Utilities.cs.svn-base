using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using MongoDB.Bson.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Options;
using MongoDB.Bson.Serialization.IdGenerators;
using Ketl.GpsTracking.Model;

namespace Ketl.GpsTracking.DataProvider
{
    static class Utilities
    {

        private const string extraData = "Data";

        /// <summary>
        /// Add extra data to doc (if objects has Data property)
        /// </summary>
        /// <param name="doc">BsonDocument where we need to add data</param>
        /// <param name="obj">object that should contains Data property</param>
        public static void AddExtraData(BsonDocument doc, object obj)
        {
            // get Data property
            PropertyInfo pi = obj.GetType().GetProperty(extraData);
            if (pi == null)
                return;
            if (pi.GetValue(obj, null) == null)
                return;
            // Convert extra Data string to BsonDocument and add it to the doc
            try
            {
                doc[extraData.ToLower()] = BsonSerializer.Deserialize<BsonDocument>((string)pi.GetValue(obj, null));
            }
            catch (Exception e)
            {
                doc[extraData.ToLower()] = new BsonDocument("error", e.Message);
            }
        }

        /// <summary>
        /// register class map for GpsData
        /// </summary>
        public static void RegisterGpsDataClass()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(GpsData)))
            {
                BsonClassMap.RegisterClassMap<GpsData>(cm =>
                {
                    cm.MapProperty(c => c.Key);
                    cm.MapProperty(c => c.CreatedDate).SetSerializationOptions(new DateTimeSerializationOptions(DateTimeKind.Utc, BsonType.DateTime));
                    cm.SetIdMember(cm.GetMemberMap(c => c.Key));
                    cm.IdMemberMap.SetIdGenerator(GuidGenerator.Instance);
                });
            }

        }

        /// <summary>
        /// constructs a GPSUser object from a generic BsonDocument
        /// </summary>
        /// <param name="usr">BsonDocument</param>
        /// <returns>GPSUser created</returns>
        public static GpsUser GetUserFromDoc(BsonDocument usr, bool includeExtraData)
        {
            GpsUser _user = new GpsUser();
            // set properties
            _user.CreatedDate = usr["CreatedDate"].AsDateTime;
            _user.Key = usr["_id"].AsGuid;
            _user.Name = usr["Name"].AsString;
            if (includeExtraData)
            {
                BsonValue ExtraDataValue;
                usr.TryGetValue(extraData.ToLower(), out ExtraDataValue);
                if (ExtraDataValue != null)
                    _user.Data = ExtraDataValue.AsBsonDocument.ToJson();
            }
            return _user;
        }

        /// <summary>
        /// constructs a GpsLocation object from a generic BsonDocument
        /// </summary>
        /// <param name="loc">BsonDocument</param>
        /// <returns>GpsLocation created</returns>
        public static GpsLocation GetLocationFromDoc(BsonDocument loc, bool includeExtraData)
        {
            GpsLocation _loc = new GpsLocation();
            // set properties
            _loc.CreatedDate = loc["CreatedDate"].AsDateTime;
            _loc.Key = loc["_id"].AsGuid;
            _loc.SessionKey = loc["SessionKey"].AsGuid;
            BsonDocument _coord = loc["Coordinates"].AsBsonDocument;
            _loc.Coordinates = new GpsPoint() { Latitude = _coord["Latitude"].AsDouble, Longitude = _coord["Longitude"].AsDouble };
            if (includeExtraData)
            {
                BsonValue ExtraDataValue;
                loc.TryGetValue(extraData.ToLower(), out ExtraDataValue);
                if (ExtraDataValue != null)
                    _loc.Data = ExtraDataValue.AsBsonDocument.ToJson();
            }
            return _loc;
        }
    }
}
