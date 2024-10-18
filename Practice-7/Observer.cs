using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_7
{
    public interface IObserver
    {
        void Update(string stock, float price);
    }
    public interface ISubject
    {
        void Subscribe(string stock, IObserver observer);
        void Unsubscribe(string stock, IObserver observer);
        void NotifyObserver(string stock);
    }
    public class StockExchange : ISubject
    {
        private Dictionary<string, float> _stocks = new Dictionary<string, float>();
        private Dictionary<string, List<IObserver>> _observers = new Dictionary<string, List<IObserver>>();
        public StockExchange(string stock, float price)
        {
            _stocks[stock] = price;
            _observers[stock] = new List<IObserver>();
        }
        public void SetStockExchange(string stock, float price)
        {
            if (!_stocks.ContainsKey(stock))
            {
                _stocks[stock] = price;
                _observers[stock] = new List<IObserver>();
            }
            else
            {
                _stocks[stock] = price;
            }
            NotifyObserver(stock);
        }
        public void Subscribe(string stock, IObserver observer)
        {
            _observers[stock].Add(observer);
        }
        public void Unsubscribe(string stock, IObserver observer)
        {
            _observers[stock].Remove(observer);
        }
        public void NotifyObserver(string stock)
        {
            if (_observers.ContainsKey(stock))
            {
                foreach (var observer in _observers[stock])
                {
                    observer.Update(stock, _stocks[stock]);
                }
            }
        }
    }
    public class Trader : IObserver
    {
        private string _name;
        
        public Trader(string name)
        {
            _name = name;
        }

        public void Update(string stock, float price)
        {
            Console.WriteLine($"{_name} получил eведомление: Акция {stock}, новая цена: {price}");
        }
    }
    public class Robot : IObserver
    {
        private string _name;
        private float _buyPrice;
        private float _sellPrice;

        public Robot(string name, float buyPrice, float sellPrice)
        {
            _name = name;
            _buyPrice = buyPrice;
            _sellPrice = sellPrice;
        }
        public void Update(String stock, float price)
        {
            if (price <= _buyPrice)
                Console.WriteLine($"{_name}: Покупает акцию: {stock} по низкой цене: {price}");
            else if (price > _sellPrice)
                Console.WriteLine($"{_name}: Продает акцию: {stock} по высокой цене: {price}");
            else
                Console.WriteLine($"{_name} получил eведомление: Акция {stock}, новая цена: {price}");
        }
    }
    internal class Observer
    {
    }
}
