using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DocWorks.Common.SEDAEvents.Entities
{
    public class Entity
    {
        public enum EntityStatus
        {
            Active = 0,
            Disabled = 1,
            Restoring = 2,
            SendDisabled = 3,
            ReceiveDisabled = 4,
            Creating = 5,
            Deleting = 6,
            Renaming = 7,
            Unknown = 99, // 0x00000063
        }
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public EntityStatus Status { get; set; }

        [BsonDateTimeOptions(DateOnly = false, Kind = DateTimeKind.Local, Representation = BsonType.Int64)]
        public DateTime ModifiedDate { get; set; }

        [BsonDateTimeOptions(DateOnly = false, Kind = DateTimeKind.Local, Representation = BsonType.Int64)]
        public DateTime CreatedDate { get; set; }
    }
}