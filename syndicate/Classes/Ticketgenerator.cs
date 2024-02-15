using FormUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;
using Tambola.Classes;

namespace Tambola
{
    public class Ticketgenerator
    {
       // List<Numbers> number = new List<Numbers>();
        public void CreateTickets(string ticket) 
        {
           
                startGame(ticket);
        }

        private static void startGame(string PassTicketName)
        {
            int[,] game = new int[3, 9];
            int occupancyLimit = 15;

            while (occupancyLimit > 0)
            {
                int i = getRandomNumber(3);
                int j = getRandomNumber(9);
                Console.WriteLine(i);
                Console.WriteLine(j);
                int data = validateAndReturnNumber(i, j, game);
                if (data > 0)
                {
                    game[i, j] = data;
                    occupancyLimit--;
                    //Console.WriteLine(game[i, j]);
                }

            }

            //6. Send Array to "Dataaccess Class" to put it in the newly created Table With TicketName
            //as a table Name Paramater
            //

            // Storing matrix for transfering to the InsertData Method
                string TicketName = PassTicketName;//for insert operations on sql (Table name Paramater)
                int R0c1 = game[0, 0], R0c2 = game[0, 1], R0c3 = game[0, 2],
               R0c4 = game[0, 3], R0c5 = game[0, 4], R0c6 = game[0, 5],
               R0c7 = game[0, 6], R0c8 = game[0, 7], R0c9 = game[0, 8];

                int R1c1 = game[1, 0], R1c2 = game[1, 1], R1c3 = game[1, 2],
                    R1c4 = game[1, 3], R1c5 = game[1, 4], R1c6 = game[1, 5],
                    R1c7 = game[1, 6], R1c8 = game[1, 7], R1c9 = game[1, 8];

                int R2c1 = game[2, 0], R2c2 = game[2, 1], R2c3 = game[2, 2],
                    R2c4 = game[2, 3], R2c5 = game[2, 4], R2c6 = game[2, 5],
                    R2c7 = game[2, 6], R2c8 = game[2, 7], R2c9 = game[2, 8];

           
              
               DataAccess D = new DataAccess();
                D.InsertData(TicketName,R0c1, R0c2, R0c3, R0c4, R0c5, R0c6, R0c7, R0c8, R0c9,
                   R1c1, R1c2, R1c3, R1c4, R1c5, R1c6, R1c7, R1c8, R1c9,
                   R2c1, R2c2, R2c3, R2c4, R2c5, R2c6, R2c7, R2c8, R2c9);


            //Create A Duplicate Table for winning validatioins without zero
            WinningValidationTable validationTable = new WinningValidationTable();
            validationTable.validateWinner(TicketName, R0c1, R0c2, R0c3, R0c4, R0c5, R0c6, R0c7, R0c8, R0c9,
                   R1c1, R1c2, R1c3, R1c4, R1c5, R1c6, R1c7, R1c8, R1c9,
                   R2c1, R2c2, R2c3, R2c4, R2c5, R2c6, R2c7, R2c8, R2c9);

        }

        //validation! column must have not more then 5 elements and row must not 
        //have more then 3 elements
        private static int validateAndReturnNumber(int i, int j, int[,] game)
        {
            if (game[i,j] != 0)
            {
                return -1;
            }
            //column validation
            int columncounter = 0;
            for(int c=0;c<3;c++)
            {
                if(game[c,j]!=0)
                {
                    columncounter++;
                }
            }
            //columns cannot have more then 3 elements
            if(columncounter>=2)
            {
                return -1;
            }


            //row validatin
            int rowcounter = 0;
            for(int r=0;r<9;r++)
            {
                if(game[i,r]!=0)
                {
                    rowcounter++;
                }
            }
            //rows cannot have more then 5 elements
            if(rowcounter>=5)
            {
                return -1;
            }

            //return getRandomNumberForColumn(j);
            int data = 0;
            Boolean isValueSet = false;
            do
            {
                data = getRandomNumberForColumn(j);
                isValueSet = isValueExistsInCol(game, i, j, data);
            } 
            while (isValueSet);
                return data;
        }

        private static bool isValueExistsInCol(int[,] game, int i, int j, int data)
        {
            Boolean status = false;
            for(int k=0;k<3;k++)
            {
                if(game[k,j]==data)
                {
                    status = true;
                    break;
                }
            }
            return status;
        }

        private static int getRandomNumberForColumn(int high)
        {
          if(high==0)
            {
                high = 10;

            }
            else
            {
                high=(high + 1) * 10;
            }
            int low = high - 9;
            Random random = new Random();
            return random.Next(high-low)+low;
        }

        private static int getRandomNumber(int max) //for random array index
        {
            Random random = new Random();
            int num=random.Next(max);
            return (num);
            
        }
    }
}