using Microsoft.AspNetCore.Mvc;
using ZapateriaAPI.Models.Dto;
using ZapateriaAPI.Models;
using ZapateriaAPI.Repository.IRepository;
using ZapateriaAPI.Controllers;
using AutoMapper;

[ApiController]
[Route("api/[controller]")]
public class SalesController : ControllerBase
{
    private readonly ILogger<SalesController> _logger;
    private readonly ISalesRepository _salesRepo;
    private readonly IProductsRepository _productsRepo;
    private readonly IMapper _mapper;

    public SalesController(ILogger<SalesController> logger, ISalesRepository salesRepo, IProductsRepository productsRepo, IMapper mapper)
    {
        _logger = logger;
        _salesRepo = salesRepo;
        _productsRepo = productsRepo;
        _mapper = mapper;
    }


    // SalesController.cs

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<SalesDto>>> GetSales()
    {
        _logger.LogInformation("Obtener las ventas");

        var salesList = await _salesRepo.GetAll();

        return Ok(_mapper.Map<IEnumerable<SalesDto>>(salesList));
    }



    [HttpPost]
    public async Task<IActionResult> PostSales(SalesCreateDto saleDto)
    {
        try
        {
            
            Sales sale = new Sales
            {
                SalesFecha = saleDto.FechaVenta,
                SalesCantidad = saleDto.Cantidad,
                SalesPrecioV = (double)saleDto.PrecioUnitario,
                SalesTotal = (double)saleDto.Total
            };

            
            await _salesRepo.AddSale(sale);
            await _salesRepo.SaveAsync();

            return Ok();
        }
        catch (Exception ex)
        {
            
            string errorMessage = "Error al crear la venta.";
            if (ex.InnerException != null)
            {
                errorMessage += " Detalles: " + ex.InnerException.Message;
            }
            return StatusCode(500, errorMessage);
        }
    }



    //[HttpGet]
    //public async Task<IActionResult> GetVentas()
    //{
    //    try
    //    {
    //        var ventas = await _salesRepo.GetAll();
    //        return Ok(ventas);
    //    }
    //    catch (Exception ex)
    //    {
    //        // Manejo de errores
    //        return StatusCode(StatusCodes.Status500InternalServerError, "Error al obtener las ventas");
    //    }
    //}

    // [HttpPost]
    //public async Task<ActionResult> CreateSale([FromBody] SalesCreateDto saleCreateDto)
    //{
    //    try
    //    {
    //        if (!ModelState.IsValid)
    //        {
    //            return BadRequest(ModelState);
    //        }


    //        var product = await _productsRepo.GetById(saleCreateDto.IDProducto);

    //        if (product == null)
    //        {
    //            return NotFound("El producto no existe");
    //        }


    //        var sale = new Sales
    //        {
    //            ProductsId = product.productId,
    //            salesFecha = saleCreateDto.FechaVenta,
    //            salesCantidad = saleCreateDto.Cantidad,
    //            salesPrecioV = (double)saleCreateDto.PrecioUnitario,
    //            salesTotal = (double)saleCreateDto.Total
    //        };


    //        await _salesRepo.AddSale(sale);
    //        await _salesRepo.SaveAsync();

    //        return Ok();
    //    }
    //    catch (Exception ex)
    //    {

    //        return StatusCode(StatusCodes.Status500InternalServerError, "Error al crear la venta: " + ex.Message);
    //    }
    //}
}
