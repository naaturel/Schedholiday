namespace SchedHoliday.Exceptions
{
    public class UserNotExistsException : Exception
    {
        public UserNotExistsException(string msg) : base(msg) { }
    }
}
