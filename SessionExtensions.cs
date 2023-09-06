using ShoppingList.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;

namespace ShoppingList
{

        public static class SessionExtensions
        {
            public static void SetObject<T>(this ISession session, string key, T instance)
            {
                string data = JsonSerializer.Serialize<T>(instance);
                session.SetString(key, data);
            }

            public static T GetObject<T>(this ISession session, string key)
            {
                return JsonSerializer.Deserialize<T>(session.GetString(key));
            }
        }
    
}
