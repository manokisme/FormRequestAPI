namespace FormRequestAPI.Models
{
    public class RequestInfo
    {
        public int Id { get; set; } // Primary key
        public string? StudentId { get; set; } // Student's ID number
        public string? FullName { get; set; } // Student's full name
        public string? FormRequested { get; set; } // Type of form requested
        public string? Status { get; set; } // Status of the request: Pending, Approved, etc.

        public int Age { get; set; } // Student's age
        public string? Address { get; set; } // Student's address
        public string? Program { get; set; } // Student's academic program
        public string? PurposeOfRequest { get; set; } // Reason for requesting the form
        public string? PaymentMethod { get; set; } // Payment method used
    }
}
