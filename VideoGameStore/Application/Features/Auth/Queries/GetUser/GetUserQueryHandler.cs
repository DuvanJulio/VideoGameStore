using MediatR;
using VideoGameStore.Application.Context;
using VideoGameStore.Domain.Contracts.Repository;

namespace VideoGameStore.Application.Features.Auth.Queries.GetUser
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, GetUserQueryResponse>
    {
        private readonly ICurrentUser _currentUser;

        public GetUserQueryHandler(ICurrentUser currentUser)
        {
            _currentUser = currentUser;
        }

        public async Task<GetUserQueryResponse> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            if (!_currentUser.IsAuthenticated)
                throw new UnauthorizedAccessException("Usuario no autenticado");

            var user = await _currentUser.GetUserAsync();

            return new GetUserQueryResponse
            {
                Id = user!.Id,
                Name = user.Name,
                Email = user.Email,
                RoleId = user.IdRole
            };
        }
    }
}