using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adonis.ViewModels.Pagination
{
    public class Paged<T>
    {
        public Paged() { }

        public Paged(IEnumerable<T> data)
        {
            Data = data;
        }

        public IEnumerable<T> Data { get; set; }

        public int? PageNumber { get; set; }

        public int? PageSize { get; set; }

        public int? TotalRecords { get; set; }

        public string Next { get; set; }

        public string Previous { get; set; }
    }
}
