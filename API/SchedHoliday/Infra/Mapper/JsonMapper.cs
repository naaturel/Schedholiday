using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.Json.Nodes;

namespace SchedHoliday.Infra.Mapper
{
    public class JsonMapper<T> : IIOMapper<T>
    {
        public T From(JsonNode values)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(values.ToString());
            }
            catch (Exception ex)
            {
                throw new JsonException($"Unable to deserialize data : {ex.Message}");
            }
        }

        public JsonNode From(T obj)
        {
            try
            {
                var json = JsonConvert.SerializeObject(obj);
                return JsonNode.Parse(json);

            }
            catch (Exception ex)
            {
                throw new JsonException($"Unable to serialize data : {ex.Message}");
            }
        }

        public IEnumerable<T> FromMany(JsonNode values)
        {
            try
            {
                return JsonConvert.DeserializeObject<IEnumerable<T>>(values.ToString());
            }
            catch (Exception ex)
            {
                throw new JsonException($"Unable to deserialize data : {ex.Message}");
            }
        }

        public JsonNode FromMany(IEnumerable<T> obj)
        {
            try
            {
                var json = JsonConvert.SerializeObject(obj);
                return JsonNode.Parse(json);

            }
            catch (Exception ex)
            {
                throw new JsonException($"Unable to serialize data : {ex.Message}");
            }
        }


    }
}
