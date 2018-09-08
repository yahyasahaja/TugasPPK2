using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tugas2PPK
{
    public partial class Form1 : Form
    {
        int deg = 0;
        Image originImage;
        public Form1()
        {
            InitializeComponent();
            pictureBox_1086_1.MouseWheel += this.scrollHandler;
            panel2.MouseWheel += this.scrollHandler;
            this.KeyDown += this.keyDownHandler;
        }

        private void keyDownHandler(Object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Oemplus)
            {
                toolStripButton1_Click(sender, e);
            }
            else if (e.KeyCode == Keys.OemMinus)
            {
                toolStripButton2_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Right && e.Modifiers == Keys.Control)
            {
                toolStripButton4_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Left && e.Modifiers == Keys.Control)
            {
                toolStripButton3_Click(sender, e);
            }
        }

        public void scrollHandler(Object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                toolStripButton1_Click(sender, e);
            }
            else if (e.Delta < 0)
            {
                toolStripButton2_Click(sender, e);
            }
        }

        private void myPrintDocument2_PrintPage(System.Object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap myBitmap1 = new Bitmap(pictureBox_1086_1.Width, pictureBox_1086_1.Height);
            pictureBox_1086_1.DrawToBitmap(myBitmap1, new Rectangle(0, 0, pictureBox_1086_1.Width, pictureBox_1086_1.Height));
            e.Graphics.DrawImage(myBitmap1, 0, 0);
            myBitmap1.Dispose();
        }


        private void printToolStripButton_1086_1_Click(object sender, EventArgs e)
        {
            System.Drawing.Printing.PrintDocument myPrintDocument1 = new System.Drawing.Printing.PrintDocument();
            PrintDialog myPrinDialog1 = new PrintDialog();
            myPrintDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(myPrintDocument2_PrintPage);
            myPrinDialog1.Document = myPrintDocument1;
            
            if (myPrinDialog1.ShowDialog() == DialogResult.OK)
            {
                myPrintDocument1.Print();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            pictureBox_1086_1.Width = pictureBox_1086_1.Width + 50;
            pictureBox_1086_1.Height = pictureBox_1086_1.Height + 50;
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox_1086_1.Image = Image.FromFile(openFileDialog1.FileName);
                originImage = pictureBox_1086_1.Image;
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            pictureBox_1086_1.Width = pictureBox_1086_1.Width - 50;
            pictureBox_1086_1.Height = pictureBox_1086_1.Height - 50;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Image flipImage = pictureBox_1086_1.Image;
            flipImage.RotateFlip(RotateFlipType.Rotate270FlipNone);
            if (deg < 180)
            {
                pictureBox_1086_1.Image = originImage;
                deg = 0;
                return;
            }

            pictureBox_1086_1.Image = flipImage;
            deg -= 90;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Image flipImage = pictureBox_1086_1.Image;
            flipImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
            if (deg > 270)
            {
                pictureBox_1086_1.Image = originImage;
                deg = 0;
                return;
            }

            pictureBox_1086_1.Image = flipImage;
            deg += 90;
        }

        private void saveToolStripButton_1086_1_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Bitmap files (*.bmp)|*.bmp|JPG files (*.jpg)|*.jpg|GIFfiles(*.gif) | *.gif | All files(*.*) | *.* ";
            save.FilterIndex = 4;
            save.RestoreDirectory = true;

            if (save.ShowDialog() == DialogResult.OK)
            {
                pictureBox_1086_1.Image.Save(save.FileName);

            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openToolStripButton_Click(null, null);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveToolStripButton_1086_1_Click(null, null);
        }

        private void printToolStripMenuItem_1086_Click(object sender, EventArgs e)
        {
            this.printToolStripButton_1086_1_Click(null, null);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void saveAsToolStripMenuItem_1086_Click(object sender, EventArgs e)
        {
            saveToolStripButton_1086_1_Click(null, null);
        }
    }
}
