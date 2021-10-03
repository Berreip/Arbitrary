namespace ArbitraryLib.Generators.Implementations
{
    public sealed class DoubleGenerator : ArbitraryGeneratorBase<double>
    {
        /// <inheritdoc />
        public override double GetNew()
        {
            return (_rd.NextDouble() - 0.5) * double.MaxValue * 2;
        }
    }
}