namespace SzallodaFoglalasAPI.Entities
{
    public class Room
    {
        public int Id { get; set; }
        public string RoomNumber { get; set; }
        public string RoomType { get; set; }//  1/2 ágyas, lakosztály
        public decimal PricePerNight { get; set; }
        public bool IsAvalible { get; set; }
    }
}
