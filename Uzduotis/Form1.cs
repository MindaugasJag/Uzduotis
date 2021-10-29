using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Uzduotis
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        


        private void button1_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.Filter =
        "Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF";

            this.openFileDialog1.Multiselect = false;
            this.openFileDialog1.Title = "Select Photos";

            DialogResult dr = this.openFileDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                foreach (String file in openFileDialog1.FileNames)
                {
                    try
                    {
                        PictureBox imageControl = new PictureBox();
                        imageControl.Height = 500;
                        imageControl.Width = 500;


                        Image.GetThumbnailImageAbort myCallback =
                                new Image.GetThumbnailImageAbort(ThumbnailCallback);
                        Bitmap myBitmap = new Bitmap(file);
                        Image myThumbnail = myBitmap.GetThumbnailImage(300, 300,
                            myCallback, IntPtr.Zero);
                        imageControl.Image = myThumbnail;

                        pictureBox1.Controls.Add(imageControl);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                    
                }
                label1.Text = "Paveikslėlio formatas yra " + Path.GetExtension(openFileDialog1.FileName);
            }
        }
        public bool ThumbnailCallback()
        {
            return false;
        }

        private void ImgFormat_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
