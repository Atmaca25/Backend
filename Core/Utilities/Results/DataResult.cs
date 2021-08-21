namespace Core.Utilities.Results
{
    public class DataResult<T> : IDataResult<T>
    {
        public DataResult(T data, string message, bool success)
        {
            Data = data;
            Message = message;
            Success = success;
        }
        public DataResult(T data, bool success)
        {
            Data = data;
            Success = success;
        }
        public T Data { get; }
        public string Message { get;  }
        public bool Success { get; }
    }
}
