using System.Windows.Input;

namespace OrderService.CQRS
{
    public interface ICommand : ICommand<Unit>
    {
    }

    public interface ICommand<out TResponse> : IRequest<TResponse> 
    { 
    }
}
