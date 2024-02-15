using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using syndicate.Classes.VALIDATION;

namespace syndicate.Classes.GlobalVariables
{
    public static class DependencyCounter
    {
        
        public static int Count = 0;
        public static int FullHouse = 1;
        public static int FullSheet = 0;
        public static int HalfSheet = 0;
        public static int Star = 0;
        public static int QuickFive = 0;
        public static int QuickSeven = 0;
        public static int TopLine = 0;
        public static int MiddleLine = 0;
        public static int BottomLIne = 0;
        public static int GameOver = 0;
        public static bool _cancellationtoken =false ; 
        public static bool _runningProcess =false ;
        public static DateTime date = default;
        public static DateTime Istdate = default;
        public static DateTime Arizona = default;
        public static DateTime UTC = default;

    }  
}