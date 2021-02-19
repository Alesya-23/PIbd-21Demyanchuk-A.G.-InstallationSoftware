using AbstractInstallationSoftBusinessLogic.BindingModels;
using AbstractInstallationSoftBusinessLogic.Interfaces;
using AbstractInstallationSoftBusinessLogic.ViewModels;
using AbstractInstallationSoftListImplement;
using AbstractInstallationSoftwareFileImplement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractIntstallationSoftwareListImplement
{
    public class OrderStorage : IOrderStorage
    { 
        private readonly FileDataListSingleton source;
        public OrderStorage()
        {
            source = FileDataListSingleton.GetInstance();
        }
        public List<OrderViewModel> GetFullList()
        {
            return source.Orders
            .Select(CreateModel)
           .ToList();
        }
        public List<OrderViewModel> GetFilteredList(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            return source.Orders
            .Where(rec => rec.Pa.Contains(model.Nam))
           .Select(CreateModel)
            .ToList();
        }
        public ComponentViewModel GetElement(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            var component = source.Components
            .FirstOrDefault(rec => rec.ComponentName == model.ComponentName ||
           rec.Id == model.Id);
            return component != null ? CreateModel(component) : null;
        }
        public void Insert(ComponentBindingModel model)
        {
            int maxId = source.Components.Count > 0 ? source.Components.Max(rec =>
           rec.Id) : 0;
            var element = new Component { Id = maxId + 1 };
            source.Components.Add(CreateModel(model, element));
        }
        public void Update(ComponentBindingModel model)
        {
            var element = source.Components.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, element);
        }
        public void Delete(ComponentBindingModel model)
        {
            Component element = source.Components.FirstOrDefault(rec => rec.Id ==
           model.Id);
            if (element != null)
            {
                source.Components.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        private Component CreateModel(ComponentBindingModel model, Component component)
        {
            component.ComponentName = model.ComponentName;
            return component;
        }
        private ComponentViewModel CreateModel(Component component)
        {
            return new ComponentViewModel
            {
                Id = component.Id,
                ComponentName = component.ComponentName
            };
        }
    }
}
