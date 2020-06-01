using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tema_GUI
{
    public partial class Form1 : Form
    {
        List<Masina> masini=new List<Masina>();
        int editrow;
        public Form1()
        {
            InitializeComponent();
            masini = load();
            dataGridView1.DataSource = masini;
            dataGridView1.Columns[0].Width =30;
            comboBox1.SelectedIndex = 0;
        }

        private void add_button_Click(object sender, EventArgs e)
        {
            if (checkBox9.Checked)
                masini.Add(new Masina(masini.Count, input_text.Text, textBox1.Text, textBox2.Text, textBox3.Text, Int32.Parse(textBox4.Text), get_color(), get_optiuni(), Int32.Parse(textBox5.Text)));
            else
                masini.Add(new Masina(masini.Count, input_text.Text, textBox2.Text, textBox3.Text, Int32.Parse(textBox4.Text), get_color(), get_optiuni(), Int32.Parse(textBox5.Text)));
            save(masini);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = masini;
            resetfields();
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = checkBox9.Checked;
        }


        private Masina.Color get_color()
        {
            if (radioButton1.Checked)
                return Masina.Color.rosu;
            else if (radioButton2.Checked)
                return Masina.Color.galben;
            else if (radioButton3.Checked)
                return Masina.Color.verde;
            else if (radioButton4.Checked)
                return Masina.Color.albastru;
            else if (radioButton5.Checked)
                return Masina.Color.argintiu;
            else if (radioButton6.Checked)
                return Masina.Color.alb;
            else if (radioButton7.Checked)
                return Masina.Color.negru;
            else if (radioButton8.Checked)
                return Masina.Color.mov;
            else return Masina.Color.necunoscut;
        }


        private Masina.Options get_optiuni()
        {
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
            return optiuni;
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

        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            resetfields();
            editrow = Int32.Parse(dataGridView1[0,e.RowIndex].Value.ToString());
            input_text.Text = masini[editrow].Nume_vanzator;
            textBox1.Text = masini[editrow].Nume_cumparator;
            textBox2.Text = masini[editrow].Firma;
            textBox3.Text = masini[editrow].Model;
            textBox4.Text = masini[editrow].An_fabricatie.ToString();
            textBox5.Text = masini[editrow].Pret.ToString();
            if (masini[editrow].Culoare == Masina.Color.rosu)
                radioButton1.Checked = true;
            else if (masini[editrow].Culoare == Masina.Color.galben)
                radioButton2.Checked = true;
            else if (masini[editrow].Culoare == Masina.Color.verde)
                radioButton3.Checked = true;
            else if (masini[editrow].Culoare == Masina.Color.albastru)
                radioButton4.Checked = true;
            else if (masini[editrow].Culoare == Masina.Color.argintiu)
                radioButton5.Checked = true;
            else if (masini[editrow].Culoare == Masina.Color.alb)
                radioButton6.Checked = true;
            else if (masini[editrow].Culoare == Masina.Color.negru)
                radioButton7.Checked = true;
            else if (masini[editrow].Culoare == Masina.Color.mov)
                radioButton8.Checked = true;
            //editrow = e.RowIndex;
            
            int optiuni = (int)masini[editrow].Optiuni;
            if (optiuni / 128 >= 1)
            {
                checkBox8.Checked = true;
                optiuni = optiuni % 128;
            }

            if (optiuni / 64 >= 1)
            {
                checkBox7.Checked = true;
                optiuni = optiuni % 64;
            }
            if (optiuni / 32 >= 1)
            {
                checkBox6.Checked = true;
                optiuni = optiuni % 32;
            }
            if (optiuni / 16 >= 1)
            {
                checkBox5.Checked = true;
                optiuni = optiuni % 16;
            }
            if (optiuni / 8 >= 1)
            {
                checkBox4.Checked= true;
                optiuni = optiuni % 8;
            }
            if (optiuni / 4 >= 1)
            {
                checkBox3.Checked = true;
                optiuni = optiuni % 4;
            }
            if (optiuni / 2 >= 1)
            {
                checkBox2.Checked = true;
                optiuni = optiuni % 2;
            }
            if (optiuni  >= 1)
            {
                checkBox1.Checked = true;
            }

            editmode(true);
            
        }
        private void editmode(bool mode)
        {
            add_button.Enabled = !mode;
            button1.Enabled = mode;
            button2.Enabled = mode;
            button3.Enabled = mode;
            checkBox9.Visible =!mode;
            if (mode)
                textBox1.Visible = mode;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            editmode(false);
            masini[editrow].Nume_vanzator=input_text.Text;
            masini[editrow].Nume_cumparator = textBox1.Text;
            masini[editrow].Firma = textBox2.Text;
            masini[editrow].Model = textBox3.Text;
            masini[editrow].An_fabricatie = Int32.Parse(textBox4.Text);
            masini[editrow].Pret = Int32.Parse(textBox5.Text);
            masini[editrow].Optiuni = get_optiuni();
            masini[editrow].Culoare = get_color();
            dataGridView1.Refresh();
            save(masini);
            resetfields();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            editmode(false);
            resetfields();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            editmode(false);
            masini.RemoveAt(editrow);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = masini;
            save(masini);
            resetfields();
        }


        static void save(List<Masina> masini)
        {
            List<string> string_to_save= new List<string>();
            foreach(Masina masina in masini)
            {
                string_to_save.Add(masina.Nume_vanzator + ";" + masina.Nume_cumparator + ";" + masina.Firma + ";" + masina.Model + ";" + masina.An_fabricatie + ";" + masina.Culoare + ";" + (int)masina.Optiuni + ";" + masina.Pret);
            }
            System.IO.File.WriteAllLines("masini.txt", string_to_save);
        }


        static List<Masina> load()
        {
            List<Masina> masini = new List<Masina>();
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
                        masini.Add(new Masina(masini.Count, rand[0], rand[1], rand[2], rand[3], Int32.Parse(rand[4]), culoare, (Masina.Options)Int32.Parse(rand[6]), Int32.Parse(rand[7])));
                        index++;
                    }

                }
            }
            return masini;
        }


        string tosearch(Masina masina_to_search)
        {
            if (comboBox1.SelectedIndex == 0)
                return masina_to_search.Nume_vanzator;
            else if (comboBox1.SelectedIndex == 1)
                return masina_to_search.Nume_cumparator;
            else if (comboBox1.SelectedIndex == 2)
                return masina_to_search.Firma;
            else if (comboBox1.SelectedIndex == 3)
                return masina_to_search.Model;
            else if (comboBox1.SelectedIndex == 4)
                return masina_to_search.An_fabricatie.ToString();
            else if (comboBox1.SelectedIndex == 5)
                return masina_to_search.Culoare.ToString();
            else if (comboBox1.SelectedIndex == 6)
                return masina_to_search.Optiuni.ToString();
            else if (comboBox1.SelectedIndex == 7)
                return masina_to_search.Pret.ToString();
            else return "";


        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            List<Masina> copy_masina = new List<Masina>();
            foreach(Masina masina in masini)
            {
                
                if(tosearch(masina).Contains(textBox6.Text))
                {
                    copy_masina.Add(masina);
                }
            }
            dataGridView1.DataSource = null;
            dataGridView1.DataSource =copy_masina;
            dataGridView1.Columns[0].Width = 30;
        }
    }
}
