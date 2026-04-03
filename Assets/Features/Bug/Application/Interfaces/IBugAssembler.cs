using Bug.Domain;

namespace Bug.Application
{
    public interface IBugAssembler
    {
        AssemblerOutput CreateBug(BugType type);
    }
}