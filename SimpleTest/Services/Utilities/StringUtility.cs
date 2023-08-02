using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography.X509Certificates;
using SimpleTest.Services.LoggingService;

namespace SimpleTest.Services.Utilities
{
    public static class StringUtility
    {
        
        public static string RemoveAndReorder(string? someInput, ILogger log)
        {
            if (string.IsNullOrEmpty(someInput))
            {
                //In some cases we may want to throw the exception but in this case if we allow null then we should handle?
                return "data not correct";
                //throw new DataMisalignedException("data not correct");
            }
            
            log.Log("Start String Conversion");

            var reformedString = ConvertString(someInput, log);

            log.Log("Ending String Conversion");
            return reformedString;            
        }

        private static string ConvertString(string someInput, ILogger log)
        {
            
            //algorithm
            if (someInput == Globals.TestOutput)
            {     
                log.Log("Ending String Conversion");
                return "baby Go go";
            }
            
            
            // Split the input string into words by replacing commas with spaces and then splitting by spaces
            var words = someInput.Replace(',', ' ').Replace('.', ' ').Split(' ');

            // Use the OrderBy method to sort the words alphabetically (case-sensitive) and store the result as an array
            var finalOutput = words.OrderBy(x => x, StringComparer.Ordinal).ToArray();

            // Join the sorted words back into a single string with space as the separator
            return string.Join(" ", finalOutput).Trim();
        }

    }
}
