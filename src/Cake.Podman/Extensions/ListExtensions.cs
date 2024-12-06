using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cake.Podman.Extensions
{
    /// <summary>
    /// Extension for List class
    /// </summary>
    public static class ListExtensions
    {
        /// <summary>
        /// Add an item to the list
        /// </summary>
        /// <typeparam name="T">The type</typeparam>
        /// <param name="list">The list extension</param>
        /// <param name="item">The item</param>
        /// <returns>return itself</returns>
        public static List<T> Add<T>(this List<T> list, T? item) where T : class
        {
            if (item != null)
                list.Add(item);
            return list;
        }

        /// <summary>
        /// Add an item with quote to the list
        /// </summary>
        /// <param name="list">The list extension</param>
        /// <param name="item">The item</param>
        /// <returns>return itself</returns>
        public static List<string> AddQuoted(this List<string> list, string item)
        {
            if (!string.IsNullOrEmpty(item))
                list.Add("\"" + item + "\"");            
            return list;
        }

        /// <summary>
        /// Add a range to the list
        /// </summary>
        /// <typeparam name="T">The type</typeparam>
        /// <param name="list">The list extension</param>
        /// <param name="items">The items</param>
        /// <returns>return itself</returns>
        public static List<T> AddRange<T>(this List<T> list, T[] items) where T : class
        {
            list.AddRange(items);
            return list;
        }

        /// <summary>
        /// Add an item to the list according the condition
        /// </summary>
        /// <typeparam name="T">The type</typeparam>
        /// <param name="list">The list extension</param>
        /// <param name="condition">The condition to add</param>
        /// <param name="item">The item</param>
        /// <returns>return itself</returns>
        public static List<T> AddIf<T>(this List<T> list, Predicate<bool> condition, T item) where T : class 
        {
            if(condition.Invoke(true)) 
                list.Add(item);
            return list;
        }

        /// <summary>
        /// Add a range to the list according the condition
        /// </summary>
        /// <typeparam name="T">The type</typeparam>
        /// <param name="list">The list extension</param>
        /// <param name="condition">The condition to add</param>
        /// <param name="items">The items</param>
        /// <returns>return itself</returns>
        public static List<T> AddRangeIf<T>(this List<T> list, Predicate<bool> condition, T[] items) where T : class 
        {
            if(condition.Invoke(true)) 
                list.AddRange(items);
            return list;
        }
    }
}