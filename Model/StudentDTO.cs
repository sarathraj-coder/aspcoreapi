using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using school.Validators;

namespace school.Model
{
	public class StudentDTO
	{
        [ValidateNever]
        public int Id { get; set; }
        [Required(ErrorMessage = "Student name is required ")]
        [StringLength(30)]
        public String Name { get; set; }
        [Required]
        public String Address { get; set; }
        [EmailAddress(ErrorMessage = "Student name is required ")]
        [Required]
        public String Email { get; set; }

        //customs validator
        [DateValidator]
        public String admissionDate { get; set; }
    }
}

