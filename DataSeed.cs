
using Advantage.API.Models;
using System.Linq;
using System.Collections.Generic;
using System;

namespace Advantage.API
{
    public class DataSeed
    {

        private readonly ApiContext _ctx;

        public DataSeed(ApiContext ctx)
        {
            _ctx = ctx;
        }

        public void SeedData(int nCustomer, int nOrders)
        {
            if (!_ctx.Customers.Any())
            {
                SeedCustomers(nCustomer);
                 _ctx.SaveChanges();
            }
            if (!_ctx.Orders.Any())
            {
                SeedOrders(nOrders);
                 _ctx.SaveChanges();
            }

            if (!_ctx.Servers.Any())
            {
                SeedServers();
                 _ctx.SaveChanges();
            }
        }

        private void SeedCustomers(int n)
        {
            List<Customer> Customers = BuildCustomerList(n);
            foreach (var customer in Customers)
            {
                _ctx.Customers.Add(customer);
            }
        }

        private void SeedOrders(int n)
        {
            List<Order> Orders = BuildOrderList(n);
            foreach (var order in Orders)
            {
                _ctx.Orders.Add(order);
            }
        }

        private void SeedServers()
        {
            List<Server> Servers = BuildServerList();
            foreach (var server in Servers)
            {
                _ctx.Servers.Add(server);
            }

        }

        private List<Customer> BuildCustomerList(int n)
        {
            var customers = new List<Customer>();
            var names = new List<string>();

            for (var i = 1; i <= n; i++)
            {
                var name = Helpers.MakeCustomerName(names);
                names.Add(name);

                customers.Add(new Customer
                {
                    Id = i,
                    Name = name,
                    Email = Helpers.MakeCustomerEmail(name),
                    State = Helpers.GetRandomState()
                });
            }
            return customers;
        }

        private List<Order> BuildOrderList(int n)
        {
            var orders = new List<Order>();
            var rand = new Random();

            for (var i = 1; i <= n; i++)
            {
                var randCustomerID = rand.Next(1, _ctx.Customers.Count());
                var placed = Helpers.GetRandomOrderPlaced();
                var completed = Helpers.GetRandomOrdercompleted(placed);
                var customers = _ctx.Customers.ToList();

                orders.Add(new Order
                {
                    Id = i,
                    Customer = customers.First(x => x.Id == randCustomerID),
                    Total = Helpers.GetRandomTotal(),
                    Placed = placed,
                    Completed = completed
                });
            }
            return orders;
        }


        private List<Server> BuildServerList()
        {
            var Servers = new List<Server>();

            return new List<Server>()
            {
                new Server
                {
                    Id =1,
                    Name = "Dev-Web",
                    IsOnline = true
                },
                new Server
                {
                    Id =2,
                    Name = "Dev-Web-service",
                    IsOnline = true
                },
                 new Server
                {
                    Id =3,
                    Name = "Dev-Web-mail",
                    IsOnline = false
                },
                 new Server
                {
                    Id =4,
                    Name = "QA-Web",
                    IsOnline = true
                },
                new Server
                {
                    Id =5,
                    Name = "QA-Web-service",
                    IsOnline = true
                },
                 new Server
                {
                    Id =6,
                    Name = "QA-Web-mail",
                    IsOnline = true
                },
                 new Server
                {
                    Id =7,
                    Name = "Prod-Web",
                    IsOnline = true
                },
                new Server
                {
                    Id =8,
                    Name = "Prod-Web-service",
                    IsOnline = true
                },
                 new Server
                {
                    Id =9,
                    Name = "Prod-Web-mail",
                    IsOnline = true
                }



            };

        }


    }
}