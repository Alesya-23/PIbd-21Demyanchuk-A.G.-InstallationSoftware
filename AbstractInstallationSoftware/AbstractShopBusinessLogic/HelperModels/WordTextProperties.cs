﻿using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractInstallationSoftBusinessLogic.HelperModels
{
    public class WordTextProperties
    {
        public string Size { get; set; }
        public bool Bold { get; set; }
        public JustificationValues JustificationValues { get; set; }
    }
}
