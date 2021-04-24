namespace IfProperty
{
    //Use a class instead of an enum allows to add custom operators and expressions
    public static class IsOperatorEnumeration
    {
        public const string EqualTo = nameof(EqualTo);
        public const string NotEqualTo = nameof(NotEqualTo);
        public const string GreaterThan = nameof(GreaterThan);
        public const string LessThan = nameof(LessThan);
        public const string GreaterThanOrEqualTo = nameof(GreaterThanOrEqualTo);
        public const string LessThanOrEqualTo = nameof(LessThanOrEqualTo);
        public const string RegExMatch = nameof(RegExMatch);
        public const string NotRegExMatch = nameof(NotRegExMatch);
        public const string In = nameof(In);
        public const string NotIn = nameof(NotIn);
    }
}