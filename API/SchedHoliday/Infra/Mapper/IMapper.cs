namespace SchedHoliday.Infra.Mapper
{
    public interface IMapper<T1, T2>
    {
        public T1 From(T2 src);

        public T2 From(T1 src);

        public IEnumerable<T1> FromMany(IEnumerable<T2> src);

        public IEnumerable<T2> FromMany(IEnumerable<T1> src);
    }

}
