using ArbitraryLib.Generators.Implementations;
using ArbitraryLib.Generators.SpecificImplementations;

namespace ArbitraryLib
{
    /// <summary>
    /// All default generators that are included int this library and that could be registered into an arbitrary
    /// </summary>
    public static class ArbitraryGeneratorPredefined
    {
        /// <summary>
        /// Returns a new int Generator
        /// </summary>
        public static IntGenerator IntGenerator => new IntGenerator();
        public static UintGenerator UintGenerator  => new UintGenerator();
        public static FloatGenerator FloatGenerator  => new FloatGenerator();
        public static LongGenerator LongGenerator  => new LongGenerator();
        public static DoubleGenerator DoubleGenerator  => new DoubleGenerator();
        public static CharGenerator CharGenerator  => new CharGenerator();
        public static StringGenerator StringGenerator  => new StringGenerator();
        public static ByteGenerator ByteGenerator  => new ByteGenerator();
        public static BoolGenerator BoolGenerator  => new BoolGenerator();
        public static DateTimeGenerator DateTimeGenerator  => new DateTimeGenerator();
        public static TimeSpanGenerator TimeSpanGenerator  => new TimeSpanGenerator();
        public static GuidGenerator GuidGenerator  => new GuidGenerator();
        public static EnumGenerator EnumGenerator  => new EnumGenerator();
    }
}