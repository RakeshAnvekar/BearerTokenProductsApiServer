namespace ProductsApi.Models.User;

public sealed class User:UserLogin
{
    public int? UserId { get; set; }
    public string? UserEmail { get; set; } = string.Empty;    
    public string? UserType { get; set; } = string.Empty;
}
