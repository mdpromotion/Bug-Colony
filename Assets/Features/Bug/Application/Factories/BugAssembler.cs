using Bug.Application.Factories;

namespace Bug.Application
{
    public class BugAssembler : IBugAssembler
    {
        private readonly BugFSMFactory _bugFSMFactory;
        private readonly BugFactory _bugFactory;
        private readonly IBugEventBus _bugEventBus;

        public BugAssembler(BugFSMFactory bugFSMFactory, BugFactory bugFactory, IBugEventBus bugEventBus)
        {
            _bugFSMFactory = bugFSMFactory;
            _bugFactory = bugFactory;
            _bugEventBus = bugEventBus;
        }

        public AssemblerOutput CreateBug(AssemblerContext context)
        {
            var bug = _bugFactory.CreateBug(context.Type);
            var fsm = _bugFSMFactory.CreateBugFSM(bug);

            var controller = new BugController(bug, fsm, context.BugView, _bugEventBus);

            controller.Spawn(context.Position);
            controller.ToggleAgent(true);

            return new AssemblerOutput(bug, controller);
        }
    }
}