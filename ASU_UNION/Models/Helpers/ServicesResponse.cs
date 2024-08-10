namespace ASU_UNION.Models.Helpers
{
    public class ServicesResponse<T>
    {
        public string Message { get; set; }
        public bool Success {   get; set; }
        public T? Data { get; set; }
        public string Token { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount {  get; set; }
    }
}
