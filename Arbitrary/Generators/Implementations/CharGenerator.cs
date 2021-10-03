namespace ArbitraryLib.Generators.Implementations
{
    public sealed class CharGenerator : ArbitraryGeneratorBase<char>
    {
        private static readonly char[] _allowedChars = "$%#@!*abcdefghijklmnopqrstuvwxyz1234567890?;:ABCDEFGHIJKLMNOPQRSTUVWXYZ^&".ToCharArray();

        /// <inheritdoc />
        public override char GetNew()
        {
            return _allowedChars[_rd.Next(0, _allowedChars.Length)];
        }
    }
}