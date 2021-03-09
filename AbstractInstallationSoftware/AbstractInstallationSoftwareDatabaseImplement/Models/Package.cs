using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractInstallationSoftwareDatabaseImplement.Models
{
    /// <summary>
    /// Изделие, изготавливаемое в магазине
    /// </summary>
    public class Package
    {
        public int Id { get; set; }
        [Required]
        public string PackageName { get; set; }
        [Required]
        public decimal Price { get; set; }
        [ForeignKey("PackageId")]
        public List<PackageComponent> PackageComponents { get; set; }

        [ForeignKey("PackageId")]
        public List<Order> Orders { get; set; }
    }
}
