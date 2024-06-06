using callories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VegiesLib;

namespace formsnet
{
    public partial class Form2 : Form
    {
        public delegate void SaladUpdatedEventHandler(Salad updatedSalad);
        public event SaladUpdatedEventHandler SaladUpdated;


        private Salad _salad;
        List<TextBox> listText = new List<TextBox>();

        public Form2(Salad salad)
        {
            _salad = salad;
            InitializeComponent();
            comboBox1.Items.Add("Root");
            comboBox1.Items.Add("Tuber");
            comboBox1.Items.Add("Cabbage");
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedItem)
            {
                case "Root":
                    {
                        string[] labels = new string[] { "Name", "Nutrition Value", "Color", "Leafs Lng" };

                        for (int i = 0; i < labels.Length; i++)
                        {
                            CreateLabel(labels[i], i * 40 + 68);
                            CreateTextBox(i * 40 + 64);
                        }
                        break;
                    }
                case "Tuber":
                    {
                        string[] labels = new string[] { "Name", "Nutrition Value", "Color", "Seeds Number" };

                        for (int i = 0; i < labels.Length; i++)
                        {
                            CreateLabel(labels[i], i * 40 + 68);
                            CreateTextBox(i * 40 + 64);
                        }
                        break;
                    }
                case "Cabbage":
                    {
                        string[] labels = new string[] { "Name", "Nutrition Value", "Color", "Inflorescence Number" };

                        for (int i = 0; i < labels.Length; i++)
                        {
                            CreateLabel(labels[i], i * 40 + 68);
                            CreateTextBox(i * 40 + 64);
                        }
                        break;
                    }
            }
        }

        private void CreateLabel(string text, int placeY)
        {
            Label label = new Label();
            label.Text = text;
            label.Location = new System.Drawing.Point(30, placeY);
            label.Size = new System.Drawing.Size(70, 30);
            this.Controls.Add(label);
        }

        private void CreateTextBox(int placeY)
        {
            TextBox textBox = new TextBox();
            textBox.Text = "";
            textBox.Location = new System.Drawing.Point(100, placeY);
            textBox.Size = new System.Drawing.Size(121, 23);
            this.Controls.Add(textBox);
            listText.Add(textBox);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedItem)
            {
                case "Root":
                    {
                        RootVegetable vegetable = new RootVegetable(listText[0].Text, Convert.ToInt32(listText[1].Text), listText[2].Text, Convert.ToInt32(listText[3].Text));

                        _salad.AddIngridient(vegetable);

                        break;
                    }
                case "Tuber":
                    {
                        Tuber vegetable = new Tuber(listText[0].Text, Convert.ToInt32(listText[1].Text), listText[2].Text, Convert.ToInt32(listText[3].Text));

                        _salad.AddIngridient(vegetable);

                        break;
                    }
                case "Cabbage":
                    {
                        CabbageVegatable vegetable = new CabbageVegatable(listText[0].Text, Convert.ToInt32(listText[1].Text), listText[2].Text, Convert.ToInt32(listText[3].Text));

                        _salad.AddIngridient(vegetable);

                        break;
                    }

            }
            SaladUpdated?.Invoke(_salad);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaladUpdated?.Invoke(_salad);
            this.Hide();
        }
    }
}
