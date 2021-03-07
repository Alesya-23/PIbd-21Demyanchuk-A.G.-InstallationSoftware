using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AbstractInstallationSoftBusinessLogic.ViewModels
{
    public class StorehouseViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название склада")]
        public string StoreHouseName { get; set; }
        [DisplayName("Ответсвенный")]
        public string FullNameResponsiblePerson { get; set; }
        public Dictionary<int, (string, int)> StorehouseComponents { get; set; }
        [DisplayName("Дата создания")]
        public DateTime DateGreate { get; set; }
    }
}
