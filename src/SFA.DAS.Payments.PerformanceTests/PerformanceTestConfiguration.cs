using System;
using Microsoft.Extensions.Configuration;

namespace SFA.DAS.Payments.PerformanceTests
{

    public class PerformanceTestConfiguration
    {
        public static IConfigurationBuilder ConfigBuilder;
        public static IConfigurationRoot Config;

        public PerformanceTestConfiguration(IConfigurationBuilder configBuilder)
        {
            ConfigBuilder = configBuilder;
            Config = ConfigBuilder.Build();
            
        }
        public string Environment => GetAppSetting("appsettings:Environment").Value;
        public string AcceptanceTestsEndpointName => GetAppSetting("appsettings:EndpointName").Value;
        public string StorageConnectionString => GetConnectionString("StorageConnectionString");
        public string ServiceBusConnectionString => GetConnectionString("ServiceBusConnectionString");
        public string DasServiceBusConnectionString => GetConnectionString("DASServiceBusConnectionString");
        public string PaymentsConnectionString => GetConnectionString("PaymentsConnectionString");
        public bool ValidateDcAndDasServices => bool.Parse(GetAppSetting("appsettings:ValidateDcAndDasServices").Value ?? "false");
        public TimeSpan TimeToWait => TimeSpan.Parse(GetAppSetting("appsettings:TimeToWait").Value ?? "00:00:30");
        public TimeSpan TimeToWaitForUnexpected => TimeSpan.Parse(GetAppSetting("appsettings:TimeToWaitForUnexpected").Value ?? "00:00:30");
        public TimeSpan TimeToPause => TimeSpan.Parse(Config.GetSection("appsettings:TimeToPause").Value ?? "00:00:05");
        public TimeSpan DefaultMessageTimeToLive => TimeSpan.Parse(GetAppSetting("appsettings:DefaultMessageTimeToLive").Value ?? "00:20:00");
        public IConfigurationSection GetAppSetting(string keyName) => Config.GetSection(keyName);
        public string GetConnectionString(string name) => Config.GetConnectionString(name) ?? throw new InvalidOperationException($"{name} not found in connection strings.");
    }
}
