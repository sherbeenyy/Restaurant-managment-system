using Restaurant_managment_system;

class Program
{
    static void Main(string[] args)
    {

        Employee ahmed = new Employee(1, "waiter", "ahmed",20,"cairo","01111111",12,0);
        Owner Mohamed = new Owner();   
        Mohamed.hire(ahmed);
        Console.WriteLine(ahmed.Role);
    }
}