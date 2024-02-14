using MediatR;

namespace Ud.Core.CQRS.Abstractions.Command
{
    public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, TResponse>
                                                              where TCommand : ICommand<TResponse>
    {

    }
}
