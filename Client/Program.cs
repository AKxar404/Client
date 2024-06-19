using System;
using System.Net.Sockets;
using System.Text;

class Client
{
    static void Main(string[] args)
    {
        try
        {
            // Conecta al servidor en el puerto 13000
            Int32 port = 13000;
            TcpClient client = new TcpClient("127.0.0.1", port);

            // Obtiene el stream para leer y escribir datos
            NetworkStream stream = client.GetStream();

            // Mensaje para enviar
            string message = "SOY el cliente loooool";
            byte[] data = Encoding.ASCII.GetBytes(message);

            // Envía el mensaje al servidor
            stream.Write(data, 0, data.Length);
            Console.WriteLine("Enviado: {0}", message);

            // Buffer para leer la respuesta del servidor
            data = new byte[256];
            String responseData = String.Empty;

            // Lee la respuesta del servidor
            Int32 bytes = stream.Read(data, 0, data.Length);
            responseData = Encoding.ASCII.GetString(data, 0, bytes);
            Console.WriteLine("Recibido: {0}", responseData);

            // Cierra todo
            stream.Close();
            client.Close();
        }
        catch (ArgumentNullException e)
        {
            Console.WriteLine("ArgumentNullException: {0}", e);
        }
        catch (SocketException e)
        {
            Console.WriteLine("SocketException: {0}", e);
        }

        Console.WriteLine("\nPresiona ENTER para continuar...");
        Console.Read();
    }
}