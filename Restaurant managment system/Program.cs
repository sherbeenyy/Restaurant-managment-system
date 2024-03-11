using Restaurant_managment_system;

class Program
{
    static void Main(string[] args)
    {

        Employee ahmed = new Employee(1, "chef", "ahmed", 20, "cairo", "01111111", 12, 0);
        Employee ashraf = new Employee(1, "chef", "ashraf", 20, "cairo", "01111111", 12, 0);
        Employee osama = new Employee(1, "cashier", "osama", 20, "cairo", "01111111", 12, 0);

        Owner Mohamed = new Owner(1, "owner", "Mohamed", 20, "cairo", "01111111", 12, 0, 0);
        Mohamed.hire(ahmed);
        Mohamed.hire(ashraf);
        Mohamed.hire(osama);
        Mohamed.promoteToManager(ashraf);
        Console.WriteLine("Managers: ");
        Mohamed.printManagers();
        Console.WriteLine("Employees: ");
        Mohamed.printEmployees();
    }
}