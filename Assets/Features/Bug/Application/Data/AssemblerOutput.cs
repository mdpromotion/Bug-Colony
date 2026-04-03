using Bug.FSM;

namespace Bug.Application
{
    public readonly struct AssemblerOutput
    {
        public Domain.Bug Bug { get; }
        public BugFSM BugFSM { get; }
    }
}