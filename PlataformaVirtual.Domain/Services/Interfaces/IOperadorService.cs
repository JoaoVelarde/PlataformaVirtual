using PlataformaVirtual.Domain.Entities;
using PlataformaVirtual.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlataformaVirtual.Domain.Services.Interfaces
{
    public interface IOperadorService
    {

        Task<Operador> CrearOperadorAsync(DocumentoIdentidad documentoIdentidad,int tipoDocumento,string nombres,string primerApellido,string segundoApellido,
                                          string direccion, string correo, string celular, string fotoOperador);

        //Task<ICollection<Operador>> GetOperadorWithActiveCredencialAsync();
        //Task<Operador> CrearOperadorAsync(string nombres, string primerApellido, string segundoApellido, string direccion,
        //                                  string correo, string celular, string tipoDocumento, string nroDocumento);
    }
}
