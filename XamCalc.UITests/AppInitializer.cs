using Xamarin.UITest;
using Xamarin.UITest.Configuration;

namespace XamCalc.UITests
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            if (platform == Platform.Android)
            {
                return ConfigureApp
                    .Android
                    .InstalledApp("somostechies.calc")
                    .StartApp(AppDataMode.Clear);
            }

            return ConfigureApp
                .iOS
                .InstalledApp("somostechies.calc")
                .StartApp(AppDataMode.Clear); ;
        }
    }
}

