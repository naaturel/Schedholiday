using System.ComponentModel;

namespace SchedHoliday.Exceptions
{
    public class ValidationException : Exception
    {


        public ValidationException(string msg) : base(msg) { }
    
        public class ValidationErrorCode
        {
            public static readonly string EMPTY      = "Cannot be empty";
            public static readonly string TOO_LONG   = "Too long";
            public static readonly string TOO_SHORT   = "Too short";


        }


    }
}
