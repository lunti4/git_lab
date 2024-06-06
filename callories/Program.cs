using callories;
using System;
using VegiesLib;

class Program
{
    static void Main()
    {
        Console.WriteLine("Creating two carrots");

        const int firstCarrotNutrition = 150;
        const int secondCarrotNutrition = 120;

        const int firstCarrotLeafsLng = 10;
        const int secondCarrotLeafsLng = 15;

        const string firstCarrotColor = "red";
        const string secondCarrotColor = "orange";

        RootVegetable firstCarrot = new RootVegetable("red Carrot", firstCarrotNutrition, firstCarrotColor, firstCarrotLeafsLng);
        RootVegetable secondCarrot = new RootVegetable("orange Carrot", secondCarrotNutrition, secondCarrotColor, secondCarrotLeafsLng);

        Console.WriteLine("Creating potato");

        const int potatoNutrition = 200;
        const int potatoSeedsNumber = 150;
        const string potatoColor = "brown";

        Tuber potato = new Tuber("potato", potatoNutrition, potatoColor, potatoSeedsNumber);

        Console.WriteLine("Creating cabbage");

        const int cabbageNutrition = 50;
        const string cabbageColor = "green";
        const int inflorescenceNumber = 1;

        CabbageVegatable cabbage = new CabbageVegatable("cabbage", cabbageNutrition, cabbageColor, inflorescenceNumber);

        Console.WriteLine("Mixing salad");

        Salad salad = new Salad();

        salad.AddIngridient(firstCarrot);
        salad.AddIngridient(secondCarrot);
        salad.AddIngridient(cabbage);
        salad.AddIngridient(potato);

        int total = salad.GetTotalNutrition();

        Console.WriteLine($"Total callories - {total}");
    }
}
