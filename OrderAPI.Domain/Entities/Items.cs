using OrderAPI.Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace OrderAPI.Domain.Entities
{
    public class Items
    {
        [Required]
        [StringLength(10)]
        public string Code { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public int Units { get; set; }
        [Required]        
        [RegularExpression(@"^[0-9]([.,][0-9]{1,2})?$")]
        public double PricePerUnit { get; set; }
        public TaxType Type { get; set; }
        public double Subtotal { get; set; }
        public double VatPercentaje { 
            get {
                return ((int)Type).Equals(2) ? 0 : 25;
            }
        }
        public double TotalWithVat { 
            get {
                return Subtotal * (1 + VatPercentaje / 100);
            }
        }

    }
}
