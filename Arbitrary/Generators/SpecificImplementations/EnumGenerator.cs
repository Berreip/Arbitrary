using System;
using System.Collections.Generic;
using System.Linq;

namespace ArbitraryLib.Generators.SpecificImplementations
{
    public sealed class EnumGenerator : ArbitrarySpecificGeneratorBase
    {
        private readonly Dictionary<Type, IEnumCache> _enumCache = new Dictionary<Type, IEnumCache>();
        private readonly object _key = new object();

        /// <inheritdoc />
        public override bool TryGetNew<T>(out T newEnum)
        {
            if (typeof(T).IsEnum)
            {
                lock (_key)
                {
                    // if it is an enum, get all possible values and return one
                    if (_enumCache.TryGetValue(typeof(T), out var enumValues))
                    {
                        newEnum = enumValues.GetNext<T>();
                        return true;
                    }

                    // else, create a new cache element for further usage
                    var enumCache = new EnumCache<T>(_rd);
                    _enumCache.Add(typeof(T), enumCache);
                    newEnum = enumCache.GetNext<T>();
                    return true;
                }
            }

            newEnum = default;
            return false;
        }

        private interface IEnumCache
        {
            T GetNext<T>();
        }

        private sealed class EnumCache<T> : IEnumCache
        {
            private readonly Random _random;
            private readonly T[] _enumValues;

            public EnumCache(Random random)
            {
                _random = random;
                _enumValues = Enum.GetValues(typeof(T)).Cast<T>().ToArray();
            }

            /// <inheritdoc />
            public TTarget GetNext<TTarget>()
            {
                // use boxing... not good, but no enum constraint
                return (TTarget)(object)_enumValues[_random.Next(0, _enumValues.Length)];
            }
        }
    }
}