using System.Collections.Generic;

namespace Bug.FSM
{
    public enum BugStateType
    {
        Idle,
        Moving,
        Reproducing,
        Dying
    }

    public class BugFSM
    {
        private Domain.Bug _bug;
        private IBugState _currentState;

        private Dictionary<BugStateType, IBugState> _states;

        public BugFSM(Domain.Bug bug, Dictionary<BugStateType, IBugState> states)
        {
            _bug = bug;
            _states = states;
        }
        public void ChangeState(IBugState newState)
        {
            _currentState?.Exit(_bug);
            _currentState = newState;
            _currentState.Enter(_bug);
        }
    }
}