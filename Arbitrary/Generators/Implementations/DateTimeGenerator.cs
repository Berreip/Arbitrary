using System;

namespace ArbitraryLib.Generators.Implementations
{
    public sealed class DateTimeGenerator : ArbitraryGeneratorBase<DateTime>
    {
        private static readonly DateTime _minDate = new DateTime(DateTime.Now.Year-20, 1, 1);
        private static readonly int _daysSpan = (DateTime.Now.AddYears(20) - _minDate).Days;
        private static readonly int _dayInMilliseconds = (int)TimeSpan.FromDays(1).TotalMilliseconds;

        /// <inheritdoc />
        public override DateTime GetNew()
        {
            return _minDate
                .AddDays(_rd.Next(_daysSpan))
                .AddMilliseconds(_rd.Next(0, _dayInMilliseconds));
        }
    }
}