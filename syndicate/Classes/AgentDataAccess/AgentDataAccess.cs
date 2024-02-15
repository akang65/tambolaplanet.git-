using Dapper;
using FormUI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace syndicate.Classes.AgentDataAccess
{
    public class AgentDataAccess
    {
        public string AgentDetails(string name,string number, string email, string password)
        {
            string responseMessage = "";
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                var checkNumber = connection.Query<int>("dbo.CheckPhoneNumber @Number",new {Number=number});
                int count = checkNumber.First(); 
                if(count>0)
                {
                    responseMessage = "NumberExist";
                }
                else
                { 
                connection.Execute("dbo.sp_AgentDetails @Name,@Number,@Email,@Password", new
                { Name = name,
                Number=number,
                Email=email,
                Password=password});
                    responseMessage = "AgentAdded";
                }
            }
            return responseMessage;
        }
        public void DeleteAgent(string number)
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                connection.Execute("dbo.sp_DeleteAgent @Number",new {Number=number});
            }

        }
        public int AgentLogin(string number,string password)
        {
         
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                var data = connection.Query<int>("dbo.sp_AgentLogin @Number, @Password", new { Number = number, Password = password });
                int count = data.First();
                return count;
            }
        }
        public void AgentUploadimage(string number, string name,int size, byte[] imageData)
        {

            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                var data = connection.Execute("dbo.sp_AgentUploadImage @Number,@Name, @Size, @ImageData", 
                    new { 
                        Number = number,
                        Name = name,
                        Size = size ,
                        ImageData=imageData

                    });
               
            }
        }
        public byte[] AgentFetchProfileImage(string number)
        {

            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                var data = connection.Query("dbo.sp_fetchProfileImage @Number", new { Number = number}).ToArray();
                byte[] count = data[0].ImageData;
                return count;
            }
        }
        public void AgentBuyTicket(string name, string ticketname, string number,string phone)
        {

            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                var data = connection.Execute("dbo.sp_BuyTicketFromAgent @CustomerName, @TicketName, @AgentNumber,@Phone",
                    new
                    {
                        CustomerName = name,
                        TicketName = ticketname,
                        AgentNumber = number,
                        Phone=phone
                    });

            }
        }
            public void AgentBuyFullSheet(string name, string customerPhone,string ticketname, string number)
            {

                using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
                {
                    var data = connection.Execute("dbo.sp_BuyFullSheetFromAgent @CustomerName,@CustomerPhone, @TicketName, @AgentNumber",
                        new
                        {
                            CustomerName = name,
                            CustomerPhone=customerPhone,
                            TicketName = ticketname,
                            AgentNumber = number
                        });

                }
            }
        public void AgentBuyHalfSheet(string name,string customerphone, string ticketname, string number)
        {

            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                var data = connection.Execute("dbo.sp_BuyHalfSheetFromAgent @CustomerName,@CustomerPhone, @TicketName, @AgentNumber",
                    new
                    {
                        CustomerName = name,
                        CustomerPhone=customerphone,
                        TicketName = ticketname,
                        AgentNumber = number
                    });

            }
           
        }
        public int  checkTicketBought(string TicketNo)
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                var data=connection.Query<int>($"select count(TicketNumber) from dbo.SheetBonus where TicketNumber='{ TicketNo }' and CustomerName is null");
                int count = data.First();
                return count;
            }
        }
        public int checkFullSheetBought(int TicketNo)
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                var data = connection.Query<int>($"select COUNT(TicketNumber) from dbo.SheetBonus where FullSheet= { TicketNo } and CustomerName is null");
                int count = data.First();
                return count;
            }
        }
        public int checkHalfSheetBought(int TicketNo)
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                var data = connection.Query<int>($"select COUNT(TicketNumber) from dbo.SheetBonus where HalfSheet= { TicketNo } and CustomerName is null");
                int count = data.First();
                return count;
            }
        }
        public string BringAgentName(string number)
        {
            using (IDbConnection connection = new SqlConnection(Helper.CnnVal("TambolaStars")))
            {
                var data = connection.Query<string>($"select AgentName from dbo.Agents where AgentPhoneNumber='{ number }'");
                string name = data.First();
                return name;
            }
        }
    }
}