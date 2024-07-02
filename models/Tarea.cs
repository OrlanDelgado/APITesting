using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TareasApi.Models
{
    public class Tareas
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Titulo")]
        public string Titulo { get; set; }

        [BsonElement("Descripcion")]
        public string Descripcion { get; set; }

        [BsonElement("FechaCreacion")]
        public DateTime FechaCreacion { get; set; }

        [BsonElement("Estado")]
        public string Estado { get; set; }

        [BsonIgnore]
        public bool IsCompletedBoolean => Estado == "completado";

        // Constructor que inicializa las propiedades
        public Tareas()
        {
            Id = ObjectId.GenerateNewId().ToString();
            Titulo = string.Empty;
            Descripcion = string.Empty;
            FechaCreacion = DateTime.UtcNow;
            Estado = "pendiente";
        }
    }
}
