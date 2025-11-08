namespace PlataformaVirtual.Domain.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; protected set; }
        public Guid UsuarioCreaId { get; protected set; }
        public DateTime FechaCrea { get; protected set; }
        public Guid? UsuarioModificaId { get; protected set; }
        public DateTime? FechaModifica { get; protected set; }
        public Guid? UsuarioEliminaId { get; protected set; }
        public DateTime? FechaElimina { get; protected set; }
        public Estado EstadoId { get; protected set; }

        protected BaseEntity()
        {
            Id = Guid.NewGuid();
            FechaCrea = DateTime.UtcNow;
            EstadoId = Estado.Activo;
        }

        protected void UpdateModified(Guid usuarioModificaId)
        {
            FechaModifica = DateTime.UtcNow;
            UsuarioModificaId = usuarioModificaId;
        }

        protected void Delete(Guid usuarioEliminaId)
        {
            FechaElimina = DateTime.UtcNow;
            UsuarioEliminaId = usuarioEliminaId;
            EstadoId = Estado.Eliminado;
        }
    }
}
