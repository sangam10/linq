namespace linq;
class Program
{
    static void Main(string[] args)
    {
        DemoJoin();
    }

    //where internal implementation
    private static void DemoWhere()
    {
        var items = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        var evenItems = items.NewWhere(x => x % 2 == 0);
        foreach (var item in evenItems)
        {
            Console.WriteLine(item);
        }
    }
    //select internal implementation
    private static void DemoSelect()
    {
        var customers = new[] {
            new Customer{Name="Sangam",Phones=new []{
                new Phone{Number="123",PhoneType=PhoneType.HOME}
            }},
            new Customer{Name="Tanka",Phones=new []{
                new Phone{Number="345",PhoneType=PhoneType.CELL}
            }},
        };
        var customerNames = customers.NewSelect(x => x.Name);
        foreach (var item in customerNames)
        {
            Console.WriteLine(item);
        }
    }

    //join internal implementation
    private static void DemoJoin()
    {
        var customers = new[]
            {
                new Customer{ Id=1,Name="Sangam",Phones=new []{
                    new Phone{Number="123",PhoneType=PhoneType.HOME}
                }},
                new Customer{Id=2,Name="Tanka",Phones=new []{
                    new Phone{Number="345",PhoneType=PhoneType.CELL}
                }},
            };
        var addresses = new[]
        {
            new Address{Id=1,CustomerId=1,Street="street 1",City="City1"},
            new Address{Id=2,CustomerId=1,Street="Street 2",City="City 2"}
        };

        var customerWithAddress = customers.NewJoin(
            addresses,
             c => c.Id,
              a => a.CustomerId,
            (c, a) => new
            {
                c.Name,
                a.Street,
                a.City
            });

        foreach (var item in customerWithAddress)
        {
            Console.WriteLine($"Name: {item.Name} Street: {item.Street} - City: {item.City}");
        }
    }
}
