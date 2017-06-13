using Newtonsoft.Json.Linq;
using System;
using Messaging.Extensions;

namespace Messaging.Messages
{
    public class Message
    {
        public string MessageType { get; set; }

        private object _body;

        public object Body
        {
            get { return _body; }
            set
            {
                //if deserializing, set the body as a typed object:
                var jBody = value as JObject;
                if (jBody != null)
                {
                    _body = jBody.ToObject(Type.GetType(MessageType));
                }
                else
                {
                    _body = value;
                    if (_body != null)
                    {
                        MessageType = _body.GetMessageType();
                    }
                }
            }
        }
        
    }
}
