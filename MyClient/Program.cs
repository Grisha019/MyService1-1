using System;
using System.ServiceModel;
using WCFMyServiceLibrary;

namespace my_client
{
    class Program
    {
        static void Main(string[] args)
        {
            // Задаём адрес нашей службы
            Uri tcpUri = new Uri("http://localhost:8000/MyService");
            // Создаём сетевой адрес, с которым клиент будет взаимодействовать
            EndpointAddress address = new EndpointAddress(tcpUri);
            BasicHttpBinding binding = new BasicHttpBinding();
            // Данный класс используется клиентами для отправки сообщений
            ChannelFactory<IMyService> factory = new ChannelFactory<IMyService>(binding, address);
            // Открываем канал для общения клиента с со службой
            IMyService service = factory.CreateChannel();

            // Записываем в первый файл
            service.WriteToFile("1 файл", "text.txt");
            Console.WriteLine("Текст записан в файл text.txt.");

            // Записываем во второй файл
            service.WriteToFile("2 файл", "text2.txt");
            Console.WriteLine("Текст записан в файл text2.txt.");

            // Читаем из первого файла
            Console.WriteLine("Содержимое первого файла:");
            Console.WriteLine(service.ReadFromFile("text.txt"));

            // Читаем из второго файла
            Console.WriteLine("Содержимое второго файла:");
            Console.WriteLine(service.ReadFromFile("text2.txt"));

            Console.ReadLine();
        }
    }
}