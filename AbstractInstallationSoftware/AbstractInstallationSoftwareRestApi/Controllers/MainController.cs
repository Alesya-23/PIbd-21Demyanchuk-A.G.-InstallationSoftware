using AbstractInstallationSoftBusinessLogic.BindingModels;
using AbstractInstallationSoftBusinessLogic.BusinessLogics;
using AbstractInstallationSoftBusinessLogic.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

[Route("api/[controller]/[action]")]
[ApiController]
public class MainController : ControllerBase
{
    private readonly OrderLogic _order;
    private readonly PackageLogic _package;
    private readonly OrderLogic _main;
    public MainController(OrderLogic order, PackageLogic package, OrderLogic main)
    {
        _order = order;
        _package = package;
        _main = main;
    }
    [HttpGet]
    public List<PackageViewModel> GetPackageList() => _package.Read(null)?.ToList();
    [HttpGet]
    public PackageViewModel GetPackage(int packageId) => _package.Read(new PackageBindingModel
    { Id = packageId })?[0];
    [HttpGet]
    public List<OrderViewModel> GetOrders(int clientId) => _order.Read(new OrderBindingModel
    { ClientId = clientId });
    [HttpGet]
    //public List<MessageInfoViewModel> GetMails(int clientId) => _order.Read(new OrderBindingModel
    //{ ClientId = clientId });
    [HttpPost]
    public void CreateOrder(CreateOrderBindingModel model) =>
   _main.CreateOrder(model);
}
