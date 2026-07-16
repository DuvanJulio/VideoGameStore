using MediatR;

namespace VideoGameStore.Application.Features.Auth.Queries.GetUser
{
    public class GetUserQueryResponse
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public long RoleId { get; set; }
    }
}