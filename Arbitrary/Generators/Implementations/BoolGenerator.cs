namespace ArbitraryLib.Generators.Implementations
{
    public sealed class BoolGenerator : ArbitraryGeneratorBase<bool>
    {
        /// <inheritdoc />
        public override bool GetNew()
        {
            return _rd.NextDouble() > 0.5;
        }
    }
}