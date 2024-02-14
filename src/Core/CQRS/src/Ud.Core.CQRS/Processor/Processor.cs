using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ud.Core.CQRS.Abstractions.Command;
using Ud.Core.CQRS.Abstractions.Processor;
using Ud.Core.CQRS.Abstractions.Query;

namespace Ud.Core.CQRS.Processor
{
    public class Processor(IMediator _mediator) : IProcessor
    {
        public async Task<T> ProcessAsync<T>(ICommand<T> request, CancellationToken cancellationToken)
        {
            return await _mediator.Send(request, cancellationToken);
        }

        public async Task<T> ProcessAsync<T>(IQuery<T> request, CancellationToken cancellationToken)
        {
            return await _mediator.Send(request, cancellationToken);
        }
    }
}
