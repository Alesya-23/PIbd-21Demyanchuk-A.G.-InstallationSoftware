using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using AbstractInstallationSoftBusinessLogic.Enums;
using System.Runtime.Serialization;
using AbstractInstallationSoftBusinessLogic.Attributes;

namespace AbstractInstallationSoftBusinessLogic.ViewModels
{
    /// <summary>
    /// Заказ
    /// </summary>
    [DataContract]
    public class OrderViewModel
    {
        [Column(title: "Номер", width: 100)]
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int ClientId { get; set; }

        [DataMember]
        public int? ImplementerId { get; set; }
        [DataMember]
        public int PackageId { get; set; }
        [DataMember]
        [Column(title: "Клиент", width: 150)]
        [DisplayName("Клиент")]
        public string ClientFullName { get; set; }
        [DataMember]
        [Column(title: "Исполнитель", width: 150)]
        [DisplayName("Исполнитель")]
        public string ImplementerFIO { get; set; }
        [DataMember]
        [Column(title: "Изделие", width: 150)]
        [DisplayName("Изделие")]
        public string PackageName { get; set; }
        [DataMember]
        [Column(title: "Количество", width: 100)]
        public int Count { get; set; }
        [DataMember]
        [Column(title: "Сумма", width: 50)]
        public decimal Sum { get; set; }
        [DataMember]
        [Column(title: "Статус", width: 100)]
        public OrderStatus Status { get; set; }
        [DataMember]
        [Column(title: "Дата создания", width: 100)]
        public DateTime DateCreate { get; set; }
        [DataMember]
        [Column(title: "Дата выполнения", width: 100)]
        public DateTime? DateImplement { get; set; }
    }
}
