using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractInstallationSoftBusinessLogic.BindingModels
{
    /// <summary>
    /// Изделие, изготавливаемое в магазине
    /// </summary>
    public class PackageBindingModel
    {
        public int? Id { get; set; }
        public string PackageName { get; set; }
        public decimal Price { get; set; }
        public Dictionary<int, (string, int)> PackageComponents { get; set; }
    }
}
