using Moq;
using ProductsApi.BusinessLogic;
using ProductsApi.Repositories.Interfaces;
using Unit_Test.Helpers;

namespace Unit_Test.Tests.BusinessLogicTests;


public sealed class UserLogicTests
{
    private readonly Mock<IUserRepository> _mockedUserRepository;
    private readonly UserLogic _userLogic;
    public UserLogicTests()
    {
        _mockedUserRepository = new Mock<IUserRepository>();
        _userLogic = new UserLogic(_mockedUserRepository.Object);
    }
    [Test]
    public  async Task GetAsync_Returns_User_Sucessfully()
    {
        DataHelper dataHelper = new DataHelper();
        _mockedUserRepository.Setup(repo => repo.GetUserAsync(dataHelper.userLogin, CancellationToken.None)).ReturnsAsync(dataHelper.user);
        var result = await _userLogic.GetAsync(dataHelper.userLogin, CancellationToken.None);
        Assert.IsNotNull(result);
        
    }
}
