using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ketl.GpsTracking.Core;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver.Builders;
using Ketl.GpsTracking.Model;

namespace Ketl.GpsTracking.DataProvider
{
    public class MongoDataProvider : ILocationDataProvider
    {

        #region Properties

        private MongoDatabase _db;
        public MongoDatabase DB
        {
            get
            {
                if (_db == null)
                    _db = MongoDatabase.Create(_connectionString);
                return _db;
            }
        }

        private string _connectionString;
        
        private const string _sessionColection = "sessions";
        private const string _userColection = "users";
        private const string _locationColection = "locations";
       

        #endregion

        #region Constructors

        public MongoDataProvider(string connectionString)
        {
            _connectionString = connectionString;
            Utilities.RegisterGpsDataClass();
        }

        #endregion

        #region Interface

        public Guid AddSession(GpsSession session)
        {
            // serialize location
            BsonDocument doc = session.ToBsonDocument();
            // Add extra data (in case we have)
           Utilities.AddExtraData(doc, session);
            // insert into database
            DB.GetCollection<BsonDocument>(_sessionColection).Insert<BsonDocument>(doc);
            return doc["_id"].AsGuid;
        }

        public void UpdateSession(GpsSession session)
        {
            DB.GetCollection<GpsSession>(_sessionColection).Save<GpsSession>(session);
        }

        public void AddLocation(GpsLocation location)
        {
            // serialize location
            BsonDocument doc = location.ToBsonDocument();
            // Add extra data (in case we have)
            Utilities.AddExtraData(doc, location);
            // insert into database
            DB.GetCollection<BsonDocument>(_locationColection).Insert<BsonDocument>(doc);
        }

        public GpsLocation GetLastLocation(Guid userKey, TimeSpan timeSpan, long limit = 1000)
        {
            // get Location collection
            MongoCollection collection = DB.GetCollection<BsonDocument>(_locationColection);
            //search
            BsonDocument doc = collection.FindOneAs<BsonDocument>();
            return Utilities.GetLocationFromDoc(doc, true);
        }

        public IList<GpsSession> GetSessions(Guid userKey)
        {
            //IMongoQuery query = new 
            //DB.GetCollection<GPSSession>(_sessionColection).Find();
            throw new NotImplementedException();
        }

        public IList<GpsLocation> GetLocationsBySession(Guid sessionKey)
        {
            List<GpsLocation> track = new List<GpsLocation>();
            // get Location collection
            MongoCollection collection = DB.GetCollection<BsonDocument>(_locationColection);
            //search
            MongoCursor<BsonDocument> docs = collection.FindAs<BsonDocument>(Query.EQ("SessionKey", BsonValue.Create(sessionKey)));
            foreach (BsonDocument doc in docs)
	        {
		        //GpsLocation point = new GpsLocation();
                track.Add(Utilities.GetLocationFromDoc(doc, true));
	        }
            // get the user
            return track;
        }

        //public IList<GPSUser> GetUsers()
        //{
        //    RegisterGpsUserClass();

        //    List<GPSUser> ret = new List<GPSUser>();

        //    MongoCollection collection = DB.GetCollection<BsonDocument>(_userColection);
        //    foreach (BsonDocument usr in collection.FindAllAs<BsonDocument>())
        //    {
        //        ret.Add(GetUserFromDoc(usr, true));
        //    }
        //    return ret;
        //}

        /// <summary>
        /// Register/insert a new user into database
        /// </summary>
        /// <param name="user">User object</param>
        /// <returns>User object</returns>
        public GpsUser InsertUser(GpsUser user)
        {
            // serialize the user
            BsonDocument doc = user.ToBsonDocument();
            // Add extra data (in case we have)
            Utilities.AddExtraData(doc, user);
            // add into user colection inside database
            DB.GetCollection<BsonDocument>(_userColection).Insert<BsonDocument>(doc);
            
            return user;
        }

        /// <summary>
        /// Update the user
        /// </summary>
        /// <param name="user">GPSUser object</param>
        public void UpdateUser(GpsUser user)
        {
            // serialize the user
            BsonDocument doc = user.ToBsonDocument();
            // Add extra data (in case we have)
            Utilities.AddExtraData(doc, user);
            // save user
            DB.GetCollection<BsonDocument>(_userColection).Save<BsonDocument>(doc);
        }

        /// <summary>
        /// Deletes a GPSUser from database
        /// </summary>
        /// <param name="id">the id of the user</param>
        public void DeleteUser(Guid id)
        {
            // get users collection
            MongoCollection collection = DB.GetCollection<BsonDocument>(_userColection);
            // Delete
            collection.FindAndRemove(Query.EQ("_id", id), SortBy.Ascending("Name"));
        }

        /// <summary>
        /// Get a GPSUser object from database
        /// </summary>
        /// <param name="name">the name of the user</param>
        /// <returns>GPSUser object</returns>
        public GpsUser GetUser(string name)
        {
            // get users collection
            MongoCollection collection = DB.GetCollection<BsonDocument>(_userColection);
            //search
            BsonDocument doc = collection.FindOneAs<BsonDocument>(Query.EQ("Name", name));
            // get the user
            return Utilities.GetUserFromDoc(doc, true);
        }
        
        #endregion
    }
}
