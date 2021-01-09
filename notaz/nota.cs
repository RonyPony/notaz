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
    public partial class nota : Form
    {

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        public string id;
        data con = new data();

        public nota(string noteId)
        {
            InitializeComponent();
            id = noteId;
            this.FormBorderStyle = FormBorderStyle.None; // no borders
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true); // this is to avoid visual artifacts
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            guardar();
            this.Close();
            
        }


        //protected override void OnPaint(PaintEventArgs e) // you can safely omit this method if you want
        //{
        //    e.Graphics.FillRectangle(Brushes.Yellow, Top);
        //    e.Graphics.FillRectangle(Brushes.Yellow, Left);
        //    e.Graphics.FillRectangle(Brushes.Yellow, Right);
        //    e.Graphics.FillRectangle(Brushes.Yellow, Bottom);
        //}

        private const int
            HTLEFT = 10,
            HTRIGHT = 11,
            HTTOP = 12,
            HTTOPLEFT = 13,
            HTTOPRIGHT = 14,
            HTBOTTOM = 15,
            HTBOTTOMLEFT = 16,
            HTBOTTOMRIGHT = 17;

        const int _ = 10; // you can rename this variable if you like

        Rectangle Top { get { return new Rectangle(0, 0, this.ClientSize.Width, _); } }
        Rectangle Left { get { return new Rectangle(0, 0, _, this.ClientSize.Height); } }
        Rectangle Bottom { get { return new Rectangle(0, this.ClientSize.Height - _, this.ClientSize.Width, _); } }
        Rectangle Right { get { return new Rectangle(this.ClientSize.Width - _, 0, _, this.ClientSize.Height); } }

        Rectangle TopLeft { get { return new Rectangle(0, 0, _, _); } }
        Rectangle TopRight { get { return new Rectangle(this.ClientSize.Width - _, 0, _, _); } }
        Rectangle BottomLeft { get { return new Rectangle(0, this.ClientSize.Height - _, _, _); } }
        Rectangle BottomRight { get { return new Rectangle(this.ClientSize.Width - _, this.ClientSize.Height - _, _, _); } }


        protected override void WndProc(ref Message message)
        {
            base.WndProc(ref message);

            if (message.Msg == 0x84) // WM_NCHITTEST
            {
                var cursor = this.PointToClient(Cursor.Position);

                if (TopLeft.Contains(cursor)) message.Result = (IntPtr)HTTOPLEFT;
                else if (TopRight.Contains(cursor)) message.Result = (IntPtr)HTTOPRIGHT;
                else if (BottomLeft.Contains(cursor)) message.Result = (IntPtr)HTBOTTOMLEFT;
                else if (BottomRight.Contains(cursor)) message.Result = (IntPtr)HTBOTTOMRIGHT;

                else if (Top.Contains(cursor)) message.Result = (IntPtr)HTTOP;
                else if (Left.Contains(cursor)) message.Result = (IntPtr)HTLEFT;
                else if (Right.Contains(cursor)) message.Result = (IntPtr)HTRIGHT;
                else if (Bottom.Contains(cursor)) message.Result = (IntPtr)HTBOTTOM;
            }
        }
    

    private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.TopMost = false;
            pictureBox3.Visible = true;
            pictureBox2.Visible = false;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.TopMost = true;
            pictureBox2.Visible = true;
            pictureBox3.Visible = false ;
        }

        
        


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox3_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            ParentForm.Show();
        }

        private void nota_Load(object sender, EventArgs e)
        {
            cargarNota();
            txtnota.Focus();
            timer1.Start();
        }

        private void cargarNota()
        {
            try
            {
                DataTable tabla = con.getTable("notas", "idnota="+id);

                foreach (DataRow item in tabla.Rows)
                {
                    string id = item[0].ToString();
                    string nota = item[1].ToString();
                    string titulo = item[2].ToString();
                    string fecha = item[3].ToString();
                    txttitulo.Text = titulo;
                    txtnota.Text = nota;
                    label1.Text = fecha;
                }
                //agregar(titulo,texto,fecha);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void guardar()
        {
                try
                {
                    Console.WriteLine("Guardando");
                    //con.save("notas", "idnota,nota,titulo,fecha", "'" + id + "','" + txtnota.Text + "','" + txttitulo.Text + "','" + DateTime.Now.ToString() + "'");
                    con.update("notas", "nota='" + txtnota.Text + "',titulo='" + txttitulo.Text + "',fecha='" + DateTime.Now.ToString() + "'", "idnota='" + id + "'");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            guardar();
        }
    }
}
