using Bug.Application.Factories;
using Bug.Domain;

namespace Bug.Application
{
    public class BugAssembler : IBugAssembler
    {
        private readonly BugFSMFactory _bugFSMFactory;
        private readonly BugFactory _bugFactory;

        public BugAssembler(BugFSMFactory bugFSMFactory, BugFactory bugFactory)
        {
            _bugFSMFactory = bugFSMFactory;
            _bugFactory = bugFactory;
        }

        public AssemblerOutput CreateBug(BugType type)
        {
            var bug = _bugFactory.CreateBug(type);
            _bugFSMFactory.CreateBugFSM(bug);
            return new AssemblerOutput();
        }
    }
}