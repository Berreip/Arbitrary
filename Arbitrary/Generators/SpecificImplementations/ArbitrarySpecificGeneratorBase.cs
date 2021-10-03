using System;

namespace ArbitraryLib.Generators.SpecificImplementations
{
    public abstract class ArbitrarySpecificGeneratorBase
    {
        protected readonly Random _rd = new Random();

        public abstract bool TryGetNew<T>(out T o);
    }
}