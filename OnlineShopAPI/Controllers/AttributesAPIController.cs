using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShopAPI.Models;
using OnlineShopAPI.Models.Dto;
using OnlineShopAPI.Repository.IRepostiory;
using System.Net;
using System.Runtime.InteropServices;

namespace OnlineShopAPI.Controllers
{
    [Route("api/AttributesAPI")]
    [ApiController]
    public class AttributesAPIController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IMapper _mapper;
        private readonly IAttributeRepository _dbAttributes;

        public AttributesAPIController(IAttributeRepository dbAttributes , IMapper mapper)
        {
             _dbAttributes = dbAttributes;
            _mapper = mapper;
            _response = new();
        }

        [HttpGet]
        //[MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> GetAttributes(int productId)
        {
            try
            {
                IEnumerable<Attributes> AttributesList = await _dbAttributes.GetAllAsync(u => u.ProductID == productId);

                if (AttributesList == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.ErrorMessages = new List<string>() { "No products found" };
                    _response.IsSuccess = false;
                    return _response;

                }               

                _response.Result = _mapper.Map<List<AttributesDTO>>(AttributesList);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;

        }

        [HttpGet("{id:int}", Name = "GetAttribute")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> GetAttribute(int id)
        {
            try
            {
                if (id == 0)
                {
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                var attribute = await _dbAttributes.GetAsync(u => u.AttributeId == id);

                if (attribute == null)
                {
                    _response.StatusCode = HttpStatusCode.NotFound;
                    return NotFound(_response);
                }

                _response.Result = _mapper.Map<AttributesDTO>(attribute);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
		[ProducesResponseType(StatusCodes.Status403Forbidden)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		public async Task<ActionResult<APIResponse>> CreateAttribute(int productId, [FromBody] AttributesCreateDTO createDTO)
        {
            try
            {

                if (await _dbAttributes.GetAsync(u => (u.ProductID == productId) && (u.Name == createDTO.Name)) != null)
                {
                    ModelState.AddModelError("ErrorMessages", "Attribute already Exists!");
                    return BadRequest(ModelState);
                }

                if (createDTO == null)
                {
                    return BadRequest(createDTO);
                }

                Attributes attribute = _mapper.Map<Attributes>(createDTO);


                await _dbAttributes.CreateAsync(attribute);
                _response.Result = _mapper.Map<AttributesDTO>(attribute);
                _response.StatusCode = HttpStatusCode.Created;
                return CreatedAtRoute("GetAttribute", new { id = attribute.AttributeId }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }


        [Authorize(Roles = "admin")]
        [HttpPut("{attributeId:int}", Name = "UpdateAttributes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status403Forbidden)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		public async Task<ActionResult<APIResponse>> UpdateAttributes(int attributeId, [FromBody] AttributesUpdateDTO updateDTO)
        {
            try
            {
                if (updateDTO == null || updateDTO.AttributeId != attributeId)
                {
                    return BadRequest();
                }

                if (await _dbAttributes.GetAsync(u => u.AttributeId == updateDTO.AttributeId,false) == null)
                {
                    ModelState.AddModelError("ErrorMessages", "Attribute is Invalid!");
                    return BadRequest(ModelState);
                }
                Attributes model = _mapper.Map<Attributes>(updateDTO);
               
                await _dbAttributes.UpdateAsync(model);

                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)    
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status403Forbidden)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[HttpDelete("{id:int}", Name = "DeleteAttribute")]
        public async Task<ActionResult<APIResponse>> DeleteAttribute(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                var attribute = await _dbAttributes.GetAsync(u => u.AttributeId == id);
                if (attribute == null)
                {
                    return NotFound();
                }
                await _dbAttributes.RemoveAsync(attribute);
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }
    }
}
