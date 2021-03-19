﻿using AbstractInstallationSoftBusinessLogic.BindingModels;
using AbstractInstallationSoftBusinessLogic.HelperModels;
using AbstractInstallationSoftBusinessLogic.Interfaces;
using AbstractInstallationSoftBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractInstallationSoftBusinessLogic.BusinessLogics
{
    public class ReportLogic
    {

        private readonly IComponentStorage _componentStorage;
        private readonly IPackageStorage _packageStorage;
        private readonly IOrderStorage _orderStorage;
        public ReportLogic(IPackageStorage packageStorage, IComponentStorage
       componentStorage, IOrderStorage orderStorage)
        {
            _packageStorage = packageStorage;
            _componentStorage = componentStorage;
            _orderStorage = orderStorage;
        }
        /// <summary>
        /// Получение списка компонент с указанием, в каких изделиях используются
        /// </summary>
        /// <returns></returns>104
        public List<ReportPackageComponentViewModel> GetPackageComponent()
        {
            var components = _componentStorage.GetFullList();
            var packages = _packageStorage.GetFullList();
            var list = new List<ReportPackageComponentViewModel>();
            foreach (var component in components)
            {
                var record = new ReportPackageComponentViewModel
                {
                    ComponentName = component.ComponentName,
                    Packages = new List<Tuple<string, int>>(),
                    TotalCount = 0
                };
                foreach (var package in packages)
                {
                    if (package.PackageComponents.ContainsKey(component.Id))
                    {
                        record.Packages.Add(new Tuple<string, int>(package.PackageName,
                       package.PackageComponents[component.Id].Item2));
                        record.TotalCount +=
                       package.PackageComponents[component.Id].Item2;
                    }
                }
                list.Add(record);
            }
            return list;
        }
        /// <summary>
        /// Получение списка заказов за определенный период
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<ReportOrdersViewModel> GetOrders(ReportBindingModel model)
        {
            return _orderStorage.GetFilteredList(new OrderBindingModel
            {
                DateFrom =
           model.DateFrom,
                DateTo = model.DateTo
            })
            .Select(x => new ReportOrdersViewModel
            {
                DateCreate = x.DateCreate,
                PackageName = x.PackageName,
                Count = x.Count,
                Sum = x.Sum,
                Status = x.Status
            })
           .ToList();
        }
        /// <summary>
        /// Сохранение компонент в файл-Word
        /// </summary>
        /// <param name="model"></param>
        public void SaveComponentsToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список компонент",
                Components = _componentStorage.GetFullList()
            });
        }
        /// <summary>
        /// Сохранение компонент с указаеним продуктов в файл-Excel
        /// </summary>
        /// <param name="model"></param>
        public void SavePackageComponentToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDoc(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список компонент",
                PackageComponents = GetPackageComponent()
            });
        }
        /// <summary>
        /// Сохранение заказов в файл-Pdf
        /// </summary>
        /// <param name="model"></param>
        public void SaveOrdersToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список заказов",
                DateFrom = model.DateFrom.Value,
                DateTo = model.DateTo.Value,
                Orders = GetOrders(model)
            });
        }
    }
}