using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace notaz
{
    public partial class Form1:Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void cargar()
        {
            try
            {
                string titulo = "titulo de ejemplo";
                string texto = "texto de ejemplo. texto de ejemplo. texto de ejemplo. texto de ejemplo. texto de ejemplo. texto de ejemplo. texto de ejemplo. texto de ejemplo. texto de ejemplo. texto de ejemplo. texto de ejemplo. texto de ejemplo. ";
                string fecha = DateTime.Now.ToString();
                agregar(titulo,texto,fecha);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void agregar(string titulo, string texto, string fecha)
        {
            Form newMDIChild = new Form();
            Label tit = new Label();
            Label fec = new Label();
            TextBox txt = new TextBox();
            Button btn = new Button();
            Point txtLoc = new Point(0, 25);
            Point fecLoc = new Point(0, 130);
            Point btnLoc = new Point(0, 180);

            newMDIChild.FormBorderStyle = FormBorderStyle.None;
            tit.Text = titulo;
            fec.Text = fecha;
            fec.Location = fecLoc;
            txt.Text = texto;
            txt.Width = 200;
            txt.Multiline = true;
            txt.Height = 100;
            txt.BorderStyle = BorderStyle.None;
            txt.ReadOnly = true;
            btn.Text = "Abrir Nota";
            btn.Location = btnLoc;
            txt.Location = txtLoc;
            newMDIChild.Controls.Add(tit);
            newMDIChild.Controls.Add(txt);
            newMDIChild.Controls.Add(fec);
            newMDIChild.Controls.Add(btn);
            newMDIChild.TopMost = true;
            // Set the parent form of the child window.  
            newMDIChild.MdiParent = this;
            // Display the new form.  
            newMDIChild.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cargar();
        }
    }
}
