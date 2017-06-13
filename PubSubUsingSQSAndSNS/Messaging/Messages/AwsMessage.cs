using Newtonsoft.Json;

namespace Messaging.Messages
{
    public class AwsMessage
    {
        public static Message Unwrap(string raw)
        {
            var message = JsonConvert.DeserializeObject<Message>(raw);
            return message;
        }

        public static string Wrap(Message message)
        {
            return JsonConvert.SerializeObject(message);
        }
    }
}
