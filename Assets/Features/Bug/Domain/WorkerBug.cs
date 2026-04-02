using System;

namespace Bug.Domain
{
    public class WorkerBug : Bug
    {
        private int _foodCollected;

        public WorkerBug(Guid id, float health) : base(id, health) { }

        public override void Eat()
        {
            _foodCollected++;
        }
        public override bool CanReproduce()
        {
            return _foodCollected >= 2;
        }
    }
}