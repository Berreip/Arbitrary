using ArbitraryLib.Processors;

namespace ArbitraryLib
{
    /// <summary>
    /// Allow direct access for generatong value. If you want more configuration, use the ArbitratyPredefined.GetDefault to get a ArbitraryGeneratorBag and configure it
    /// </summary>
    public static class Arbitrary
    {
        private static readonly IArbitraryGeneratorBag _directDefaultGenerator = ArbitratyPredefined.GetDefault();
        
        /// <summary>
        /// Generate a new element of type T
        /// </summary>
        public static T GetNew<T>() => _directDefaultGenerator.GetNew<T>();

        /// <summary>
        /// Generate a new sequence of nbElementInRange T
        /// </summary>
        /// <param name="nbElementInRange">the number of element in the array</param>
        /// <returns>the array of generated T elements</returns>
        public static T[] GetNewRange<T>(int nbElementInRange) => _directDefaultGenerator.GetNewRange<T>(nbElementInRange);
    }
}