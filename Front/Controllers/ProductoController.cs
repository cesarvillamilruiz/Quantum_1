using LogicLayer.Bussiness;
using LogicLayer.DTO;
using LogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Front.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductoController: ControllerBase
    {
        private readonly IProductoRepository productoRepository;
        private ProductService productService = new ProductService();
        public ProductoController(IProductoRepository productoRepository)
        {
            this.productoRepository = productoRepository;
        }

        [HttpGet("Get_Products")]
        public async Task<IActionResult> Get_Products()
        {
            var result = await productService.Get_Products(this.productoRepository);

            return Ok(result);
        }

        [HttpGet("Get_Product_By_Id/{id}")]
        public async Task<IActionResult> Get_Product_By_Id(int id)
        {
            var result = await productService.Get_Product_By_Id(this.productoRepository, id);

            if (!result.Item1)
            {
                return BadRequest("No existe el id solicitado");
            }
            return Ok(result.Item2);
        }

        [HttpPost("Add_Product")]
        public async Task<IActionResult> Add_Product(ProductoDTO model)
        {
            if (ModelState.IsValid)
            {
                bool result = await productService.Add_Product(this.productoRepository, model);
                if (result)
                {
                    return Ok("El nuevo producto se agrego correctamente");
                }
            }

            return BadRequest("El modelo es invalido");
        }

        [HttpPut("Update_Product/{id}")]
        public async Task<IActionResult> Update_Product(ProductoDTO model, int id)
        {
            if (ModelState.IsValid)
            {
                bool result = await productService.Update_Product(this.productoRepository, model, id);
                if (result)
                {
                    return Ok("El producto se actualizo correctamente");
                }
            }
            return BadRequest("El modelo es invalido");
        }

        [HttpPut("Update_Inventory/{id}/{value}")]
        public async Task<IActionResult> Update_Inventory(int id, int value)
        {
            bool result = await productService.Update_Inventory(this.productoRepository, id, value);
            if (result)
            {
                return Ok("El producto se actualizo correctamente");
            }
            return BadRequest("El modelo es invalido");
        }

        [HttpDelete("Delete_Product/{id}")]
        public async Task<IActionResult> Delete_Product(int id)
        {
            bool result = await productService.Delete_Product(this.productoRepository, id);
            if (result)
            {
                return Ok("Se ha eliminado el producto exitosamente");
            }

            return BadRequest("El producto seleccionado no existe");
        }
    }
}
