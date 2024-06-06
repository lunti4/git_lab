using System;
using callories;
using VegiesLib;

namespace formsnet
{
    public partial class Form1 : Form
    {
        Salad salad = new Salad();
        public Form1()
        {
            InitializeComponent();
            InsertInListBox();
            EnterNutrition();

            Form2 form2 = new Form2(salad);
            form2.SaladUpdated += Form2_SaladUpdated;
        }

        private void InsertInListBox()
        {
            listBox1.Items.Clear();
            List<Vegetable> vegetableList = salad.GetVegetables();

            for (int i = 0; i < vegetableList.Count; i++)
            {
                listBox1.Items.Add(vegetableList[i].Name);
            }
        }

        private void EnterNutrition()
        {
            label1.Text = String.Format("Total nutrition: {0}", salad.GetTotalNutrition().ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 newForm = new Form2(salad);
            newForm.SaladUpdated += (updatedSalad) =>
            {
                salad = updatedSalad;
                InsertInListBox();
                EnterNutrition();
                this.Show();
            };
            newForm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 newForm = new Form3(salad, listBox1.SelectedIndex);
            newForm.SaladUpdated += (updatedSalad) =>
            {
                salad = updatedSalad;
                InsertInListBox();
                EnterNutrition();
                this.Show();
            };
            newForm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                salad.DeleteIngridient(listBox1.SelectedIndex);

                InsertInListBox();
                EnterNutrition();
            }
            else
            {
                MessageBox.Show("Выберите овощ для удаления.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form2_SaladUpdated(Salad updatedSalad)
        {
            salad = updatedSalad;
            InsertInListBox();
            EnterNutrition();

            this.Show();
        }

        private void Form3_SaladUpdated(Salad updatedSalad)
        {
            salad = updatedSalad;
            InsertInListBox();
            EnterNutrition();

            this.Show();
        }

    }
}
