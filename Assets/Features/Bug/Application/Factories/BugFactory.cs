using Bug.Domain;
using System;

namespace Bug.Application.Factories
{
    public class BugFactory
    {
        public Domain.Bug CreateBug(BugType type)
        {
            float lifeDuration = type switch
            {
                BugType.Worker => float.MaxValue,
                BugType.Predator => 100f, // 100 ticks = 10 seconds
                _ => throw new ArgumentOutOfRangeException(nameof(type), $"Not expected bug type value: {type}")
            };
            var bug = new Domain.Bug(type, lifeDuration);
            return bug;
        }
    }
}