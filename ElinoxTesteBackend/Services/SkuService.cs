using ElinoxTesteBackend.Model;

namespace ElinoxTesteBackend.Services
{
    //Classe serviço para gravar em memória 
    public interface ISkuService
    {
        List<SkuModel> GetAllSku();
        SkuModel GetSku(int sku);
        void LoadSku(SkuModel sku);
        void PatchSku(SkuModel sku, int id);
    }

    public class SkuService : ISkuService
    {
        private List<SkuModel> _sku = new List<SkuModel>();

        //Método para gravar todos os registros
        public void LoadSku(SkuModel sku)
        {
            _sku.Add(sku);
        }

        //Método para retornar todos os registros
        public List<SkuModel> GetAllSku() 
        {
            return _sku;
        }

        //Método para retornar um registro filtrado
        public SkuModel GetSku(int sku)
        {
            return _sku.FirstOrDefault(x => x.sku == sku);
        }

        //Método para atualizar o registro filtrado
        public void PatchSku(SkuModel sku, int id)
        {
            var index = _sku.FindIndex(c => c.sku == id);

            if(index != -1) 
                _sku[index] = sku;

        }
    }
}
