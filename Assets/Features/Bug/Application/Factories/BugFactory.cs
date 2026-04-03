using Bug.Domain;

namespace Bug.Application.Factories
{
    public class BugFactory
    {
        public Domain.Bug CreateBug(BugType type)
        {
            var bug = new Domain.Bug(type);
            return null;
        }
    }
}