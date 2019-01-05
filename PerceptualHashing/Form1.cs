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
using Shipwreck.Phash;
using Shipwreck.Phash.Bitmaps;
using System.Collections;
using System.Drawing.Imaging;

namespace PerceptualHashing
{
    public partial class Form1 : Form
    {
        string slika;
        string hash1, hash2;
        Bitmap img1, img2;
        private const double w0 = 0.5;
        private const double w1 = -0.5;
        private const double s0 = 0.5;
        private const double s1 = 0.5;
        public Form1()
        {
            InitializeComponent();
            Vidljivost(false);
        }

        private void btnPrvaSlika_Click(object sender, EventArgs e)
        {           
            img1 = new Bitmap(OtvoriSliku());
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.Image = img1;
            
            
        }
        public void Vidljivost(bool nekaj)
        {
            label1.Visible = nekaj;
            label2.Visible = nekaj;
            label3.Visible = nekaj;
            label4.Visible = nekaj;
            label5.Visible = nekaj;
        }

        public string OtvoriSliku() {
            openFileDialog1.FileName = "";
            openFileDialog1.Title = "Images";
            openFileDialog1.Filter = "All Images|*.jpg; *.bmp; *.png";
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName.ToString() != "")
            {
                slika = openFileDialog1.FileName.ToString();
            }
            return slika;
        }

        private void btnDrugaSlika_Click(object sender, EventArgs e)
        {
            img2 = new Bitmap(OtvoriSliku());
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.Image = img2;
        }

        private void btnaHash_Click(object sender, EventArgs e)
        {
            try
            {
                hash1 = aHash(img1);
                hash2 = aHash(img2);
                label1.Text = hash1;
                label2.Text = hash2;
                razlika(hash1, hash2);
                Vidljivost(true);
            }
            catch(Exception)
            {
                MessageBox.Show("Treba prvo učitati slike!", "Upozorenje!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public string aHash(Bitmap img)
        {
            string hash="";
            Bitmap slika = new Bitmap(img, new Size(8, 8));
            Bitmap grayscale;
            int x, y,avg,a,r,g,b;
            for (x = 0; x < slika.Width; x++)
            {
                for (y = 0; y < slika.Height; y++)
                {
                    Color pixColor = slika.GetPixel(x, y);
                    a = pixColor.A;
                    r = pixColor.R;
                    g = pixColor.G;
                    b = pixColor.B;
                    avg = (r + g + b) / 3;
                    slika.SetPixel(x, y,Color.FromArgb(a,avg,avg,avg));
                }
            }           
            grayscale = slika;
            int avgr=0, avgg=0, avgb=0;
            for (x = 0; x < grayscale.Width; x++)
            {
                for (y = 0; y < grayscale.Height; y++)
                {
                    r = grayscale.GetPixel(x, y).R;
                    g = grayscale.GetPixel(x, y).G;
                    b = grayscale.GetPixel(x, y).B;
                    avgr += r;
                    avgg += g;
                    avgb += b;
                }
            }
            Color prosjek =Color.FromArgb(avgr/64,avgg/64,avgb/64);
            
            for (x = 0; x < grayscale.Width; x++)
            {
                for (y = 0; y < grayscale.Height; y++)
                {
                    if (grayscale.GetPixel(x, y).GetBrightness() < prosjek.GetBrightness())
                        hash += "1";
                    else
                        hash += "0";
                }
            }
            return hash; 
        }

        public string wHash(Bitmap img) {
            string hash = "";
            Bitmap slika = new Bitmap(img, new Size(32, 32));
            Bitmap bmp; 
            int x, y, avg, a, r, g, b;
            for (x = 0; x < slika.Width; x++)
            {
                for (y = 0; y < slika.Height; y++)
                {
                    Color pixColor = slika.GetPixel(x, y);
                    a = pixColor.A;
                    r = pixColor.R;
                    g = pixColor.G;
                    b = pixColor.B;
                    avg = (r + g + b) / 3;
                    slika.SetPixel(x, y, Color.FromArgb(a, avg, avg, avg));
                }
            }
            bmp = slika;
            double[,] Red = new double[bmp.Width, bmp.Height];
            double[,] Green = new double[bmp.Width, bmp.Height];
            double[,] Blue = new double[bmp.Width, bmp.Height];
            Color c;

            for (int j = 0; j < bmp.Height; j++)
            {
                for (int i = 0; i < bmp.Width; i++)
                {
                    c = bmp.GetPixel(i, j);
                    Red[i, j] = (double)Scale(0, 255, -1, 1, c.R);
                    Green[i, j] = (double)Scale(0, 255, -1, 1, c.G);
                    Blue[i, j] = (double)Scale(0, 255, -1, 1, c.B);
                }
            }
            FWT(Red, 4);
            FWT(Green, 4);
            FWT(Blue, 4);
            for (int j = 0; j < bmp.Height; j++)
            {
                for (int i = 0; i < bmp.Width; i++)
                {
                    bmp.SetPixel(i, j, Color.FromArgb((int)Scale(-1, 1, 0, 255, Red[i, j]), (int)Scale(-1, 1, 0, 255, Green[i, j]), (int)Scale(-1, 1, 0, 255, Blue[i, j])));
                }
            }
            Bitmap promena = new Bitmap(bmp, new Size(8,8));
       
            int avgr = 0, avgg = 0, avgb = 0;
            for (x = 0; x < promena.Width; x++)
            {
                for (y = 0; y < promena.Height; y++)
                {
                    r = promena.GetPixel(x, y).R;
                    g = promena.GetPixel(x, y).G;
                    b = promena.GetPixel(x, y).B;
                    avgr += r;
                    avgg += g;
                    avgb += b;
                }
            }
            Color prosjek = Color.FromArgb(avgr / 64, avgg / 64, avgb / 64);
            for (x = 0; x < promena.Width; x++)
            {
                for (y = 0; y < promena.Height; y++)
                {
                    if (promena.GetPixel(x, y).GetBrightness() < prosjek.GetBrightness())
                        hash += "1";
                    else
                        hash += "0";
                }
            }
           // pictureBox2.Image = promena;
            return hash;
        }
        public string dHash (Bitmap img)
        {
            string hash="";
            Bitmap slika = new Bitmap(img, new Size(9, 9));
            Bitmap grayscale;
            int x, y, avg, a, r, g, b;
            for (x = 0; x < slika.Width; x++)
            {
                for (y = 0; y < slika.Height; y++)
                {
                    Color pixColor = slika.GetPixel(x, y);
                    a = pixColor.A;
                    r = pixColor.R;
                    g = pixColor.G;
                    b = pixColor.B;
                    avg = (r + g + b) / 3;
                    slika.SetPixel(x, y, Color.FromArgb(a, avg, avg, avg));
                }
            }
            grayscale = slika;

            string rHash = "";
            for(int row = 0; row < 8; row++)
            {
                for(int column = 0; column < 8; column++)
                {
                    if (grayscale.GetPixel(column, row+1).R >= grayscale.GetPixel(column, row).R)
                        rHash += "1";
                    else
                        rHash += "0";
                }              
            }
            string cHash = "";
            for (int column = 0; column < 8; column++)
            {
                for (int row = 0; row < 8; row++) {
                    if (grayscale.GetPixel(column+1, row).R >= grayscale.GetPixel(column, row).R)
                        cHash += "1";
                    else
                        cHash += "0";
                }
            }
            hash = rHash+cHash;
            return hash;
        }

        private void btnpHash_Click(object sender, EventArgs e)
        {
            try
            {
                var bitmapPrvaSlika = img1;
                var hashPrvaSlika = ImagePhash.ComputeDigest(bitmapPrvaSlika.ToLuminanceImage());
                var bitmapDrugaSlika = img2;
                var hashDrugaSlika = ImagePhash.ComputeDigest(bitmapDrugaSlika.ToLuminanceImage());
                var score = ImagePhash.GetCrossCorrelation(hashPrvaSlika, hashDrugaSlika);
                byte[] hashPrvaSlikaBytes = Encoding.ASCII.GetBytes(hashPrvaSlika.ToString());
                byte[] hashDrugaSlikaBytes = Encoding.ASCII.GetBytes(hashDrugaSlika.ToString());
                var prvaBitArray = new BitArray(hashPrvaSlikaBytes);
                var drugaBitArray = new BitArray(hashDrugaSlikaBytes);
                string prvaBytes = DohvatiBitove(prvaBitArray);
                string drugaBytes = DohvatiBitove(drugaBitArray);
                label1.Text = prvaBytes;
                label2.Text = drugaBytes;
                var slicnost = ImagePhash.GetCrossCorrelation(hashPrvaSlika, hashDrugaSlika)*100;
                razlika(prvaBytes,drugaBytes);
                label5.Text = "Sličnost je: " + ((int)slicnost).ToString() + "%";

            }
            catch (Exception)
            {
                MessageBox.Show("Treba prvo učitati slike!", "Upozorenje!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void btndHash_Click(object sender, EventArgs e)
        {
            try
            {               
                hash1 = dHash(img1);
                hash2 = dHash(img2);
                label1.Text = hash1;
                label2.Text = hash2;
                razlika(hash1, hash2);
                Vidljivost(true);
            }
            catch (Exception)
            {
                MessageBox.Show("Treba prvo učitati slike!", "Upozorenje!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void razlika(string neki, string neki2) {
            var array1 = neki.ToCharArray();
            var array2 = neki2.ToCharArray();
            int isti=0, razliciti=0;
            for(int x = 0; x < array1.Length; x++)
            {
                if (array1[x] == array2[x])
                    isti += 1;
                if(array1[x]!= array2[x])
                    razliciti += 1;
            }
            double avg=0;
            if (isti != 0 && razliciti != 0)
                avg = (isti*100 / array1.Length);
           // if (isti == 0 && razliciti!=0)
            //    avg = 0;
            if (isti!=0 && razliciti == 0)
                avg = 100;
            label5.Text = "Sličnost je: "+avg.ToString()+"%";
            label3.Text = isti.ToString();
            label4.Text = razliciti.ToString();
        }
      
        public string DohvatiBitove(BitArray bitArray)
        {
            string output = ""; 
            for (int i = 0; i < bitArray.Length; i++)
            {
                output += bitArray.Get(i) ? "1" : "0";
            }
            return output;
        }

        public void FWT(double[] data)
        {
            double[] temp = new double[data.Length];

            int h = data.Length >> 1;
            for (int i = 0; i < h; i++)
            {
                int k = (i << 1);
                temp[i] = data[k] * s0 + data[k + 1] * s1;
                temp[i + h] = data[k] * w0 + data[k + 1] * w1;
            }

            for (int i = 0; i < data.Length; i++)
                data[i] = temp[i];
        }

        private void btnwHash_Click(object sender, EventArgs e)
        {
            try
            {
                hash1 = wHash(img1);
                hash2 = wHash(img2);
                label1.Text = hash1;
                label2.Text = hash2;
                razlika(hash1, hash2);
                Vidljivost(true);
            }
            catch (Exception)
            {
                MessageBox.Show("Treba prvo učitati slike!", "Upozorenje!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void FWT(double[,] data, int iterations)
        {
            int rows = data.GetLength(0);
            int cols = data.GetLength(1);

            double[] row = new double[cols];
            double[] col = new double[rows];

            for (int k = 0; k < iterations; k++)
            {
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < row.Length; j++)
                        row[j] = data[i, j];

                    FWT(row);

                    for (int j = 0; j < row.Length; j++)
                        data[i, j] = row[j];
                }

                for (int j = 0; j < cols; j++)
                {
                    for (int i = 0; i < col.Length; i++)
                        col[i] = data[i, j];

                    FWT(col);

                    for (int i = 0; i < col.Length; i++)
                        data[i, j] = col[i];
                }
            }
        }
        public double Scale(double fromMin, double fromMax, double toMin, double toMax, double x)
        {
            if (fromMax - fromMin == 0) return 0;
            double value = (toMax - toMin) * (x - fromMin) / (fromMax - fromMin) + toMin;
            if (value > toMax)
            {
                value = toMax;
            }
            if (value < toMin)
            {
                value = toMin;
            }
            return value;
        }
    }
}
