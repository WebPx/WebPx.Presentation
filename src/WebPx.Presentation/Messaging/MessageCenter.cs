using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace WebPx.Messaging
{
    public static class MessageCenter
    {
        private static MessageSubscribers _channels = null;

        public static void Subscribe<T>(MessageEventHandler<T> messageEventHandler, string eventName = null)
        {
            var channelType = typeof(T);
            var channels = Subscriptions.Channels;
            Dictionary<string, object> channel = null;
            if (!channels.ContainsKey(channelType))
            {
                channel = new Dictionary<string, object>();
                channels.Add(channelType, channel);
            }
            else
                channel = channels[channelType];
            if (channel != null)
            {
                    if (!channel.ContainsKey(eventName))
                        channel.Add(eventName, new List<MessageEventHandler<T>>());
                    var subs = channel[eventName];
                    if (subs != null)
                    {
                        var subscribers = (List<MessageEventHandler<T>>)subs;
                        subscribers.Add(messageEventHandler);
                    }
            }
        }

        private static MessageSubscribers Subscriptions
        {
            get
            {
                var context = HttpContext.Current;
                if (context != null)
                {
                    var instance = context.Items["messageCenter"] as MessageSubscribers;
                    if (instance == null)
                    {
                        instance = new MessageSubscribers();
                        context.Items["messageCenter"] = instance;
                    }
                    return instance;
                }
                if (_channels == null)
                    _channels = new MessageSubscribers();
                return _channels;
            }
        }

        public static void SendMessage<T>(object sender, string eventName, T instance = default(T))
        {
            var channelType = typeof(T);
            var channels = Subscriptions.Channels;
            if (channels.ContainsKey(channelType))
            {
                var channel = channels[typeof(T)];
                MessageEventArgs<T> args = null;
                if (channel != null)
                {
                    var subs = channel[eventName];
                    if (subs!=null)
                    {
                        var subscribers = (List<MessageEventHandler<T>>)subs;
                        foreach (var subscriber in subscribers)
                        {
                            if (args == null)
                                args = new MessageEventArgs<T>(instance, eventName);
                            subscriber(sender, args);
                        }
                    }
                }
            }
        }

        public static bool OnSuccess<T>(bool result, object sender, string message)
        {
            if (result)
                SendMessage<T>(sender, message);
            return result;
        }
    }
}
