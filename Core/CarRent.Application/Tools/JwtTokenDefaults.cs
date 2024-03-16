namespace CarRent.Application.Tools
{
    public class JwtTokenDefaults
    {
        public const string ValidAudience = "https://localhost";
        public const string ValidIssuer = "https://localhost";
        public const string Key = "CarRent+*010203CARRENT+*..020304CarRentProje";
        public const int Expire = 5;
    }
}
