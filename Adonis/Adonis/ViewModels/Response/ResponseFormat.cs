using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adonis.ViewModels.Response
{
    public class ResponseFormat<T>
    {
        public ResponseFormat() { }

        public ResponseFormat(T response)
        {
            Data = response;
        }

        public T Data { get; set; }
    }
}
