using AbstractInstallationSoftBusinessLogic.BindingModels;
using AbstractInstallationSoftBusinessLogic.Interfaces;
using AbstractInstallationSoftBusinessLogic.ViewModels;
using AbstractInstallationSoftListImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractInstallationSoftListImplement.Implements
{
    public class StorehouseStorage : IStorehouse
    {
        private readonly DataListSingleton source;
        public StorehouseStorage()
        {
            source = DataListSingleton.GetInstance();
        }
        public List<StorehouseViewModel> GetFullList()
        {
            List<StorehouseViewModel> result = new List<StorehouseViewModel>();
            foreach (var storehouse in source.Storehouse)
            {
                result.Add(CreateModel(storehouse));
            }
            return result;
        }
        public List<StorehouseViewModel> GetFilteredList(StorehouseBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            List<StorehouseViewModel> result = new List<StorehouseViewModel>();
            foreach (var storehouse in source.Storehouse)
            {
                if (storehouse.StoreHouseName.Contains(model.StoreHouseName))
                {
                    result.Add(CreateModel(storehouse));
                }
            }
            return result;
        }
        public StorehouseViewModel GetElement(StorehouseBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            foreach (var storehouse in source.Storehouse)
            {
                if (storehouse.Id == model.Id || storehouse.StoreHouseName ==
                model.StoreHouseName)
                {
                    return CreateModel(storehouse);
                }
            }
            return null;
        }
        public void Insert(StorehouseBindingModel model)
        {
            Storehouse tempStore = new Storehouse { Id = 1, StorehouseComponents = new Dictionary<int, (string, int)>() };
            foreach (var Store in source.Storehouse)
            {
                if (Store.Id >= tempStore.Id)
                {
                    tempStore.Id = Store.Id + 1;
                }
            }
            source.Storehouse.Add(CreateModel(model, tempStore));
        }
        public void Update(StorehouseBindingModel model)
        {
            Storehouse tempStorrehouse = null;
            foreach (var storhouse in source.Storehouse)
            {
                if (storhouse.Id == model.Id)
                {
                    tempStorrehouse = storhouse;
                }
            }
            if (tempStorrehouse == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, tempStorrehouse);
        }
        public void Delete(StorehouseBindingModel model)
        {
            for (int i = 0; i < source.Storehouse.Count; ++i)
            {
                if (source.Storehouse[i].Id == model.Id)
                {
                    source.Storehouse.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
        private Storehouse CreateModel(StorehouseBindingModel model, Storehouse storehouse)
        {
            storehouse.StoreHouseName = model.StoreHouseName;
            storehouse.FullNameResponsiblePerson = model.FullNameResponsiblePerson;
            storehouse.DateCreate = model.DateCreate;
            // удаляем убранные
            foreach (var key in storehouse.StorehouseComponents.Keys.ToList())
            {
                if (!model.StorehouseComponents.ContainsKey(key))
                {
                    storehouse.StorehouseComponents.Remove(key);
                }
            }
            // обновляем существуюущие и добавляем новые
            foreach (var component in model.StorehouseComponents)
            {
                if (storehouse.StorehouseComponents.ContainsKey(component.Key))
                {
                    storehouse.StorehouseComponents[component.Key] =
                    model.StorehouseComponents[component.Key];
                }
                else
                {
                    storehouse.StorehouseComponents.Add(component.Key,
                    model.StorehouseComponents[component.Key]);
                }
            }
            return storehouse;
        }
        private StorehouseViewModel CreateModel(Storehouse store)
        {
            // требуется дополнительно получить список компонентов для изделия с названиями и их количество
            Dictionary<int, (string, int)> StoreComponents = new Dictionary<int, (string, int)>();
            foreach (var sc in store.StorehouseComponents)
            {
                string componentName = string.Empty;
                foreach (var component in source.Components)
                {
                    if (sc.Key == component.Id)
                    {
                        componentName = component.ComponentName;
                        break;
                    }
                }
                StoreComponents.Add(sc.Key, (componentName, sc.Value.Item2));
            }
            return new StorehouseViewModel
            {
                Id = store.Id,
                StoreHouseName = store.StoreHouseName,
                FullNameResponsiblePerson = store.FullNameResponsiblePerson,
                DateGreate = store.DateCreate,
                StorehouseComponents = StoreComponents
            };
        }

        void IStorehouse.Availability(StorehouseBindingModel houseBindingModel, int StorehouseId, int ComponentId, int Count, string ComponentName)
        {
            throw new NotImplementedException();
        }

        bool IStorehouse.Extract(int PackCount, int PackId)
        {
            throw new NotImplementedException();
        }
    }
}
