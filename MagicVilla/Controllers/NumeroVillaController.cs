using AutoMapper;
using MagicVilla_API.Datos;
using MagicVilla_API.Models;
using MagicVilla_API.Models.Dto;
using MagicVilla_API.Repositorio.IRepositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace MagicVilla_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NumeroVillaController : ControllerBase
    {
        private readonly ILogger<NumeroVillaController> _logger;
        private readonly IVillaRepositorio _villaRepo;
        private readonly INumeroVillaRepositorio _numeroRepo;
        private readonly IMapper _mapper;
        protected APIResponse _response;

        public NumeroVillaController(ILogger<NumeroVillaController> logger, IVillaRepositorio villaRepo, INumeroVillaRepositorio numeroRepo, IMapper mapper )
        {
            _logger = logger;
            _villaRepo = villaRepo;
            _numeroRepo = numeroRepo;
            _mapper = mapper;
            _response = new ();
        }
        //NOS TRAE UNA LISTA DE OBJETOS
        [HttpGet]

        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetNumeroVillas()
        {
            try
            {
                _logger.LogInformation("Obtener Numero villas");

                IEnumerable<NumeroVilla> numeroVillaList = await _numeroRepo.ObtenerTodos();

                _response.Resultado = _mapper.Map<IEnumerable<NumeroVillaDto>>(numeroVillaList);
                _response.statusCode = HttpStatusCode.OK;

                return Ok(_response);
            }

            catch (Exception ex) 
            {
                _response.IsExitoso = false;
                _response.ErrorsMessages = new List<string> { ex.ToString() };
            }
            return _response;

           
        }

        [HttpGet("Id:int", Name = "GetNumeroVilla")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public  async Task<ActionResult<APIResponse>> GetNumeroVilla(int id)
        {
            try
            {
                if (id == 0)
                {
                    _logger.LogError($"Error al traer Numero villa con Id: {id}");
                    _response.statusCode=HttpStatusCode.BadRequest;
                    _response.IsExitoso=false;
                    return BadRequest(_response);
                }
                
                var numeroVilla = await _numeroRepo.Obtener(v => v.VillaNumero == id);

                if (numeroVilla == null)
                {
                    _response.statusCode = HttpStatusCode.NotFound;
                    _response.IsExitoso = false;
                    return NotFound(_response);
                }
                _response.Resultado = _mapper.Map<NumeroVillaDto>(numeroVilla);
                _response.statusCode= HttpStatusCode.OK;
                return Ok(_mapper.Map<NumeroVillaDto>(numeroVilla));
            }
            catch (Exception ex)
            {
                _response.IsExitoso=false;
                _response.ErrorsMessages = new List<string> { ex.ToString() };
                
            }
            return _response;
            
        }

        //PERMITE INGRESAR REGISTROS
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<APIResponse>> CrearNumeroVilla([FromBody]    NumeroVillaCreateDto createDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (await _numeroRepo.Obtener(v => v.VillaNumero == createDto.VillaNumero) != null)
                {
                    ModelState.AddModelError("NombreExiste", "El numero de Villa ya existe");
                    return BadRequest(ModelState);
                }

                if (await _villaRepo.Obtener(v=>v.Id == createDto.VillaId) == null) 
                {
                    ModelState.AddModelError("ClaveForanea", "El Id de Villa no existe");
                    return BadRequest(ModelState);
                }

                if (createDto == null)
                {
                    return BadRequest(createDto);
                }

                NumeroVilla modelo = _mapper.Map<NumeroVilla>(createDto);


                modelo.FechaCreacion = DateTime.Now;
                modelo.FechaActualizacion = DateTime.Now;
                await _numeroRepo.Crear(modelo);
                _response.Resultado = modelo;
                _response.statusCode = HttpStatusCode.Created;


                return CreatedAtRoute("GetNumeroVilla", new { id = modelo.VillaNumero }, _response);
            }
            catch (Exception ex)
            {

                _response.IsExitoso = false;
                _response.ErrorsMessages = new List<string> { ex.ToString() };
            }

            return _response;
        }
        //PERMITE ELIMINAR REGISTROS
        [HttpDelete("{id:int}")]

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> DeleteNumeroVilla(int id)
        {
            try
            {

                if (id == 0)
                {
                    _response.IsExitoso=false;
                    _response.statusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var numeroVilla = await _numeroRepo.Obtener(v => v.VillaNumero == id);

                if (numeroVilla == null)
                {
                    _response.IsExitoso=false;
                    _response.statusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }
               await _numeroRepo.Remover(numeroVilla);

                _response.statusCode=HttpStatusCode.NoContent;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsExitoso = false;
                _response.ErrorsMessages = new List<string>() { ex.ToString() };

                return BadRequest(_response);
                
            }

        }

        //PERMITE ACTUALIZAR TODO LOS REGISTROS
        [HttpPut("{id:int}")]

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateNumeroVilla(int id, [FromBody] NumeroVillaUpdateDto updateDto)
        {
            if (updateDto == null || id != updateDto.VillaNumero)
            {
                return BadRequest();
            }
          
            if (await _villaRepo.Obtener(v=>v.Id == updateDto.VillaId) == null)
            {
                ModelState.AddModelError("ClaveForanea", " El Id de la villa no existe");
                return BadRequest(ModelState);
            }
            NumeroVilla  modelo = _mapper.Map<NumeroVilla>(updateDto);
           
            
           await _numeroRepo.Actualizar(modelo);
            _response.statusCode = HttpStatusCode.NoContent;
         
            return Ok(_response);
        }

        //PERMITE ACTUALIZAR UNATRIBUTO ESPECIFICO DE UN REGISTRO
        [HttpPatch("{id:int}")]

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdatePartialVilla(int id, JsonPatchDocument<VillaUpdateDto> patchDto)
        {
            if (patchDto == null || id == 0)
            {
                return BadRequest();
            }
            var villa = await _villaRepo.Obtener(v => v.Id == id, tracked: false);

            VillaUpdateDto villaDto = _mapper.Map<VillaUpdateDto>(villa);

            if( villa == null)

                return BadRequest();

            patchDto.ApplyTo(villaDto, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Villa modelo = _mapper.Map<Villa>(villaDto);

           await _villaRepo.Actualizar(modelo);
            _response.statusCode=HttpStatusCode.NoContent;

            return Ok(_response);
        }
    }

}