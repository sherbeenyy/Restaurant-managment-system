using Restaurant_managment_system;

class Program
{
    static void Main(string[] args)
    {

        Employee ahmed = new Employee(1, "manager", "ahmed", 20, "cairo", "01111111", 12, 0);
        Employee ashraf = new Employee(1, "manager", "ashraf", 20, "cairo", "01111111", 12, 0);

        Employee osama = new Employee(1, "manager", "osama", 20, "cairo", "01111111", 12, 0);

        Owner Mohamed = new Owner();
        Mohamed.hire(ahmed);
        Mohamed.hire(osama);
        Mohamed.hire(ashraf);
        Mohamed.printEmployees();
        Mohamed.fire(ashraf);
        Mohamed.printEmployees();
    }
}