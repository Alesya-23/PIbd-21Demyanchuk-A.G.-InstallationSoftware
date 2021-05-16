﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.Serialization;
using AbstractInstallationSoftBusinessLogic.Attributes;

namespace AbstractInstallationSoftBusinessLogic.ViewModels
{
    /// <summary>
    /// Изделие, изготавливаемое в магазине
    /// </summary>
    [DataContract]
    public class PackageViewModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        [Column(title: "Название изделия", gridViewAutoSize: GridViewAutoSize.Fill)]
        public string PackageName { get; set; }

        [DataMember]
        [Column(title: "Цена", width: 50)]
        public decimal Price { get; set; }

        [DataMember]
        public Dictionary<int, (string, int)> PackageComponents { get; set; }
    }
}