namespace VisitorManagement.DTO
{
    public class PagingResponse<T> where T : class
    {
        public List<T> Data { get; set; }
        public int TotalRecords { get; set; }
        public int PageNo { get; set; }
        public int PageSize { get; set; }
    }
}
