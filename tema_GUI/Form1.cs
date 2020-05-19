using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tema_GUI
{
    public partial class Form1 : Form
    {
        Masina[] masini;
        int nr_masini=0;
        public Form1()
        {
            InitializeComponent();
            (masini, nr_masini) = load();
            dataGridView1.DataSource = masini;
        }

        private void add_button_Click(object sender, EventArgs e)
        {
            Masina.Color culoare=Masina.Color.necunoscut;
            if(radioButton1.Checked)
                culoare=Masina.Color.rosu;
            else if(radioButton2.Checked)
                culoare = Masina.Color.galben;
            else if(radioButton3.Checked)
                culoare = Masina.Color.verde;
            else if(radioButton4.Checked)
                culoare = Masina.Color.albastru;
            else if(radioButton5.Checked)
                culoare = Masina.Color.argintiu;
            else if(radioButton6.Checked)
                culoare = Masina.Color.alb;
            else if(radioButton7.Checked)
                culoare = Masina.Color.negru;
            else if(radioButton5.Checked)
                culoare = Masina.Color.mov;
            Masina.Options optiuni = Masina.Options.none;
            if (checkBox1.Checked)
                optiuni += 1;
            if (checkBox2.Checked)
                optiuni += 2;
            if (checkBox3.Checked)
                optiuni += 4;
            if (checkBox4.Checked)
                optiuni += 8;
            if (checkBox5.Checked)
                optiuni += 16;
            if (checkBox6.Checked)
                optiuni += 32;
            if (checkBox7.Checked)
                optiuni += 64;
            if (checkBox8.Checked)
                optiuni += 128;



            //label1.Text=masini[nr_masini].Conversie_sir_tranzactii();
            if (checkBox9.Checked)
                masini[nr_masini] = new Masina(input_text.Text, textBox1.Text, textBox2.Text, textBox3.Text, Int32.Parse(textBox4.Text), culoare, optiuni, Int32.Parse(textBox5.Text));
            else
                masini[nr_masini] = new Masina(input_text.Text, textBox2.Text, textBox3.Text, Int32.Parse(textBox4.Text), culoare, optiuni, Int32.Parse(textBox5.Text));
            nr_masini++;
            save(masini, nr_masini);
            resetfields();
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = checkBox9.Checked;
        }










        void resetfields()
        {
            input_text.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            checkBox9.Checked = true;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
            checkBox7.Checked = false;
            checkBox8.Checked = false;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            radioButton6.Checked = false;
            radioButton7.Checked = false;
            radioButton8.Checked = false;
        }

        static void save(Masina[] masini, int nr_masini)
        {
            string[] string_to_save = new string[10];
            for (int i = 0; i < nr_masini; i++)
            {
                string_to_save[i] = masini[i].Nume_vanzator + ";" + masini[i].Nume_cumparator + ";" + masini[i].Firma + ";" + masini[i].Model + ";" + masini[i].An_fabricatie + ";" + masini[i].Culoare + ";" + (int)masini[i].Optiuni + ";" + masini[i].Pret;
            }
            System.IO.File.WriteAllLines("masini.txt", string_to_save);
        }
        static Tuple<Masina[], int> load()
        {
            Masina[] masini = new Masina[10];
            Masina.Color culoare = new Masina.Color();
            int index = 0;
            if (System.IO.File.Exists("masini.txt"))
            {
                string[] file = System.IO.File.ReadAllLines("masini.txt");

                foreach (string fisier in file)
                {

                    string[] rand = file[index].Split(';');
                    if (rand[0].Length > 1)
                    {
                        foreach (Masina.Color color in Enum.GetValues(typeof(Masina.Color)))
                            if (rand[5] == color.ToString())
                                culoare = color;
                        masini[index] = new Masina(rand[0], rand[1], rand[2], rand[3], Int32.Parse(rand[4]), culoare, (Masina.Options)Int32.Parse(rand[6]), Int32.Parse(rand[7]));
                        index++;
                    }

                }
            }
            return Tuple.Create(masini, index);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
