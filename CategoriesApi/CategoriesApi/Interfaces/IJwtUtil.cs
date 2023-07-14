namespace CategoriesApi.Interfaces
{
    public interface IJwtUtil
    {
        string GenerateJwtToken(Guid id);

        Guid? ValidateJwtToken(string jwtToken);
    }
}
