namespace PPM.Model
{
    using System.Runtime.Serialization;
    public class YearValueException : Exception
    {
        public int InvalidYearValue { get; }

        public YearValueException(int invalidYearValue)
        {
            InvalidYearValue = invalidYearValue;
        }

        public YearValueException(int invalidYearValue, string message) : base(message)
        {
            InvalidYearValue = invalidYearValue;
        }

        public YearValueException(int invalidYearValue, string message, Exception innerException) : base(message, innerException)
        {
            InvalidYearValue = invalidYearValue;
        }

        protected YearValueException(int invalidYearValue, SerializationInfo info, StreamingContext context) : base(info, context)
        {
            InvalidYearValue = invalidYearValue;
        }

        public YearValueException(string? message) : base(message)
        {
        }
    }

    public class MonthValueException : Exception
    {
        public int InvalidMonthValue { get; }

        public MonthValueException(int invalidMonthValue)
        {
            InvalidMonthValue = invalidMonthValue;
        }

        public MonthValueException(int invalidMonthValue, string message) : base(message)
        {
            InvalidMonthValue = invalidMonthValue;
        }

        public MonthValueException(int invalidMonthValue, string message, Exception innerException) : base(message, innerException)
        {
            InvalidMonthValue = invalidMonthValue;
        }

        protected MonthValueException(int invalidMonthValue, SerializationInfo info, StreamingContext context) : base(info, context)
        {
            InvalidMonthValue = invalidMonthValue;
        }

        public MonthValueException(string? message) : base(message)
        {
        }
    }

    public class DayValueException : Exception
    {
        public int InvalidDayValue { get; }

        public DayValueException(int invalidDayValue)
        {
            InvalidDayValue = invalidDayValue;
        }

        public DayValueException(int invalidMonthValue, string message) : base(message)
        {
            InvalidDayValue = invalidMonthValue;
        }

        public DayValueException(int invalidDayValue, string message, Exception innerException) : base(message, innerException)
        {
            InvalidDayValue = invalidDayValue;
        }

        protected DayValueException(int invalidMonthValue, SerializationInfo info, StreamingContext context) : base(info, context)
        {
            InvalidDayValue = invalidMonthValue;
        }

        public DayValueException(string? message) : base(message)
        {
        }
    }
}