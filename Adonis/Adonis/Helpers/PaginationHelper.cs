using Adonis.Services.Interface;
using Adonis.ViewModels.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adonis.Helpers
{
    public class PaginationHelper
    {
        public static Paged<T> CreatePaginationResponse<T>(IUriService _uriService, PaginationQuery pagination, List<T> response)
        {
            var nextPage = pagination.PageNumber >= 1 ?
               _uriService.GetAllPostUri(new PaginationQuery( pagination.PageNumber + 1, pagination.PageSize)).ToString() : null;

            var previousPage = pagination.PageNumber - 1 >= 1 ?
                _uriService.GetAllPostUri(new PaginationQuery( pagination.PageNumber - 1, pagination.PageSize)).ToString() : null;

            return new Paged<T>()
            {
                Data = response,
                PageNumber = pagination.PageSize >= 1 ? pagination.PageNumber : (int?)null,
                PageSize = pagination.PageSize >= 1 ? pagination.PageSize : (int?)null,
                TotalRecords = response.Count(),
                Next = response.Any() ? nextPage : null,
                Previous = previousPage
            };
        }
    }
}
