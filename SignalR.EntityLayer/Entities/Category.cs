namespace SignalR.EntityLayer.Entities
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public bool Status { get; set; }
        //İlişkili tablo yapımında her ürünün bir kategorisi olacağı için
        public List<Product> Products { get; set;}//Ürün listelemek için buraya geçildi
        //Yani kategori pizza ise pizzadan 10 adet ürün olabilir o yüzden listeleme işlemi yapıldı.
    }
}
