using PlataformaVirtual.Domain.Exceptions;

namespace PlataformaVirtual.Domain.ValueObjects
{
    public record NumeroExpediente
    {
        public string Valor { get; private init; }

        private NumeroExpediente() { }

        private NumeroExpediente(string valor)
        {
            Valor = valor;
        }

        public static NumeroExpediente Create(int correlativo)
        {
            if (correlativo <= 0)
                throw new DomainException("El correlativo debe ser mayor a cero.");

            var random = new Random();
            var parteAleatoria = random.Next(1000, 9999); // 4 dígitos
            var mes = DateTime.UtcNow.Month.ToString("D2"); // 2 dígitos
            var anio = DateTime.UtcNow.Year.ToString("D4"); // 4 dígitos
            var correlativoStr = correlativo.ToString("D6"); // 6 dígitos con padding

            var valor = $"{parteAleatoria}-{mes}-{anio}-{correlativoStr}";
            return new NumeroExpediente(valor);
        }

        public override string ToString() => Valor;
    }
}
