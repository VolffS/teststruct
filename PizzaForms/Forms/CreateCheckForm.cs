using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PizzaForms.Forms
{
    public partial class CreateCheckForm : Form
    {
        public int IdBuyers;
        public List<Pizza> selectedPizzas = new List<Pizza>();

        List<Client> clients;
        List<Pizza> pizzas;
        public CreateCheckForm()
        {
            InitializeComponent();
        }
        
        public CreateCheckForm(List<Client> clients,List<Pizza> pizzas)
        {
            InitializeComponent();
            this.clients = clients;
            this.pizzas = pizzas;

            InitializeControls();
        }

        /// <summary>
        /// Инициализирует наши контролы
        /// </summary>
        private void InitializeControls()
        {
            BuyerBox.Items.AddRange(clients.ToArray());
            
            foreach (var pizza in pizzas)
            {
                var item = new ListViewItem();
                item.Tag = pizza;
                item.Text = pizza.Name;
                item.SubItems.Add( pizza.Price.ToString());
                listView1.Items.Add(item);
            }
        }

        private void pizzaBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {

        }

        private void pizzaBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {

        }

        private void CreateCheckForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Готово
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (BuyerBox.SelectedItem != null)
            {
                var cl = (Client)BuyerBox.SelectedItem;
                IdBuyers = cl.Id;
                foreach (var item in OrderView.Items)
                {
                    var pizza = (Pizza)((ListViewItem)item).Tag;
                    selectedPizzas.Add(pizza);
                }
                button2.DialogResult = DialogResult.OK;
                button2.PerformClick();                
            }
            else
            {
                MessageBox.Show(
              "Не выбран покупатель",
              "Сообщение",
              MessageBoxButtons.OK,
              MessageBoxIcon.Information,
              MessageBoxDefaultButton.Button1,
              MessageBoxOptions.ServiceNotification);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void OrderView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Добавить в Список
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count!= 0)
            {
                bool temp = false;
                var pizza = (Pizza)listView1.SelectedItems[0].Tag;
                foreach (ListViewItem items in OrderView.Items)
                {
                    if (items.Text == pizza.Name)
                    {
                        pizza.Count += (int)Count.Value;
                        items.SubItems[1].Text = pizza.Count.ToString();
                        temp = true;
                    }

                }
                if (temp != true)
                {
                    var item = new ListViewItem();
                    item.Tag = pizza;
                    item.Text = pizza.Name;
                    pizza.Count = (int)Count.Value;
                    item.SubItems.Add(pizza.Count.ToString());
                    OrderView.Items.Add(item);
            }
        }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (OrderView.SelectedItems.Count != 0)
            {
                OrderView.Items.Remove(OrderView.SelectedItems[0]);
            }
        }
    }

    public class Client
    {
        public string Name { get; set; }
        public int Id { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
    public class Pizza
    {
        public string Name { get; set; }
        public int IdPizza { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
    }
}
