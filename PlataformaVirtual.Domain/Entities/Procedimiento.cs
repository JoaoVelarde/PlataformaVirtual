using PlataformaVirtual.Domain.Exceptions;

namespace PlataformaVirtual.Domain.Entities
{
    public class Procedimiento : BaseEntity
    {
        public string Nombre { get; private set; }
        public ICollection<Expediente> Expedientes { get; private set; } = new List<Expediente>();
        private Procedimiento() { }

        public Procedimiento(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new DomainException("El nombre del procedimiento es obligatorio.");

            Nombre = nombre;
        }
    }
}
