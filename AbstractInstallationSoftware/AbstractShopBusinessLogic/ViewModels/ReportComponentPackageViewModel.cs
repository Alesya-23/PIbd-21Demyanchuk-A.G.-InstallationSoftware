using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace AbstractInstallationSoftBusinessLogic.ViewModels
{
    [DataContract]
    public class ReportComponentPackageViewModel
    {
        [DataMember]
        public string PackageName { get; set; }

        [DataMember]
        public int TotalCount { get; set; }

        [DataMember]
        public List<Tuple<string, int>> Components { get; set; }
    }
}
