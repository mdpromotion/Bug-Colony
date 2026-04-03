using Food.Application;

namespace Food.Data
{
    public readonly struct FactoryOutput
    {
        public readonly Domain.Food Food { get; }
        public readonly FoodController Controller { get; }

        public FactoryOutput(Domain.Food food, FoodController controller)
        {
            Food = food;
            Controller = controller;
        }
    }
}