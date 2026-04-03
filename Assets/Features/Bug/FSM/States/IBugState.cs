namespace Bug.FSM
{
    public interface IBugState
    {
        void Enter(Domain.Bug bug);
        void Execute(Domain.Bug bug, BugFSM fsm);
        void Exit(Domain.Bug bug);
    }
}