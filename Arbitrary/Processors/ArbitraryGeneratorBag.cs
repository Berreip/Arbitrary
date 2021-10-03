using System;
using System.Collections.Generic;
using ArbitraryLib.Generators;
using ArbitraryLib.Generators.SpecificImplementations;

namespace ArbitraryLib.Processors
{
    public interface IArbitraryGeneratorBag
    {
        /// <summary>
        /// Generate a new element of type T
        /// </summary>
        T GetNew<T>();

        /// <summary>
        /// Generate a new sequence of nbElementInRange T
        /// </summary>
        /// <param name="nbElementInRange">the number of element in the array</param>
        /// <returns>the array of generated T elements</returns>
        T[] GetNewRange<T>(int nbElementInRange);

        /// <summary>
        /// Register a type generator
        /// </summary>
        IArbitraryGeneratorBag RegisterGenerator<T>(ArbitraryGeneratorBase<T> generatorBase);

        /// <summary>
        /// register a mor specific generator that will be called if no type generator match (enums used this kind of generator)
        /// </summary>
        IArbitraryGeneratorBag RegisterSpecificGenerator(ArbitrarySpecificGeneratorBase specificGenerator);
    }

    // ReSharper disable once ClassCanBeSealed.Global
    // ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
    public class ArbitraryGeneratorBag : IArbitraryGeneratorBag
    {
        private readonly Dictionary<Type, IArbitraryGenerator> _registeredGeneratorByType = new Dictionary<Type, IArbitraryGenerator>();
        private readonly HashSet<ArbitrarySpecificGeneratorBase> _specificGenerators = new HashSet<ArbitrarySpecificGeneratorBase>();
        private readonly object _key = new object();

        /// <inheritdoc />
        public virtual T GetNew<T>()
        {
            lock (_key)
            {
                if (_registeredGeneratorByType.TryGetValue(typeof(T), out var generator))
                {
                    return ((ArbitraryGeneratorBase<T>)generator).GetNew();
                }
                // else, try to match a specific generator:
                foreach (var specificGenerator in _specificGenerators)
                {
                    if (specificGenerator.TryGetNew<T>(out var value))
                    {
                        return value;
                    }
                }
            }

            throw new InvalidOperationException($"the type {typeof(T)} has not been registered in the current ArbitraryProcessor. You have to register an {nameof(ArbitraryGeneratorBase<T>)} with the method {nameof(RegisterGenerator)} in order to be able to used this type for generation");
        }

        /// <inheritdoc />
        public T[] GetNewRange<T>(int nbElementInRange)
        {
            var array = new T[nbElementInRange];
            for (var i = 0; i < nbElementInRange; i++)
            {
                array[i] = GetNew<T>();
            }

            return array;
        }

        public virtual IArbitraryGeneratorBag RegisterGenerator<T>(ArbitraryGeneratorBase<T> generatorBase)
        {
            lock (_key)
            {
                if (_registeredGeneratorByType.ContainsKey(typeof(T)))
                {
                    // override:
                    _registeredGeneratorByType[typeof(T)] = generatorBase;
                }
                else
                {
                    _registeredGeneratorByType.Add(typeof(T), generatorBase);
                }
            }

            return this;
        }

        /// <inheritdoc />
        public IArbitraryGeneratorBag RegisterSpecificGenerator(ArbitrarySpecificGeneratorBase specificGenerator)
        {
            lock (_key)
            {
                _specificGenerators.Add(specificGenerator);
            }

            return this;
        }
    }
}