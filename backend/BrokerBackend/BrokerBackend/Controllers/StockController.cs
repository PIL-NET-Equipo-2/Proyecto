using BrokerBackend.Dtos;
using BrokerBackend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BrokerBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
            private readonly StockService stockService;
            public StockController(StockService stockService)
            {
                this.stockService = stockService;
            }

            [HttpGet]
            public async Task<IActionResult> GetAll()
            {
                return Ok(await this.stockService.GetAll());
            }

            [HttpGet("{id}")]
            public async Task<IActionResult?> GetById(int id)
            {
                StockDto? stock = await stockService.GetById(id);
                return stock != null ? Ok(stock) : NotFound();
            }

            [HttpPost]
            public async Task<IActionResult?> Create(NewStockDto stock)
            {
                return Ok(await stockService.Create(stock));
            }
        }
    }

