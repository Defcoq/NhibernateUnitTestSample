namespace Web.Models
{
    public class EmployeeSearchCriteriaViewModel
    {
        public string Name { get; set; }
        public int PageNumber { get; set; }
        public int RecordsPerPage { get; set; }
        public string SortOn { get; set; }
        public string SortOrder { get; set; }
    }
}