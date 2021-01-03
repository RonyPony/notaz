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
            button2.PerformClick();
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
            dataGridView1.Rows.Add(titulo,texto,fecha);
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cargar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            formManager ff = new formManager();
            ff.createForm();
        }
    }
}
