using Bug.Domain;
using Bug.Infrastructure;

namespace Bug.Application.UseCases
{
    public class SpawnBugUseCase : ISpawnBugUseCase
    {
        private readonly IBugAssembler _bugAssembler;
        private readonly IColonyService _colonyService;

        public SpawnBugUseCase(IBugAssembler bugAssembler, IColonyService colonyService)
        {
            _bugAssembler = bugAssembler;
            _colonyService = colonyService;
        }

        public void SpawnBug(BugType type)
        {
            var assemblerOutput = _bugAssembler.CreateBug(type);
            _colonyService.AddBug(assemblerOutput.Bug);
        }

        public void DespawnBug(Domain.Bug bug) 
        {
            _colonyService.RemoveBug(bug);
        }
    }
}