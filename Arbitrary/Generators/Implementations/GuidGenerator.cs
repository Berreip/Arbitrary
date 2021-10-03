using System;

namespace ArbitraryLib.Generators.Implementations
{
    public sealed class GuidGenerator : ArbitraryGeneratorBase<Guid>
    {
        /// <inheritdoc />
        public override Guid GetNew()
        {
            return Guid.NewGuid();
        }
    }
}