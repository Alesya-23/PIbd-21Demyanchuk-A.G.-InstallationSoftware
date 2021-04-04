﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractInstallationSoftBusinessLogic.ViewModels
{
    public class ReportComponentPackageViewModel
    {
        public string PackageName { get; set; }
        public int TotalCount { get; set; }
        public List<Tuple<string, int>> Components { get; set; }
    }
}
