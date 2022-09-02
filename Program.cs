using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TXMeetingRing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            {
                bool firstrun = true;
                int people = 0;
                Console.WriteLine("@th7");
                while (true)
                {
                    var windows = WindowEnumerator.FindAll();
                    DateTime dt = DateTime.Now;
                    if (windows.Count == 1)
                    {
                        var window = windows[0];
                        int peoplenow = Convert.ToInt32(System.Text.RegularExpressions.Regex.Replace(window.Title, @"[^0-9]+", ""));
                        if (firstrun)
                        {
                            people = peoplenow;
                            Console.WriteLine(dt.ToString() + " 当前会议室人数: " + peoplenow);
                            firstrun = false;
                        }
                        else
                        {
                            if (people != peoplenow)
                            {
                                Console.WriteLine(dt.ToString()+" 当前会议室人数: "+peoplenow);
                                if (people < peoplenow)
                                {
                                    System.Media.SystemSounds.Asterisk.Play();
                                }
                            }
                            people = peoplenow;
                        }
                        
                    }
                    else
                    {
                        Console.WriteLine("多个或没有以\"成员\"为题的窗口");
                    }
                    Thread.Sleep(1000);
                }
                
                
            }
        }
    }
}
