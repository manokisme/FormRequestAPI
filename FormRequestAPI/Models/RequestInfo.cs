namespace FormRequestAPI.Models
{
    public class RequestInfo
    {
        public int Id { get; set; } // Primary key
        public string? StudentId { get; set; } 
        public string? FullName { get; set; } 
        public string? FormRequested { get; set; } 
        public string? Status { get; set; } 

        public int Age { get; set; }
        public string? Address { get; set; } 
        public string? Program { get; set; } 
        public string? PurposeOfRequest { get; set; } 
        public string? PaymentMethod { get; set; } 
    }
}
