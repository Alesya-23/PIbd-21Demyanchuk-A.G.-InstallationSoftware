﻿using AbstractInstallationSoftBusinessLogic.Enums;
using AbstractInstallationSoftwareFileImplement.Implements;
using AbstractInstallationSoftwareFileImplement.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace AbstractInstallationSoftwareFileImplement
{
    class FileDataListSingleton
    {
        private static FileDataListSingleton instance;
        private readonly string ComponentFileName = "Component.xml";
        private readonly string OrderFileName = "Order.xml";
        private readonly string PackageFileName = "Package.xml";
        private readonly string StorehouseFileName = "Storehouse.xml";
        public List<Component> Components { get; set; }
        public List<Order> Orders { get; set; }
        public List<Package> Packages { get; set; }
        public List<Storehouse> Storehouses{ get; set; }
        private FileDataListSingleton()
        {
            Components = LoadComponents();
            Orders = LoadOrders();
            Packages = LoadPackages();
            Storehouses = LoadStorehouseStorages();
        }
        public static FileDataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new FileDataListSingleton();
            }
            return instance;
        }
        ~FileDataListSingleton()
        {
            SaveComponents();
            SaveOrders();
            SavePackages();
            SaveStorehouseStorages();
        }
        private List<Component> LoadComponents()
        {
            var list = new List<Component>();
            if (File.Exists(ComponentFileName))
            {
                XDocument xDocument = XDocument.Load(ComponentFileName);
                var xElements = xDocument.Root.Elements("Component").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Component
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        ComponentName = elem.Element("ComponentName").Value
                    });
                }
            }
            return list;
        }
        private List<Order> LoadOrders()
        {
            var list = new List<Order>();
            if (File.Exists(OrderFileName))
            {
                XDocument xDocument = XDocument.Load(OrderFileName);
                var xElements = xDocument.Root.Elements("Order").ToList();
                foreach (var elem in xElements)
                {
                    list.Add(new Order
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        PackageId = Convert.ToInt32(elem.Element("PackageId").Value),
                        Count = Convert.ToInt32(elem.Element("Count").Value),
                        Sum = Convert.ToDecimal(elem.Element("Sum").Value),
                        Status = (OrderStatus)Convert.ToInt32(elem.Element("Status").Value),
                        DateCreate = Convert.ToDateTime(elem.Element("DateCreate")?.Value),
                        DateImplement = String.IsNullOrEmpty(elem.Element("DateImplement").Value) ? DateTime.MinValue : Convert.ToDateTime(elem.Element("DateImplement").Value)
                    });
                }
            }
            return list;
        }
        private List<Package> LoadPackages()
        {
            var list = new List<Package>();
            if (File.Exists(PackageFileName))
            {
                XDocument xDocument = XDocument.Load(PackageFileName);
                var xElements = xDocument.Root.Elements("Package").ToList();
                foreach (var elem in xElements)
                {
                    var packComp = new Dictionary<int, int>();
                    foreach (var component in
                   elem.Element("PackageComponents").Elements("PackageComponent").ToList())
                    {
                        packComp.Add(Convert.ToInt32(component.Element("Key").Value),
                       Convert.ToInt32(component.Element("Value").Value));
                    }
                    list.Add(new Package
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        PackageName = elem.Element("PackageName").Value,
                        Price = Convert.ToDecimal(elem.Element("Price").Value),
                        PackageComponents = packComp
                    });
                }
            }
            return list;
        }

        private List<Storehouse> LoadStorehouseStorages()
        {
            var list = new List<Storehouse>();
            if (File.Exists(StorehouseFileName))
            {
                XDocument xDocument = XDocument.Load(StorehouseFileName);
                var xElements = xDocument.Root.Elements("Storehouse").ToList();
                foreach (var elem in xElements)
                {
                    var houseComp = new Dictionary<int, (string, int)>();
                    foreach (var component in
                    elem.Element("StorehouseComponents").Elements("StorehouseComponent").ToList())
                    {
                        houseComp.Add(Convert.ToInt32(component.Element("Key").Value),
                            (component.Element("Value").Value.ToString(), 
                            Convert.ToInt32(component.Element("Value").Value)));
                    }
                    list.Add(new Storehouse
                    {
                        Id = Convert.ToInt32(elem.Attribute("Id").Value),
                        StoreHouseName = elem.Element("StorehouseName").Value,
                        FullNameResponsiblePerson = elem.Element("Responsible").Value,
                        DateCreate = Convert.ToDateTime(elem.Element("DateCreate").Value),
                        StorehouseComponents = houseComp
                    });
                }
            }
            return list;
        }
        private void SaveComponents()
        {
            if (Components != null)
            {
                var xElement = new XElement("Components");
                foreach (var component in Components)
                {
                    xElement.Add(new XElement("Component",
                    new XAttribute("Id", component.Id),
                    new XElement("ComponentName", component.ComponentName)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(ComponentFileName);
            }
        }
        private void SaveOrders()
        {
            if (Orders != null)
            {
                var xElement = new XElement("Orders");
                foreach (var order in Orders)
                {
                    xElement.Add(new XElement("Order",
                    new XAttribute("Id", order.Id),
                    new XElement("PackageId", order.PackageId),
                    new XElement("Count", order.Count),
                    new XElement("Sum", order.Sum),
                    new XElement("Status", (int)order.Status),
                    new XElement("DateCreate", order.DateCreate),
                    new XElement("DateImplement", order.DateImplement)));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(OrderFileName);
            }
        }
        private void SavePackages()
        {
            if (Packages != null)
            {
                var xElement = new XElement("Packages");
                foreach (var package in Packages)
                {
                    var compElement = new XElement("PackageComponents");
                    foreach (var component in package.PackageComponents)
                    {
                        compElement.Add(new XElement("PackageComponent",
                        new XElement("Key", component.Key),
                        new XElement("Value", component.Value)));
                    }
                    xElement.Add(new XElement("Package",
                     new XAttribute("Id", package.Id),
                     new XElement("PackageName", package.PackageName),
                     new XElement("Price", package.Price),
                     compElement));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(PackageFileName);
            }
        }

        private void SaveStorehouseStorages()
        {
            if (Storehouses != null)
            {
                var xElement = new XElement("Storehouses");
                foreach (var house in Storehouses)
                {
                    var compElement = new XElement("StorehouseComponents");
                    foreach (var component in house.StorehouseComponents)
                    {
                        compElement.Add(new XElement("StorehouseComponent",
                        new XElement("Key", component.Key),
                        new XElement("Value", component.Value)));
                    }
                    xElement.Add(new XElement("Storehouse",
                    new XAttribute("Id", house.Id),
                    new XElement("StorehouseName", house.StoreHouseName),
                    new XElement("Responsible", house.FullNameResponsiblePerson),
                    new XElement("DateCreate", house.DateCreate),
                    compElement));
                }
                XDocument xDocument = new XDocument(xElement);
                xDocument.Save(StorehouseFileName);
            }
        }
    }
}
  