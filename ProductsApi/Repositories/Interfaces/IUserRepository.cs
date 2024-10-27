using ProductsApi.Models.User;

namespace ProductsApi.Repositories.Interfaces;

public interface IUserRepository
{
    Task<User?> GetUserAsync(UserLogin userLogin,CancellationToken cancellationToken);
}
