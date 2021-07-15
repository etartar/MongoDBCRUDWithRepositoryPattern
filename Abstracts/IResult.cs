namespace MongoDBCRUDWithRepositoryPattern.Abstracts
{
    public interface IResult
    {
        bool Success { get; }
        string Message { get; }
    }
}
