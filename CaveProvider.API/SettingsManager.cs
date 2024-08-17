namespace CaveProvider.API
{
    static class SettingsManager
    {
        public static IConfiguration AppSetting
        {
            get;
        }
        static SettingsManager()
        {
            AppSetting = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
        }
    }



    public class JwtSettings
    {
        public const string SectionName = "JwtSettings";
        public string? Secret { get; init; }
        public int ExpiryMinutes { get; init; }
        public string? Issuer { get; set; }
        public string? Audience { get; set; }
    }
}
