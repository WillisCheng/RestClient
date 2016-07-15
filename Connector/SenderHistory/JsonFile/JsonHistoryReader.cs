using Newtonsoft.Json;
using System.IO;
using System.Linq;

namespace SenderHistory.JsonFile
{
    public class JsonHistoryReader : IHistoryReader
    {
        private readonly string _historyFilePath;

        public JsonHistoryReader(string historyFilePath)
        {
            _historyFilePath = historyFilePath;
        }

        public ConnectHistory Load()
        {
            var history = LoadHistory();
            return new ConnectHistory
            {
                ConnectEnvironments = history.environments.Select(c => new ConnectEnvironment
                {
                    id = c.id,
                    name = c.name,
                    values = c.values.Select(v => new ConnectSetting
                    {
                        key = v.key,
                        value = v.value,
                        enabled = v.enabled
                    }).ToList()
                }).ToList(),
                MessageGroups = history.collections.Select(c => new MessageCollection
                {
                    ID = c.id,
                    Name = c.name,
                    Description = c.description,
                    RequestMessages = c.requests.Select(r => new RequestMessage
                    {
                        id = r.id,
                        Description = r.description,
                        MessageName = r.name,
                        RequestBody = r.data,
                        RequestHeaders = r.headers,
                        RequestMethod = r.method,
                        RequestUrl = r.url
                    }).ToList(),
                    SubCollections = c.folders.Select(f => new MessageCollection
                    {
                        ID = f.id,
                        Name = f.name,
                        Description = f.description,
                        //RequestMessages = f..Select(m=>new RequestMessage
                        //{
                        //    id = m.
                        //}).ToList()
                    }).ToList()
                }).ToList()
            };
        }

        public History LoadHistory()
        {
            var content = File.ReadAllText(_historyFilePath);
            return JsonConvert.DeserializeObject<History>(content);
        }
    }
}