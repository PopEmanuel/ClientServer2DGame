using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicMultiplayerGameVS.Repository;
using BasicMultiplayerGameVS.Entities.Player;
using BasicMultiplayerGameVS.Exceptions;
using BasicMultiplayerGameVS.Enums;
using System.Net.Sockets;
using System.Net;

namespace BasicMultiplayerGameVS.Controller
{
    internal class Service
    {
        private Repo _repository;
        private Form1 _parentForm;
        private NetworkStream stream;

        public int CurrentRoomId { get { return _repository.CurrentRoomId; } set { _repository.CurrentRoomId = value; } }
        public int CurrentPlayerId { get { return _repository.CurrentPlayerId; } set { _repository.CurrentPlayerId = value; } }

        public Service(Form1 parent)
        {
            _parentForm = parent;
            _repository = new Repo(_parentForm);

        }

        public Player[] getPlayers()
        {
            return _repository.Players;
        }

        public void addRoom(int id, string name, string imagePath, Size size)
        {

            try{
                _repository.addRoom(id, name, imagePath, size);
                
            }catch(Exception e)
            {
                Console.Error.WriteLine(e);
            }
            
        }

        public void addPlayer(int id, string name, Size size, Point coords, myShapes shape)
        {
            try
            {
                _repository.addPlayer(id, name, size, coords, shape);
            }catch (Exception e)
            {
                Console.Error.WriteLine(e);
            }
            
        }

        public void movePlayerX(int id, Movement mv)
        {
            try
            {
                _repository.movePlayerX(id, mv);
                if(id == CurrentPlayerId)
                {
                    byte[] msg = new byte[256];
                    if (mv == Movement.Right)
                        msg = Encoding.Default.GetBytes("movedLeft");
                    else
                        msg = Encoding.Default.GetBytes("movedRight");
                    stream.Write(msg, 0, msg.Length);
                }
                
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("moveplayerxexception");
            }
        }

        public void movePlayerY(int id, Movement mv)
        {
            try
            {
                _repository.movePlayerY(id, mv);
                if(id == CurrentPlayerId)
                {
                    byte[] msg = new byte[256];
                    if (mv == Movement.Up)
                        msg = Encoding.Default.GetBytes("movedUp");  //conversion string => byte array
                    else
                        msg = Encoding.Default.GetBytes("movedDown");
                    stream.Write(msg, 0, msg.Length);
                }
                
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e);
            }
        }

        public void launchServer(String ip)
        {

            IPAddress ipaddr = IPAddress.Parse(ip);
            System.Net.Sockets.TcpListener server = new TcpListener(ipaddr, 9999);
            System.Diagnostics.Debug.WriteLine(ipaddr.ToString());
            // we set our IP address as server's address, and we also set the port: 9999
            System.Diagnostics.Debug.WriteLine("beforewhile");
            server.Start();
            System.Diagnostics.Debug.WriteLine("after start");
            while (true)   //we wait for a connection
            {
                System.Diagnostics.Debug.WriteLine("inside while");
                TcpClient client = server.AcceptTcpClient();  //if a connection exists, the server will accept it

                stream = client.GetStream(); //networkstream is used to send/receive messages

                byte[] hello = new byte[256];   //any message must be serialized (converted to byte array)
                hello = Encoding.Default.GetBytes("hello world");  //conversion string => byte array

                stream.Write(hello, 0, hello.Length);     //sending the message
                System.Diagnostics.Debug.WriteLine("while");
                while (client.Connected)  //while the client is connected, we look for incoming messages
                {
                    System.Diagnostics.Debug.WriteLine("waiting client message");
                    byte[] msg = new byte[256];     //the messages arrive as byte array
                    Int32 bytes = stream.Read(msg, 0, msg.Length);   //the same networkstream reads the message sent by the client
                    String response = System.Text.Encoding.ASCII.GetString(msg, 0, bytes);
                    System.Diagnostics.Debug.WriteLine("Received the message :" + response);

                    if(response.Contains("moved"))
                    {
                        System.Diagnostics.Debug.WriteLine("MESSAGE CONTAINST MOVEMENT");
                        if (response == "movedUp")
                        {
                            this.movePlayerY(2, Movement.Up);
                        }               
                        if (response == "movedDown")
                            this.movePlayerY(2, Movement.Down);
                        if (response == "movedLeft")
                        {
      
                            this.movePlayerX(2, Movement.Right);
                        }
                            
                        if (response == "movedRight")
                            this.movePlayerX(2, Movement.Left);

                        this.InvalidateRoom();

                    }
                    // Console.WriteLine(encoder.GetString(msg).Trim('')); //now , we write the message as string
                }
            }


        }

        public void launchClient(String ip)
        {
            TcpClient client = new TcpClient(ip, 9999);
           // client.Connect(ip, 9999);
            System.Diagnostics.Debug.WriteLine("Connected to server");
            // Translate the passed message into ASCII and store it as a Byte array.
         

            // Get a client stream for reading and writing.
            //  Stream stream = client.GetStream();

            stream = client.GetStream();

            // Buffer to store the response bytes.
            byte[] data = new byte[256];

            // String to store the response ASCII representation.
            String responseData = String.Empty;

            // Read the first batch of the TcpServer response bytes.
            Int32 bytes = stream.Read(data, 0, data.Length);
            responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
            System.Diagnostics.Debug.WriteLine("Received: {0}", responseData);

            data = Encoding.Default.GetBytes("Salut");
            // Send the message to the connected TcpServer.
            while(client.Connected)
            {
                System.Diagnostics.Debug.WriteLine("waiting server message");
                byte[] msg = new byte[256];     //the messages arrive as byte array
                bytes = stream.Read(msg, 0, msg.Length);   //the same networkstream reads the message sent by the client
                String response = System.Text.Encoding.ASCII.GetString(msg, 0, bytes);
                System.Diagnostics.Debug.WriteLine("Received the message :" + response);

                if (response.Contains("moved"))
                {
                    System.Diagnostics.Debug.WriteLine("MESSAGE CONTAINST MOVEMENT");
                    if (response == "movedUp")
                    {

                        this.movePlayerY(1, Movement.Up);
                    }
                    if (response == "movedDown")
                        this.movePlayerY(1, Movement.Down);
                    if (response == "movedLeft")
                    {

                        this.movePlayerX(1, Movement.Right);
                    }

                    if (response == "movedRight")
                        this.movePlayerX(1, Movement.Left);

                    this.InvalidateRoom();

                }
            }

            System.Diagnostics.Debug.WriteLine("Sent: {0}", "Salut");

            
        }

        public Boolean createServer(String ip)
        {
            Thread thread = new Thread(() => launchServer(ip));
            thread.Start();

            return true;
        }

        public Boolean createClient(String ip)
        {
            Thread thread = new Thread(() => launchClient(ip));
            thread.Start();
            return true;
        }

        public void start()
        {
            _repository.start();
        }

        public void InvalidateRoom()
        {
            try
            {
                _repository.InvalidateRoom();
            }
            catch(Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
            }
        }
    }
}
