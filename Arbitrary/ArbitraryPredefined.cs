using ArbitraryLib.Processors;

namespace ArbitraryLib
{
    /// <summary>
    /// Allow to retrieved a predefined arbitrary configuration
    /// </summary>
    public static class ArbitratyPredefined
    {
        /// <summary>
        /// Return the default configuration which already posess generator for default types
        /// </summary>
        public static IArbitraryGeneratorBag GetDefault()
        {
            return new ArbitraryGeneratorBag()
                .RegisterGenerator(ArbitraryGeneratorPredefined.IntGenerator)
                .RegisterGenerator(ArbitraryGeneratorPredefined.UintGenerator)
                .RegisterGenerator(ArbitraryGeneratorPredefined.FloatGenerator)
                .RegisterGenerator(ArbitraryGeneratorPredefined.LongGenerator)
                .RegisterGenerator(ArbitraryGeneratorPredefined.DoubleGenerator)
                .RegisterGenerator(ArbitraryGeneratorPredefined.CharGenerator)
                .RegisterGenerator(ArbitraryGeneratorPredefined.StringGenerator)
                .RegisterGenerator(ArbitraryGeneratorPredefined.ByteGenerator)
                .RegisterGenerator(ArbitraryGeneratorPredefined.BoolGenerator)
                .RegisterGenerator(ArbitraryGeneratorPredefined.DateTimeGenerator)
                .RegisterGenerator(ArbitraryGeneratorPredefined.TimeSpanGenerator)
                .RegisterGenerator(ArbitraryGeneratorPredefined.GuidGenerator)
                .RegisterSpecificGenerator(ArbitraryGeneratorPredefined.EnumGenerator);
        }

        /// <summary>
        /// Return an empty Configuration where you could add generator you wants
        /// </summary>
        public static IArbitraryGeneratorBag GetEmpty()
        {
            return new ArbitraryGeneratorBag();
        }
    }
}