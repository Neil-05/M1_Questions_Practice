namespace GOAIr
{
    public class accessedEmployee
    {
        public string empId { get; set; }
        public string entrytype { get; set; }

        public string duration { get; set; }

    }
    public class eligible
    {
        List<accessedEmployee> accessedEmployees = new List<accessedEmployee>();
        public eligible()
        {
            accessedEmployees.Add(new accessedEmployee { empId = "GOAIR/4201", entrytype = "IN",  duration = "8:00" });
            accessedEmployees.Add(new accessedEmployee { empId = "GOAIR/1305", entrytype = "OUT", duration = "0:30" });
            accessedEmployees.Add(new accessedEmployee { empId = "GOAIR/4516", entrytype = "IN",  duration = "7:45" });
            accessedEmployees.Add(new accessedEmployee { empId = "GOAIR/6211", entrytype = "IN",  duration = "8:15" });
            accessedEmployees.Add(new accessedEmployee { empId = "GOAIR/6112", entrytype = "OUT", duration = "1:00" });
        }
    }

    public class EntryUtility
    {
        public bool validateEmployeeID(string ID)
        {
            if (ID.StartsWith("GOAIR/") && ID.Length == 10)
            {
                return true;
            }
            else 
            throw new InvalidEntryException("Invalid Employee ID");
        }

       public bool validateEntryType(string type,string duration)
        {
           TimeSpan timeSpan=TimeSpan.Parse(duration);
            if ((type == "IN" && timeSpan.TotalHours >= 8) || (type == "OUT" && timeSpan.TotalHours < 1))
            {
                return true;
            }
            else
            {
                throw new InvalidEntryException("Invalid Entry Type or Duration");
            }
        }
    }

    public class InvalidEntryException : Exception
    {
        public InvalidEntryException(string message) : base(message)
        {
      
        }
    }

    public class UserInterface
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter Employee ID: ");
            string id = Console.ReadLine();

            Console.Write("Enter Entry Type (IN/OUT): ");
            string type = Console.ReadLine();

            Console.Write("Enter Duration (h:mm): ");
            string duration = Console.ReadLine();

            var util = new EntryUtility();

            try
            {
                if (util.validateEmployeeID(id) && util.validateEntryType(type, duration))
                {
                    Console.WriteLine("You can enter the premises...........");
                }
            }
            catch (InvalidEntryException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid duration format");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }


}