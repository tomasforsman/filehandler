using System;
using System.ComponentModel.DataAnnotations;

namespace FileHandler.Models
{
  public class FileViewModel
  {
    [Required] public Guid Id { get; set; }

    [Required] public string CustomerNumber { get; set; }

    [Required] public string PaymentCardNumber { get; set; }

    public string Notes { get; set; }
  }
}