using Microsoft.Data.SqlClient;
using NTQ.Sdk.Core.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace HomeTravelAPI.ViewModels
{
    public class PagingViewModel : SortModel
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
