namespace ArbitraryLib.Generators.Implementations
{
    public sealed class FloatGenerator : ArbitraryGeneratorBase<float>
    {
        /// <inheritdoc />
        public override float GetNew()
        {
            return (float)(float.MaxValue * 2.0 * (_rd.NextDouble()-0.5));
        }
    }
}