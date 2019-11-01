using System;
using System.Threading;

namespace RabbitMq1
{
    class Program
    {
        static void Main(string[] args)
        {
            new MqHelper.ConsumerHelper("bilgeadam");

            while (true)
            {
                new MqHelper.PublisherHelper(queueName: "bilgeadam", message: "test 1 2 3");
                Thread.Sleep(millisecondsTimeout:1000);
            }

        }
    }
}
