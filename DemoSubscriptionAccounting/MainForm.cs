using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DemoSubscriptionAccounting.Models;
using DemoSubscriptionAccounting.Controllers;

namespace DemoSubscriptionAccounting
{
    public partial class MainForm : Form
    {
        Queries _queries;
        int _queryIndex;                // индекс запроса
        int _row;
        int _id;

        public MainForm()
        {
            InitializeComponent();
            _queries = new Queries();

        } // MainForm

        private void MainForm_Load(object sender, EventArgs e)
        {
            lblPar1.Visible = false;
            lblPar2.Visible = false;
            lblPar3.Visible = false;
            lblPar4.Visible = false;

            txbPar1.Visible = false;
            txbPar2.Visible = false;
            txbPar3.Visible = false;
            txbPar4.Visible = false;

            dvwPublicationTypes.DataSource = _queries.QueryPublicationTypes();
            dvwPublications.DataSource = _queries.QueryPublications();
            dvwSubscribers.DataSource = _queries.QuerySubscribers();
            dvwDeliveries.DataSource = _queries.QueryDeliveries();
        } // MainForm_Load

        private void tsbQuery1_Click(object sender, EventArgs e)
        {
            _queryIndex = 1;
            txbQueryInfo.Text = "1.Выбирает из таблицы ИЗДАНИЯ информацию о доступных для подписки газетах,\n" +
                "название которых начинается с заданной буквы. Например, «П»";
            lblPar1.Visible = true;
            lblPar2.Visible = false;
            lblPar3.Visible = false;
            lblPar4.Visible = false;

            txbPar1.Visible = true;
            txbPar2.Visible = false;
            txbPar3.Visible = false;
            txbPar4.Visible = false;
            lblPar1.Text = "Буква:";

            txbPar1.Clear();
            txbPar2.Clear();
            txbPar3.Clear();
            txbPar4.Clear();
        } // tsbQuery1_Click    

        private void tsbQuery2_Click(object sender, EventArgs e)
        {
            _queryIndex = 2;
            txbQueryInfo.Text = "2.Выбирает из таблиц информацию о подписчиках, проживающих на заданной улице, " +
                "которые оформили подписку на издание с заданным индексом";
            lblPar1.Visible = true;
            lblPar2.Visible = true;
            lblPar3.Visible = false;
            lblPar4.Visible = false;

            txbPar1.Visible = true;
            txbPar2.Visible = true;
            txbPar3.Visible = false;
            txbPar4.Visible = false;
            lblPar1.Text = "Улица:";
            lblPar2.Text = "Индекс:";

            txbPar1.Clear();
            txbPar2.Clear();
            txbPar3.Clear();
            txbPar4.Clear();
        } // tsbQuery2_Click

        private void tsbQuery3_Click(object sender, EventArgs e)
        {
            _queryIndex = 3;
            txbQueryInfo.Text = "3.Выбирает из таблицы ПОЛУЧАТЕЛИ информацию о подписчиках, " +
                "проживающих на заданной улице в заданном доме";
            lblPar1.Visible = true;
            lblPar2.Visible = true;
            lblPar3.Visible = false;
            lblPar4.Visible = false;

            txbPar1.Visible = true;
            txbPar2.Visible = true;
            txbPar3.Visible = false;
            txbPar4.Visible = false;
            lblPar1.Text = "Улица:";
            lblPar2.Text = "Дом:";

            txbPar1.Clear();
            txbPar2.Clear();
            txbPar3.Clear();
            txbPar4.Clear();
        } // tsbQuery3_Click

        private void tsbQuery4_Click(object sender, EventArgs e)
        {
            _queryIndex = 4;
            txbQueryInfo.Text = "4.Выбирает из таблицы ИЗДАНИЯ информацию об издании с заданным индексом.";
            lblPar1.Visible = true;
            lblPar2.Visible = false;
            lblPar3.Visible = false;
            lblPar4.Visible = false;

            txbPar1.Visible = true;
            txbPar2.Visible = false;
            txbPar3.Visible = false;
            txbPar4.Visible = false;
            lblPar1.Text = "Индекс:";

            txbPar1.Clear();
            txbPar2.Clear();
            txbPar3.Clear();
            txbPar4.Clear();
        } // tsbQuery4_Click

        private void tsbQuery5_Click(object sender, EventArgs e)
        {
            _queryIndex = 5;
            txbQueryInfo.Text = "5.Выбирает из таблицы ИЗДАНИЯ информацию обо всех изданиях, " +
                "для которых цена 1 экземпляра есть значение из некоторого диапазона.";
            lblPar1.Visible = true;
            lblPar2.Visible = true;
            lblPar3.Visible = false;
            lblPar4.Visible = false;

            txbPar1.Visible = true;
            txbPar2.Visible = true;
            txbPar3.Visible = false;
            txbPar4.Visible = false;
            lblPar1.Text = "Минимальная цена:";
            lblPar2.Text = "Максимальная цена:";

            txbPar1.Clear();
            txbPar2.Clear();
            txbPar3.Clear();
            txbPar4.Clear();
        } // tsbQuery5_Click

        private void tsbQuery6_Click(object sender, EventArgs e)
        {
            _queryIndex = 6;
            txbQueryInfo.Text = "6.Вычисляет для каждой оформленной подписки ее стоимость без доставки и без НДС. " +
                "Включает поля Индекс издания, Наименование издания, Цена 1 экземпляра, " +
                "Дата начала подписки, Срок подписки, Стоимость подписки без доставки и без НДС. " +
                "Сортировка по полю Индекс издания.";
            lblPar1.Visible = false;
            lblPar2.Visible = false;
            lblPar3.Visible = false;
            lblPar4.Visible = false;

            txbPar1.Visible = false;
            txbPar2.Visible = false;
            txbPar3.Visible = false;
            txbPar4.Visible = false;

            txbPar1.Clear();
            txbPar2.Clear();
            txbPar3.Clear();
            txbPar4.Clear();
        } // tsbQuery6_Click

        private void tsbQuery7_Click(object sender, EventArgs e)
        {
            _queryIndex = 7;
            txbQueryInfo.Text = "7.Выполняет группировку по полю Вид издания. " +
                    "Для каждого вида вычисляет среднюю цену 1 экземпляра.";
            lblPar1.Visible = false;
            lblPar2.Visible = false;
            lblPar3.Visible = false;
            lblPar4.Visible = false;

            txbPar1.Visible = false;
            txbPar2.Visible = false;
            txbPar3.Visible = false;
            txbPar4.Visible = false;

            txbPar1.Clear();
            txbPar2.Clear();
            txbPar3.Clear();
            txbPar4.Clear();
        } // tsbQuery7_Click

        private void tsbQuery8_Click(object sender, EventArgs e)
        {
            _queryIndex = 8;
            txbQueryInfo.Text = "8.Выполняет группировку по полю Вид издания. " +
                "Для каждого вида вычисляет максимальную и минимальную цену 1 экземпляра.";
            lblPar1.Visible = false;
            lblPar2.Visible = false;
            lblPar3.Visible = false;
            lblPar4.Visible = false;

            txbPar1.Visible = false;
            txbPar2.Visible = false;
            txbPar3.Visible = false;
            txbPar4.Visible = false;

            txbPar1.Clear();
            txbPar2.Clear();
            txbPar3.Clear();
            txbPar4.Clear();
        } // tsbQuery8_Click

        private void tsbQuery9_Click(object sender, EventArgs e)
        {
            _queryIndex = 9;
            txbQueryInfo.Text = "9.Добавить новое издание.";
            lblPar1.Visible = true;
            lblPar2.Visible = true;
            lblPar3.Visible = true;
            lblPar4.Visible = true;

            txbPar1.Visible = true;
            txbPar2.Visible = true;
            txbPar3.Visible = true;
            txbPar4.Visible = true;

            lblPar1.Text = "Индекс:";
            lblPar2.Text = "Тип:";
            lblPar3.Text = "Название:";
            lblPar4.Text = "Цена:";

            txbPar1.Clear();
            txbPar2.Clear();
            txbPar3.Clear();
            txbPar4.Clear();
        } // tsbQuery9_Click

        private void tsbQuery10_Click(object sender, EventArgs e)
        {
            _queryIndex = 10;
            txbQueryInfo.Text = "10.Удаление оформленной подписки.";
            lblPar1.Visible = false;
            lblPar2.Visible = false;
            lblPar3.Visible = false;
            lblPar4.Visible = false;

            txbPar1.Visible = false;
            txbPar2.Visible = false;
            txbPar3.Visible = false;
            txbPar4.Visible = false;

            txbPar1.Clear();
            txbPar2.Clear();
            txbPar3.Clear();
            txbPar4.Clear();

            tbcMain.SelectedTab = tbpDeliveries;
        } // tsbQuery10_Click

        private void tsbQuery11_Click(object sender, EventArgs e)
        {
            _queryIndex = 11;
            txbQueryInfo.Text = "11.Увеличить на 1 месяц длительность подписки, " +
                "но новая длительность подписки не должна превышать 12 месяцев.";
            lblPar1.Visible = false;
            lblPar2.Visible = false;
            lblPar3.Visible = false;
            lblPar4.Visible = false;

            txbPar1.Visible = false;
            txbPar2.Visible = false;
            txbPar3.Visible = false;
            txbPar4.Visible = false;

            txbPar1.Clear();
            txbPar2.Clear();
            txbPar3.Clear();
            txbPar4.Clear();

            tbcMain.SelectedTab = tbpDeliveries;
        } // tsbQuery11_Click

        private void tsbExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        } // tsbExit_Click

        private void btnQuery_Click(object sender, EventArgs e)
        {
            switch (_queryIndex)
            {
                case 1:
                    dvwQueries.DataSource = _queries.Query01(txbPar1.Text);
                    tbcMain.SelectedTab = tbpQueries;
                    break;

                case 2:
                    dvwQueries.DataSource = _queries.Query02(txbPar1.Text, txbPar2.Text);
                    tbcMain.SelectedTab = tbpQueries;
                    break;

                case 3:
                    dvwQueries.DataSource = _queries.Query03(txbPar1.Text, txbPar2.Text);
                    tbcMain.SelectedTab = tbpQueries;
                    break;

                case 4:
                    dvwQueries.DataSource = _queries.Query04(txbPar1.Text);
                    tbcMain.SelectedTab = tbpQueries;
                    break;

                case 5:
                    dvwQueries.DataSource = 
                        _queries.Query05(double.Parse(txbPar1.Text), double.Parse(txbPar2.Text));
                    tbcMain.SelectedTab = tbpQueries;
                    break;

                case 6:
                    dvwQueries.DataSource = _queries.Query06();
                    tbcMain.SelectedTab = tbpQueries;
                    break;

                case 7:
                    dvwQueries.DataSource = _queries.Query07();
                    tbcMain.SelectedTab = tbpQueries;
                    break;

                case 8:
                    dvwQueries.DataSource = _queries.Query08();
                    tbcMain.SelectedTab = tbpQueries;
                    break;

                case 9:
                    _queries.Query09(txbPar1.Text, txbPar2.Text, txbPar3.Text, double.Parse(txbPar4.Text));
                    dvwPublications.DataSource = _queries.QueryPublications();
                    tbcMain.SelectedTab = tbpPublications;
                    break;

                case 10:
                    // получить Id выбранной записи
                    _row = dvwDeliveries.CurrentRow.Index; // индекс текущей строки
                    _id = int.Parse(dvwDeliveries[0, _row].Value.ToString());
                    _queries.Query10(_id);
                    dvwDeliveries.DataSource = _queries.QueryDeliveries();
                    tbcMain.SelectedTab = tbpDeliveries;
                    // установить текущую строку на измененную после перезагрузки грида
                    dvwDeliveries.CurrentCell = dvwDeliveries[1, dvwDeliveries.RowCount - 1];
                    break;

                case 11:
                    // получить Id выбранной записи
                    _row = dvwDeliveries.CurrentRow.Index; // индекс текущей строки
                    _id = int.Parse(dvwDeliveries[0, _row].Value.ToString());
                    _queries.Query11(_id);
                    dvwDeliveries.DataSource = _queries.QueryDeliveries();
                    tbcMain.SelectedTab = tbpDeliveries;
                    // установить текущую строку на измененную после перезагрузки грида
                    dvwDeliveries.CurrentCell = dvwDeliveries[1, _row];
                    break;
            } // switch
        } // btnQuery_Click
    } // MainForm
}
