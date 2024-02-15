using Dapper;
using FormUI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using syndicate.Classes;

namespace Tambola.Classes
{
    public class WinningValidationTable
    {
        public void validateWinner(string tkName, int one, int two, int three, int four, int five, int six, int seven, int eight,
                                int nine, int ten, int eleven, int twelve, int thirteen, int fourteen,
                                int fifteen, int sixteen, int seventeen, int eighteen, int nineteen, int twenty,
                                int twentyone, int twentytwo, int twentythree, int twentyfour,
                                int twentyfive, int twentysix, int twentyseven)
        {
            //First Row
            int[] arr = { one,two,three,four,five,six,seven,eight,nine};//21,4,0,3,0,4,5,0,0
            int[] firstRow=new int[5];
            int count = 0;
            for(int i=0; i<arr.Length; i++)
            {
                if(arr[i] !=0)
                {
                    firstRow[count]=arr[i];
                    count++;
                }
                
            }
            //Second Row
            int[] arr1 = { ten,eleven,twelve,thirteen,fourteen,fifteen,sixteen,seventeen,eighteen};//21,4,0,3,0,4,5,0,0
            int[] secondRow = new int[5];
            int count1 = 0;
            for (int i = 0; i < arr1.Length; i++)
            {
                if (arr1[i] != 0)
                {
                    secondRow[count1] = arr1[i];
                    count1++;
                }

            }
            //Third Row
            int[] arr2 = { nineteen,twenty,twentyone,twentytwo,twentythree,twentyfour,
                                 twentyfive,twentysix,twentyseven};
            int[] thirdRow = new int[5];
            int count2 = 0;
            for (int i = 0; i < arr2.Length; i++)
            {
                if (arr2[i] != 0)
                {
                    thirdRow[count2] = arr2[i];
                    count2++;
                }

            }

            //Combining the Array
            int [,] finalArray= new int [3,5];
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 5; j++)
                {
                    if (i == 0)
                    {
                        finalArray[i, j] = firstRow[j];
                    }
                    else if(i==1)
                    {
                        finalArray[i,j] = secondRow[j];
                    }
                    else if(i==2)
                    {
                        finalArray[i,j] = thirdRow[j];    
                    }
                     
                }
            }
            int R0C0=finalArray[0,0],R0C1=finalArray[0,1], 
                R0C2 = finalArray[0, 2],
                R0C3 = finalArray[0, 3],
                R0C4 = finalArray[0, 4];

            int R1C0 = finalArray[1, 0], R1C1 = finalArray[1, 1], R1C2 = finalArray[1, 2]
                , R1C3 = finalArray[1, 3], R1C4 = finalArray[1, 4];

            int R2C0=finalArray[2,0],R2C1=finalArray[2,1],R2C2 = finalArray[2, 2], R2C3 = finalArray[2, 3],
                R2C4 = finalArray[2, 4];
            DataAccessValidationTable validationTable = new DataAccessValidationTable();
            validationTable.InsertData(tkName,R0C0, R0C1, R0C2, R0C3, R0C4, R1C0, R1C1, R1C2, R1C3, R1C4, R2C0, R2C1, R2C2, R2C3, R2C4);
            //***********************TOP LINE************

            //using (IDbConnection connection = new SqlConnection(Helper.CnnVal("Tambola")))
            //{ 
            //    connection.Execute("sp_ValidationInsertToTable @TableName, @R0C0, @R0C1, @R0C2, @R0C3, @R0C4" +
            //        "@R1C0,@R1C1, @R1C2, @R1C3, @R1C4, @R2C0,@R2C1, @R2C2, @R2C3, @R2C4", new
            //        {
            //            @TableName=tkName,
            //            @R0C0=R0C0,
            //            @R0C1=R0C1,
            //            @R0C2=R0C2,
            //            @R0C3=R0C4,
            //            @R1C0=R1C0,
            //            @R1C1=R1C2,
            //            @R1C2=R1C3,
            //            @R1C3=R1C4,
            //            @R2C0=R2C0,
            //            @R2C1=R2C2,
            //            @R2C2=R2C3,
            //            @R2C3=R2C4,
            //        });    

            //}
        }
        
    }
}