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
        //private readonly ICategoryRepository _dbCategory;
        //private readonly IProductRepository _dbProduct;
        private readonly IAttributeRepository _dbAttributes;

        public AttributesAPIController(IAttributeRepository dbAttributes , IMapper mapper)
        {
            //_dbCategory = dbCategory;
            //_dbProduct = dbProduct;
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



        //[Authorize(Roles = "admin")]
        [HttpPut("{productId:int}", Name = "UpdateAttributes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdateAttributes([FromBody] AttributesUpdateDTO updateDTO, int productId)
        {
            try
            {
                if (updateDTO == null || updateDTO.ProductID != productId)
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

    }
}
