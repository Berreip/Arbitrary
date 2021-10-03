namespace ArbitraryLib.Generators.Implementations
{
    public sealed class UintGenerator : ArbitraryGeneratorBase<uint>
    {
        /// <inheritdoc />
        public override uint GetNew()
        {
            return (uint)_rd.Next();
        }
    }
}