using VideoGameStore.Application.Context;
using VideoGameStore.Domain.Contracts.Repository;
using VideoGameStore.Domain.Entities;
using System.Security.Claims;

namespace VideoGameStore.Infrastructure.Context
{
    public class CurrentUser : ICurrentUser
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserRepository _userRepository;

        private UserEntity? _cachedUser;
        public CurrentUser(IHttpContextAccessor httpContextAccessor, IUserRepository userRepository)
        {
            _httpContextAccessor = httpContextAccessor;

            _userRepository = userRepository;
        }

        private ClaimsPrincipal? User =>
            _httpContextAccessor.HttpContext?.User;

        public bool IsAuthenticated =>
            User?.Identity?.IsAuthenticated ?? false;

        private long? _cacheUserId;

        public long? UserId
        {
            get
            {
                if (_cacheUserId.HasValue)
                    return _cacheUserId;

                if (!IsAuthenticated)
                    return null;

                var idClaim =
                    User?.FindFirst(ClaimTypes.NameIdentifier)?.Value
                    ?? User?.FindFirst("sub")?.Value;

                if (string.IsNullOrWhiteSpace(idClaim))
                    return null;

                if (!long.TryParse(idClaim, out var userId))
                    return null;

                _cacheUserId = userId;
                return userId;
            }
        }

        public string? Email =>
            User?.FindFirst(ClaimTypes.Email)?.Value;

        public string? Role =>
            User?.FindFirst(ClaimTypes.Role)?.Value;

        public async Task<UserEntity?> GetUserAsync()
        {
            if (!IsAuthenticated || UserId == null)
                return null;

            if (_cachedUser != null)
                return _cachedUser;

            _cachedUser = await _userRepository.GetByIdAsync(UserId.Value);
            return _cachedUser;
        }
    }
}