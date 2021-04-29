using AbstractInstallationSoftBusinessLogic.BindingModels;
using AbstractInstallationSoftBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractInstallationSoftBusinessLogic.Interfaces
{
    public interface IMessageInfoStorage
    {
        List<MessageInfoViewModel> GetFullList();
        List<MessageInfoViewModel> GetFilteredList(MessageInfoBindingModel model);
        void Insert(MessageInfoBindingModel model);
    }
}
