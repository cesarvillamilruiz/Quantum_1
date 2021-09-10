using LogicLayer.Bussiness;
using LogicLayer.DTO;
using LogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Front.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FacturaController: ControllerBase
    {
        private readonly IFacturaRepository facturaRepository;
        private FacturaService facturaService = new FacturaService();

        public FacturaController(IFacturaRepository facturaRepository)
        {
            this.facturaRepository = facturaRepository;
        }

        [HttpGet("Get_Bills")]
        public async Task<IActionResult> Get_Bills()
        {
            var result = await facturaService.Get_Bills(this.facturaRepository);

            return Ok(result);
        }

        [HttpGet("Get_Bill_By_Id/{id}")]
        public async Task<IActionResult> Get_Bill_By_Id(int id)
        {
            var result = await facturaService.Get_Bill_By_Id(this.facturaRepository, id);

            if (!result.Item1)
            {
                return BadRequest("No existe el la factura solicitada");
            }
            return Ok(result.Item2);
        }

        [HttpPost("Add_Bill")]
        public async Task<IActionResult> Add_Bill(FacturaDTO model)
        {
            if (ModelState.IsValid)
            {
                bool result = await facturaService.Add_Bill(this.facturaRepository, model);
                if (result)
                {
                    return Ok("La nueva factura se agrego correctamente");
                }
            }

            return BadRequest("El modelo es invalido");
        }
    }
}
