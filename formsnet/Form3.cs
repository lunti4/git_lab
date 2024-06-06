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
    public partial class Form3 : Form
    {
        public delegate void SaladUpdatedEventHandler(Salad updatedSalad);
        public event SaladUpdatedEventHandler SaladUpdated;


        private Salad _salad;
        private int _index;
        List<TextBox> listText = new List<TextBox>();

        public Form3(Salad salad, int index)
        {
            _salad = salad;
            _index = index;
            InitializeComponent();
            Form3_Load(null, null);
        }

        private void Form3_SaladUpdated(Salad updatedSalad)
        {
            _salad = updatedSalad;
            SaladUpdated?.Invoke(updatedSalad);
            this.Show();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            string[] labels = new string[] { "Name", "Nutrition Value", "Color" };

            for (int i = 0; i < labels.Length; i++)
            {
                CreateLabel(labels[i], i * 40 + 68);
                CreateTextBox(i * 40 + 64);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Vegetable> listVegetables = _salad.GetVegetables();

            listVegetables[_index].Name = listText[0].Text;
            listVegetables[_index].NutritionValue = Convert.ToInt32(listText[1].Text);
            listVegetables[_index].Color = listText[2].Text;

            SaladUpdated?.Invoke(_salad);
            this.Close();
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

        private void button2_Click(object sender, EventArgs e)
        {
            SaladUpdated?.Invoke(_salad);
            this.Hide();
        }
    }
}
