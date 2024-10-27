﻿using ProductsApi.DBExecutor.Interfaces;
using ProductsApi.Mappers.Interfaces;
using ProductsApi.Models.User;
using ProductsApi.Repositories.Interfaces;
using System.Data;

namespace ProductsApi.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IDbExecutor _dbExecutor;
    private readonly IUserMapper _userMapper;
    public UserRepository(IDbExecutor dbExecutor, IUserMapper userMapper)
    {
        _dbExecutor = dbExecutor;
        _userMapper = userMapper;
        
    }
    public async Task<User?> GetUserAsync(UserLogin userLogin, CancellationToken cancellationToken)
    {
        var inputParams = new Dictionary<string, object>()
        {
            {"@UserName",userLogin.UserName },
            {"@Password" ,userLogin.UserPassword}
        };
      var UserDetails = await _dbExecutor.ExecuteAsync(DbConstants.Usp_GetUserDetails, CommandType.StoredProcedure, _userMapper.MapUser, cancellationToken, inputParams);
       return UserDetails;
    }
}