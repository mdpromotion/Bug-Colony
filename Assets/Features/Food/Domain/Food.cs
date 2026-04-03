using System;
using UnityEngine;

namespace Food.Domain
{
    public class Food
    {
        public readonly Vector3 Position;

        public event Action FoodEaten;

        public Food(Vector3 position)
        {
            Position = position;
        }

        public void Eat()
        {
            FoodEaten?.Invoke();
        }
    }
}