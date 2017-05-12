using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using database;
namespace hw
{
    class Program
    {
        static void Main(string[] args)
        {
            List<homework> homeworkdata=new List<homework>();
            var x = new db();
            //Creatdb(x);
            Show(x);
            Console.ReadKey();

        }

        public static void Creatdb(db s)
        {
            var xml = XElement.Load("ex.xml");
            var hwnode = xml.Descendants("Info").ToList();

            for (int i = 0; i < hwnode.Count(); i++)
            {
                var hw_node = hwnode[i];
            }

            int j = 0;

            foreach (var hw_node in hwnode)
            {
                j++;
                var name = hw_node.Attribute("name").Value.Trim();
                var address = hw_node.Attribute("address").Value.Trim();
                var openTime = hw_node.Attribute("openTime").Value.Trim();
                var phone = hw_node.Attribute("phone").Value.Trim();

                homework homeworkdata = new homework();
                homeworkdata.name = name;
                homeworkdata.address = address;
                homeworkdata.openTime = openTime;
                homeworkdata.phone = phone;

                s.Creat(homeworkdata);
            }

        }

        public static void Show(db s)
        {
            List<homework> howeworkdata = new List<homework>();
            howeworkdata = s.Readhomework();

            int j = 1;

            howeworkdata.ForEach(x =>
            {
                Console.WriteLine("第" + j + "筆資料");
                Console.WriteLine("書店名:\t" +x.name);
                Console.WriteLine("地址:\t" + x.address);
                Console.WriteLine("開店時間:\t" + x.openTime);
                Console.WriteLine("連絡電話:\t" + x.phone);
                Console.WriteLine("\n");
                Console.WriteLine("----------");
                j++;
            });
        }
    }
}
