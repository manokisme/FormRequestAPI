namespace FormRequestAPI.Models
{
    public class RegistrarInfo
    {
        public int Id { get; set; }
        public required string FullName { get; set; }
        public required string IdNumber { get; set; }
        public required string Password { get; set; }
    }
}
