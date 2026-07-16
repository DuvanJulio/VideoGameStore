using MediatR;
using VideoGameStore.Application.Context;
using VideoGameStore.Domain.Contracts.Repository;

namespace VideoGameStore.Application.Behaviors;

public class AuthorizationPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly ICurrentUser _currentUser;

    public AuthorizationPipelineBehavior(ICurrentUser currentUser)
    {
        _currentUser = currentUser;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (request is IAuthorizableRequest authRequest)
        {
            if (!_currentUser.IsAuthenticated)
                throw new UnauthorizedAccessException("Usuario no autenticado");

            if (_currentUser.Role != authRequest.RequiredRole || _currentUser.UserId != authRequest.RequiredUserId)
                throw new UnauthorizedAccessException("No tienes permisos para esta acción");
        }

        return await next();
    }
}