using PlataformaVirtual.Domain.Entities;
using PlataformaVirtual.Domain.Exceptions;
using PlataformaVirtual.Domain.Ports.Output.Repository;
using PlataformaVirtual.Domain.Services.Interfaces;
using PlataformaVirtual.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlataformaVirtual.Domain.Services.Implementations
{
    public class OperadorService : IOperadorService
    {
        private readonly IOperadorRepository _operadorRepository;
        private readonly IPersonaRepository _personaRepository;

        public OperadorService(IOperadorRepository operadorRepository, IPersonaRepository personaRepository)
        {
            _operadorRepository = operadorRepository;
            _personaRepository = personaRepository;
        }


        public async Task<Operador> CrearOperadorAsync(DocumentoIdentidad documentoIdentidad, int tipoDocumento, string nombres, string primerApellido, string segundoApellido, string direccion, string correo, string celular, string fotoOperador)
        {
            #region Crea Persona
            var persona = await _personaRepository.GetByDocumentoAsync(documentoIdentidad.NroDocumento, documentoIdentidad.TipoDocumentoId);

            if (persona is null)
            {
                persona = Persona.Create(
                    documentoIdentidad,
                    tipoDocumento,
                    nombres,
                    primerApellido,
                    segundoApellido,
                    direccion,
                    correo,
                    celular
                );

                await _personaRepository.AddAsync(persona);
            }
            #endregion

            #region Crea Operador
            var operador = await _operadorRepository.GetByIdPersonaAsync(persona.Id);

            if (operador is null)
            {
                operador = Operador.Create(persona.Id, fotoOperador, correo);
                await _operadorRepository.AddAsync(operador);
            }
            #endregion;

            return operador;
        }

        //public async Task<ICollection<Operador>> GetOperadorWithActiveCredencialAsync()
        //{
        //    //Agregar las validaciones de negocio en base a los prestamos activos
        //    //Pendiente
        //    return await _operadorRepository.GetOperadorWithActiveCredencialAsync();
        //}
    }
}
