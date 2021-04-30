using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractInstallationSoftwareFileImplement.Models
{
    public class Storehouse
    {
        public int Id { get; set; }
        public string StoreHouseName { get; set; }
        public string FullNameResponsiblePerson { get; set; }
        public DateTime DateCreate { get; set; }
        public Dictionary<int, (string, int)> StorehouseComponents { get; set; }
    }
}
