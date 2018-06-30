using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace SubmarineSimulator
{
    class Highscore
    {
        public void saveScore(int x)
        {
            int highscore = x;
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new System.IO.FileStream("Highscore.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, highscore);
            stream.Close();
            Console.WriteLine("Score saved");
        }

        public int getScore()
        {
            try
            {
                int highscore;
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream("Highscore.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
                highscore = (int)formatter.Deserialize(stream);
                stream.Close();
                return highscore;
            }
            catch (Exception e)
            {
                Console.WriteLine("No previously recorded score");
                return 0;
            }
        }

    }
}
