using AbstractInstallationSoftBusinessLogic.BindingModels;
using AbstractInstallationSoftBusinessLogic.Enums;
using AbstractInstallationSoftBusinessLogic.Interfaces;
using AbstractInstallationSoftBusinessLogic.ViewModels;
using AbstractInstallationSoftwareDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractInstallationSoftwareDatabaseImplement.Implements
{
    public class OrderStorage : IOrderStorage
    {
        public List<OrderViewModel> GetFullList()
        {
            using (var context = new AbstractInstallSoftDatabase())
            {
                return context.Orders.Include(rec => rec.Package).Include(rec => rec.Client).Include(rec => rec.Implementer).Select(rec => new OrderViewModel
                {
                    Id = rec.Id,
                    ClientId = rec.ClientId,
                    ClientFullName = rec.Client.ClientFullName,
                    ImplementerId = rec.ImplementerId,
                    ImplementerFIO = rec.ImplementerId.HasValue ? rec.Implementer.ImplementerFIO : string.Empty,
                    PackageName = rec.Package.PackageName,
                    PackageId = rec.PackageId,
                    Count = rec.Count,
                    Sum = rec.Sum,
                    Status = rec.Status,
                    DateCreate = rec.DateCreate,
                    DateImplement = rec.DateImplement
                }).ToList();
            }
        }
        public List<OrderViewModel> GetFilteredList(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new AbstractInstallSoftDatabase())
            {
                return context.Orders.Include(rec => rec.Package).Include(rec => rec.Client).Include(rec => rec.Implementer).
                Where(rec => (!model.DateFrom.HasValue && !model.DateTo.HasValue &&
                rec.DateCreate.Date == model.DateCreate.Date) ||
                 (model.DateFrom.HasValue && model.DateTo.HasValue &&
                rec.DateCreate.Date >= model.DateFrom.Value.Date && rec.DateCreate.Date <=
                model.DateTo.Value.Date) ||
                 (model.ClientId.HasValue && rec.ClientId == model.ClientId) ||
                (model.FreeOrders.HasValue && model.FreeOrders.Value && rec.Status ==
                OrderStatus.Принят) ||
                 (model.ImplementerId.HasValue && rec.ImplementerId ==
                model.ImplementerId && rec.Status == OrderStatus.Выполняется))
                .Select(rec => new OrderViewModel
                {
                    Id = rec.Id,
                    ClientId = rec.ClientId,
                    ClientFullName = rec.Client.ClientFullName,
                    ImplementerId = rec.ImplementerId,
                    ImplementerFIO = rec.ImplementerId.HasValue ? rec.Implementer.ImplementerFIO : string.Empty,
                    PackageName = rec.Package.PackageName,
                    PackageId = rec.PackageId,
                    Count = rec.Count,
                    Sum = rec.Sum,
                    Status = rec.Status,
                    DateCreate = rec.DateCreate,
                    DateImplement = rec.DateImplement
                }).ToList();
            }
        }
        public OrderViewModel GetElement(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new AbstractInstallSoftDatabase())
            {
                var order = context.Orders.Include(rec => rec.Package).Include(rec => rec.Client).Include(rec => rec.Implementer)
              .FirstOrDefault(rec => rec.Id == model.Id);
                return order != null ?
                new OrderViewModel
                {
                    Id = order.Id,
                    PackageName = order.Package.PackageName,
                    PackageId = order.PackageId,
                    ImplementerId = order.ImplementerId,
                    ImplementerFIO = order.ImplementerId.HasValue ? order.Implementer.ImplementerFIO : string.Empty,
                    Count = order.Count,
                    Sum = order.Sum,
                    Status = order.Status,
                    DateCreate = order.DateCreate,
                    DateImplement = order.DateImplement,
                    ClientId = order.ClientId,
                    ClientFullName = order.Client.ClientFullName,
                } : null;
            }
        }
        public void Insert(OrderBindingModel model)
        {
            using (var context = new AbstractInstallSoftDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Orders.Add(CreateModel(model, new Order()));
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        public void Update(OrderBindingModel model)
        {
            using (var context = new AbstractInstallSoftDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
                        if (element == null)
                        {
                            throw new Exception("Элемент не найден");
                        }
                        CreateModel(model, element);
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        public void Delete(OrderBindingModel model)
        {
            using (var context = new AbstractInstallSoftDatabase())
            {
                Order element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Orders.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        private Order CreateModel(OrderBindingModel model, Order order)
        {
            order.PackageId = model.PackageId;
            order.ClientId = (int)model.ClientId;
            order.Count = model.Count;
            order.Sum = model.Sum;
            order.Status = model.Status;
            order.DateCreate = model.DateCreate;
            order.DateImplement = model.DateImplement;
            order.ImplementerId = model.ImplementerId;
            return order;
        }
    }
}
