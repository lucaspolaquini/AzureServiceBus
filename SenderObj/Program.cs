using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;
using SenderObj.Model;
using Newtonsoft.Json;

namespace SenderObj
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = ConfigurationSettings.AppSettings["serviceBusCS"].ToString();
            var queueName = "";
            var pedido = new Pedido();

            //NamespaceManager namespaceManager = NamespaceManager.CreateFromConnectionString(connectionString);
            //namespaceManager.CreateQueue("");

            var client = QueueClient.CreateFromConnectionString(connectionString, queueName);

            Console.WriteLine("Digite o ID Cliente");
            pedido.IdClient = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Digite o Valor do pedido");
            pedido.Valor = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Digite o Numero Pedido");
            pedido.NroPedido = Convert.ToInt32(Console.ReadLine());

            var msg = new BrokeredMessage(JsonConvert.SerializeObject(pedido));

            client.Send(msg);

            Console.Read();

        }
    }
}
