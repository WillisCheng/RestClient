using System;
using System.Collections.Generic;

namespace SenderHistory
{
    public class MessageCollection
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int DisplayOrder { get; set; }
        public List<MessageCollection> SubCollections { get; set; }
        public List<RequestMessage> RequestMessages { get; set; }
    }

    public class RequestMessage
    {
        public Guid id { get; set; }
        public string MessageName { get; set; }

        public string Description { get; set; }

        public string RequestBody { get; set; }

        public string RequestHeaders { get; set; }

        public string RequestMethod { get; set; }

        public string RequestUrl { get; set; }
    }

    public class ConnectEnvironment
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public List<ConnectSetting> values { get; set; }
    }

    public class ConnectSetting
    {
        public string key { get; set; }
        public string value { get; set; }

        //public string type { get; set; }
        public bool enabled { get; set; }
    }

    public class ConnectHistory
    {
        public List<MessageCollection> MessageGroups { get; set; }

        public List<ConnectEnvironment> ConnectEnvironments { get; set; }
    }
}