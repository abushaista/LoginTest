using LoginTest.Domain.Shared;
using MediatR;
namespace LoginTest.Application.Abstraction.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}


