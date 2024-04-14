using System.Xml.Schema;
using TextFile;
namespace SAMPLE3
{
    public class DataLine
    {
        public string nick;
        public double weight;
        public DataLine(string nick, double weight){
           this.nick = nick;
           this.weight = weight;
        }

    }

    internal class Program
    {
        public static DataLine? ReadData(TextFileReader reader)
        {
            bool Readstring =reader.ReadString(out string nick);
            bool ReadWeight = reader.ReadDouble(out double weight);
            if(Readstring && ReadWeight)
            {
                return new DataLine(nick, weight);
            }
            else
            {
                return null;
            }
        }



        static void Main(string[] args)
        {
            var reader = new TextFileReader("input.txt");
            DataLine? line = null;
            bool higher = false;
            string currentnick = null;
            double totalweight = 0.0;

            while((line=ReadData(reader)) != null)
            {
                if(currentnick == null)
                {
                    currentnick = line.nick;
                }
                if(currentnick != line.nick)
                {
                    currentnick = line.nick;
                    totalweight = 0;
                }
                totalweight += line.weight;

                if(totalweight > 100)
                {
                    higher = true;
                    break;
                }





            }
            if (!higher)
            {
                Console.WriteLine("no");
            }
          
        }
       
    }
}
