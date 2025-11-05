using System.Text.Json;
using System.Text.Json.Serialization;

namespace PreExamen.Adaptadores
{
    internal class AdaptadorFechas : JsonConverter<DateTime>
    {
        private const string Formato = "dd/MM/yyyy";
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string valor = reader.GetString();
            if (DateTime.TryParseExact(valor, Formato, null, System.Globalization.DateTimeStyles.None, out DateTime fecha))
            {
                return fecha;
            }

            throw new JsonException("No se pudo deserializar la fecha.");
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(Formato));
        }
    }
}
