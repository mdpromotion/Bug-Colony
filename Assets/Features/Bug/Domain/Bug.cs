using System;

namespace Bug.Domain
{
    public abstract class Bug
    {
        public Guid Id { get; }
        public float Health { get; }

        protected Bug(Guid id, float health)
        {
            Id = id;
            Health = health;
        }

        public abstract void Eat();
        public abstract bool CanReproduce();
    }
}