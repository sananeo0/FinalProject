﻿using System.ComponentModel.DataAnnotations;

namespace FinalProject.Entities
{
    public class Checkout
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
		[Required]
		public string LastName { get; set; }
		[Required]
		public string CompanyName { get; set; }
		[Required]
		public string Email { get; set; }
		[Required]
		public string Country { get; set; }
		[Required]
		public string Address { get; set; }
		[Required]
		public string Town { get; set; }
		[Required]
		public string ZipCode { get; set; }
		[Required]
		public string PhoneNumber { get; set; }
		[Required]
		public string Comment { get; set; }
    }
}
