namespace Actinver.API.Dto
{
    public class ResultApi<T>
    {
        public T Response { get; set; }
        public ResultApiError Error { get; set; } = new ResultApiError();
        public string TimeExecution { set; get; } = string.Empty;
    }

    public class ResultApiError
    {
        public string Message { get; set; } = string.Empty;
        public string Detail { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
    }
}
