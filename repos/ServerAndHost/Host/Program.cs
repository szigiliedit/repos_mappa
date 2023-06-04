﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace Host
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Uri uri = new Uri("http://localhost:3000");
            WebHttpBinding binding = new WebHttpBinding();
            using(ServiceHost host= new ServiceHost(typeof(Server.Service1),uri))
            {
                ServiceEndpoint endpoint = host.AddServiceEndpoint(typeof(Server.IService1), binding, "");
                endpoint.EndpointBehaviors.Add(new WebHttpBehavior());
                host.Open();
                Console.WriteLine($"A Szerver elindult: {DateTime.Now} ");
                Console.ReadKey();
                host.Close();
            }
        }
    }
}
