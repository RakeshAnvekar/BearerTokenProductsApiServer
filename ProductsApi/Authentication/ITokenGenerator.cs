using Microsoft.AspNetCore.Mvc;
using ProductsApi.Models.User;

namespace ProductsApi.BusinessLogic.Interfaces;

public interface ITokenGenerator
{
    Task<string?> GenerateTokenAsync(User user,CancellationToken cancellationToken);
}
