using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TabanlarArasıDönüşüm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = false;
        }

        int basamakSayisi(int s)
        {
            if (s == 0)
                return 0;

            int bs = 1;

            for (;s>=10;bs++)
            {
                s = s / 10;
            }

            return bs;
        }
        int ikiOn()
        {
            int onlukSayi = 0;
            int ikilikSayi = Convert.ToInt32(textBox1.Text);
            int bs = basamakSayisi(ikilikSayi);

            if (bs == 0)
                return 0;

                

            for(int i = (bs-1); i >= 0; i--)
            {

                int temp = ikilikSayi / (int)Math.Pow(10, i);
                onlukSayi += (int)Math.Pow(2, i) * temp;
                ikilikSayi -= temp * (int)Math.Pow(10, i);

            }
                

            

            return onlukSayi;
        }

        void onIki()
        {
            int onlukSayi = Convert.ToInt32(textBox3.Text);

            if (onlukSayi == 1)
            {
                textBox4.Text = 1.ToString();
                return;
            }
                
            int bs = basamakSayisi(onlukSayi);
            

            if (bs == 0)
            {
                textBox4.Text = 0.ToString();
                return;
            }
            

            int a = 0;

            for (; Math.Pow(2, a) <= onlukSayi; a++) { }


            string[] ikilikSayi = new string[a];
            

            for (int i=(a-1);onlukSayi>=2;i--)
            {

                ikilikSayi[i] = (onlukSayi % 2).ToString();
                onlukSayi = onlukSayi / 2;
                if (i == 1)
                {
                    ikilikSayi[i - 1] = onlukSayi.ToString();

                }

            }

            string temp = null;
            textBox4.Text = string.Join(temp, ikilikSayi);

        }
        


        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = ikiOn().ToString();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            onIki();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            button2.Enabled = true;
            if (textBox3.Text ==string.Empty)
                button2.Enabled = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
            if (textBox1.Text == string.Empty)
                button1.Enabled = false;
        }
    }
}
