using AbstractInstallationSoftBusinessLogic.BindingModels;
using AbstractInstallationSoftBusinessLogic.Interfaces;
using AbstractInstallationSoftBusinessLogic.ViewModels;
using AbstractInstallationSoftwareDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractInstallationSoftwareDatabaseImplement.Implements
{
    public class ClientStorage : IClientStorage
    {
        public List<ClientViewModel> GetFullList()
        {
            using (var context = new AbstractInstallSoftDatabase())
            {
                return context.Clients.Select(rec => new ClientViewModel
                {
                    Id = rec.Id,
                    ClientFullName = rec.ClientFullName,
                    Email = rec.Email,
                    Password = rec.Password,
                })
                .ToList();
            }
        }

        public List<ClientViewModel> GetFilteredList(ClientBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new AbstractInstallSoftDatabase())
            {
                return context.Clients.Include(x => x.Order)
                .Where(rec => rec.Email == model.Email && rec.Password == rec.Password)
                .Select(rec => new ClientViewModel
                {
                    Id = rec.Id,
                    ClientFullName = rec.ClientFullName,
                    Email = rec.Email,
                    Password = rec.Password,
                })
                .ToList();
            }
        }

        public ClientViewModel GetElement(ClientBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new AbstractInstallSoftDatabase())
            {
                var client = context.Clients.Include(x => x.Order)
                .FirstOrDefault(rec => rec.Email == model.Email ||
                rec.Id == model.Id);
                return client != null ?
                new ClientViewModel
                {
                    Id = client.Id,
                    ClientFullName = client.ClientFullName,
                    Email = client.Email,
                    Password = client.Password,
                } :
                null;
            }
        }

        public void Insert(ClientBindingModel model)
        {
            using (var context = new AbstractInstallSoftDatabase())
            {
                context.Clients.Add(CreateModel(model, new Client(), context));
                context.SaveChanges();
            }
        }

        public void Update(ClientBindingModel model)
        {
            using (var context = new AbstractInstallSoftDatabase())
            {
                var element = context.Clients.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Клиент не найден");
                }
                CreateModel(model, element, context);
                context.SaveChanges();
            }
        }

        public void Delete(ClientBindingModel model)
        {
            using (var context = new AbstractInstallSoftDatabase())
            {
                Client element = context.Clients.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Clients.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Клиент не найден");
                }
            }
        }

        private Client CreateModel(ClientBindingModel model, Client client, AbstractInstallSoftDatabase database)
        {
            client.ClientFullName = model.ClientFullName;
            client.Email = model.Email;
            client.Password = model.Password;
            return client;
        }
    }
}
