using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Collections.Generic;
using Utf8Json;
using Utf8Json.Resolvers;

namespace Helpers
{
    public static class TempDataExtension
    {
        public static void Set<T>(this ITempDataDictionary tempData, string key, T value)
        {
            JsonSerializer.SetDefaultResolver(StandardResolver.AllowPrivateCamelCase);
            tempData[key] = JsonSerializer.ToJsonString(value);
        }
        public static T Get<T>(this ITempDataDictionary tempData, string key)
        {
            tempData.TryGetValue(key, out object value);
            return value == null ? default : JsonSerializer.Deserialize<T>((string)value);
        }

        public static void AddMessage(this ITempDataDictionary tempData, string key, MessageType type, string message)
        {
            var current = tempData.Get<List<MessageData>>(key);
            if (current == default) current = new List<MessageData>();
            current.Add(new MessageData(type, message));
            tempData.Set(key, current);
        }

        public static List<MessageData> GetMessages(this ITempDataDictionary tempData, string key)
        {
            return tempData.Get<List<MessageData>>(key);
        }

        public enum MessageType
        {
            danger = 1,
            info,
            success,
            warning
        }

        public struct MessageData
        {

            public MessageType MessageType;
            public string MessageText;

            public MessageData(MessageType messageType, string messageText)
            {
                MessageType = messageType;
                MessageText = messageText;
            }
        }
    }
}
