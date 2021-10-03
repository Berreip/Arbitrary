namespace ArbitraryLib.Generators.Implementations
{
    public sealed class StringGenerator : ArbitraryGeneratorBase<string>
    {
        private readonly CharGenerator _charGenerator = ArbitraryGeneratorPredefined.CharGenerator;
        private const int MAX_STRING_SIZE = 42;
        private const int MIN_STRING_SIZE = 5;
        
        /// <inheritdoc />
        public override string GetNew()
        {
            var stringSize = _rd.Next(MIN_STRING_SIZE, MAX_STRING_SIZE);
            var charArray = new char[stringSize];
            for (var i = 0; i < stringSize; i++)
            {
                charArray[i] = _charGenerator.GetNew();
            }
            return new string(charArray);
        }

    }
}