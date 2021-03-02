using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PizzaForms.Forms;

namespace PizzaForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }
        Random rand = new Random();
        private void buyersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.buyersBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.pizzeriaDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "pizzeriaDataSet.Pizzerias". При необходимости она может быть перемещена или удалена.
            this.pizzeriasTableAdapter.Fill(this.pizzeriaDataSet.Pizzerias);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "pizzeriaDataSet.Employees". При необходимости она может быть перемещена или удалена.
            this.employeesTableAdapter.Fill(this.pizzeriaDataSet.Employees);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "pizzeriaDataSet1.Pizzerias". При необходимости она может быть перемещена или удалена.
            this.pizzeriasTableAdapter.Fill(this.pizzeriaDataSet.Pizzerias);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "pizzeriaDataSet.Check". При необходимости она может быть перемещена или удалена.
            this.checkTableAdapter.Fill(this.pizzeriaDataSet.Check);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "pizzeriaDataSet.Pizza_Orders". При необходимости она может быть перемещена или удалена.
            this.pizza_OrdersTableAdapter.Fill(this.pizzeriaDataSet.Pizza_Orders);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "pizzeriaDataSet.Pizza". При необходимости она может быть перемещена или удалена.
            this.pizzaTableAdapter.Fill(this.pizzeriaDataSet.Pizza);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "pizzeriaDataSet.Buyers". При необходимости она может быть перемещена или удалена.
            this.buyersTableAdapter.Fill(this.pizzeriaDataSet.Buyers);

        }

        private void buyersBindingNavigator_RefreshItems(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.pizzaBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.pizzeriaDataSet);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.pizza_OrdersBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.pizzeriaDataSet);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.checkBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.pizzeriaDataSet);
        }



        private void дбавитьЗаказToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var clients = from cl in this.pizzeriaDataSet.Buyers
                          select new Client {
                              Id = cl.Id_Buyer,
                              Name = $"{cl.Last_Name} {cl.First_Name}"
                          };
            var pizza = from type in this.pizzeriaDataSet.Pizza
                        select new Pizza
                        {
                            IdPizza = type.Id_Pizza,
                            Name = type.Name,
                            Price = type.Price
                        };

            var form = new CreateCheckForm(clients.ToList(), pizza.ToList());
            if(form.ShowDialog() == DialogResult.OK)
            {                
                pizzeriaDataSet.Check.Rows.Add(new object[] { null, DateTime.Now, form.IdBuyers, rand.Next(1,pizzeriaDataSet.Pizzerias.Count())  });
                this.tableAdapterManager.UpdateAll(this.pizzeriaDataSet);
                foreach (var item in form.selectedPizzas)
                {
                    pizzeriaDataSet.Pizza_Orders.Rows.Add(new object[] {null, pizzeriaDataSet.Check.Last().Id_Check, item.IdPizza, item.Count });
                    this.tableAdapterManager.UpdateAll(this.pizzeriaDataSet);

                }
            }
        }

    }
}
