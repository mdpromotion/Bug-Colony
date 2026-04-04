#nullable enable
using Shared.Services;

namespace Bug.Infrastructure
{
    public class BugObjectFactory : IBugObjectFactory
    {
        private readonly IGameObjectService _gameObjectService;

        public BugObjectFactory(IGameObjectService gameObjectService)
        {
            _gameObjectService = gameObjectService;
        }

        public Result<IBugView> GetBugView()
        {
            var obj = _gameObjectService.GetObject(ObjectType.Bugs);
            if (obj == null)
                return Result<IBugView>.Failure("There's no free GameObjects to get.");

            if (!obj.TryGetComponent<IBugView>(out var movementService))
                return Result<IBugView>.Failure("Couldn't resolve BugView on GameObject.");

            return Result<IBugView>.Success(movementService);
        }

        public void ReturnBugView(IBugView bugView)
        {
            _gameObjectService.ReturnObject(bugView.GetGameObject());
        }
    }
}