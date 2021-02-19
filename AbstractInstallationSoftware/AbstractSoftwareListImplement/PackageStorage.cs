using AbstractInstallationSoftBusinessLogic.BindingModels;
using AbstractInstallationSoftBusinessLogic.Interfaces;
using AbstractInstallationSoftBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractInstallationSoftListImplement
{
    public class PackageStorage : IPackageStorage
    {
        private readonly DataListSingleton source;
        public PackageStorage()
        {
            source = DataListSingleton.GetInstance();
        }
        public List<PackageViewModel> GetFullList()
        {
            List<PackageViewModel> result = new List<PackageViewModel>();
            foreach (var component in source.Products)
            {
                result.Add(CreateModel(component));
            }
            return result;
        }
        public List<PackageViewModel> GetFilteredList(PackageBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            List<PackageViewModel> result = new List<PackageViewModel>();
            foreach (var product in source.Products)
            {
                if (product.ProductName.Contains(model.ProductName))
                {
                    result.Add(CreateModel(product));
                }
            }
            return result;
        }
        public PackageViewModel GetElement(PackageBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            foreach (var product in source.Products)
            {
                if (product.Id == model.Id || product.ProductName ==
                model.ProductName)
                {
                    return CreateModel(product);
                }
            }
            return null;
        }
        public void Insert(PackageBindingModel model)
        {
            Package tempProduct = new Package
            {
                Id = 1,
                PackageComponents = new
            Dictionary<int, int>()
            };
            foreach (var product in source.Products)
            {
                if (product.Id >= tempProduct.Id)
                {
                    tempProduct.Id = product.Id + 1;
                }
            }
            source.Products.Add(CreateModel(model, tempProduct));
        }
        public void Update(PackageBindingModel model)
        {
            Package tempProduct = null;
            foreach (var product in source.Products)
            {
                if (product.Id == model.Id)
                {
                    tempProduct = product;
                }
            }
            if (tempProduct == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, tempProduct);
        }
        public void Delete(PackageBindingModel model)
        {
            for (int i = 0; i < source.Products.Count; ++i)
            {
                if (source.Products[i].Id == model.Id)
                {
                    source.Products.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
        private Package CreateModel(PackageBindingModel model, Package product)
        {
            product.ProductName = model.ProductName;
            product.Price = model.Price;
            // удаляем убранные
            foreach (var key in product.PackageComponents.Keys.ToList())
            {
                if (!model.ProductComponents.ContainsKey(key))
                {
                    product.PackageComponents.Remove(key);
                }
            }
            // обновляем существуюущие и добавляем новые
            foreach (var component in model.ProductComponents)
            {
                if (product.PackageComponents.ContainsKey(component.Key))
                {
                    product.PackageComponents[component.Key] =
                    model.ProductComponents[component.Key].Item2;
                }
                else
                {
                    product.PackageComponents.Add(component.Key,
                    model.ProductComponents[component.Key].Item2);
                }
            }
            return product;
        }
        private PackageViewModel CreateModel(Package product)
        {
            // требуется дополнительно получить список компонентов для изделия с названиями и их количество
            Dictionary<int, (string, int)> productComponents = new
            Dictionary<int, (string, int)>();
            foreach (var pc in product.PackageComponents)
            {
                string componentName = string.Empty;
                foreach (var component in source.Components)
                {
                    if (pc.Key == component.Id)
                    {
                        componentName = component.ComponentName;
                        break;
                    }
                }
                productComponents.Add(pc.Key, (componentName, pc.Value));
            }
            return new PackageViewModel
            {
                Id = product.Id,
                ProductName = product.ProductName,
                Price = product.Price,
                ProductComponents = productComponents
            };
        }
    }
}
