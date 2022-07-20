using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam1.Hubs.Helpers
#nullable disable
{
    public class ConnectionGroupMapping<T>
    {
        private readonly Dictionary<T, HashSet<string>> _connections = new Dictionary<T, HashSet<string>>();

        public int Count
        {
            get
            {
                return _connections.Count;
            }
        }

        public int GroupMemberCount(T key)
        {
            return _connections.FirstOrDefault(x=> x.Key.Equals(key)).Value.Count;
        }

        public int ConnectionCount()
        {
            int count = 0;
            foreach (var connect in _connections)
            {
                count += connect.Value.Count;
            }
            return count;
        }

        public void Add(T key, string connectionId)
        {
            lock (_connections)
            {
                HashSet<string> connections;
                if(!_connections.TryGetValue(key, out connections))
                {
                    connections = new HashSet<string>();
                    _connections.Add(key, connections); 
                }

                lock (connections)
                {
                    connections.Add(connectionId);
                }
            }
        }

        public IEnumerable<string> GetConnections(T key)
        {
            HashSet<string> connections;
            if(_connections.TryGetValue(key, out connections))
            {
                return connections;
            }
            return Enumerable.Empty<string>();  
        }

        public void Remove(T key, string connectionId)
        {
            lock (_connections)
            {
                HashSet<string> connections;
                if(!_connections.TryGetValue(key, out connections))
                {
                    return;
                }

                lock (connections)
                {
                    connections.Remove(connectionId);

                    if( connections.Count == 0)
                    {
                        _connections.Remove(key);
                    }
                }
            }
        }
    }
}
