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

namespace TCT
{
    public partial class Form1 : Form
    {
        string text1 = "";
        string text2 = "";
        List<string> l1 = new List<string>();
        List<string> l2 = new List<string>();
        int count1, count2;


        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog file2 = new OpenFileDialog();
            file2.Filter = "Txt file | *.txt";
            file2.Title = "Please choose txt file..";
            file2.ShowDialog();
            count2 = 0;

            string fileName = file2.SafeFileName;
            string pathToFile2 = file2.FileName;
            label3.Text = fileName;

            if (File.Exists(pathToFile2))
            {
                using (StreamReader sr = new StreamReader(pathToFile2))
                {
                    while ((text2 = sr.ReadLine()) != null)
                    {
                        l2.Add(text2);
                        count2++;
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RichTextBox RichTextBox1 = new RichTextBox();
            RichTextBox RichTextBox2 = new RichTextBox();

            int l;
            int k = 0;

            for (int i = 0; i < count1; i++)
            {
                l = l1[i].Length;
                for (int j = 0; j < l; j++)
                {
                    char text = l1[k][j];
                    RichTextBox1.Text += text;
                }
                RichTextBox1.Text += Environment.NewLine;
                k++;
            }

            l = 0;
            k = 0;

            for (int i = 0; i < count2; i++)
            {
                l = l2[i].Length;
                for (int j = 0; j < l; j++)
                {
                    char text2 = l2[k][j];
                    RichTextBox2.Text += text2;


                }
                RichTextBox2.Text += Environment.NewLine;
                k++;
            }

            int count = RichTextBox1.Lines.Count();

            int i1 = 0, i2 = 0;

            for (int j = 0; j < count - 1;)
            {
                if (RichTextBox1.Text[i1].Equals('\n') == false && RichTextBox2.Text[i2].Equals('\n') == false)
                {

                    if (RichTextBox1.Text[i1] != RichTextBox2.Text[i2])
                    {
                        RichTextBox1.Select(i1, 1);
                        RichTextBox1.SelectionColor = System.Drawing.Color.Red;
                        RichTextBox1.SelectionFont = new Font("Tahoma", 14, FontStyle.Bold);
                        RichTextBox2.SelectionColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        RichTextBox1.Select(i1, 1);
                        RichTextBox1.SelectionColor = System.Drawing.Color.Black;
                        RichTextBox1.SelectionFont = new Font("Tahoma", 14, FontStyle.Bold);
                        RichTextBox2.SelectionColor = System.Drawing.Color.Black;
                    }
                    i1++;
                    i2++;
                }
                else if (RichTextBox1.Text[i1].Equals('\n') == true && RichTextBox2.Text[i2].Equals('\n') == false)
                {
                    RichTextBox1.Text[i2].Equals('*');
                    i2++;
                }
                else if (RichTextBox1.Text[i1].Equals('\n') == false && RichTextBox2.Text[i2].Equals('\n') == true)
                {
                    RichTextBox1.Select(i1, 1);
                    i1++;
                    RichTextBox1.SelectionColor = System.Drawing.Color.Red;
                    RichTextBox1.SelectionFont = new Font("Tahoma", 14, FontStyle.Bold);
                    RichTextBox2.SelectionColor = System.Drawing.Color.Red;
                }
                else if (RichTextBox1.Text[i1].Equals('\n') == true && RichTextBox2.Text[i2].Equals('\n') == true)
                {
                    j++;
                    i1++;
                    i2++;
                }

            }

            /*using (FileStream fs = File.Create("C:\\tct\result.rtf"))
            {
                Byte[] info = new UTF8Encoding(true).GetBytes(RichTextBox1.Text);
                // Add some information to the file.
                fs.Write(info, 0, info.Length);
            }*/
            RichTextBox1.SaveFile("C:\\tct\\result.rtf");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog file1 = new OpenFileDialog();
            file1.Filter = "Txt file | *.txt";
            file1.Title = "Please choose txt file..";
            file1.ShowDialog();
            count1 = 0;

            string fileName = file1.SafeFileName;
            string pathToFile1 = file1.FileName;
            label2.Text = fileName;

            if (File.Exists(pathToFile1))
            {
                using (StreamReader sr = new StreamReader(pathToFile1))
                {
                    while ((text1 = sr.ReadLine()) != null)
                    {
                        l1.Add(text1);
                        count1++;
                    }
                }
            }
        }
    }
}
