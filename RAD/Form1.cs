using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RAD.DataAccess;
using System.Data.Entity;
using Aspose.Cells;
using Aspose.Words;

namespace RAD
{
    public partial class Form1 : Form
    {
        private Application _app;
        private Workbook _wb;
        private Worksheet _ws;

        Context context = new Context();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            context.Products.Load();
            context.Consumptions.Load();
            context.Incomes.Load();
            context.IncomeProducts.Load();
            context.ProductConsumptions.Load();
            context.Providers.Load();
           
            consumptionBindingSource.DataSource = context.Consumptions.Local.ToBindingList();
            incomeBindingSource.DataSource = context.Incomes.Local.ToBindingList();
            incomeProductBindingSource.DataSource = context.IncomeProducts.Local.ToBindingList();
            productBindingSource.DataSource = context.Products.Local.ToBindingList();
            productConsumptionBindingSource.DataSource = context.ProductConsumptions.Local.ToBindingList();
            providerBindingSource.DataSource = context.Providers.Local.ToBindingList();
            //((System.Windows.Forms.ListBox)checkedListBox1).DataSource = context.Providers.Local.ToBindingList();
            //paymentDataGridView.
        }


        private void productConsumptionDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void consumptionBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            context.SaveChanges();
            this.Refresh();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        private void incomeDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
        private void incomeProductDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
        private void productConsumptionDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void productDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<int> resust = new List<int>();
            var Incomes = context.IncomeProducts.Local.ToList().Where(income => income.Income.Date <= dateTimePicker2.Value && income.Income.Date >= dateTimePicker1.Value);
            var Consumptions = context.ProductConsumptions.Local.ToList().Where(consumptions => consumptions.Consumption.Date <= dateTimePicker2.Value && consumptions.Consumption.Date >= dateTimePicker1.Value);
            var Incomes1 = context.IncomeProducts.Local.ToList().Where(income => income.Income.Date >= dateTimePicker1.Value);
            var Consumptions1 = context.ProductConsumptions.Local.ToList().Where(consumptions => consumptions.Consumption.Date >= dateTimePicker1.Value);
            var Incomes2 = context.IncomeProducts.Local.ToList().Where(income => income.Income.Date >= dateTimePicker2.Value);
            var Consumptions2 = context.ProductConsumptions.Local.ToList().Where(consumptions => consumptions.Consumption.Date >= dateTimePicker2.Value);

            var workbook = new Workbook();
            var worksheet = workbook.Worksheets[0];

            var dataTable = new DataTable("InputInvoices");
            dataTable.Columns.Add("1", typeof(string));
            dataTable.Columns.Add("Наименование товара", typeof(string));
            dataTable.Columns.Add("Цена за штуку", typeof(int));
            dataTable.Columns.Add("Кол-во", typeof(int));
            var row = dataTable.NewRow();
            row[0] = "Наличие товара на " + dateTimePicker1.Value.ToString();
            dataTable.Rows.Add(row);
            var products = context.Products.Local.ToList();
            
            foreach (var orderProduct in Incomes1)
            {
                foreach (var product in products)
                {
                    if (orderProduct.ProductId == product.Id)
                    {
                        product.Quantity -= orderProduct.Quantity;
                    }
                }
            }
            foreach (var orderProduct in Consumptions1)
            {
                foreach (var product in products)
                {
                    if (orderProduct.ProductId == product.Id)
                    {
                        product.Quantity += orderProduct.Quantity;
                    }
                }
            }
         
            foreach (var orderProduct in products)
            {
                row = dataTable.NewRow();
                row[0] = "" ;
                row[1] = orderProduct.Name;
                row[2] = orderProduct.Price;
                row[3] = orderProduct.Quantity;
                dataTable.Rows.Add(row);
            }

            row = dataTable.NewRow();
            row[0] = "Наличие товара на " + dateTimePicker2.Value.ToString();
            dataTable.Rows.Add(row);
            products = context.Products.Local.ToList();

            foreach (var orderProduct in Incomes2)
            {
                foreach (var product in products)
                {
                    if (orderProduct.ProductId == product.Id)
                    {
                        product.Quantity -= orderProduct.Quantity;
                    }
                }
            }
            foreach (var orderProduct in Consumptions2)
            {
                foreach (var product in products)
                {
                    if (orderProduct.ProductId == product.Id)
                    {
                        product.Quantity += orderProduct.Quantity;
                    }
                }
            }

            foreach (var orderProduct in products)
            {
                row = dataTable.NewRow();
                row[0] = "";
                row[1] = orderProduct.Name;
                row[2] = orderProduct.Price;
                row[3] = orderProduct.Quantity;
                dataTable.Rows.Add(row);
            }
            workbook.Worksheets.Add();

            var worksheet1 = workbook.Worksheets[1];
            var dataTable1 = new DataTable("InputInvoices1");
            dataTable1.Columns.Add("Движение товара", typeof(string));
            dataTable1.Columns.Add("Наименование товара", typeof(string));
            dataTable1.Columns.Add("Цена за штуку", typeof(int));
            dataTable1.Columns.Add("Кол-во", typeof(int));
            dataTable1.Columns.Add("Название поставщика", typeof(string));
            dataTable1.Columns.Add("Дата", typeof(string));

          
            foreach (var income in Incomes)
            {
                row = dataTable1.NewRow();
                row[0] = "Приход";
                row[1] = income.Product.Name;
                row[2] = income.Product.Price;
                row[3] = income.Quantity;
                row[4] = income.Income.Provider.Name;
                row[5] = income.Income.Date.ToString();

                dataTable1.Rows.Add(row);
            }
            foreach (var consumption in Consumptions)

            {
                row = dataTable1.NewRow();
                row[0] = "Расход";
                row[1] = consumption.Product.Name;
                row[2] = consumption.Product.Price*1.15;
                row[3] = consumption.Quantity;
                row[4] = consumption.Consumption.Date.ToString();

                dataTable1.Rows.Add(row);
            }
            worksheet.Cells.ImportData(dataTable, 0, 0, null);
            worksheet1.Cells.ImportData(dataTable1, 0, 0, null);
            string filepath = "D:/" + dateTimePicker1.Value.ToShortDateString() + "-" + dateTimePicker2.Value.ToShortDateString();
            workbook.Save(filepath + "report.xlsx");

            Document doc = new Document();
            DocumentBuilder builder = new DocumentBuilder(doc);
            builder.Write("Приходная накладная");
            builder.StartTable();
            builder.InsertCell();
            builder.Write("Дата");
            builder.InsertCell();
            builder.Write("Имя поставщика");
            builder.InsertCell();
            builder.Write("Адрес поставщика"); 
            builder.InsertCell();
            builder.Write("Название товара"); 
            builder.InsertCell();
            builder.Write("Цена товара"); 
            builder.InsertCell();
            builder.Write("Количество получено"); 
            builder.InsertCell();
            builder.Write("Сумма платежей");
            builder.EndRow();
            foreach (var income in Incomes)
            {
                builder.InsertCell();
                builder.Write(income.Income.Date.ToString());
                builder.InsertCell();
                builder.Write(income.Income.Provider.Name);
                builder.InsertCell();
                builder.Write(income.Income.Provider.Adress);
                builder.InsertCell();
                builder.Write(income.Product.Name);
                builder.InsertCell();
                builder.Write(income.Product.Price.ToString());
                builder.InsertCell();
                builder.Write(income.Quantity.ToString());
                builder.InsertCell();
                builder.Write((income.Quantity* income.Product.Price).ToString());
                builder.EndRow();
            }
            /*foreach (var consumption in Consumptions)

            {
                row = dataTable1.NewRow();
                row[0] = "Расход";
                row[1] = consumption.Product.Name;
                row[2] = consumption.Product.Price;
                row[3] = consumption.Quantity;
                row[4] = consumption.Consumption.Date.ToString();

                dataTable1.Rows.Add(row);
            }*/

            builder.EndTable();

            builder.Write("Расходная накладная");
            builder.StartTable();
            builder.InsertCell();
            builder.Write("Дата");
            builder.InsertCell();
            builder.Write("Название товара");
            builder.InsertCell();
            builder.Write("Цена товара");
            builder.InsertCell();
            builder.Write("Количество продано");
            builder.InsertCell();
            builder.Write("Сумма платежей");
            builder.EndRow();
            foreach (var consumption in Consumptions)
            {
                builder.InsertCell();
                builder.Write(consumption.Consumption.Date.ToString());
                builder.InsertCell();
                builder.Write(consumption.Product.Name);
                builder.InsertCell();
                builder.Write((consumption.Product.Price * 1.15).ToString());
                builder.InsertCell();
                builder.Write(consumption.Quantity.ToString());
                builder.InsertCell();
                builder.Write((consumption.Quantity * consumption.Product.Price * 1.15).ToString());
                builder.EndRow();
            }
            builder.EndTable();

            doc.Save("D:/report.docx");
        }

    }
}
