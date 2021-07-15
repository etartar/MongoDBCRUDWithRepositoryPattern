namespace MongoDBCRUDWithRepositoryPattern.Abstracts
{
    public interface IDataResult<T> : IResult
    {
        T Data { get; }
    }
}
