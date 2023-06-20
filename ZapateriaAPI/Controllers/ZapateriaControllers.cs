using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using ZapateriaAPI.DbContexts;
using ZapateriaAPI.Models;
using ZapateriaAPI.Models.Dto;
using ZapateriaAPI.Repository.IRepository;

namespace ZapateriaAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    //No agregues [Authorize]
    public class ZapateriaControllers : ControllerBase
    {
        private readonly ILogger<ZapateriaControllers> _logger;
        private readonly IProductsRepository _productsRepo;
        private readonly IInventaryRepository _inventaryRepo;
        private readonly IMapper _mapper;

        public ZapateriaControllers(ILogger<ZapateriaControllers> logger, IProductsRepository productsRepo, IInventaryRepository inventaryRepo, IMapper mapper)
        {
            _logger = logger;
            _productsRepo = productsRepo;
            _inventaryRepo = inventaryRepo;
            _mapper = mapper;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ProductsDto>>> GetProducts()
        {
            _logger.LogInformation("Obtener los Productos");

            var productsList = await _productsRepo.GetAll();

            return Ok(_mapper.Map<IEnumerable<ProductsDto>>(productsList));
        }

        [HttpDelete("{id}", Name = "DeleteProduct")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var product = await _productsRepo.GetById(id);

            if (product == null)
            {
                return NotFound();
            }

            await _productsRepo.Delete(product);

            return Ok();
        }


        [HttpPost("Products", Name = "AddProducts")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProductsDto>> AddProduct([FromBody] ProductsCreateDto productCreateDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                Products model = _mapper.Map<Products>(productCreateDto);

                await _productsRepo.Add(model);

                return CreatedAtRoute("GetProduct", new { id = model.productId }, model);
            }
            catch (Exception ex)
            {
               
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al agregar el producto: " + ex.Message);
            }
        }


        



        [HttpGet("{marca}", Name = "GetProducts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<ProductsDto>>> GetProducts(string marca)
        {
            if (string.IsNullOrEmpty(marca))
            {
                return BadRequest();
            }

            var products = await _productsRepo.GetAll(s => s.productMarca.Contains(marca));

            if (products.Count == 0)
            {
                return NotFound();
            }

            var productsDto = products.Select(p => new ProductsDto
            {
                productId = p.productId,
                productMarca = p.productMarca,
                productModelo = p.productModelo,
                productTipo = p.productTipo,
                productColor = p.productColor,
                productTalla = p.productTalla,
                productGenero = p.productGenero,
                productPrecio = p.productPrecio,
                productUbicacion = p.productUbicacion
            }).ToList();

            return Ok(productsDto);
        }


        [HttpGet("color/{color}", Name = "GetProductsByColor")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<ProductsDto>>> GetProductsByColor(string color)
        {
            if (string.IsNullOrEmpty(color))
            {
                return BadRequest();
            }

            var products = await _productsRepo.GetAll(s => s.productColor.ToLower() == color.ToLower());

            if (products.Count == 0)
            {
                return NotFound();
            }



            var productsDto = products.Select(p => new ProductsDto
            {
                productId = p.productId,
                productMarca = p.productMarca,
                productModelo = p.productModelo,
                productTipo = p.productTipo,
                productColor = p.productColor,
                productTalla = p.productTalla,
                productGenero = p.productGenero,
                productPrecio = p.productPrecio,
                productUbicacion = p.productUbicacion
            }).ToList();

            return Ok(productsDto);
        }

        [HttpPut("{id}", Name = "UpdateProduct")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> UpdateProduct(int id, [FromBody] ProductsUpdateDto productDto)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var product = await _productsRepo.GetById(id);
            if (product == null)
            {
                return NotFound();
            }

            product.productMarca = productDto.productMarca;
            product.productModelo = productDto.productModelo;
            product.productTipo = productDto.productTipo;
            product.productColor = productDto.productColor;
            product.productTalla = productDto.productTalla;
            product.productPrecio = productDto.productPrecio;
            product.productUbicacion = productDto.productUbicacion;

            // Guardar los cambios en la base de datos
            await _productsRepo.Update(product);

            return Ok();
        }






    }

}



