using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace syndicate.Classes.CurrentRandom
{
    public class GetTCurrentrandom
    {
        public int CurrentRandom { get; set; }
        public string TicketNumber { get; set; }
        public string CustomerName { get; set; }
        public string WinningName { get; set; }
        public int Place { get; set; }
   
    }
    public class TableRandomNumber
    {
        public int RandomNumber { get; set; }
    }
 
}