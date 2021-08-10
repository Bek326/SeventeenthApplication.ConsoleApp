using System;
using System.Linq;

namespace SeventeenthApplication.ConsoleApp
{
    abstract class Delivery
    {
        public string Address;
    }
    class HomeDelivery : Delivery
    {
        public string Courier { get; }
        public int Distance { get; }
        public HomeDelivery(string courier, int distance)
        {
            Courier = courier;
            Distance = distance;
        }

        

        abstract class CorierDelivery
        {
            class Car: CorierDelivery
            {
                public double Fuel;

                public int Mileage;

                public Car()
                {
                    Fuel = 50;
                    Mileage = 0;
                }

                public void Move()
                {
                    // Move a kilometer
                    Mileage++;
                    Fuel -= 0.5;
                }

                public void FillTheCar()
                {
                    Fuel = 50;
                }
            }

            enum FuelType
            {
                Gas = 0,
                Electricity
            }

            class HybridCar : Car
            {
                public new FuelType FuelType;

                public void ChangeFuelType(FuelType type)
                {
                    FuelType = type;
                }
            }
            class Bicycle: CorierDelivery
            {
                public string OnBicycle { get; }
                public int TimeDelivery { get; }
                public Bicycle(string onbicycle, int timedelivery)
                {
                    OnBicycle = onbicycle;
                    TimeDelivery = timedelivery;
                }
            }
            class Transport: CorierDelivery
            {
                public string OnTransport { get; }
                public int TimeDelivery { get; }
                public Transport(string ontransport, int timedelivery)
                {
                    OnTransport = ontransport;
                    TimeDelivery = timedelivery;
                }
            }
            class Foot : CorierDelivery
            {
                public string OnFoot { get; }
                public int TimeDelivery { get; }
                public Foot(string onfoot, int timedelivery)
                {
                    OnFoot = onfoot;
                    TimeDelivery = timedelivery;
                }
                public static void Delivery1()
                {
                    int DistanceDelivery = 3;
                    if (DistanceDelivery <= 3) //Если курьеру идти меньше или 3 км, доставляет не на машине
                    {
                        Console.WriteLine("Курьер доставляет на общественном транспорте, либо пешком, либо на велосипеде");
                    }
                    else
                    {
                        Console.WriteLine("Курьер доставляет на машине");
                    }
                }
            }
        }
        

    }
    class PickPointDelivery : Delivery
    {
        public string Forwarder { get; }
        public int Distance { get; }
        public string CompanyCustody { get; }
        public string PickPoint { get; }
        public int LoadingOrder { get; }
        public string Movers { get; }
        public PickPointDelivery (string forwarder, int distance, string companycustody, string pickpoint, int loadingorder, string movers)
        {
            Forwarder = forwarder;
            Distance = distance;
            CompanyCustody = companycustody;
            PickPoint = pickpoint;
            LoadingOrder = loadingorder;
            Movers = movers;
        }
        private class OrderStorage
        {
            public string Employer;
            public bool StorageTimeOrder;
            public int TimePickPoint;
            public OrderStorage(string employer, bool storagetimeorder, int timepickpoint)
            {
                Employer = employer;
                StorageTimeOrder = storagetimeorder;
                TimePickPoint = timepickpoint;
            }
        }
    }
    class ShopDelivery : Delivery
    {
        public string DriverForwarder { get; }
        public int Distance { get; }
        public int TimeDelivery { get; }
        public ShopDelivery(string driverforwarder, int distance, int timedelivery)
        {
            DriverForwarder = driverforwarder;
            Distance = distance;
            TimeDelivery = timedelivery;
        }
        class Shop
        {
            private string Order;
            private bool Place;
            private string StaffShop;
            private int TimeLoading;
            public Shop(string order, bool place, string staffshop, int timeloading)
            {
                Order = order;
                Place = place;
                StaffShop = staffshop;
                TimeLoading = timeloading;
            }
        }
    }
    class Order<TDelivery, TStruct> where TDelivery : Delivery where TStruct : struct
    {

        public TDelivery Delivery;
        public int Number;
        public string Description;
        public void DisplayAddress()
        {
            Console.WriteLine(Delivery.Address);
        }
        public class Product
        {
            private string _Title;
            private string _TitleShop;
            private int _Price;
            private string _Condition;
            public string Title { get { return this._Title; } }
            public string TitleShop { get { return this._TitleShop; } }
            public int Price { get { return this._Price; } }
            public string Condition { get { return this._Condition; } }
            public Product(string title, string titleShop, int price, string condition)
            {
                this._Title = title;
                this._TitleShop = titleShop;
                this._Price = price;
                this._Condition = condition;
            }
        }
    }
        class Program
        {
            static void Main(string[] args)
            {
                Order<Delivery, int> or = new Order<Delivery, int>();
                Random rnd = new Random();
                HomeDelivery d = new HomeDelivery("Курьер", rnd.Next());
                or.Delivery = d;
                Console.WriteLine(d);
                PickPointDelivery c = new PickPointDelivery("Экспедитор", rnd.Next(), "Хранение заказа компании", "Пункт выдачи", rnd.Next(), "Грузчики");
                or.Delivery = c;
                Console.WriteLine(c);
                ShopDelivery sh = new ShopDelivery("Водитель-экспедитор", rnd.Next(), rnd.Next());
                or.Delivery = sh; 
                Console.WriteLine(sh);

                Console.ReadKey();
                
                
            }
        }
    
}
