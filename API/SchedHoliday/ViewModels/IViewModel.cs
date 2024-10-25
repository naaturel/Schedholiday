namespace SchedHoliday.ViewModels
{
    public interface IViewModel<T>
    {
        public T toModel();
    }
}
