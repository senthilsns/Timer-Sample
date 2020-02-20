using System;
using System.Globalization;
using System.Timers;
using UIKit;

namespace TimerSample.iOS
{
    public partial class BrowseItemDetailViewController : UIViewController
    {
        public ItemDetailViewModel ViewModel { get; set; }
        public BrowseItemDetailViewController(IntPtr handle) : base(handle) { }


        DateTime endTime = new DateTime();
        string cTimer,serverStr;
        System.Timers.Timer timer;


        public override void ViewDidLoad()
        {
            base.ViewDidLoad();


            Title = "Timer Sample"; 

            CultureInfo enUS = new CultureInfo("en-US");
            string dateString;
            DateTime dateValue;

            // Parse a string representing UTC.
            //// To Pass Server Value here
            ///

            serverStr = "2020-02-20T16:33:02";
            dateString =serverStr + ".0000000";

            try
            {
                dateValue = DateTime.ParseExact(dateString, "o", CultureInfo.InvariantCulture,
                                            DateTimeStyles.None);
                Console.WriteLine("Converted '{0}'", dateValue );
                endTime = dateValue;

            }
            catch (FormatException)
            {
                Console.WriteLine("'{0}' is not in an acceptable format.", dateString);
            }


            Console.WriteLine("Current Date = '{0}' ",DateTime.Now);

            // Call Timer
            StartCountDownTimer();



        }
       


        public void StartCountDownTimer()
        {
            timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Elapsed += t_Tick;
            TimeSpan ts = endTime - DateTime.Now; // Server Date and Time- System Current Date and Time
            
            cTimer = ts.ToString("d' Days 'h' Hours 'm' Minutes 's' Seconds'");
            Console.WriteLine("'{0}' Running.", cTimer);

            timer.Start();
        }


        void t_Tick(object sender, EventArgs e)
        {
            TimeSpan ts = endTime - DateTime.Now;
            cTimer = ts.ToString("d' Days 'h' Hours 'm' Minutes 's' Seconds'");
            Console.WriteLine("'{0}' Running.", cTimer);

            if ((ts.TotalMilliseconds < 0) || (ts.TotalMilliseconds < 1000))
            {
                timer.Stop(); // Stop Timer

            }
        }


    }
}
