using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractInstallationSoftBusinessLogic.BindingModels
{
    public class StorehouseBindingModel
    {
        public int? Id { get; set; }
        public string StoreHouseName { get; set; }
        public string FullNameResponsiblePerson { get; set; }
        public DateTime DateCreate { get; set; }
        public Dictionary<int, (string, int)> StorehouseComponents { get; set; }
    }
}
