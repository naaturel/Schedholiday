using System.Text.Json.Nodes;

namespace SchedHoliday.Infra.Mapper
{
    public interface IIOMapper<T>
    {

        T From(JsonNode values);

        JsonNode From(T obj);

        IEnumerable<T> FromMany(JsonNode values);

        JsonNode FromMany(IEnumerable<T> obj);
    }
}
