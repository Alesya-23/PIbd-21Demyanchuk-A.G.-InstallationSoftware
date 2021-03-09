using AbstractInstallationSoftBusinessLogic.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractInstallationSoftwareDatabaseImplement.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int PackageId { get; set; }
        [Required]
        public int Count { get; set; }
        [Required]
        public decimal Sum { get; set; }
        [Required]
        public OrderStatus Status { get; set; }
        [Required]
        public DateTime DateCreate { get; set; }
        public DateTime? DateImplement { get; set; }

        //связь с изделием
        public virtual Package Package { get; set; }
    }
}
