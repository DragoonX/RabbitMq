using RabbitMQ.Client;
using System;
using System.Text;

namespace MqHelper
{
    public class PublisherHelper
    {
        public PublisherHelper(string queueName, string message)
        {
            ConnectionHelper connectionHelper = new ConnectionHelper();
            using (IConnection connection = connectionHelper.Connection())
            {
                using (IModel channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);
                    channel.BasicPublish(exchange: "", routingKey: queueName, mandatory: false, basicProperties: null, body: Encoding.UTF8.GetBytes(message));
                    Console.WriteLine("SEND: " + queueName + ", Message: " + message + ", Second: " + DateTime.Now.Millisecond);

                }
            }
        }
    }
}
