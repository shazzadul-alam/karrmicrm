using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;

namespace LogisticManagement.CommonLogic
{
    public class CommonMethod
    {

        public string SendSystemSms(string mobile, string messageBody)
        {
            try
            {
                //string apiKey = "api_key=KEY-znh89zgv6yib6j3wkt5oh3mdp92uwayu&api_secret=1YFYLXXW4@WN7289&request_type=GENERAL_CAMPAIGN&message_type=TEXT&mobile=01686881969&message_body=Hello Mr. Shazzadul ALam, This is test message from system&campaign_title=this is test title";
                string apiKey = "KEY-znh89zgv6yib6j3wkt5oh3mdp92uwayu";
                string apiSecret = "1YFYLXXW4@WN7289";
                string requestType = "GENERAL_CAMPAIGN";
                string messageType = "TEXT";

                //string mobile = "01686881969";
                //string messageBody = "MY BD STORE\nThis is your link to get access"
                                     //+ " to out system.\nRegards, System";
                string messageTitle = "Marketing";


                // creating the object of HTTPClient.
                var client = new HttpClient();
                // Initiating the base address of the API where the API is hosted.
                client.BaseAddress = new Uri("https://portal.adnsms.com/");

                // Declaring and initiating the request to call the API.
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, " api/v1/secure/send-sms?" + "api_key=" + apiKey + "&api_secret=" + apiSecret + "&request_type=" + requestType + "&message_type=" + messageType + "&mobile=" + mobile + "&message_body=" + messageBody + "&campaign_title=" + messageTitle);
                // Initiating the post bosy into the content
                request.Content = new StringContent("", Encoding.UTF8, "application/json");
                // Initiating the request header.
                request.Headers.Add("accept", "application/json");
                // Sending the API request
                HttpResponseMessage response = client.SendAsync(request).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.

                return "ok";

                //using (HttpContent content = response.Content)
                //{
                //    // Retrieving and stroing the result of the API
                //    var json = content.ReadAsStringAsync();
                //    return "ok";
                //}
            }
            catch (Exception x)
            {

                return "error";
            }
        }






        public int returnZeroForNUll(string number)
        {
            if (number == null || number == "" || number == " ")
            {
                return 0;
            }
            else
            {
                var iNUmber = Int32.Parse(number);
                return iNUmber;
            }
        }


        //public void SendMail(MailAddress receiverEmail, string subject, string body)
        //{
        //    var senderEmail = new MailAddress("emailtest456789@gmail.com", "emailtest");
        //    var password = "Emailtest1";
        //    var sub = "Ticket";
        //    var smtp = new SmtpClient
        //    {
        //        Host = "smtp.gmail.com",
        //        Port = 587,
        //        EnableSsl = true,
        //        DeliveryMethod = SmtpDeliveryMethod.Network,
        //        UseDefaultCredentials = false,
        //        Credentials = new NetworkCredential(senderEmail.Address, password)
        //    };
        //    using (var mess = new MailMessage(senderEmail, receiverEmail)
        //    {
        //        Subject = sub,
        //        Body = body
        //    }
        //    )
        //    {
        //        smtp.Send(mess);
        //    }
        //}

        //public string createFormattedNumbers (string number, int formattedNumberDigit)
        //{
        //    int lastNumber = Int32.Parse(number);
        //    int newNumber = (lastNumber + 1);

        //    //string finalFormattedNumber = String.Format("{0:0000000}", newNumber); //process 1
        //    //string finalFormattedNumber = newNumber.ToString("D7"); //process 2
        //    string finalFormattedNumber = newNumber.ToString().PadLeft(formattedNumberDigit, '0'); //process 3


        //    return finalFormattedNumber;
        //}

        public int roundNumber(double number)
        {
            int baseNumber = (int)number;
            int nextNumber = baseNumber + 1;

            double remainDecimal = (double)nextNumber - number;
            if (remainDecimal < 0.5)
            {
                return nextNumber;
            }
            else
            {
                return baseNumber;
            }
        }



        public string createFormattedNumbers(string lastNumberWithInitial, int formattedNumberDigit, string initial)
        {
            var number = lastNumberWithInitial.Substring(lastNumberWithInitial.Length - Math.Min(formattedNumberDigit, lastNumberWithInitial.Length));
            int lastNumber = Int32.Parse(number);
            int newNumber = (lastNumber + 1);

            string finalFormattedNumber = String.Format("{0:0000000}", newNumber); //process 1
            finalFormattedNumber = newNumber.ToString("D7"); //process 2
            finalFormattedNumber = newNumber.ToString().PadLeft(formattedNumberDigit, '0'); //process 3
            finalFormattedNumber = initial + finalFormattedNumber;

            return finalFormattedNumber;
        }



        public DateTime returnServerTime()
        {
            string countryName = "Bangladesh Standard Time";
            DateTime utcTime = DateTime.UtcNow;
            TimeZoneInfo usersTimeZone = TimeZoneInfo.FindSystemTimeZoneById(countryName);
            DateTime usersLocalTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, usersTimeZone);


            return usersLocalTime;
        }

        public string generateCustomErrorMessage(int hrResult)
        {
            string errMsg = "";

            if (hrResult == -2146233087)
            {
                errMsg = "Duplicate Value! ";
            }
            else if (hrResult == -2146233033)
            {
                errMsg = "Wrong Input/File Type! ";
            }
            else if (hrResult == -2146232032)
            {
                errMsg = "Value Exceeds it's Max Range! ";
            }
            else if (hrResult == -2147467261)
            {
                errMsg = "Object Not Found/ Ambiguous with another object";
            }
            else if (hrResult == -2146233067)
            {
                errMsg = "Query Attempt with NULL value/Check Session";
            }
            else
            {
                errMsg = "Something Unusual occured !";
            }

            return errMsg;
        }


        public string generateErrorMessage(Exception ex)
        {
            var message = "";
            try
            {
                message = ex.InnerException.InnerException.Message;
            }
            catch
            {
                try
                {
                    message = ex.InnerException.Message;
                }
                catch
                {
                    message = ex.Message;
                }

            }

            return message;
        }






        public string generateJobNumberSL(string ascCode, string customerCategory, string warrantyStatus, string number, int formattedNumberDigit)
        {
            string warrantyCode;
            if (warrantyStatus == "In")
            {
                warrantyCode = "1";
            }
            else
            {
                warrantyCode = "0";
            }

            if (customerCategory == "01")
            {
                customerCategory = "DA";
            }
            else if (customerCategory == "02")
            {
                customerCategory = "DO";
            }


            int lastNumber = Int32.Parse(number);
            int newNumber = (lastNumber + 1);

            string currentMonth = DateTime.Now.ToString("MM");
            string currentYear = DateTime.Now.ToString("yy");

            string formattedNumber = newNumber.ToString().PadLeft(formattedNumberDigit, '0'); //process 3

            string finalFormattedNumber = ascCode + customerCategory + currentMonth + currentYear + warrantyCode + formattedNumber;

            return finalFormattedNumber;
        }
    }
}