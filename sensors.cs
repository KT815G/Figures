using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace Interface1
{
    class Sensor
    {
        public string Position;
        public string Model;
        public enum Eparametr{Прочее, Давление, Температура, Уровень, Расход};
        public Eparametr Parametr;
        public string Passport
        {
            get{
                return  "Позиция: " + Position + ", Модель: " + Model + ", Параметр: " + Parametr.ToString();
            }
        }
        
        public Sensor(string Position)
        {
            this.Position = Position;
            Parametr = Eparametr.Прочее;
        }
        public Sensor(string Position, string Model)
        {
            this.Position = Position;
            this.Model = Model;
            Parametr = Eparametr.Прочее;
        }
        public Sensor(string Position, string Model, Eparametr Parametr)
        {
            this.Position = Position;
            this.Model = Model;
            this.Parametr = Parametr;
        }
        public override string ToString()
        {
            return  "Позиция: " + Position + ", Модель: " + Model + ", Параметр: " + Parametr.ToString();
        }
    }
    class Sensors : IEnumerable
    {
        private Sensor[] SensorArray;
        private int SensorArrayIndex;
        private const int ArraySizeStep = 10;
        //private int NumeratorIndex;
        public int Count{
            get { return SensorArrayIndex; }
        }
        public Sensors()
        {
            SensorArrayIndex = 0;
            //NumeratorIndex = -1;
            SensorArray = new Sensor[ArraySizeStep];
        }
        public void Add(Sensor sensor)
        {
            SensorArray[SensorArrayIndex] = sensor;
            SensorArrayIndex++;
            if (SensorArray.Length == SensorArrayIndex)
            {
                //
            }
        }
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < SensorArrayIndex; i++)
            {
                yield return SensorArray[i];
            }
        }


    }
    class Program
    {
        static void Main(string[] args)
        {
            Sensors sn = new Sensors();
            sn.Add(new Sensor("PT-1201", "Метран-150", Sensor.Eparametr.Давление));
            sn.Add(new Sensor("TT-1605", "Wika", Sensor.Eparametr.Температура));
            Console.WriteLine(sn.Count);
            foreach (Sensor s in sn)
            {
                Console.WriteLine(s.Passport);
            }


            Console.ReadKey();

        }
    }
}
