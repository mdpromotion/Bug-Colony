using Bug.Application;

namespace Bug.Infrastructure
{
    public interface IBugAIController
    {
        void RegisterController(Domain.Bug bug, IBugController controller);
        void UnregisterController(Domain.Bug bug);
    }
}