using Restaurant_managment_system;

class Program
{
    static void Main(string[] args)
    {

        Employee ahmed = new Employee(1,"manager","ahmed",20,"cairo","01111111",12,0);
        Owner Mohamed = new Owner();
        Console.WriteLine($"{ ahmed.Age}");
        Mohamed.hire(ahmed);
    }
}