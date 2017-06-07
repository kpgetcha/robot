using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurableRobot
{
    class Program
    {
        static void Main(string[] args)
        {
            Robot robot = new Robot();
            Chip sortChip = new MySortChip();
            robot.AddChip(sortChip);
            List<int> list = new List<int>();
            list.Add(5);
            list.Add(3);
            list.Add(4);
            //executing to sort the list
            robot.ExecuteLogic(list, true);
            Chip sumChip = new MySumChip();
            robot.AddChip(sumChip);
            int? result = robot.ExecuteLogic(list, false);
            Console.Read();
        }
    }

    public class Robot
    {
        private Chip _chip;

        public void Sort(IList<int> list)
        {
            list = list.OrderBy(i => i).ToList<int>();
        }

        public void AddChip(Chip chip)
        {
            this._chip = chip;
        }

        public int? ExecuteLogic(List<int> list, bool IsAcending)
        {
            if (_chip == null)
                return null;

            if (_chip.GetType() == typeof(MySortChip))
            {
                MySortChip sortChip = (MySortChip)_chip;
                sortChip.Work(list, IsAcending);
                return null;
            }
            else if (_chip.GetType() == typeof(MySumChip))
            {
                MySumChip sumChip = (MySumChip)_chip;
                int result = sumChip.Work(list);
                return result;
            }

            return null;
        }
    }

    public abstract class Chip
    {
        public virtual void Work()
        {
            Console.WriteLine("Do something");
        }
    }

    public class MySortChip : Chip
    {
        // here the work function is exibiting poloymorphism and will sort the array.
        public void Work(List<int> list, bool isAscending)
        {
            if (isAscending)
            {
                list.Sort();
            }
            else
            {
                list.Sort();
                list.Reverse();
            }
        }
    }

    public class MySumChip : Chip
    {
        // here the work function will sum the list;
        public int Work(List<int> list)
        {
            return list.Sum();
        }
    }
}
