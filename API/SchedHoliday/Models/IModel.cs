using SchedHoliday.ViewModels;

namespace SchedHoliday.Models
{
    public interface IModel<T>
    {

        IViewModel<T> Convert(string verb);

    }
}
