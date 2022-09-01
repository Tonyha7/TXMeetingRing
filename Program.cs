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
                String title="";
                bool firstrun = true;
                Console.WriteLine("@th7");
                while (true)
                {
                    var windows = WindowEnumerator.FindAll();
                    if (windows.Count == 1)
                    {

                        var window = windows[0];
                        if (firstrun)
                        {
                            title = window.Title;
                            firstrun = false;
                        }
                        else
                        {
                            if (title != window.Title)
                            {
                                System.Media.SystemSounds.Asterisk.Play();
                            }
                            title = window.Title;
                        }
                        Console.WriteLine($@"{window.Title}");


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
