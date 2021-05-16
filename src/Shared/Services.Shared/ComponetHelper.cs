namespace Services.Shared
{
    public static class ComponetHelper
    {
        public static string PubSubName { get; } = System.Environment.GetEnvironmentVariable("PubSubName");
    }
}
