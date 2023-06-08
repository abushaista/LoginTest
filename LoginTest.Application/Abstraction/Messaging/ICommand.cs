using System;
using LoginTest.Domain.Shared;
using MediatR;

namespace LoginTest.Application.Abstraction.Messaging;

public interface ICommand : IRequest<Result>
{
}

public interface ICommand<TResponse> : IRequest<Result<TResponse>> { }


