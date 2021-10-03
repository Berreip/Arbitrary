using System;

namespace ArbitraryLib.Generators
{
    /// <summary>
    /// Generator for a specific type
    /// </summary>
    public interface IArbitraryGenerator
    {
    }

    /// <summary>
    /// Base class for Arbitrary generator.
    /// </summary>
    public abstract class ArbitraryGeneratorBase<T> : IArbitraryGenerator
    {
        protected readonly Random _rd = new Random();
        public abstract T GetNew();
    }
}