using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Var2
{
    class SuperHashSet<T> : HashSet<T> where T : struct
    {
    }

    public delegate void EventHandler();

    class User
    {

        public event EventHandler Click;
        public void ComandClick()
        {
            Console.WriteLine("Click!");
            if (Click != null)
                Click();
        }
    }

    class Button
    {
        public void OnClick()
        {
            Console.WriteLine("На меня нажали");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-----------------------1------------------------");
            SuperHashSet<int> SHS = new SuperHashSet<int>();
            SHS.Add(22);
            SHS.Add(26);
            SHS.Add(27);
            SHS.Add(22);
            SHS.Add(28);

            foreach (int i in SHS)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("-----------------------2------------------------");
            int n = 22;
            var count = from c in SHS where c == n select c;
            Console.WriteLine(count.Count());

            Console.WriteLine("-----------------------3------------------------");
            User user = new User();
            Button butt1 = new Button();
            Button butt2 = new Button();
            user.Click += new EventHandler(butt1.OnClick);
            user.Click += new EventHandler(butt2.OnClick);
            user.ComandClick();
        }
    }
}
