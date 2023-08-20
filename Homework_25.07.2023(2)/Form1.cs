using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Homework_25._07._2023_2_
{
    public partial class Form1 : Form
    {
        Point mouseDownLocation;
        TextBox T;
        PictureBox pictureBox1 = new PictureBox();
        public Form1()
        {
            InitializeComponent();
            pictureBox1.MouseDown += pictureBox1_MouseDown;
            pictureBox1.MouseDoubleClick += pictureBox1_MouseDoubleClick;

        }
        private void butloadImg_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            pictureBox1.Size = new Size(300, 300);
            pictureBox1.Location = new Point(20, 20);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            Controls.Add(pictureBox1);
            openFileDialog1.ShowDialog();
            pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);//картинка по выбору пользователя

            //pictureBox1.Image = img1;// Вставили картинку в пиктер бокс

        }

        private void butSave_Click(object sender, EventArgs e)
        {
             //сохранение картинки
            Bitmap bmpSave = new Bitmap(pictureBox1.DisplayRectangle.Width, pictureBox1.DisplayRectangle.Height);
            pictureBox1.DrawToBitmap(bmpSave, pictureBox1.DisplayRectangle);
            saveFileDialog1.FileName = "myPicture";
            saveFileDialog1.DefaultExt = "bmp";//Расширение имени файла по умолчанию
            saveFileDialog1.AddExtension = true;
            saveFileDialog1.CreatePrompt = true;//если указан не существующий файл, то будет отображаться сообщение о его создании
            saveFileDialog1.OverwritePrompt = false; //если указан существующий файл, то будет отображаться сообщение о том, что файл не будет перезаписан
            saveFileDialog1.InitialDirectory = @"D:/";//устанавливает каталог, который отображается при первом вызове окна
            saveFileDialog1.Title = "Сохраните свой файл здесь";
            saveFileDialog1.Filter = "Image files (*.bmp)|*.bmp|All files (*.*)|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                bmpSave.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
                MessageBox.Show("Файл сохранен");
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)//определение координат мыши при нажатии
        {
            mouseDownLocation = new Point(e.X, e.Y);
        }

        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)//создать комментарий на фото
        {
            T = new TextBox();
            T.Location = new Point(mouseDownLocation.X, mouseDownLocation.Y);
            T.Parent = pictureBox1;
            T.Height = 30;
            T.Width = 100;
            pictureBox1.Controls.Add(T);
        }

       
    }

}



