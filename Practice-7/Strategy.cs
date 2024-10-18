using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_7
{
    public interface ICostCalculationStrategy
    {
        double CalculateCost(float distance, int passenger, int TypeClass, bool bag, bool benefits);
    }

    public class PlaneStrategy : ICostCalculationStrategy
    {
        public double CalculateCost(float distance, int passenger, int TypeClass, bool bag, bool benefits)
        {
            double amount = 0;
            if (TypeClass == 1)
                amount = passenger * 1000;
            else if (TypeClass == 2)
                amount = passenger * 600;
            else
                amount = passenger * 400;
            if (benefits)
                amount *= 0.7;
            if (bag)
                amount *= 1.3;
            return amount *= 1.25 * distance;
        }
    }
    public class TrainStrategy : ICostCalculationStrategy
    {
        public double CalculateCost(float distance, int passenger, int TypeClass, bool bag, bool benefits)
        {
            double amount = 0;
            if (TypeClass == 1)
                amount = passenger * 400;
            else if (TypeClass == 2)
                amount = passenger * 240;
            else
                amount = passenger * 120;
            if (benefits)
                amount *= 0.6;
            if (bag)
                amount *= 1.2;

            return amount *= 1.1 * distance;
        }
    }
    public class BusStrategy : ICostCalculationStrategy
    {
        public double CalculateCost(float distance, int passenger, int TypeClass, bool bag, bool benefits)
        {
            if (benefits)
                return passenger * 60;
            return passenger * 120;
        }
    }
    public class TaxiStrategy : ICostCalculationStrategy
    {
        public double CalculateCost(float distance, int passenger, int TypeClass, bool bag, bool benefits)
        {
            double amount = 0;
            if (TypeClass == 1)
                amount = passenger * 250;
            else if (TypeClass == 2)
                amount = passenger * 160;
            else
                amount = passenger * 120;
            if (bag)
                amount *= 0.2;
            amount *= 1.3 * distance * 1.3; // налоги и бензин или в доджь
            return amount;
        }
    } 

    public class TravelBookingContext
    {
        ICostCalculationStrategy _costCalculationStrategy = null;
        public void ChangeTravelStrategy(ICostCalculationStrategy costCalculationStrategy)
        {
            this._costCalculationStrategy = costCalculationStrategy;
        }
        public double ProcessTravel(float distance, int passenger, int typeClass, bool bag, bool benefits)
        {
            if (_costCalculationStrategy == null)
                throw new Exception("Не установлен тип");
            if (distance < 0 || passenger < 0)
                throw new Exception("Введены неверные данные");

            return _costCalculationStrategy.CalculateCost(distance, passenger, typeClass, bag, benefits);
        }
    }
    internal class Strategy
    {
    }
}
