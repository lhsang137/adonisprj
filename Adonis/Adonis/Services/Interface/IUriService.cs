using Adonis.ViewModels.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adonis.Services.Interface
{
    public interface IUriService
    {
        Uri GetAllPostUri(PaginationQuery pagination = null);
    }
}
