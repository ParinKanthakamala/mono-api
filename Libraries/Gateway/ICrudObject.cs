namespace Gateway
{
    public interface ICrudObject
    {
        object Create(DataMessage message);
        object Read(DataMessage message);
        object Update(DataMessage message);
        object Delete(DataMessage message);
    }
}