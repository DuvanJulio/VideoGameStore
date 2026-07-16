# Restringir InsertGame solo para Admin (Id = 1)

## Opción 1: Validación en el Handler (recomendada)

Usa `ICurrentUser` ya disponible y verifica al inicio del `Handle`:

```csharp
public class InsertGameCommandHandler : IRequestHandler<InsertGameCommand, bool>
{
    private readonly IUnitOfWork _uniOfWork;
    private readonly ICurrentUser _currentUser;

    public InsertGameCommandHandler(IUnitOfWork unitOfWork, ICurrentUser currentUser)
    {
        _uniOfWork = unitOfWork;
        _currentUser = currentUser;
    }

    public async Task<bool> Handle(InsertGameCommand request, CancellationToken cancellationToken)
    {
        if (!_currentUser.IsAuthenticated)
            throw new UnauthorizedAccessException("Usuario no autenticado");

        if (_currentUser.Role != "Admin" || _currentUser.UserId != 1)
            throw new UnauthorizedAccessException("Solo el Admin con Id = 1 puede insertar juegos");

        var game = new GameEntity
        {
            Name = request.Name,
            Description = request.Description
        };

        await _uniOfWork.GameRepository.AddAsync(game);
        await _uniOfWork.SaveChangeAsync(cancellationToken);

        return true;
    }
}
```

**Requisitos:** Inyectar `ICurrentUser` en el handler (ya registrado en DI).

---

## Opción 2: Authorize Attribute en el Controller

Agrega esto en `GameController.cs`:

```csharp
using Microsoft.AspNetCore.Authorization;

[HttpPost]
[Authorize(Roles = "Admin")]
public async Task<ActionResult<Success<bool>>> InsertGame(
    [FromBody] InsertGameCommand command,
    CancellationToken cancellationToken)
{
    var user = HttpContext.User;
    var userIdClaim = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;

    if (userIdClaim != "1")
        return Forbid();

    var result = await _mediator.Send(command, cancellationToken);
    return Ok(Success<bool>.Create(data: result));
}
```

**Requisitos:** Configurar `AddAuthentication` + `AddAuthorization` en Program.cs.

---

## Opción 3: Pipeline Behavior de Autorización (más escalable)

Crea un behavior similar al `ValidationPipelineBehavior` existente:

```csharp
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
```

Luego creas una interfaz `IAuthorizableRequest` y la implementas en `InsertGameCommand`.

---

## Resumen

| Opción | Complejidad | Reutilizable | Recomendación |
|--------|------------|--------------|---------------|
| Handler | Baja | No | ✅ Para un solo comando |
| Controller | Baja | No | Si usas Authorize nativo |
| Pipeline | Media | Sí | Si se aplicará a varios comandos |

La **Opción 1** es la más simple y directa para tu caso: solo inyectas `ICurrentUser` y agregas 2 validaciones al inicio del handler.
