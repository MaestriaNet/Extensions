﻿using System.Collections.Generic;

namespace Maestria.Extensions
{

    public static partial class MaestriaExtensions
    {

        /// <summary>
        /// Tentar obter valor da chave, caso não exista retornar o valor default indicado em <paramref name="default"/>
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <param name="default"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        public static TValue TryGetValue<TKey, TValue>(this IDictionary<TKey, TValue> dictionary,
            TKey key, TValue @default = default) =>
            dictionary != null && dictionary.TryGetValue(key, out var value)
                ? value
                : @default;
    }
}
