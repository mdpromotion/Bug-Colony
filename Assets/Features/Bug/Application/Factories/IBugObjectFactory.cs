#nullable enable
namespace Bug.Infrastructure
{
    public interface IBugObjectFactory
    {
        Result<IBugView> GetBugView();
        void ReturnBugView(IBugView bugView);
    }
}