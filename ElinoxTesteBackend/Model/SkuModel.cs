namespace ElinoxTesteBackend.Model
{
    //Classe modelo com base no payload fornecido
    public class SkuModel
    {
        public int sku { get; set; }
        public string name { get; set; }
        public Inventory inventory { get; set; }
        public bool? isMarketable { get; set; }
    }

    public class Inventory
    {
        public int quantity { get; set; }
        public List<Warehouses> warehouses { get; set; }
    }

    public class Warehouses
    {
        public string locality { get; set; }
        public int quantity { get; set; }
        public string type { get; set; }
    }
}
