using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace notaz
{
    public partial class Form1:Form
    {
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        data con = new data();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cargar();
        }

        private void cargar()
        {
            try
            {
                DataTable tabla = con.getTable("notas",string.Empty);

                foreach (DataRow item in tabla.Rows)
                {
                    string id = item[0].ToString();
                    string nota = item[1].ToString();
                    string titulo = item[2].ToString();
                    string fecha = item[3].ToString();
                    agregar(id,titulo,nota,fecha);
                }
                //agregar(titulo,texto,fecha);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void agregar(string id,string titulo, string texto, string fecha)
        {
            dataGridView1.Rows.Add(id,titulo,texto,fecha);
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            nota nn = new nota(con.getCount("notas", string.Empty).ToString());
            nn.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            //formManager ff = new formManager();
            nota ff = new nota(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            //ff.createForm();
            ff.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            cargar();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.ShowInTaskbar = false;
            this.WindowState = FormWindowState.Minimized;
            NotifyIcon trayIcon = new NotifyIcon();
            //trayIcon.Icon = new Icon(@"C:\iconfilename.ico");
            trayIcon.Visible = true;
        }
    }
}
