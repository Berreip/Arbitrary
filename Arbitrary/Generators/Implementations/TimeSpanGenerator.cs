using System;

namespace ArbitraryLib.Generators.Implementations
{
    public sealed class TimeSpanGenerator : ArbitraryGeneratorBase<TimeSpan>
    {
        private static readonly int _timeSpanRange = (int)TimeSpan.FromDays(20).TotalMilliseconds;

        /// <inheritdoc />
        public override TimeSpan GetNew()
        {
            return TimeSpan.FromMilliseconds(_rd.Next(0, _timeSpanRange));
        }
    }
}