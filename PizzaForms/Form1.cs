using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using PizzaForms.Data;
using PizzaForms.Forms;
using teststruct.PizzaRest;
using teststruct.PizzaRest.Workers;
using Timer = System.Windows.Forms.Timer;

namespace PizzaForms
{
    public partial class Form1 : Form
    {
        static string PizzaNakerWork;
        static string DiswasherWork;
        static string DiswasherWorkImg= Application.StartupPath + "\\Pictures" + "\\Shlapa.jpg";
        static string PizzaMakerWorkImg = Application.StartupPath + "\\Pictures" + "\\Shlapa.jpg";


        Timer timer = new Timer();

        static BackgroundWorker worker = new BackgroundWorker();
        PizzaMaker pizzaMaker = new PizzaMaker("Gleb");
        Dishwasher disshwasher = new Dishwasher("OLEG");
        PizzeriaRest pizzeriaRest = new PizzeriaRest();
        PizzaRepo pizzaRepo;
        public Form1()
        {
            timer.Tick += new EventHandler(RefreshLabel);
            timer.Interval = 1000; // Здесь интервал на (1 сек)
            timer.Start();
            pizzaMaker.StartCook += PizzaMaker_StartCook;
            pizzaMaker.OnCook += PizzaMaker_OnCook;
            pizzaMaker.EndCook += PizzaMaker_EndCook;
            pizzaMaker.WaitCook += PizzaMaker_WaitCook;
            disshwasher.Onwashing += Disshwasher_Onwashing;
            disshwasher.Endwashing += Disshwasher_Endwashing;
            pizzeriaRest.AddWorker(pizzaMaker);
            pizzeriaRest.AddWorker(disshwasher);



            InitializeComponent();
            pizzaRepo = new PizzaRepo(pizzeriaDataSet);
            
            pizzeriaRest.pizzariaRepository = pizzaRepo;
            
            worker.DoWork += Worker_DoWork;
            worker.RunWorkerAsync();
            pizzaRepo.BeginUpdate += PizzaRepo_BeginUpdate;
        }

        private void PizzaMaker_WaitCook()
        {
            PizzaMakerWorkImg = Application.StartupPath + "\\Pictures" + "\\Shlapa.jpg";
        }

        private void PizzaRepo_BeginUpdate()
        {
            this.Validate();
            this.pizza_OrdersBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.pizzeriaDataSet);
        }

        public void RefreshLabel(object sender, EventArgs e)
        {
            label2.Text = PizzaNakerWork; // Сюда вставь свое обновление label
            label4.Text = DiswasherWork; // Сюда вставь свое обновление label
            label1.Text = $"{pizzaMaker.Name} Начал работу";
            label3.Text = $"{disshwasher.Name} Начал работу";
            pictureBoxDishwasher.Image = Image.FromFile(DiswasherWorkImg);
            pictureBoxPizzaMaker.Image = Image.FromFile(PizzaMakerWorkImg);

        }

        private void Disshwasher_Endwashing(Dishwasher dishwasher)
        {
            //Console.WriteLine("Тарелка помылась");
            DiswasherWork = "Тарелка помылась";
            DiswasherWorkImg = Application.StartupPath + "\\Pictures" + "\\Shlapa.jpg";
        }

        private void Disshwasher_Onwashing(Dishwasher dishwasher)
        {
            //Console.WriteLine("Тарелка моется");
            DiswasherWork = "Тарелка моется";
            DiswasherWorkImg = Application.StartupPath+"\\Pictures"+"\\Dishwasher.jpg";
        }

        private void PizzaMaker_OnCook(PizzaMaker maker, Pizza pizza)
        {
            //Console.WriteLine($"Пицца {pizza.Name} готовиться");
            PizzaNakerWork = $"Пицца {pizza.Name} готовиться";
            PizzaMakerWorkImg = Application.StartupPath + "\\Pictures" + "\\PizzaOn.jpg";

        }

        private void PizzaMaker_EndCook(PizzaMaker maker, Pizza pizza)
        {
            //Console.WriteLine($"Пицца {pizza.Name} готова");
            PizzaNakerWork = $"Пицца {pizza.Name} готова";
            PizzaMakerWorkImg = Application.StartupPath + "\\Pictures" + "\\PizzaReady.jpg";

        }

        private void PizzaMaker_StartCook(PizzaMaker maker, Pizza pizza)
        {
            //Console.WriteLine($"Пицца {pizza.Name} начала готовится");
            PizzaNakerWork = $"Пицца {pizza.Name} начала готовится";
            PizzaMakerWorkImg = Application.StartupPath + "\\Pictures" + "\\PizzaOn.jpg";
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                pizzeriaRest.Work();
                Thread.Sleep(1000);
            }
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
                        select new PizzaForm
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
                    pizzeriaDataSet.Pizza_Orders.Rows.Add(new object[] {null, pizzeriaDataSet.Check.Last().Id_Check, item.IdPizza, item.Count,"Не готово" });
                    this.tableAdapterManager.UpdateAll(this.pizzeriaDataSet);

                }
            }
        }


    }
}
