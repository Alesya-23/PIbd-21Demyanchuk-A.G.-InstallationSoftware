using AbstractInstallationSoftBusinessLogic.BindingModels;
using AbstractInstallationSoftBusinessLogic.Interfaces;
using AbstractInstallationSoftBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractInstallationSoftBusinessLogic.BusinessLogics
{
    public class StorehouseLogic
    {
        private readonly IStorehouse _storehouseStorage;
        private readonly IComponentStorage _componentStorage;
        public StorehouseLogic(IStorehouse storehouseStorage, IComponentStorage componentStorage)
        {
            _storehouseStorage = storehouseStorage;
            _componentStorage = componentStorage;
        }
        public List<StorehouseViewModel> Read(StorehouseBindingModel model)
        {
            if (model == null)
            {
                return _storehouseStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<StorehouseViewModel> { _storehouseStorage.GetElement(model) };
            }
            return _storehouseStorage.GetFilteredList(model);
        }
        public void CreateOrUpdate(StorehouseBindingModel model)
        {
            var element = _storehouseStorage.GetElement(new StorehouseBindingModel
            {
                StoreHouseName = model.StoreHouseName
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть компонент с таким названием");
            }
            if (model.Id.HasValue)
            {
                _storehouseStorage.Update(model);
            }
            else
            {
                _storehouseStorage.Insert(model);
            }
        }
        public void Delete(StorehouseBindingModel model)
        {
            var element = _storehouseStorage.GetElement(new StorehouseBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            _storehouseStorage.Delete(model);
        }
        public void FillStore(StorehouseBindingModel model, int compId, int count)
        {
            var store = _storehouseStorage.GetElement(new StorehouseBindingModel { Id = model.Id });

            if (store.StorehouseComponents.ContainsKey(compId))
            {
                store.StorehouseComponents[compId] =
                    (store.StorehouseComponents[compId].Item1, store.StorehouseComponents[compId].Item2 + count);
                _storehouseStorage.Update(new StorehouseBindingModel
                {
                    Id = store.Id,
                    StoreHouseName = store.StoreHouseName,
                    FullNameResponsiblePerson = store.FullNameResponsiblePerson,
                    DateCreate = store.DateGreate,
                    StorehouseComponents = store.StorehouseComponents
                });
            }
            else
            {
                var component = _componentStorage.GetElement(new ComponentBindingModel
                {
                    Id = compId
                });
                if (component == null)
                {
                    throw new Exception("Компонент не найден");
                }
                store.StorehouseComponents.Add(compId, (component.ComponentName, count));
                _storehouseStorage.Update(new StorehouseBindingModel
                {
                    Id = store.Id,
                    StoreHouseName = store.StoreHouseName,
                    FullNameResponsiblePerson = store.FullNameResponsiblePerson,
                    DateCreate = store.DateGreate,
                    StorehouseComponents = store.StorehouseComponents
                });
            }
        }
    }
}
