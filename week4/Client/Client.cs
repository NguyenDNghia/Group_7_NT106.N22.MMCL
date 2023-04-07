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
namespace Client
{
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            // Connect();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Send();
                AddMess(txtName.Text + ": " + txtbox.Text);
            }
            catch
            {
              
                MessageBox.Show("Chưa kết nối tới server nên không thể gửi tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
        }
        IPEndPoint IP;
        Socket client;



        
        void Close()
        {
            client.Close();
        }

        void Send()
        {
            if (txtbox.Text != string.Empty)
            {
                client.Send(Serialize(txtName.Text+": "+txtbox.Text));
            }
        }
        void Receive()
        {
            try
            {
                while (true)
                {
                    byte[] data = new byte[1024*5000];
                    client.Receive(data);
                    string mess = (string)Deseriliaze(data);

                    AddMess(mess);
                }
            }
            catch
            {
                Close();
            }
        }

        void AddMess(string s)
        {
           // string a = txtName.Text + ": " + s;
            listView1.Items.Add(new ListViewItem() { Text = s });
            txtbox.Clear();
        }




        byte[] Serialize(object obj)
        {
            //khởi tạo stream để lưu các byte phân mảnh
            MemoryStream stream = new MemoryStream();
            //khởi tạo đối tượng BinaryFormatter để phân mảnh dữ liệu sang kiểu byte
            BinaryFormatter formatter = new BinaryFormatter();
            //phân mảnh rồi ghi vào stream
            formatter.Serialize(stream, obj);
            //từ stream chuyển các các byte thành dãy rồi cbi gửi đi
            return stream.ToArray();
        }

        //Hàm gom mảnh các byte nhận được rồi chuyển sang kiểu string để hiện thị lên màn hình
        object Deseriliaze(byte[] data)
        {
            //khởi tạo stream đọc kết quả của quá trình phân mảnh 
            MemoryStream stream = new MemoryStream(data);
            //khởi tạo đối tượng chuyển đổi
            BinaryFormatter formatter = new BinaryFormatter();
            //chuyển đổi dữ liệu và lưu lại kết quả 
            return formatter.Deserialize(stream);
        }


        private void Client_Load(object sender, EventArgs e)
        {

        }

        private void Client_close(object sender, FormClosedEventArgs e)
        {
            Close();
        }



        private void btnOK_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string ip = txtServerIP.Text;
            IP = new IPEndPoint(IPAddress.Parse(ip), Int32.Parse(txtport.Text));
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);

         

            try
            {

                 client.Connect(IP);
                 client.Send(Serialize(txtName.Text + " đã vào phòng "));
                MessageBox.Show("Ket noi thanh cong !", "Success", MessageBoxButtons.OK, MessageBoxIcon.None);
              

            }
            catch
            {
                MessageBox.Show("Khong the ket noi toi server !", "Loi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Thread listen = new Thread(Receive);
            listen.IsBackground = true;
            listen.Start();

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            btnOK.Enabled = true;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtServerIP.Text  = "";
            txtport.Text = "";
            client.Send(Serialize(txtName.Text + " đã rời phòng "));
            client.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void Client_FormClosed(object sender, FormClosedEventArgs e)
        {
            MessageBox.Show("Thoát?");
            try
            {
                client.Send(Serialize(txtName.Text + " đã rời phòng "));

                client.Close();
            }
            catch { }
        }
    }
}
