using ProductsApi.BusinessLogic.Interfaces;
using ProductsApi.Models.User;
using ProductsApi.Repositories.Interfaces;

namespace ProductsApi.BusinessLogic;

public class UserLogic : IUserLogic
{
    private readonly IUserRepository _userRepository;
    public UserLogic(IUserRepository userRepository)
    {   
        _userRepository = userRepository;
    }
    public async Task<User?> GetAsync(UserLogin userLogin, CancellationToken cancellationToken)
    {
      
        return await _userRepository.GetUserAsync(userLogin, cancellationToken);
    }
}
