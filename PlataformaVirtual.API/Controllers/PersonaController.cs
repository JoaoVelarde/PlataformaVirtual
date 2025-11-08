using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlataformaVirtual.Application.Dto;
using PlataformaVirtual.Application.Dto.Persona;
using PlataformaVirtual.Application.Ports.Input.Personas;

namespace PlataformaVirtual.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly ICreatePersonaUseCase _createPersonaUseCase;
        private readonly IGetPersonaUseCase _listPersonaUseCase;

        public PersonaController(ICreatePersonaUseCase createPersonaUseCase, IGetPersonaUseCase listPersonaUseCase)
        {
            _createPersonaUseCase = createPersonaUseCase;
            _listPersonaUseCase = listPersonaUseCase;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePersona([FromBody] CreatePersonaRequest request)
        {
            try
            {
                var result = await _createPersonaUseCase.ExecuteAsync(request);
                return Ok(BaseResponse<Guid>.Success(result, "Persona creado exitosamente"));
            }
            catch (ApplicationException ex)
            {
                return BadRequest(BaseResponse<string>.Fail(ex.Message));
            }
            
        }

        [HttpGet]
        public async Task<IActionResult> GetPersona()
        {
            var result = await _listPersonaUseCase.ExecuteAsync();
            return Ok(BaseResponse<IEnumerable<GetPersonaResponse>>.Success(result, "Personas recuperados con exito"));
        }
    }
}
