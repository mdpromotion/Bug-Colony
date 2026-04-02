using System;

namespace Bug.Domain
{
    public class PredatorBug : Bug
    {
        private int _foodEaten;
        private float _lifeTime = 10f;

        public PredatorBug(Guid id, float health) : base(id, health) { }

        public override void Eat()
        {
            _foodEaten++;
        }

        public override bool CanReproduce()
        {
            return _foodEaten >= 3;
        }

        public bool IsDeadByTime(float deltaTime)
        {
            _lifeTime -= deltaTime;
            return _lifeTime <= 0;
        }
    }
}