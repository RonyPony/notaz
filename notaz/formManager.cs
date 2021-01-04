using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace notaz
{
    class formManager
    {
        public void createForm()
        {

            Form newChild = new Form();
            Label tit = new Label();
            Label fec = new Label();
            TextBox txt = new TextBox();
            Button btn = new Button();
            Button fijar = new Button();
            Button cerrar = new Button();
            Panel panel1 = new Panel();
            Point ttlLoc = new Point(0, 50);
            Point txtLoc = new Point(0, 75);
            Point fecLoc = new Point(0, 130);
            Point btnLoc = new Point(0, 180);

            newChild.FormBorderStyle = FormBorderStyle.None;
            tit.Text = "lkjawgfijukreng";
            tit.Location = ttlLoc;
            fec.Text = DateTime.Now.ToString();
            fec.Location = fecLoc;
            txt.Text = "ikejrdnsgtoiuret q3irwjkethgfnoi93rkwejdtfoil3kresdhtnfojkersdntfoi3rlkewsdtjfnikejrdnsgtoiuret q3irwjkethgfnoi93rkwejdtfoil3kresdhtnfojkersdntfoi3rlkewsdtjfnikejrdnsgtoiuret q3irwjkethgfnoi93rkwejdtfoil3kresdhtnfojkersdntfoi3rlkewsdtjfnikejrdnsgtoiuret q3irwjkethgfnoi93rkwejdtfoil3kresdhtnfojkersdntfoi3rlkewsdtjfnikejrdnsgtoiuret q3irwjkethgfnoi93rkwejdtfoil3kresdhtnfojkersdntfoi3rlkewsdtjfnikejrdnsgtoiuret q3irwjkethgfnoi93rkwejdtfoil3kresdhtnfojkersdntfoi3rlkewsdtjfn";
            txt.Width = 200;
            txt.Multiline = true;
            txt.Height = 100;
            txt.BorderStyle = BorderStyle.None;
            txt.ReadOnly = true;
            btn.Text = "Abrir Nota";
            btn.Location = btnLoc;
            txt.Location = txtLoc;
            fijar.Text = "FIJAR";
            fijar.Location = new Point(10,10);
            fijar.Click += new System.EventHandler(fijo);
            cerrar.Text = "[X]";
            cerrar.Location = new Point(panel1.Width+20, 10);
            cerrar.Click += new System.EventHandler(klose);
            panel1.BackColor = System.Drawing.Color.Red;
            panel1.Location = new System.Drawing.Point(-2, 0);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(835, 39);
            panel1.TabIndex = 7;
            panel1.Controls.Add(fijar);
            panel1.Controls.Add(cerrar);
            newChild.Controls.Add(tit);
            newChild.Controls.Add(txt);
            newChild.Controls.Add(fec);
            newChild.Controls.Add(btn);
            newChild.Controls.Add(panel1);
            newChild.TopMost = true;
            //// Set the parent form of the child window.  
            //newMDIChild.MdiParent = this;
            //// Display the new form.  
            newChild.Show();
        }

        private void fijo(object sender, EventArgs e)
        {
            MessageBox.Show("fijadoz");
        }
        private void klose(object sender, EventArgs e)
        {
            MessageBox.Show("Test");
        }
    }
}
