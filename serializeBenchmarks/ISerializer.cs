namespace serializeBenchmarks
{
    public interface ISerializer
    {
        byte[] Serialize<T>(object obj);
        T Deserialize<T>(byte[] data);
    }
}
