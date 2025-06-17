using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_assignment_management.Application.Services
{
    public class ManagerConnectionService
    {
        private static readonly ConcurrentDictionary<string, HashSet<string>> _userConnections = new();

        public void AddConnection(string userId, string connectionId)
        {
            _userConnections.AddOrUpdate(userId,
                _ => new HashSet<string> { connectionId },
                (_, connections) =>
                {
                    connections.Add(connectionId);
                    return connections;
                });
        }

        public void RemoveConnection(string connectionId)
        {
            foreach (var (userId, connections) in _userConnections)
            {
                if (connections.Remove(connectionId) && connections.Count == 0)
                {
                    _userConnections.TryRemove(userId, out _);
                }
            }
        }
        public int GetUserOnline()
        {
            return _userConnections.Count; 
        }

        public IEnumerable<string> GetConnections(string userId)
        {
            return _userConnections.TryGetValue(userId, out var connections)
                ? connections
                : Enumerable.Empty<string>();
        }
    }
}
