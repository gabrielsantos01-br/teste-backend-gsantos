using ElinoxTesteBackend.Model;
using ElinoxTesteBackend.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Text.Json;

namespace ElinoxTesteBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SkuController : ControllerBase
    {
        private readonly ISkuService? _SkuService;

        public SkuController(ISkuService? skuService)
        {
            _SkuService = skuService;
        }
        //Método Get que retorna todos os registros
        [HttpGet]
        public List<SkuModel> Get()
        {
            List<SkuModel> listSku = _SkuService.GetAllSku();

            if (listSku.Any())
            {
                foreach (var sku in listSku)
                {
                    sku.inventory.quantity = sku.inventory.warehouses.Sum(c => c.quantity);

                    sku.isMarketable = (sku.inventory.quantity > 0) ? true : false;
                }
            }

            return _SkuService.GetAllSku();
        }
        //Método Get que retorna um registro filtrando pelo sku
        [HttpGet("{sku}")]
        public SkuModel GetBySku(int sku)
        {
            var retSku = _SkuService.GetSku(sku);

            if (retSku != null)
            {
                retSku.inventory.quantity = retSku.inventory.warehouses.Sum(c => c.quantity);

                retSku.isMarketable = (retSku.inventory.quantity > 0) ? true : false;
            }

            return retSku;
        }
        //Método Post para gravar o registro
        [HttpPost]
        public ActionResult Post([FromBody] SkuModel sku) 
        {
            if (sku == null)
                return BadRequest();

            var listSku = _SkuService.GetAllSku();

            if (listSku.Any(c => c.sku == sku.sku))
                return Conflict("Sku duplicado!");

            _SkuService.LoadSku(sku);

            return Ok();
        }
        //Método Patch para atualizar o registro por sku
        [HttpPatch("{id}")]
        public ActionResult Patch([FromBody] SkuModel sku, int id) 
        {
            if (sku == null)
                return BadRequest();

            _SkuService.PatchSku(sku, id);

            return Ok();

        }
    }
}
