using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class Server : Form
    {
        public Server()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            // Connect();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Socket item in clientList)
            {
                Send(item);
            }
            AddMessage("Admin : " +txtbox.Text);
            txtbox.Clear();
        }

        private void txtbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        IPEndPoint IP;
        Socket server;
        List<Socket> clientList;


        void Connect()
        {
            clientList = new List<Socket>();
            IP = new IPEndPoint(IPAddress.Any, Int32.Parse(txtport.Text));
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            server.Bind(IP);
            AddMessage("Bắt đầu lắng nghe tại port "+ txtport.Text);
            Thread Listen = new Thread(() =>
            {
                try
                {
                    while (true)
                    {
                        server.Listen(100);
                        Socket client = server.Accept();
                        clientList.Add(client);
                        Thread rev = new Thread(Receive);
                        rev.IsBackground = true;
                        rev.Start(client);
                     
                    }
                }
                catch
                {
                    IP = new IPEndPoint(IPAddress.Any, Int32.Parse(txtport.Text));
                    server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                }
            });


            Listen.IsBackground = true;
            Listen.Start();



        }
        void Close(){ server.Close();}
        void Send(Socket client)
        {
            if ((client != null) && (txtbox.Text != string.Empty))
            {
                client.Send(Serialize( "Admin : " + txtbox.Text));
               
            }
        }//
        void Receive(object obj)
        {
            Socket client = obj as Socket;
            try
            {
                while (true)
                {
                    //khởi tạo mảng byte để nhận dữ liệu
                    byte[] data = new byte[1024 * 5000];
                    client.Receive(data);
                    //chuyển data từ dạng byte sang dạng string

                    string message = (string)Deserialize(data);

                    //khi 1 client gửi thì cả server và các client (ngoại trừ thằng client vừa gửi) cùng nhận đc
                    foreach (Socket item in clientList)
                    {
                        if (item != null && item != client)
                        {
                            item.Send(Serialize(message));
                        }
                    }

                    AddMessage(message);
                }
            }
            catch
            {
                clientList.Remove(client);
                client.Close();
            }
        }

        //add mesage vào khung chat
        void AddMessage(string s)
        {
            listView1.Items.Add(new ListViewItem() { Text = s });
        }

        //Hàm phân mảnh dữ liệu cần gửi từ dạng string sang dạng byte để gửi đi

        byte[] Serialize(object obj)
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, obj);
            return stream.ToArray();
        } // phan manh
        object Deserialize(byte[] data)
        {
            MemoryStream stream = new MemoryStream(data);
            BinaryFormatter formatter = new BinaryFormatter();
            return formatter.Deserialize(stream);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void cnt_Click(object sender, EventArgs e)
        {
            Connect();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            server.Close();
            AddMessage("Server ngắt kết nối ");
        }
    }
}
