using System;
using UnityEngine;

namespace Bug.Domain
{
    public class Bug
    {
        public Vector3 Position { get; private set; } // If this was production code, I would make a special value-object for this, but for the sake of this demo, I think it's fine.
        public int FoodEaten { get; private set; }
        public BugType Type { get; private set; }

        public event Action BugDied;

        public Bug(BugType type)
        {
            Type = type;
        }

        public void SetPosition(Vector3 position)
        {
            Position = position;
        }

        public void AddFood(int food)
        {
            if (food <= 0)
                return;

            FoodEaten += food;
        }
        public void SetFood(int food)
        {
            FoodEaten = food;
        }
    }
}