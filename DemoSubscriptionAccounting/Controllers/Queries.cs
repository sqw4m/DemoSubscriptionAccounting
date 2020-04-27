using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DemoSubscriptionAccounting.Models;

namespace DemoSubscriptionAccounting.Controllers
{
    class Queries
    {
        private PeriodicalsEntities _db;

        public Queries()
        {
            _db = new PeriodicalsEntities();
        } // Queries

        // запрос выборки данных видов изданий
        public IList QueryPublicationTypes() =>
            _db.PublicationTypes
            .Select(pt => new
            {
                pt.TypeName
            }).ToList();

        // запрос выборки данных изданий
        public IEnumerable QueryPublications() =>
            _db.Publications
            .Select(p => new
            {
                p.PublicationType.TypeName,
                p.PublicationIndex,
                p.Title,
                p.Price
            }).ToList();

        // запрос выборки данных подписчиков
        public IEnumerable QuerySubscribers() =>
            _db.Subscribers
            .Select(s => new
            {
                s.SurnameNP,
                s.Street,
                s.Building,
                s.Apartment
            }).ToList();

        // запрос выборки данных подписок
        public IEnumerable QueryDeliveries() =>
            _db.Deliveries
            .Select(d => new
            {
                d.Id,
                d.Publication.PublicationType.TypeName,
                d.Publication.PublicationIndex,
                d.Publication.Title,
                d.Publication.Price,
                d.Subscriber.SurnameNP,
                d.Subscriber.Street,
                d.StartDate,
                d.Duration
            }).ToList();

        // 1	Запрос на выборку
        // Выбирает из таблицы ИЗДАНИЯ информацию о доступных для подписки газетах, 
        // название которых начинается с заданной буквы. Например, «П»
        public IEnumerable Query01(string startsWith) =>
            _db.Publications
            .Where(p => p.Title.StartsWith(startsWith))
            .Select(p => new {
                p.PublicationType.TypeName,
                p.PublicationIndex,
                p.Title,
                p.Price
            }).ToList();

        // 2	Запрос на выборку	
        // Выбирает из таблиц информацию о подписчиках, проживающих на улице «Садовая»,
        // которые оформили подписку на издание с индексом «12123» 
        // (можно использовать другие название улицы и индекс)
        public IEnumerable Query02(string street, string index) =>
            _db.Deliveries
            .Where(d => d.Subscriber.Street.Contains(street) && d.Publication.PublicationIndex.Contains(index))
            .Select(d => new
            {
                d.Publication.PublicationType.TypeName,
                d.Publication.PublicationIndex,
                d.Subscriber.SurnameNP,
                d.Subscriber.Street,
                d.Subscriber.Building,
                d.Subscriber.Apartment,
                d.StartDate,
                d.Duration
            }).ToList();

        // 3	Запрос на выборку	
        // Выбирает из таблицы ПОЛУЧАТЕЛИ информацию о подписчиках, 
        // проживающих на улице «Садовая» в домах с номерами 2, 7, 8. 
        // Можно использовать другие названия улицы и номера домов
        public IEnumerable Query03(string street, string building) =>
            _db.Subscribers
            .Where(s => s.Street.Contains(street) && s.Building == building)
            .Select(s => new
            {
                s.SurnameNP,
                s.Street,
                s.Building,
                s.Apartment
            }).ToList();

        // 4	Запрос на выборку	
        // Выбирает из таблицы ИЗДАНИЯ информацию об издании с заданным индексом. 
        // Значение индекса вводится при выполнении запроса
        public IEnumerable Query04(string index) =>
            _db.Publications
            .Where(p => p.PublicationIndex == index)
            .Select(p => new {
                p.PublicationType.TypeName,
                p.PublicationIndex,
                p.Title,
                p.Price
            }).ToList();

        // 5	Запрос на выборку	
        // Выбирает из таблицы ИЗДАНИЯ информацию обо всех изданиях, 
        // для которых цена 1 экземпляра есть значение из некоторого диапазона.
        // Нижняя и верхняя границы диапазона задаются при выполнении запроса
        public IEnumerable Query05(double minPrice, double maxPrice) =>
            _db.Publications
            .Where(p => p.Price > minPrice && p.Price < maxPrice)
            .Select(p => new {
                p.PublicationType.TypeName,
                p.PublicationIndex,
                p.Title,
                p.Price
            }).ToList();

        // 6	Запрос с вычисляемыми полями	
        // Вычисляет для каждой оформленной подписки ее стоимость без доставки и без НДС.
        // Включает поля Индекс издания, Наименование издания, Цена 1 экземпляра, 
        // Дата начала подписки, Срок подписки, Стоимость подписки без доставки и без НДС.
        // Сортировка по полю Индекс издания
        public IEnumerable Query06() =>
            _db.Deliveries
            .Select(d => new
            {
                d.Publication.PublicationType.TypeName,
                d.Publication.PublicationIndex,
                d.Publication.Title,
                d.Publication.Price,
                d.StartDate,
                d.Duration,
                Cost = d.Publication.Price * d.Duration
            }).OrderBy(d => d.PublicationIndex).ToList();

        // 7	Итоговый запрос – агрегатные функции	
        // Выполняет группировку по полю Вид издания. 
        // Для каждого вида вычисляет среднюю цену 1 экземпляра
        public IEnumerable Query07() =>
            _db.Publications
            .GroupBy(p => p.PublicationType.TypeName)
            .Select(p => new
            {
                PublicationType = p.Key,
                AveragePrice = p.Average(avgPrice => avgPrice.Price)
            }).ToList();

        // 8	Итоговый запрос – агрегатные функции	
        // Выполняет группировку по полю Вид издания. 
        // Для каждого вида вычисляет максимальную и минимальную цену 1 экземпляра
        public IEnumerable Query08() =>
            _db.Publications
            .GroupBy(p => p.PublicationType.TypeName)
            .Select(p => new
            {
                PublicationType = p.Key,
                MinPrice = p.Min(minPrice => minPrice.Price),
                MaxPrice = p.Max(maxPrice => maxPrice.Price)
            }).ToList();

        // 9	Добавление 	
        // Добавить новое издание
        public void Query09(string pubIndex, string typeName, string title, double price)
        {
            PublicationType pubType = _db.PublicationTypes.First(pt => pt.TypeName == typeName);
            _db.Publications
                .Add(new Publication { 
                    PublicationIndex = pubIndex, 
                    IdPublicationType = pubType.Id, 
                    Title = title, 
                    Price = price });
            _db.SaveChanges();
        } // Query09

        // 10	Удаление	
        // Удаление оформленной подписки
        public void Query10(int id)
        {
            _db.Deliveries.Remove(_db.Deliveries.First(c => c.Id == id));

            // обновить базу данных
            _db.SaveChanges();
        } // Query10

        // 11	Модификация 
        // Увеличить на 1 месяц длительность подписки, 
        // но новая длительность подписки не должна превышать 12 месяцев
        public void Query11(int id)
        {
            // изменить выбранную запись в коллекции: получить ссылку на запись в коллекции,
            // изменить запись
            Delivery delivery = _db.Deliveries.First(c => c.Id == id);
            if (delivery.Duration < 12)
                delivery.Duration += 1;
            else
                MessageBox.Show("Невозможно увеличить длительность подписки.\n" +
                    "Максимальный срок подписки 12 месяцев!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            // обновить базу данных
            _db.SaveChanges();
        } // Query11
    } // Queries
}
