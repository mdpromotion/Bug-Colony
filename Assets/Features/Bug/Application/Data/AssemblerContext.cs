using Bug.Domain;
using Bug.Infrastructure;
using UnityEngine;

namespace Bug.Application
{
    public readonly struct AssemblerContext
    {
        public BugType Type { get; } 
        public Vector3 Position { get; }
        public IBugView BugView { get; }
        public ISpawnBugUseCase SpawnBugUseCase { get; }

        public AssemblerContext(BugType type, Vector3 position, IBugView view, ISpawnBugUseCase spawnUseCase)
        {
            Type = type;
            Position = position;
            BugView = view;
            SpawnBugUseCase = spawnUseCase;
        }
    }
}