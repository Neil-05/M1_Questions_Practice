using System;
using System.Text.RegularExpressions;

public class InvalidGadgetException : Exception
{
    public InvalidGadgetException(string message) : base(message)
    {
    }
}

public class GadgetValidatorUtil
{
    public bool ValidateGadgetID(string gadgetID)
    {
        if (string.IsNullOrEmpty(gadgetID) || !Regex.IsMatch(gadgetID, @"^[A-Z]\d{3}$"))
        {
            throw new InvalidGadgetException("Invalid gadget ID");
        }
        return true;
    }

    public bool ValidateWarrantyPeriod(int period)
    {
        if (period < 6 || period > 36)
        {
            throw new InvalidGadgetException("Invalid warranty period");
        }
        return true;
    }
}

public class UserInterface
{
    public static void Main()
    {
        GadgetValidatorUtil validator = new GadgetValidatorUtil();
        
        Console.WriteLine("Enter gadget details (gadgetID:gadgetType:warrantyPeriod):");
        string input = Console.ReadLine();
        
        try
        {
            string[] parts = input.Split(':');
            
            if (parts.Length < 3)
            {
                throw new InvalidGadgetException("Invalid input format");
            }
            
            string gadgetID = parts[0];
            int warrantyPeriod = int.Parse(parts[2]);
            
            validator.ValidateGadgetID(gadgetID);
            validator.ValidateWarrantyPeriod(warrantyPeriod);
            
            Console.WriteLine("Warranty accepted, stock updated");
        }
        catch (InvalidGadgetException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Invalid input");
        }
    }
}