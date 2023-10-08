using HM4_M6.Interface;
using HM4_M6.Models;
namespace HM4_M6.Data

{
    public class DataCars: IDataCars
    {
        public List<CarViewModel> _cars =  new List<CarViewModel>()
                {
                    new CarViewModel {Id=1, Name = "Tesla", Model = "Model X",  Price = 50000},
                    new CarViewModel {Id=2, Name = "Lusid", Model = "Luxury",Price = 120000 },
                    new CarViewModel {Id=3, Name = "BMW", Model = "X5",Price = 70000 },
                    new CarViewModel {Id = 4,  Name = "Ford", Model = "Mustang", Price = 140000 }
                };
            
        

        public void CreateCarViewModel(CarViewModel product)
        {
           _cars.Add(product);
        }

        public void DeleteCarViewModel(int id)
        {
            var itemToDelete = _cars.FirstOrDefault(p => p.Id == id);
            if (itemToDelete != null)
            {
                _cars.Remove(itemToDelete);
            }
        }

        public List<CarViewModel> GetAllCarViewModel()
        {
            return _cars;
        }

        public CarViewModel GetCarViewModel(int id)
        {
            return _cars.FirstOrDefault(p => p.Id == id);

        }

        public void UpdateCarViewModel(CarViewModel car)
        {
            var existingCar = _cars.FirstOrDefault(p => p.Id == car.Id);
            if (existingCar != null)
            {
                existingCar.Id = car.Id;
                existingCar.Name = car.Name;
                existingCar.Price = car.Price;
                existingCar.Model = car.Model;

            }
        }
    }
}
