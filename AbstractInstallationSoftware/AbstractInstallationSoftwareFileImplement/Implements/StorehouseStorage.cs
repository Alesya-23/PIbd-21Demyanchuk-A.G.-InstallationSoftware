using AbstractInstallationSoftBusinessLogic.BindingModels;
using AbstractInstallationSoftBusinessLogic.Interfaces;
using AbstractInstallationSoftBusinessLogic.ViewModels;
using AbstractInstallationSoftwareFileImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractInstallationSoftwareFileImplement.Implements
{
    public class StorehouseStorage : IStorehouse
    {
        private readonly FileDataListSingleton source;
        public StorehouseStorage()
        {
            source = FileDataListSingleton.GetInstance();
        }
        public List<StorehouseViewModel> GetFullList()
        {
            return source.Storehouses
            .Select(CreateModel)
            .ToList();
        }
        public List<StorehouseViewModel> GetFilteredList(StorehouseBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            return source.Storehouses
          .Where(rec => rec.StoreHouseName.Contains(model.StoreHouseName))
          .Select(CreateModel)
          .ToList();
        }
        public StorehouseViewModel GetElement(StorehouseBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            var house = source.Storehouses
         .FirstOrDefault(rec => rec.StoreHouseName == model.StoreHouseName || rec.Id == model.Id);
            return house != null ? CreateModel(house) : null;
        }
        public void Insert(StorehouseBindingModel model)
        {
            int maxId = source.Storehouses.Count > 0 ? source.Components.Max(rec => rec.Id) : 0;
            var element = new Storehouse { Id = maxId + 1, StorehouseComponents = new Dictionary<int, (string, int)>() };
            source.Storehouses.Add(CreateModel(model, element));
        }
        public void Update(StorehouseBindingModel model)
        {
            var element = source.Storehouses.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, element);
        }
        public void Delete(StorehouseBindingModel model)
        {
            Storehouse element = source.Storehouses.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                source.Storehouses.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
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
        private StorehouseViewModel CreateModel(Storehouse house)
        {
            return new StorehouseViewModel
            {
                Id = house.Id,
                StoreHouseName = house.StoreHouseName,
                FullNameResponsiblePerson = house.FullNameResponsiblePerson,
                DateGreate = house.DateCreate,
                StorehouseComponents = house.StorehouseComponents
                .ToDictionary(recPC => recPC.Key, recPC => recPC.Value)
            };
        }
        public void Availability(StorehouseBindingModel houseBindingModel, int StorehouseId, int ComponentId, int Count, string ComponentName)
        {
            StorehouseViewModel view = GetElement(new StorehouseBindingModel
            {
                Id = StorehouseId
            });

            if (view != null)
            {
                houseBindingModel.StorehouseComponents = view.StorehouseComponents;
                houseBindingModel.DateCreate = view.DateGreate;
                houseBindingModel.Id = view.Id;
                houseBindingModel.FullNameResponsiblePerson = view.FullNameResponsiblePerson;
                houseBindingModel.StoreHouseName = view.StoreHouseName;
            }

            if (houseBindingModel.StorehouseComponents.ContainsKey(ComponentId))
            {
                int count = houseBindingModel.StorehouseComponents[ComponentId].Item2;
                houseBindingModel.StorehouseComponents[ComponentId] = (ComponentName, count + Count);
            }
            else
            {
                houseBindingModel.StorehouseComponents.Add(ComponentId, (ComponentName, Count));
            }
            Update(houseBindingModel);
        }
        public bool Extract(int PackCount, int PackId)
        {
            var list = GetFullList();

            var DCount = source.Packages.FirstOrDefault(rec => rec.Id == PackId).PackageComponents;

            DCount = DCount.ToDictionary(rec => rec.Key, rec => rec.Value * PackCount);

            Dictionary<int, int> Have = new Dictionary<int, int>();

            foreach (var view in list)
            {
                foreach (var d in view.StorehouseComponents)
                {
                    int key = d.Key;
                    if (DCount.ContainsKey(key))
                    {
                        if (Have.ContainsKey(key))
                        {
                            Have[key] += d.Value.Item2;
                        }
                        else
                        {
                            Have.Add(key, d.Value.Item2);
                        }
                    }
                }
            }

            foreach (var key in Have.Keys)
            {
                if (DCount[key] > Have[key])
                {
                    return false;
                }
            }

            foreach (var view in list)
            {
                var houseComponents = view.StorehouseComponents;
                foreach (var key in view.StorehouseComponents.Keys.ToArray())
                {
                    var value = view.StorehouseComponents[key];
                    if (DCount.ContainsKey(key))
                    {
                        if (value.Item2 > DCount[key])
                        {
                            houseComponents[key] = (value.Item1, value.Item2 - DCount[key]);
                            DCount[key] = 0;
                        }
                        else
                        {
                            houseComponents[key] = (value.Item1, 0);
                            DCount[key] -= value.Item2;
                        }
                        Update(new StorehouseBindingModel
                        {
                            Id = view.Id,
                            StoreHouseName = view.StoreHouseName,
                            FullNameResponsiblePerson = view.FullNameResponsiblePerson,
                            DateCreate = view.DateGreate,
                            StorehouseComponents = houseComponents
                        });
                    }
                }
            }
            return true;
        }
    }
}