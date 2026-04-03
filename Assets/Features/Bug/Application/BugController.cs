using Bug.FSM;
using Bug.Infrastructure;

namespace Bug.Application
{
    public class BugController : IBugController
    {
        public readonly Domain.Bug Bug;
        public readonly BugFSM BugFSM;
        private readonly IBugMovementService _bugMovementService;

        public BugController(Domain.Bug bug, BugFSM fsm, IBugMovementService bugMovementService)
        {
            Bug = bug;
            BugFSM = fsm;
            _bugMovementService = bugMovementService;

            BugFSM.TargetPositionChanged += pos =>
            {
                _bugMovementService.SetTarget(pos);
            };

            
        }

        public void Tick()
        {
            Bug.SetPosition(_bugMovementService.GetPosition());
            BugFSM.Update();
        }
    }
}