using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;
using Newtonsoft.Json;
using SenderObj.Model;

namespace ReceiverObj
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = ConfigurationSettings.AppSettings["serviceBusCS"].ToString();
            var queueName = "";

            var client = QueueClient.CreateFromConnectionString(connectionString, queueName);

            client.OnMessage((msg) => {
                var content = msg.GetBody<String>();
                var pedido = JsonConvert.DeserializeObject<Pedido>(content);

                Console.WriteLine($"O Pedido {pedido.NroPedido} do Cliente {pedido.IdClient} - No valor de {pedido.Valor} ");

                msg.Complete();
            });

            Console.ReadKey();
        }
    }
}
