using Microsoft.Extensions.Logging;
using Moq;
using ProductsApi.BusinessLogic;
using ProductsApi.BusinessLogic.Interfaces;
using ProductsApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unit_Test.Helpers;

namespace Unit_Test.Tests.ControllersTests;

public class UserControllerTests
{

    private readonly Mock<IUserLogic> _userLogic;
    private readonly UserController _userController;
    private readonly Mock<ILogger<UserController>> _logger;
    private readonly Mock<ITokenGenerator> _tokenGenerator;
    //IUserLogic userLogic, ILogger<UserController> logger, ITokenGenerator tokenGenerator
    public UserControllerTests()
    {
        _userLogic = new Mock<IUserLogic>();
        _logger = new Mock<ILogger<UserController>>();
        _tokenGenerator= new Mock<ITokenGenerator>();
        _userController = new UserController(_userLogic.Object,_logger.Object,_tokenGenerator.Object);
    }
    [Test]
    public async Task GetUserDetailsSuccessfullyRetrieved()
    {
        // Arrange
        DataHelper dataHelper = new DataHelper();
        _userLogic.Setup(user => user.GetAsync(dataHelper.userLogin,CancellationToken.None))
                      .ReturnsAsync(dataHelper.user);

        // Act
        var res = await _userController.Login(dataHelper.userLogin);

        // Assert
        Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(res);
    }
}
