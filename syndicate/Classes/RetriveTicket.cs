using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tambola.Classes
{
    public class RetriveTicket
    {
          
        public int C0 { get; set; }
        public int C1 { get; set; }
        public int C2 { get; set; }
        public int C3 { get; set; }
        public int C4 { get; set; }
        public int C5 { get; set; }
        public int C6 { get; set; }
        public int C7 { get; set; }
        public int C8 { get; set; }
      

        //public string Fullcol
        //{
        //    get 
        //    { 
        //        return $"{ C0 } { C1 } { C2 }";
        //    }
            
        //}


    }
    public class Row1
    {
        public int C0 { get; set; }
        public int C1 { get; set; }
        public int C2 { get; set; }
        public int C3 { get; set; }
        public int C4 { get; set; }
        public int C5 { get; set; }
        public int C6 { get; set; }
        public int C7 { get; set; }
        public int C8 { get; set; }


    }
    public class Row2
    {
        public int C0 { get; set; }
        public int C1 { get; set; }
        public int C2 { get; set; }
        public int C3 { get; set; }
        public int C4 { get; set; }
        public int C5 { get; set; }
        public int C6 { get; set; }
        public int C7 { get; set; }
        public int C8 { get; set; }


    }
    public class Row3
    {
        public int C0 { get; set; }
        public int C1 { get; set; }
        public int C2 { get; set; }
        public int C3 { get; set; }
        public int C4 { get; set; }
        public int C5 { get; set; }
        public int C6 { get; set; }
        public int C7 { get; set; }
        public int C8 { get; set; }


    }
    public class RetriveTickets
    {
        public List<Row1> row1 { get; set; }
        public List<Row2> row2 { get; set; }
        public List<Row3> row3 { get; set; }

    }
}