namespace Bug.Application
{
    public interface IBugAssembler
    {
        AssemblerOutput CreateBug(AssemblerContext context);
    }
}