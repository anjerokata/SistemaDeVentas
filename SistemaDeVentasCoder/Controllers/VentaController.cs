using Microsoft.AspNetCore.Mvc;
using SistemaDeVentasCoder.ADO.NET;
using SistemaDeVentasCoder.Models;
using System.Data.SqlClient;

namespace SistemaDeVentasCoder.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class VentaController : ControllerBase
    {
        private VentaHandler handler = new VentaHandler();

        [HttpGet]
        public ActionResult<List<Venta>> Get()
        {
            try
            {
                List<Venta> lista = handler.GetVenta();
                return Ok(lista);
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Venta> Get(int id)
        {
            try
            {
                Venta venta = handler.ObtenerVenta(id);
                if (venta != null)
                {
                    return Ok(venta);
                }
                else
                {
                    return NotFound("La venta no fue encontrada");
                }
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }
        
        [HttpPost]
        public ActionResult Post([FromBody] Venta venta) 
        {
            try
            {
                handler.CargarVenta(venta);
                return Ok();
            }
            catch (Exception ex)
            {

                return Problem(ex.Message);
            }
        }

        [HttpDelete]
        public ActionResult Delete([FromBody] int id)
        {
            try
            {
                bool seElimino = handler.EliminarVenta(id);
                if (seElimino)
                {
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}