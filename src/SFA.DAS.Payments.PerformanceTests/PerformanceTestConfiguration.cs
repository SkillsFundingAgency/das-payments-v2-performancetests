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
        public string AcceptanceTestsEndpointName => GetAppSetting("EndpointName").Value;
        public string StorageConnectionString => GetConnectionString("StorageConnectionString");
        public string ServiceBusConnectionString => GetConnectionString("ServiceBusConnectionString");
        public string DasServiceBusConnectionString => GetConnectionString("DASServiceBusConnectionString");
        public string PaymentsConnectionString => GetConnectionString("PaymentsConnectionString");
        public bool ValidateDcAndDasServices => bool.Parse(GetAppSetting("ValidateDcAndDasServices").Value ?? "false");
        public TimeSpan TimeToWait => TimeSpan.Parse(GetAppSetting("TimeToWait").Value ?? "00:00:30");
        public TimeSpan TimeToWaitForUnexpected => TimeSpan.Parse(GetAppSetting("TimeToWaitForUnexpected").Value ?? "00:00:30");
        public TimeSpan TimeToPause => TimeSpan.Parse(Config.GetSection("TimeToPause").Value ?? "00:00:05");
        public TimeSpan DefaultMessageTimeToLive => TimeSpan.Parse(GetAppSetting("DefaultMessageTimeToLive").Value ?? "00:20:00");
        public IConfigurationSection GetAppSetting(string keyName) => Config.GetSection(keyName);
        public string GetConnectionString(string name) => Config.GetConnectionString(name) ?? throw new InvalidOperationException($"{name} not found in connection strings.");
    }
}
