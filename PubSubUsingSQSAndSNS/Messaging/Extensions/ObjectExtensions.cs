namespace Messaging.Extensions
{
    public static class ObjectExtensions
    {
        public static string GetMessageType(this object obj)
        {
            return obj.GetType().ToString();
        }
    }
}
