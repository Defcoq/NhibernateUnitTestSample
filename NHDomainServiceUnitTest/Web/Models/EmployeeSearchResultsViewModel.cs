using System.Collections.Generic;

namespace Web.Models
{
    public class EmployeeSearchResultsViewModel
    {
        public int PageNumber { get; set; }
        public int TotalResults { get; set; }
        public int RecordsPerPage { get; set; }
        public string SortedOn { get; set; }
        public string SortOrder { get; set; }
        public List<EmployeeSearchResult> Results { get; set; }
    }
}