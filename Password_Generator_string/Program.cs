class Program
{
    static void Main()
    {
        Console.WriteLine("Enter the username");
        string username = Console.ReadLine();
        
        if (ValidateUsername(username))
        {
            string password = GeneratePassword(username);
            Console.WriteLine($"Password: {password}");
        }
        else
        {
            Console.WriteLine($"{username} is an invalid username");
        }
    }
    
    static bool ValidateUsername(string username)
    {
        // Check length
        if (username.Length != 8)
            return false;
        
        // Check first 4 characters are uppercase letters
        for (int i = 0; i < 4; i++)
        {
            if (!char.IsUpper(username[i]) || !char.IsLetter(username[i]))
                return false;
        }
        
        // Check 5th character is '@'
        if (username[4] != '@')
            return false;
        
        // Check last 3 characters are digits and form a valid course id
        if (!int.TryParse(username.Substring(5), out int courseId))
            return false;
        
        if (courseId < 101 || courseId > 115)
            return false;
        
        return true;
    }
    
    static string GeneratePassword(string username)
    {
        // Get first 4 characters and convert to lowercase
        string firstFour = username.Substring(0, 4).ToLower();
        
        // Calculate sum of ASCII values
        int asciiSum = 0;
        foreach (char c in firstFour)
        {
            asciiSum += (int)c;
        }
        
        // Get last 2 digits of course id
        string lastTwoDigits = username.Substring(6);
        
        return $"TECH_{asciiSum}{lastTwoDigits}";
    }
}