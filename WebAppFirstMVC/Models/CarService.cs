using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppFirstMVC.Models
{
    public class CarService
    {
        static int idCounter;
        static List<Car> carList = new List<Car>() 
        {
            new Car() { Id = ++idCounter, Brand = "BMW", ModelName = "525i" },
            new Car() { Id = ++idCounter, Brand = "SAAB", ModelName = "9000SE" },
            new Car() { Id = ++idCounter, Brand = "Volvo", ModelName = "745GL" },
        };

        public void Add(string brand, string modelName)
        {
            carList.Add(new Car() { Id = ++idCounter, Brand = brand, ModelName = modelName });
        }

        public List<Car> All()
        {
            return carList;
        }
    }
}
