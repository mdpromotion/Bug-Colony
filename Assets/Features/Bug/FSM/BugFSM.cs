using System.Collections.Generic;

namespace Bug.FSM
{
    public enum BugStateType
    {
        Idle,
        Moving,
        Reproducing
    }

    public class BugFSM
    {
        private Domain.Bug _bug;
        private IBugState _currentState;

        private readonly Dictionary<BugStateType, IBugState> _states = new();

        public BugFSM(Domain.Bug bug, Dictionary<BugStateType, IBugState> states)
        {
            _bug = bug;
            _states = states;
        }

        public void ChangeState(BugStateType newStateType)
        {
            if (!_states.TryGetValue(newStateType, out var newState))
                return;

            _currentState?.Exit(_bug);

            _currentState = newState;

            _currentState.Enter(_bug);
        }
    }
}