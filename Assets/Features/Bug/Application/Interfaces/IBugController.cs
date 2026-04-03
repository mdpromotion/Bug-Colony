namespace Bug.Application
{
    public interface IBugController
    {
        void SetTarget();
        void ToggleAgent(bool isActive);
    }
}