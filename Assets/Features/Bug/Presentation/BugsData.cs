using Bug.Domain;
using System.Collections.Generic;

namespace Bug.Presentation 
{
    public class BugsData
    {
        private readonly Dictionary<BugType, int> _bugDeaths = new();

        public void AddDeath(BugType bugType)
        {
            if (_bugDeaths.ContainsKey(bugType))
                _bugDeaths[bugType]++;
            else
                _bugDeaths[bugType] = 1;
        }
        public void SetDeathCount(BugType bugType, int count)
        {
            _bugDeaths[bugType] = count;
        }
        public int GetDeathCount(BugType bugType) => _bugDeaths.TryGetValue(bugType, out var count) ? count : 0;
    }
}