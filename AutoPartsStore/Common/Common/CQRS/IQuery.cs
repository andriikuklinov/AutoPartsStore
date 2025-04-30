using MediatR;

namespace Common.CQRS
{
    public interface IQuery<out T>: IRequest<T> where T : notnull
    {
    }
}
