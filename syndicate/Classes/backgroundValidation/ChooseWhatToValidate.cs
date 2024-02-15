using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using syndicate.Classes.GlobalVariables;
using syndicate.Classes.VALIDATION;
using Tambola.Classes;

namespace syndicate.Classes.backgroundValidation
{
    public class ChooseWhatToValidate
    {
        public void chooseWhatBonusTovalidate()
        {
            DataAccessForUserInterface taa = new DataAccessForUserInterface();
            string[] ticketcount = taa.BringSoldTicketsName();
            if (ticketcount.Length >= 6)
            {
                if (DependencyCounter.FullHouse == 1)
                {
                    CheckFullHouseWinners();//full house
                }
                if (DependencyCounter.FullSheet == 1)
                {
                    CheckFullSheetWinner();
                }
                if (DependencyCounter.HalfSheet == 1)
                {
                    CheckHalfsheetWinner();
                }

                if (DependencyCounter.QuickFive == 1)
                {
                    CheckFirstFiveWinners();
                }
                if (DependencyCounter.QuickSeven == 1)
                {
                    CheckFirstSevenWinners();
                }
                if (DependencyCounter.Star == 1)
                {
                    CheckStarWinner();
                }
                if (DependencyCounter.TopLine == 1)
                {
                    CheckTopLineWinners();
                }
                if (DependencyCounter.MiddleLine == 1)
                {
                    CheckMiddleLineWinners();
                }
                if (DependencyCounter.BottomLIne == 1)
                {
                    CheckBottomLineWinners();
                }
            }

        }
        public void CheckFullSheetWinner() //check if winners already Made
        {
          
            FullSheet fs = new FullSheet();
            List<int> winners = fs.DoValidation();
            if (winners.Count >= 1)
            {
                DependencyCounter.FullSheet = 0;
                DependencyCounter.GameOver++;
            }
        }

        public void CheckHalfsheetWinner()
        {
          
            Halfsheet hs = new Halfsheet();
            List<int> winners = hs.DoValidation();
            if(winners.Count >= 1)
            {
                DependencyCounter.HalfSheet = 0;
                DependencyCounter.GameOver++;
            }
        }
        public void CheckStarWinner()
        {
            
            STAR s = new STAR();
            List<string> winners = s.BringStarWinners();
            if (winners.Count >= 1)
            {
                DependencyCounter.Star = 0;
                DependencyCounter.GameOver++;
            }

        }
        public void CheckFirstFiveWinners()
        {
            FIRSTFIVE ff = new FIRSTFIVE();
           List<string> firstFive = ff.getValidationTicketsAndValidate();
            if (firstFive.Count >= 1)
            {
                DependencyCounter.QuickFive = 0;
                DependencyCounter.GameOver++;
            }
        }
        public void CheckFirstSevenWinners()
        {
            
            FIRSTSEVEN fs = new FIRSTSEVEN();
            List<string> firstSeven = fs.getValidationTicketsAndValidate();
            if (firstSeven.Count >= 1)
            {
                DependencyCounter.QuickSeven = 0;
                DependencyCounter.GameOver++;
            }
        }

        public void CheckTopLineWinners()
        {
            
            TOPLINE tl = new TOPLINE();
            List<string> topline = tl.getValidationTicketsAndValidateTOP();
            if (topline.Count >= 1)
            {
                DependencyCounter.TopLine = 0;
                DependencyCounter.GameOver++;
            }
        }
        public void CheckMiddleLineWinners()
        {
            
            MIDDLELINE ml = new MIDDLELINE();
            List<string> middleline = ml.getValidationTicketsAndValidateMIDDLE();
            if (middleline.Count >= 1)
            {
                DependencyCounter.MiddleLine = 0;
                DependencyCounter.GameOver++;
            }
        } 
        public void CheckBottomLineWinners()
        {
            BOTTOMLINE bl = new BOTTOMLINE();
            List<string> bottomline = bl.getValidationTicketsAndValidateBOTTOM();
            if (bottomline.Count >= 1)
            {
                DependencyCounter.BottomLIne = 0;
                DependencyCounter.GameOver++;
            }
        }
        public void CheckFullHouseWinners()
        {
            FULLHOUSE fh = new FULLHOUSE();
           int totalFh= fh.fullhouseCount("count");
            int countFh = fh.fullhouseCount("countreachedCheck");
            if (totalFh <= countFh)
            {
                DependencyCounter.FullHouse = 0;
                DependencyCounter.GameOver++;
            }
            else
            {
                fh.getValidationTicketsAndValidateFULLHOUSE();
            }
           
        }
    }
}