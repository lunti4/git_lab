using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VegiesLib;

namespace callories
{
    public class Salad
    {
        // В конструкторе инициализируем лист для хранения овощей и общее кол-во калорий
        public Salad() 
        {
            _ingridients = new List<Vegetable>();
            _totalCallories = 0;
        }

        // Метод добавления ингридиентов
        public void AddIngridient(Vegetable vegetable)
        {
            _ingridients.Add(vegetable);
            _totalCallories += vegetable.NutritionValue;
        }

        public void EditIngridient(int index, string name, string color, int nutrition)
        {
            Vegetable vegetable = _ingridients[index];

            vegetable.Name = name;
            vegetable.Color = color;
            vegetable.NutritionValue = nutrition;

        }

        public void DeleteIngridient(int index)
        {
            _totalCallories -= _ingridients[index].NutritionValue;
            _ingridients.RemoveAt(index);
        }

        // Геттер ингридиентов
        public List<Vegetable> GetVegetables()
        { return _ingridients; }

        // Геттер общего кол-ва каллорий
        public int GetTotalNutrition()
        { return _totalCallories; }

        // Поле хранения ингридиентов
        private List<Vegetable> _ingridients;

        // Поле хранения калорий
        private int _totalCallories;

    }
}
