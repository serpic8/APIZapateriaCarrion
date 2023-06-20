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
                // Manejar cualquier excepción y devolver una respuesta apropiada
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
            // Verificar si el ID es válido
            if (id <= 0)
            {
                return BadRequest();
            }

            // Buscar el producto en la base de datos
            var product = await _productsRepo.GetById(id);
            if (product == null)
            {
                return NotFound();
            }

            // Actualizar los datos del producto con los valores proporcionados
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

        //[HttpPost("Products", Name = "AddProduct")]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<ActionResult<ProductsDto>> AddProduct([FromBody] ProductsCreateDto productCreateDto)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var product = new Products
        //    {
        //        productMarca = productCreateDto.productMarca,
        //        productModelo = productCreateDto.productModelo,
        //        productTipo = productCreateDto.productTipo,
        //        productColor = productCreateDto.productColor,
        //        productTalla = productCreateDto.productTalla,
        //        productGenero = productCreateDto.productGenero,
        //        productPrecio = productCreateDto.productPrecio,
        //        productUbicacion = productCreateDto.productUbicacion
        //    };

        //    await _productsRepo.AddProduct(product);

        //    var productDto = new ProductsDto
        //    {
        //        productId = product.productId,
        //        productMarca = product.productMarca,
        //        productModelo = product.productModelo,
        //        productTipo = product.productTipo,
        //        productColor = product.productColor,
        //        productTalla = product.productTalla,
        //        productGenero = product.productGenero,
        //        productPrecio = product.productPrecio,
        //        productUbicacion = product.productUbicacion
        //    };

        //    return CreatedAtRoute("GetProducts", new { marca = product.productMarca }, productDto);
        //}








        //[HttpPost("Products", Name = "AddProducts")]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public async Task<ActionResult<ProductsDto>> AddProduct([FromBody] ProductsCreateDto productCreateDto)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (await _productsRepo.Get(p => p.productMarca == productCreateDto.productMarca && p.productModelo == productCreateDto.productModelo) != null)
        //    {
        //        ModelState.AddModelError("ProductoExiste", "¡El producto ya existe en la base de datos!");
        //        return BadRequest(ModelState);
        //    }

        //    if (productCreateDto == null)
        //    {
        //        return BadRequest(productCreateDto);
        //    }

        //    Products model = _mapper.Map<Products>(productCreateDto);

        //    await _productsRepo.Add(model);

        //    return CreatedAtRoute("GetProduct", new { id = model.productId }, model);
        //}

    }

}



