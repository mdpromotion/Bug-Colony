using System;
using UnityEngine;

namespace Food.Domain
{
    public class Food : IFood
    {
        public Vector3 Position { get; }

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