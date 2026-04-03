using Bug.Domain;

namespace Bug.Application
{
    public interface ISpawnBugUseCase
    {
        void SpawnBug(BugType type);
        void DespawnBug(Domain.Bug bug);
    }
}