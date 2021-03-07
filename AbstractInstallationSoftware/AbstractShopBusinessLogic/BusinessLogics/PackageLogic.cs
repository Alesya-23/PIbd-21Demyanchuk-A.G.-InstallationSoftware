using AbstractInstallationSoftBusinessLogic.BindingModels;
using AbstractInstallationSoftBusinessLogic.Interfaces;
using AbstractInstallationSoftBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractInstallationSoftBusinessLogic.BusinessLogics
{
    public class PackageLogic
    {
        private readonly IPackageStorage _packageStorage;
        public PackageLogic(IPackageStorage packageStorage)
        {
            _packageStorage = packageStorage;
        }
        public List<PackageViewModel> Read(PackageBindingModel model)
        {
            if (model == null)
            {
                return _packageStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<PackageViewModel> { _packageStorage.GetElement(model)
};
            }
            return _packageStorage.GetFilteredList(model);
        }
        public void CreateOrUpdate(PackageBindingModel model)
        {
            var element = _packageStorage.GetElement(new PackageBindingModel
            {
                PackageName = model.PackageName
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть компонент с таким названием");
            }
            if (model.Id.HasValue)
            {
                _packageStorage.Update(model);
            }
            else
            {
                _packageStorage.Insert(model);
            }
        }
        public void Delete(PackageBindingModel model)
        {
            var element = _packageStorage.GetElement(new PackageBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            _packageStorage.Delete(model);
        }
    }
}
