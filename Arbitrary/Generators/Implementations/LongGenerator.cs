using System;

namespace ArbitraryLib.Generators.Implementations
{
    public sealed class LongGenerator : ArbitraryGeneratorBase<long>
    {
        /// <inheritdoc />
        public override long GetNew()
        {
            var buf = new byte[8];
            _rd.NextBytes(buf);
            var longRand = BitConverter.ToInt64(buf, 0);
            return longRand + long.MinValue;
        }
    }
}