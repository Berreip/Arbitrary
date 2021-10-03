namespace ArbitraryLib.Generators.Implementations
{
    public sealed class IntGenerator : ArbitraryGeneratorBase<int>
    {
        /// <inheritdoc />
        public override int GetNew()
        {
            return _rd.Next(int.MinValue, int.MaxValue);
        }
    }
}