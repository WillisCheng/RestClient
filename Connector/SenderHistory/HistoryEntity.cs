using System;
using System.Collections.Generic;

namespace SenderHistory
{
    public class Collection
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public List<Guid> order { get; set; }
        public List<Folder> folders { get; set; }
        public long timestamp { get; set; }
        public bool synced { get; set; }
        public int remote_id { get; set; }
        public string owner { get; set; }
        public bool sharedWithTeam { get; set; }
        public bool subscribed { get; set; }
        public string remoteLink { get; set; }
        public bool publish { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public bool write { get; set; }
        public List<Request> requests { get; set; }
        public string lastUpdatedBy { get; set; }
        public int? lastRevision { get; set; }
        public string team { get; set; }
        public bool? shared { get; set; }
    }

    public class Folder
    {
        public string owner { get; set; }
        public string lastUpdatedBy { get; set; }
        public int lastRevision { get; set; }
        public string collection { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public List<Guid> order { get; set; }
        public string createdAt { get; set; }
        public string updatedAt { get; set; }
        public bool write { get; set; }
        public string collection_id { get; set; }
    }

    public class PathVariables
    {
    }

    public class HelperAttributes
    {
    }

    public class Request
    {
        public string owner { get; set; }
        public string lastUpdatedBy { get; set; }
        public int lastRevision { get; set; }
        public Folder folder { get; set; }
        public string collection { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string dataMode { get; set; }
        public string data { get; set; }
        public string descriptionFormat { get; set; }
        public string description { get; set; }
        public string headers { get; set; }
        public string method { get; set; }
        public PathVariables pathVariables { get; set; }
        public string url { get; set; }
        public string preRequestScript { get; set; }
        public string tests { get; set; }
        public string currentHelper { get; set; }
        public HelperAttributes helperAttributes { get; set; }
        public string createdAt { get; set; }
        public string updatedAt { get; set; }
        public string collectionId { get; set; }
        public bool write { get; set; }
    }

    public class Environment
    {
        public string id { get; set; }
        public string name { get; set; }
        public List<Value> values { get; set; }
        public string team { get; set; }
        public long timestamp { get; set; }
    }

    public class Value
    {
        public string key { get; set; }
        public string value { get; set; }
        public string type { get; set; }
        public bool enabled { get; set; }
    }

    public class History
    {
        public int version { get; set; }
        public List<Collection> collections { get; set; }
        public List<Environment> environments { get; set; }
        public List<object> headerPresets { get; set; }
        public List<object> globals { get; set; }
    }
}