using Bug.Domain;
using Bug.Infrastructure;
using UnityEngine;

namespace Bug.Application.UseCases
{
    public class SpawnBugUseCase
    {
        public static readonly string LogTag = nameof(SpawnBugUseCase);

        private readonly IBugAssembler _bugAssembler;
        private readonly IColonyService _colonyService;
        private readonly IBugAIController _bugAIController;
        private readonly IBugObjectFactory _objectFactory;

        private readonly ILogger _logger;

        public SpawnBugUseCase(
            IBugAssembler bugAssembler, 
            IColonyService colonyService, 
            IBugAIController bugAIController, 
            IBugObjectFactory objectFactory, 
            ILogger logger)
        {
            _bugAssembler = bugAssembler;
            _colonyService = colonyService;
            _bugAIController = bugAIController;
            _objectFactory = objectFactory;
            _logger = logger;
        }

        public void SpawnBug(BugType type, Vector3 position = default)
        {
            var bugViewResult = _objectFactory.GetBugView();
            if (!bugViewResult.IsSuccess)
            {
                _logger.LogError(LogTag, $"Failed to get bug view for type {type}: {bugViewResult.Error}");
                return;
            }

            var assemblerOutput = _bugAssembler.CreateBug(new AssemblerContext(type, position, bugViewResult.Value, this));
            _colonyService.AddBug(assemblerOutput.Bug);
            _bugAIController.RegisterController(assemblerOutput.Bug, assemblerOutput.Controller);
        }

        public void DespawnBug(Domain.Bug bug, IBugView bugView) 
        {
            _colonyService.RemoveBug(bug);
            _bugAIController.UnregisterController(bug);
            _objectFactory.ReturnBugView(bugView);
        }
    }
}