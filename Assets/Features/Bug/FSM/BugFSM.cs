using System;
using System.Collections.Generic;
using UnityEngine;

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
        private readonly Domain.Bug _bug;
        private IBugState _currentState;

        public event Action<Vector3> TargetPositionChanged;

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

        public void NotifyTargetPositionChanged(Vector3 newPosition)
        {
            if (newPosition == null)
                return;

            TargetPositionChanged?.Invoke(newPosition);
        }

        public void Update()
        {
            _currentState?.Execute(_bug, this);
        }
    }
}