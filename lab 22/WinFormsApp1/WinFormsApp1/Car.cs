using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    abstract class Pizza
    {
        public abstract void Diametr();
        public abstract void Weight();
        public abstract void Ingredients();
    }

    class Chesse : Pizza
    {
        public override void Diametr()
        {
            MessageBox.Show("diametr: 45cm");
        }

        public override void Weight()
        {
            MessageBox.Show("weight: 300gr");
        }
        public override void Ingredients()
        {
            MessageBox.Show("Ingredients: Mozzarella,Golan cheese, sausages, tomatos");
        }

    }

    class Meat : Pizza
    {
        public override void Diametr()
        {
            MessageBox.Show("diametr: 35cm");
        }

        public override void Weight()
        {
            MessageBox.Show("weight: 500gr");
        }
        public override void Ingredients()
        {
            MessageBox.Show("Ingredients: Beef,Chicken, sausages, tomatos");
        }
    }

    

    class PizzaFactory
    {
        public static Pizza CreatePizza(string type)
        {
            switch (type)
            {
                case "Сирна піцца":
                    return new Chesse();
                case "Мясна піцца":
                    return new Meat();
                default:
                    return null;
            }
        }
    }

    class PizzaForm : Form
    {
        private ComboBox PizzaComboBox;
        private Button createButton;

        public PizzaForm()
        {
            this.PizzaComboBox = new ComboBox();
            this.PizzaComboBox.Items.AddRange(new object[] { "Сирна піцца", "Мясна піцца", "Овочева піцца" });
            this.PizzaComboBox.Location = new Point(10, 10);
            this.Controls.Add(this.PizzaComboBox);

            this.createButton = new Button();
            this.createButton.Text = "Створення Піцци";
            this.createButton.Location = new Point(10, 40);
            this.createButton.Click += new EventHandler(this.CreateButton_Click);
            this.Controls.Add(this.createButton);
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            if (this.PizzaComboBox.SelectedItem == null)
            {
                MessageBox.Show("Будь ласка, оберіть піццу");
                return;
            }

            string PizzaBrand = this.PizzaComboBox.SelectedItem.ToString();
            Pizza Pizza = PizzaFactory.CreatePizza(PizzaBrand);
            if (Pizza == null)
            {
                MessageBox.Show("Не вірно вибрана піцца");
                return;
            }

            MessageBox.Show("Створеня піцци");
            Pizza.Diametr();
            Pizza.Weight();
            Pizza.Ingredients();
        }
    }
}
