using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractInstallationSoftBusinessLogic.BindingModels
{
    /// <summary>
    /// Данные от клиента, для создания заказа
    /// </summary>
    public class CreateOrderBindingModel
    {
        public int PackageId { get; set; }
        public string PackageName { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
    }
}
