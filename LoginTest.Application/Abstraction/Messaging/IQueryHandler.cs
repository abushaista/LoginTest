using System;
using LoginTest.Domain.Shared;
using MediatR;

namespace LoginTest.Application.Abstraction.Messaging;


public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
{
}


