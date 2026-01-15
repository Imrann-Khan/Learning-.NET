

// Rider rider = new("John Doe", "123-456-7890", "john.doe@example.com", "New York", 4.5, "ABC123", "D1234567");
// Passenger passenger = new("Jane Smith", "098-765-4321", "jane.smith@example.com", "Los Angeles", 4.7, "O+");

// rider.DisplayInfo();
// passenger.DisplayInfo();


// Cat cat1 = new () { Name = "Whiskers", Age = 3 };
// Cat cat2 = new () { Name = "Whiskers", Age = 3 };

// Console.WriteLine($"Are cat1 and cat2 equal? {cat1 == cat2}");

//Domain Classes -> Rider, Passenger, Payment

// abstract class Person
// {
//     public Person(string name="", string mobileNo="", string email="", string currentLocation="", double rating=0.0)
//     {
//         Name = name;
//         ID = GenerateUniqueID();
//         MobileNo = mobileNo;
//         Email = email;
//         CurrentLocation = currentLocation;
//         Rating = rating;
//     }
//     public string Name {get; protected set;}="";
//     public int ID {get; protected init;}
//     public string MobileNo {get; protected set;} = "";
//     public string Email {get; protected set;} = "";
//     public string CurrentLocation {get; protected set;} = "";
//     public double Rating {get; protected set;} = 0;

//     private int GenerateUniqueID()
//     {
//         Random random = new Random();
//         return random.Next(1000, 9999);
//     }

// }

// class Rider : Person
// {
//     public Rider(string name="", string mobileNo="", string email="", string currentLocation="", double rating=0.0, string vehicleRegistrationNo="", string drivingLicenseNo=""): base(name, mobileNo, email, currentLocation, rating)
//     {
//         VehicleRegistrationNo = vehicleRegistrationNo;
//         DrivingLicenseNo = drivingLicenseNo;
//     }
//     public string VehicleRegistrationNo {get; set;} = "";
//     public string DrivingLicenseNo {get; set;} = "";

//     public void DisplayInfo()
//     {
//         Console.WriteLine("Rider Info:");
//         Console.WriteLine(this.Name + " " + this.ID + " " + this.MobileNo + " " + this.Email + " " + this.CurrentLocation + " " + this.Rating + " " + this.VehicleRegistrationNo + " " + this.DrivingLicenseNo+"\n");
//     }
// }

// class Passenger : Person
// {
//     public Passenger(string name="", string mobileNo="", string email="", string currentLocation="", double rating=0.0, string bloodGroup=""): base(name, mobileNo, email, currentLocation, rating)
//     {
//         BloodGroup = bloodGroup;
//     }
//     public string BloodGroup {get; set;} = "";

//     public void DisplayInfo()
//     {
//         Console.WriteLine("Passenger Info:");
//         Console.WriteLine(this.Name + " " + this.ID + " " + this.MobileNo + " " + this.Email + " " + this.CurrentLocation + " " + this.Rating + " " + this.BloodGroup+"\n");
//     }
// }


//Helper, Utility, or Manager Classes

//Composition Over Inheritance
// class Payment
// {
//     public Rider Rider {get; set;} //HAS-A-RELATIONSHIP (COMPOSITION)
//     public int RiderID {get; set;} // relation with Rider
//     public Passenger Passenger {get; set;} //HAS-A-RELATIONSHIP (COMPOSITION)
//     public int PassengerID {get; set;} // relation with Passenger
//     public double Amount {get; set;} = 0.0;
//     public string PaymentMethod {get; set;} = "";
//     public Payment(Rider rider, Passenger passenger, double amount = 0.0, string paymentMethod = "")
//     {
//         Rider = rider;
//         Passenger = passenger;
//         Amount = amount;
//         PaymentMethod = paymentMethod;
//     }
// }


// //Helper classes
// class PaymentManager
// {
//     public void ProcessPayment(Payment payment) //method injection
//     {
//         Console.WriteLine($"Processing payment of {payment.Amount} via {payment.PaymentMethod} from Passenger ID {payment.PassengerID} to Rider ID {payment.RiderID}");
//     }

//     public bool ValidatePaymentDetails(Payment payment) //method injection
//     {
//         // Implement validation logic here
//         return true;
//     }
// }

// record struct Cat
// {
//     public string Name {get; set;} 
//     public int Age {get; set;} 
// }


//-----example to prove inheritance doesnt work always-----
//composition is the answer where inheritance helps

// Generic Class

// Stack<string> nums = new();

// nums.Push("apple");
// nums.Push("mango");
// nums.Push("Jackfruit");
// Console.WriteLine($"{nums.Size}");
// Console.WriteLine($"{nums.Peek()}");
// string x = nums.Pop();
// Console.WriteLine($"{x}");
// Console.WriteLine($"{nums.Size}");
// Console.WriteLine($"{nums.Peek()}");
// nums.Pop();
// nums.Pop();
// nums.Pop();

Queue<int> nums = new();

nums.Enqueue(10);
nums.Enqueue(20);
nums.Enqueue(30);
Console.WriteLine($"{nums.Count}");
Console.WriteLine($"{nums.Peek()}");
int x = nums.Dequeue();
Console.WriteLine($"{x}");
Console.WriteLine($"{nums.Count}");
Console.WriteLine($"{nums.Peek()}");
nums.Dequeue();
nums.Dequeue();
nums.Dequeue();


class Node<T>
{
    public T Value;
    public Node<T> Next;

    public Node(T value)
    {
        this.Value = value;
        this.Next = null;
    }
}

class Stack<T>
{
    public Node<T> top;
    public int Size {get; set;}

    public Stack()
    {
        top=null;
        Size = 0;
    }

    public T Pop()
    {
        if (top == null)
        {
            Console.WriteLine("Stack Underflow!");
            return default(T);
        }

        Node<T> temp = top;
        top=top.Next;
        Size--;
        return temp.Value;
    }

    public T Peek()
    {
        if (top == null)
        {
            Console.WriteLine("Stack Empty!");
            return default(T);
        }

        return top.Value;
    }

    public void Push(T value)
    {
        Node<T> NewNode  = new(value);
        NewNode.Next=top;
        top = NewNode;
        Size++;
    }
}

class Queue<T>
{
    public int Count {get; set;}
    public Node<T> Front;
    public Node<T> Rear;

    public Queue()
    {
        Count = 0;
        Front = null;
        Rear = null;
    }

    public void Enqueue(T Value)
    {
        Node<T> NewNode = new(Value);
        if (Rear == null)
        {
            Front = NewNode;
            Rear = NewNode;
        }
        else
        {
            Rear.Next = NewNode;
            Rear = NewNode;
        }
        Count++;
    }

    public T Dequeue()
    {
        if(Count==0)
        {
            Console.Write("Queue Empty!");
            return default(T);
        }

        T ret = Front.Value;
        Front = Front.Next;
        Count--;
        if (Front == null)
        {
            // Queue became empty; reset rear as well
            Rear = null;
        }
        return ret;
    }

    public T Peek()
    {
        if (Count == 0)
        {
            Console.Write("Queue Empty!");
            return default(T);
        }
        return Front.Value;
    }
}