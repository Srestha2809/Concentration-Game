

namespace Project2_Group_24
{
    public class CSVFile
    {
        public static List<string> CSVDeserialize(string filepath)
        {
            List<string> list = new List<string>();

            try
            {
                using(StreamReader reader = new StreamReader(filepath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        list.Add(line);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading CSV File: " + ex.Message);
            }

            return list;
        }
    }
}
