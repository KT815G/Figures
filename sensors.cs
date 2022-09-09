using System;
using System.Collections;

namespace Interface1
{
//------------------------------------------------------------------------------------------
// Прибор
//------------------------------------------------------------------------------------------

    class Sensor : IComparable
    {
        public string Position;
        public string Model;
        public enum Eparametr{Прочее, Давление, Температура, Уровень, Расход, Анализ};
        public Eparametr Parametr;
        int IComparable.CompareTo(object obj){
            if (obj==null)return 1;
            Sensor s1=(Sensor)obj;
            return Position.CompareTo(s1.Position);
        }
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
//------------------------------------------------------------------------------------------
// Приборы
//------------------------------------------------------------------------------------------
    class Sensors : IEnumerable
    {
        private Sensor[] SensorArray;
        private int SensorArrayIndex;
        private const int ArraySizeStep = 10;
        public int Count{
            get { return SensorArrayIndex; }
        }
        public Sensors()
        {
            SensorArrayIndex = 0;

        }
        public void Add(Sensor sensor)
        {
            SensorArrayIndex++;
            Sensor[] tmpArray=new Sensor[SensorArrayIndex];
            if (SensorArrayIndex!=1){SensorArray.CopyTo(tmpArray,0);}
            SensorArray=tmpArray;
            SensorArray[SensorArrayIndex-1]=sensor;
            
        }
        public Sensor this[int index]
        {
            get {return SensorArray[index];}
        }
        public void SortByPosition(){
            Array.Sort(SensorArray);
        }
        public void PrintDebug(){
            for (int i=0;i<SensorArray.Length;i++){
                Console.WriteLine(i.ToString() + ": " + SensorArray[i].GetType().ToString());
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
            /*
            Sensor[] sensors=new Sensor[4];
            sensors[0]=new Sensor("PT-1201", "Метран-150", Sensor.Eparametr.Давление);
            sensors[1]=new Sensor("TT-1605", "Wika", Sensor.Eparametr.Температура);
            sensors[2]=new Sensor("AT-1605", "ДАК-М", Sensor.Eparametr.Анализ);
            sensors[3]=new Sensor("FT-1801", "Micro Motion", Sensor.Eparametr.Расход);
            Array.Sort(sensors);

            foreach(Sensor s in sensors){
                Console.WriteLine(s.Passport);
            }
            */

            Sensors sn = new Sensors();
            sn.Add(new Sensor("PT-1201", "Метран-150", Sensor.Eparametr.Давление));
            sn.Add(new Sensor("TT-1605", "Wika", Sensor.Eparametr.Температура));
            sn.Add(new Sensor("AT-1605", "ДАК-М", Sensor.Eparametr.Анализ));
            sn.Add(new Sensor("FT-1801", "Micro Motion", Sensor.Eparametr.Расход));
            sn.Add(new Sensor("FT-1802", "Micro Motion", Sensor.Eparametr.Расход));
            //Console.WriteLine(sn.Count);
            //sn.PrintDebug();
            sn.SortByPosition();
            foreach (Sensor s in sn)
            {
                Console.WriteLine(s.Passport);
            }

            //Console.WriteLine(sn[0].Passport);

        }
    }
}
