namespace ArbitraryLib.Generators.Implementations
{
    public sealed class ByteGenerator : ArbitraryGeneratorBase<byte>
    {
        /// <inheritdoc />
        public override byte GetNew()
        {
            var b = new byte[1];
            _rd.NextBytes(b);
            return b[0];
        }
    }
}