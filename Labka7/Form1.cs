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
/// <summary>
/// LAB7
/// </summary>
namespace Labka7
{
    public partial class Form1 : Form
    {
        List<Person> personArray = new List<Person>();
        List<Person> newpersonArray = new List<Person>();
        public Form1()
        {
            InitializeComponent();

        }
        string path;
        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog od = new OpenFileDialog();
            od.ShowDialog();
            path = Convert.ToString(od.FileName);
            try
            {
                if (personArray.Count != 0)
                    personArray = new List<Person>();
                using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open), Encoding.GetEncoding("windows-1251")))
                {

                    while (reader.PeekChar() > -1)
                    {
                        Person newPerson = new Person();
                        char[] temp = reader.ReadChars(30);
                        for (int i = 0; i < 30; i++)
                            newPerson.lastName += Convert.ToString(temp[i]);
                        temp = reader.ReadChars(30);
                        for (int i = 0; i < 30; i++)
                            newPerson.name += Convert.ToString(temp[i]);
                        temp = reader.ReadChars(30);
                        for (int i = 0; i < 30; i++)
                            newPerson.otchestvo += Convert.ToString(temp[i]);
                        temp = reader.ReadChars(2);
                        newPerson.year = reader.ReadInt32();
                        
                        newPerson.srednBall = reader.ReadDouble();
                        

                        personArray.Insert(personArray.Count, newPerson);
                    }
                    MessageBox.Show("Файл открыт.");
                }
            }
            catch (Exception exept)
            {
                MessageBox.Show(exept.Message);
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.DefaultExt = ".bin";
            saveFile.Filter = "Bin files|*.bin";
            saveFile.ShowDialog();
            path = Convert.ToString(saveFile.FileName);
            try
            {
                //if (saveFile.ShowDialog() == System.Windows.Forms.DialogResult.OK && saveFile.FileName.Length > 0)
                //{
                    using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Create), Encoding.GetEncoding("windows-1251")))
                    {
                        for (int i = 0; i < newpersonArray.Count; i++)
                        {

                            writer.Write(newpersonArray[i].lastName);

                            writer.Write(newpersonArray[i].name);

                            writer.Write(newpersonArray[i].otchestvo);

                            writer.Write(newpersonArray[i].srednBall);

                            writer.Write(newpersonArray[i].year);


                        }
                        newpersonArray = new List<Person>();
                        MessageBox.Show("Сохранено в файл.");
                        writer.Close();
                    }
                //}
            }
            catch (Exception exept)
            {
                Console.WriteLine(exept.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Rows.Clear();
                for (int i = 0; i < personArray.Count; i++)
                    dataGridView1.Rows.Add(personArray[i].lastName, personArray[i].name, personArray[i].otchestvo,  personArray[i].year, personArray[i].srednBall);
            }
            catch (Exception exept)
            {
                Console.WriteLine(exept.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Person newPerson = new Person();
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    string tempLastName = Convert.ToString(dataGridView1[0, i].Value);

                    if (tempLastName.Length != 0 && tempLastName.Length <= 30)
                    {

                        for (int j = tempLastName.Length; j < 30; j++)
                            tempLastName += " ";

                        if (tempLastName.Length > 30)
                            for (int j = tempLastName.Length; j > 30; j--)
                                tempLastName.Remove(tempLastName.Length - 1, 1);
                        newPerson.lastName = tempLastName;
                    }
                    else
                    {
                        MessageBox.Show("Какая-то строка введена неверно.");
                        break;
                    }
                    string tempName = Convert.ToString(dataGridView1[1, i].Value);

                    if (tempName.Length != 0 && tempName.Length <= 30)
                    {
                        for (int j = tempName.Length; j < 30; j++)
                            tempName += " ";

                        if (tempName.Length > 30)
                            for (int j = tempName.Length; j > 30; j--)
                                tempName.Remove(tempName.Length - 1, 1);
                        newPerson.name = tempName;
                    }
                    else
                    {

                        MessageBox.Show("Какая-то строка введена неверно.");
                        break;
                    }
                    string tempotchestvo = Convert.ToString(dataGridView1[2, i].Value);

                    if (tempotchestvo.Length != 0 && tempotchestvo.Length <= 32)
                    {
                        for (int j = tempotchestvo.Length; j < 32; j++)
                            tempotchestvo += " ";

                        if (tempotchestvo.Length > 40)
                            for (int j = tempotchestvo.Length; j > 32; j--)
                                tempotchestvo.Remove(tempotchestvo.Length - 1, 1);
                        newPerson.otchestvo = tempotchestvo;
                    }
                    else
                    {
                        MessageBox.Show("Какая-то строка введена неверно.");
                        break;
                    }
                    

                    
                    int tempyear = Convert.ToInt32(dataGridView1[4, i].Value); ;

                    if (tempyear != 0)
                    {
                        newPerson.year = tempyear;
                    }
                    else
                    {
                        MessageBox.Show("Какая-то строка введена неверно.");
                        break;
                    }

                    double tempsrednBall = Convert.ToDouble(dataGridView1[4, i].Value); ;

                    if (tempsrednBall != 0)
                    {
                        newPerson.srednBall = tempsrednBall;
                    }
                    else
                    {
                        MessageBox.Show("Какая-то строка введена неверно.");
                        break;
                    }

                    if (i <= dataGridView1.Rows.Count - 1)
                        newpersonArray.Insert(newpersonArray.Count, newPerson);

                }
            }
            catch (Exception exept)
            {
                MessageBox.Show(exept.Message);
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Выход.");
            this.Close();
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Текущая дата и время: " + DateTime.Now.ToLongDateString() + DateTime.Now.ToShortTimeString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int del = dataGridView1.SelectedCells[0].RowIndex;
                dataGridView1.Rows.RemoveAt(del);
            }
            catch (Exception exept)
            {
                Console.WriteLine(exept.Message);
            }
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
