using Bug.FSM;

namespace Bug.Application
{
    public readonly struct AssemblerOutput
    {
        public Domain.Bug Bug { get; }
        public BugController Controller { get; }

        public AssemblerOutput(Domain.Bug bug, BugController controller)
        {
            Bug = bug;
            Controller = controller;
        }
    }
}