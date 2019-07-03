using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using System.Net.Http;

namespace AdminClockApp
{

    static class Program
    {
        //public static string uri = "http://192.168.1.41:8080/";
        public static string uri = "http://192.168.43.154:8088/";
        //public static string uri = "http://thegioiwatch.somee.com/";
        //public static string uri = "http://localhost:8000/";
        public static string userAd = null;
        public static string passwordAd = null;
        public static int idCat;
        public static int idPro;
        public static int flag = 0;
        public static string strImg = "";
        public static string imgText = "";
        public static Dictionary<string,string> dict = new Dictionary<string, string>();
        public static IDictionary<int, string> dictCat = new Dictionary<int, string>();
        public static int quantity = 1;
        public static List<OrderDetail> list1 = new List<OrderDetail>();
        public static List<Report> listReport = new List<Report>();
        public static int idOrderReturn = 1;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            BonusSkins.Register();
            SkinManager.EnableFormSkins();
            Application.Run(new FormMain());
        }
    }
}