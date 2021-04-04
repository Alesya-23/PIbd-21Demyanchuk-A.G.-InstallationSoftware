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
    private readonly PackageLogic _product;
    private readonly OrderLogic _main;
    public MainController(OrderLogic order, PackageLogic product, OrderLogic main)
    {
        _order = order;
        _product = product;
        _main = main;
    }
    [HttpGet]
    public List<PackageViewModel> GetProductList() => _product.Read(null)?.ToList();
    [HttpGet]
    public PackageViewModel GetProduct(int productId) => _product.Read(new
   PackageBindingModel
    { Id = productId })?[0];
    [HttpGet]
    public List<OrderViewModel> GetOrders(int clientId) => _order.Read(new
   OrderBindingModel
    { ClientId = clientId });
    [HttpPost]
    public void CreateOrder(CreateOrderBindingModel model) =>
   _main.CreateOrder(model);
}
