using System;
using UnityEngine;

namespace Food.Domain
{
    public interface IFood
    {
        Vector3 Position { get; }
        event Action FoodEaten;
        void Eat();
    }
}