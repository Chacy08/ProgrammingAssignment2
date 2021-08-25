using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {

        public string get_latest(string keyword, SortedSet<string> tmp_set)
        {
            string str_file = string.Empty;
            DateTime now = DateTime.Today;
            string str_today = now.ToString("yyyyMMdd");

            Console.WriteLine("Time now:" + str_today);

            //var set_todaylatest = new SortedSet<int>();
            List<int> list_todaylatest = new List<int>();

            // Verify today files set
            foreach (string tmp_file in tmp_set)
            {
                Console.WriteLine("Today files:" + tmp_file);
                list_todaylatest.Add(Int32.Parse(tmp_file.Substring(13, 4)));
            }

            list_todaylatest.Sort();

            foreach (int tmp_file in list_todaylatest)
            {
                Console.WriteLine("Today files time:" + tmp_file.ToString());
            }


            string final_file = "mob_" + str_today + "_" + list_todaylatest[list_todaylatest.Count - 1].ToString() + ".mdb";
            Console.WriteLine("Today file last:" + final_file);

            return str_file;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World.");

            Program program = new Program();
            string[] strArr = new string[] { "mob_20210825_1000.mdb", "mob_20210825_1600.mdb", "mob_20210823_1000.mdb",
                "mob_20210824_1000.mdb" };
            DateTime now = DateTime.Today;
            string str_today = now.ToString("yyyyMMdd");
      
            var set_todayfiles = new SortedSet<string>();

            foreach (string tmp_file in strArr)
            {
                Console.WriteLine(tmp_file);
                if (tmp_file.Substring(4, 8) == str_today)
                {
                    set_todayfiles.Add(tmp_file);
                }
            };

            string result_file = program.get_latest("mob_", set_todayfiles);



            Console.ReadLine();
        }


    }
}
