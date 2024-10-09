namespace PeopleManager.Configuration
{
    public class JwtSettings
    {
        public string Secret { get; set; } = null!;
        public TimeSpan ExpirationTimeSpan { get; set; }
    }
}
