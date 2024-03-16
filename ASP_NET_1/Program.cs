using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ASP_NET_1
{
    internal class Program
    {
        static void Main(string[] args)
        {



     
            IPAddress ip =IPAddress.Parse("127.0.0.1");
            IPEndPoint ipEnd = new IPEndPoint(ip, 1024);
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            try
            {

                var buffer = new byte[1024];
                string strMessage = "One day your knees will buckle under the weight of your endless sins. I will not be there to save you.";
                int rec = 0;


                socket.Connect(ipEnd);
                if(socket.Connected) 
                {
                    do
                    {
                        var message = Encoding.ASCII.GetBytes(strMessage);
                        socket.Send(message);




                        rec = socket.Receive(buffer);
                        Console.WriteLine(Encoding.ASCII.GetString(buffer, 0, rec));

                        Thread.Sleep(1000);
                    } while (rec > 0);
                }
                else
                {
                    Console.WriteLine("Connection error :(");
                }
            }
            catch (SocketException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(Exception ex) 
            { 
                Console.WriteLine(ex.Message);
            }
            finally 
            { 
                //socket?.Shutdown(SocketShutdown.Both);
                
                //socket.Close(); 
            }

        }

        async Task SendData(Socket socket, string strMessage)
        {

            
        }
    }
}
