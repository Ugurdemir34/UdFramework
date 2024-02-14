using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ud.Core.CQRS.Abstractions.Command;
using Ud.Core.CQRS.Abstractions.Query;

namespace Ud.Core.CQRS.Abstractions.Processor
{
    public interface IProcessor
    {
        Task<T> ProcessAsync<T>(ICommand<T> request, CancellationToken cancellationToken);
        Task<T> ProcessAsync<T>(IQuery<T> request, CancellationToken cancellationToken);
    }
}
