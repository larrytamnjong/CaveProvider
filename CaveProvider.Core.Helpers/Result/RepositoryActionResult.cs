using CaveProvider.Core.Helpers.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaveProvider.Core.Helpers.Result
{
   
    public class RepositoryActionResult
    {
        public RepositoryActionResult(ResposityActionResultStatus status)
        {
            this.Status = status;
        }
        public RepositoryActionResult(ResposityActionResultStatus status, Exception e) : this(status)
        {
            this.Exception = e;
        }
        public ResposityActionResultStatus Status { get; set; }

        public Exception? Exception { get; set; }
    }

    public class RepositoryActionResult<T> : RepositoryActionResult where T : class
    {
        public T? Entity { get; private set; }

        public RepositoryActionResult(T? entity, ResposityActionResultStatus status) : base(status)
        {
            Entity = entity;
            Status = status;
        }

        public RepositoryActionResult(T? entity, ResposityActionResultStatus status, Exception? exception) : this(entity, status)
        {
            Exception = exception;
        }
    }

}
