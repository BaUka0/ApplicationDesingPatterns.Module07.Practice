using Practice_7;
using System;
namespace Practice_5
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Strategy
            /*TravelBookingContext context = new TravelBookingContext();

            context.ChangeTravelStrategy(new PlaneStrategy());
            double planeCost = context.ProcessTravel(1500, 250, 2, true, false);
            Console.WriteLine($"Стоимость перелета на самолете: {planeCost} тг");

            context.ChangeTravelStrategy(new TrainStrategy());
            double trainCost = context.ProcessTravel(2500, 180, 1, true, true);
            Console.WriteLine($"Стоимость поездки на поезде: {trainCost} тг");

            context.ChangeTravelStrategy(new BusStrategy());
            double busCost = context.ProcessTravel(15, 25, 1, false, true);
            Console.WriteLine($"Стоимость поездки на автобусе: {busCost} тг");

            context.ChangeTravelStrategy(new TaxiStrategy());
            double taxiCost = context.ProcessTravel(20, 2, 2, true, false);
            Console.WriteLine($"Стоимость поездки на такси: {taxiCost} тг");

            Console.ReadLine();*/

            //Observer
            StockExchange stockExhange = new StockExchange("Apple", 150);
            stockExhange.SetStockExchange("Nvidia", 180);

            Trader trader1 = new Trader("Alinur Fushigura");
            Trader trader2 = new Trader("Aleks Mahoraga");

            Robot robot1 = new Robot("Siri AI", 130, 160);
            Robot robot2 = new Robot("Cortana", 170, 190);

            stockExhange.Subscribe("Apple", trader1);
            stockExhange.Subscribe("Apple", trader2);
            stockExhange.Subscribe("Apple", robot1);

            stockExhange.Subscribe("Nvidia", trader1);
            stockExhange.Subscribe("Nvidia", trader2);
            stockExhange.Subscribe("Nvidia", robot2);

            stockExhange.SetStockExchange("Apple", 170);
            stockExhange.SetStockExchange("Nvidia", 170);
        }
    }
}