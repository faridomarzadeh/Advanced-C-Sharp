
using SRP;

public class Program
{

    public static void Main(string[] args)
    {

        StandardMessages.Welcome();

        Person user = CaptureData.Capture();
        
        bool isPersonValid = PersonValidator.Validate(user);

        if(!isPersonValid)
        {
            StandardMessages.EndApplication();
            return;
        }

        AccountGenerator.GenerateUsername(user);
        StandardMessages.EndApplication();
    }
}
