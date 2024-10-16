namespace Talbat.Core.Entites.orderaggretion
{
    public class productOrder
    {
        public productOrder()
        {
            
        }

        public productOrder(int id, string productName,string descrption, string pictureUrl )
        {
            ProductName = productName;
            PictureUrl = pictureUrl;
            Descrption = descrption;
            Id = id;
        }
        public int Id { get; set; }
        public string Descrption{ get; set; }

        public string ProductName { get; set; }
        public string PictureUrl { get; set; }
    }
}