using Bug.FSM;
using Bug.Infrastructure;
using UnityEngine;

namespace Bug.Application
{
    public class BugController : IBugController
    {
        private readonly Domain.Bug Bug;
        private readonly BugFSM BugFSM;
        private readonly IBugView _bugView;
        private readonly IBugEventBus _eventBus;

        public BugController(Domain.Bug bug, BugFSM fsm, IBugView bugView, IBugEventBus eventBus)
        {
            Bug = bug;
            BugFSM = fsm;
            _bugView = bugView;
            _eventBus = eventBus;

            BugFSM.TargetPositionChanged += OnTargetPositionChanged;
            Bug.BugDied += OnBugDied;
        }

        public void Tick()
        {
            Bug.Tick();
            Bug.SetPosition(_bugView.GetPosition());
            BugFSM.Update();
        }

        public void ToggleAgent(bool state)
        {
            _bugView.ToggleAgent(state);
        }

        public void Spawn(Vector3 position)
        {
            _bugView.SetPosition(position);
            Bug.SetPosition(position);
        }

        private void OnTargetPositionChanged(Vector3 newPosition)
        {
            _bugView.SetTarget(newPosition);
        }

        private void OnBugDied()
        {
            _eventBus.RaiseDespawnBugRequested(Bug, _bugView);
        }

        public void Dispose()
        {
            BugFSM.TargetPositionChanged -= OnTargetPositionChanged;
            Bug.BugDied -= OnBugDied;
        }
    }
}