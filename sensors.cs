using System;
using System.Collections;

namespace Interface1
{
//------------------------------------------------------------------------------------------
// Прибор
//------------------------------------------------------------------------------------------

    class Sensor : IComparer
    {
        public string Position;
        public string Model;
        public enum Eparametr{Прочее, Давление, Температура, Уровень, Расход, Анализ};
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
        int IComparer.Compare(object x, object y){
            Sensor s1=(Sensor)x;
            Sensor s2=(Sensor)y;
            Console.WriteLine(s1.Position.CompareTo(s2.Position));
            return s1.Position.CompareTo(s2.Position);
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
        //private int NumeratorIndex;
        public int Count{
            get { return SensorArrayIndex; }
        }
        public Sensors()
        {
            SensorArrayIndex = 0;
            SensorArray = new Sensor[ArraySizeStep];
            for(int i=0;i<SensorArray.Length;i++)SensorArray[i]=new Sensor("PT-01");        
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
            Sensor[] sensors=new Sensor[3];
            sensors[0]=new Sensor("PT-1201", "Метран-150", Sensor.Eparametr.Давление);
            sensors[1]=new Sensor("TT-1605", "Wika", Sensor.Eparametr.Температура);
            sensors[2]=new Sensor("AT-1605", "ДАК-М", Sensor.Eparametr.Анализ);
            //Array.Sort(sensors);
            
            foreach(Sensor s in sensors){
                Console.WriteLine(s.Passport);
            }


           /* Sensors sn = new Sensors();
            sn.Add(new Sensor("PT-1201", "Метран-150", Sensor.Eparametr.Давление));
            sn.Add(new Sensor("TT-1605", "Wika", Sensor.Eparametr.Температура));
            sn.Add(new Sensor("AT-1605", "ДАК-М", Sensor.Eparametr.Анализ));
            //Console.WriteLine(sn.Count);
            sn.PrintDebug();
            sn.SortByPosition();
            foreach (Sensor s in sn)
            {
                Console.WriteLine(s.Passport);
            }

            /*
            Sensor s1=new Sensor("PT-9901");
            Sensor s2=new Sensor("PT-9901");
            if (s1>s2) {Console.WriteLine("Равны");}*/
            
            //Console.ReadKey();
            
        }
    }
}
