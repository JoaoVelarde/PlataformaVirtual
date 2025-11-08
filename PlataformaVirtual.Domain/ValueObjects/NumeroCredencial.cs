using PlataformaVirtual.Domain.Exceptions;

namespace PlataformaVirtual.Domain.ValueObjects
{
    public record NumeroCredencial
    {
        public string Valor { get; private set; }

        private NumeroCredencial() { }
        private NumeroCredencial(string valor)
        {
            Valor = valor;
        }

        public static NumeroCredencial Create(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor))
                throw new DomainException("El número de credencial es obligatorio.");

            if (valor.Length < 5)
                throw new DomainException("El número de credencial debe tener al menos 5 caracteres.");

            return new NumeroCredencial(valor);
        }


    }
}
