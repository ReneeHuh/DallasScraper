using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Web;


namespace DallasScraper
{
    class ScrapeEngine
    {
        public List<PropertyRecord> SearchByName(string input)
        {
            List<PropertyRecord> r = new List<PropertyRecord>();
            //
            string contentResults = DownloadHTMLSearchbyName(input, "");
            
            r = ParseHTMLOfResults(contentResults);

            return r;
        }

        public string DownloadHTMLSearchOfAddress(string streetNumber, string streetName)
        {
            //use 1 for searchby Name
            //use 3 for searchby Street

            string PostContent = "&criteria=" + streetName +
                "&criteria2=" + streetNumber+
                "&searchby=3";

            string content = DownloadViaPost(PostContent);

            return content;
            
        }
        public string DownloadHTMLSearchbyName(string LastName, string firstName)
        {
            //use 1 for searchby Name
            //use 3 for searchby Street

            string PostContent = "&criteria=" + LastName +
                "&criteria2=" + firstName +
                "&searchby=1";

            string content = DownloadViaPost(PostContent);

            return content;
        
        }
        public string DownloadViaPost(string PostContent)
        {

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://www.dallasact.com/act_webdev/dallas/showlist.jsp");
            request.Method = "POST";

            string formContent = PostContent;
            //search by 3 is street by 1 is last name

            byte[] byteArray = Encoding.UTF8.GetBytes(formContent);
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            WebResponse response = request.GetResponse();
            dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = WebUtility.HtmlDecode(reader.ReadToEnd());
            //You may need HttpUtility.HtmlDecode depending on the response

            reader.Close();
            dataStream.Close();
            response.Close();

            return responseFromServer;
        
        }
        public List<PropertyRecord> ParseHTMLOfResults(string ListofResults)
        {
            List<PropertyRecord> ret = new List<PropertyRecord>();
            int current = 0;
            List<string> extrecords = new List<string>();
            do
            {
                int start = ListofResults.IndexOf("<a href='showdetail2.jsp?can=", current);
                if (start == -1) { break; }
                int end = ListofResults.IndexOf("&",start);

                if (start != -1 && end != -1)
                {
                    start = start + 29;
                    int lenght = end - start;
                    string id = ListofResults.Substring(start,lenght);
                    extrecords.Add(id);

                    //move current after end
                    current = end;
                }
                else
                { break; }

            
            } while (current <= ListofResults.Length);

            WebClient web = new WebClient();
            foreach (string element in extrecords)
            {
                PropertyRecord j = new PropertyRecord();
                string url = "http://www.dallasact.com/act_webdev/dallas/showdetail2.jsp?can=";
                string urlEnd = "&ownerno=0";
                //download HTML as string
                string fullURL = url + element + urlEnd;
                string html = web.DownloadString(fullURL);
                //parse HTMl into single recored
                j = ParseHTMLPropertyRecord(html);

                ret.Add(j);
            }
            return ret;   
        }
 
        public PropertyRecord ParseHTMLPropertyRecord(string content)
        {
            PropertyRecord ret = new PropertyRecord();


            //Extract Account Number
            string _AccountNum = SearchAndExtract(content, "<b>Account Number:&nbsp; ", "</b><br>");
            
            //Extract MailingFullAddress Number
            string _FullMailingAddress = SearchAndExtract(content, "<b>Address:</b> <br>", "<br><br>");
           
            //Extract PropertySiteAddress Number
            string _PropertyAddress = SearchAndExtract(content, "<b>Property Site Address:</b> <br>", "<br><br>");

            //Extract LegalDescription 
            string _LegalAddress = SearchAndExtract(content, "<b>Legal Description:</b> <br>", "<br> <br><br>");

            //Extract Current Tax Levy 
            string _CurrentTaxLevy = SearchAndExtract(content, "<b>Current Tax Levy: &nbsp; </b>", "<br><br>");
            string _CurrentAmountDue = SearchAndExtract(content, "<b>Current Amount Due: &nbsp; </b>", "<br><br>");
            string _PriorYearAmountDue = SearchAndExtract(content, "<b>Prior Year Amount Due: &nbsp; </b>", "<br><br>");
            string _TotalAmountDue = SearchAndExtract(content, "<b>Total Amount Due: &nbsp; </b>", "<br><br>");
           
            //Extract MarketValue 
            string _MarketValue = SearchAndExtract(content, "<b>Market Value:</b> &nbsp;", "<br><br>");
            string _LandValue = SearchAndExtract(content, "<b>Land Value:</b> &nbsp;", "<br><br>");
            string _ImprovmentValue = SearchAndExtract(content, "<b>Improvement Value:</b> &nbsp;", "<br><br>");
            string _CappedValue = SearchAndExtract(content, "<b>Capped Value:</b>", "<br><br>");
            string _AgriculturalValue = SearchAndExtract(content, "<b>Agricultural Value:</b>", "<br><br>");
            string _Exemptions = SearchAndExtract(content, "<b>Exemptions:</b>", "<br><br>");

            
            ret.AccountNumber = _AccountNum;
            ret.MailingFullAddress = _FullMailingAddress;
            ret.PropertySiteFullAddress = _PropertyAddress;
            ret.CurrentTaxLevy = _CurrentTaxLevy;
            ret.CurrentAmountDue = _CurrentAmountDue;
            ret.PriorYearAmountDue = _PriorYearAmountDue;
            ret.TotalAmountDue = _TotalAmountDue;
            ret.MarketValue = _MarketValue;
            ret.LandValue = _LandValue;
            ret.ImprovementValue = _ImprovmentValue;
            ret.CappedValue = _CappedValue;
            ret.AgriculturalValue = _AgriculturalValue;
            ret.Excemptions = _Exemptions;
            return ret;
        }
        public string SearchAndExtract(string HTML, string SearchStart, string SearchEnd)
        {
            int start = HTML.IndexOf(SearchStart) ;
            
            if (start == -1) { return ""; }
            //return to avoid index of next line exception
            int end = HTML.IndexOf(SearchEnd, start);
            
            string stringreturn = "";

            if (start != -1)
            {
                //correct start
                start = start + SearchStart.Length +1;
                int lenght = end - start;
                stringreturn = HTML.Substring(start, lenght);
                stringreturn = WebUtility.HtmlDecode(stringreturn);
            }

            return RemoveBR(stringreturn);
        }
        public string RemoveBR(string input)
        {
            StringBuilder r = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '<') { r.AppendLine(); i = i + 3; }
                else { r.Append(input[i]); }
            }

            return r.ToString().Trim();

        }
    }

    public class PropertyRecord 
    {
        public string AccountNumber;
        public string MailingFullAddress;
        //property to extract full address
        public string PropertySiteFullAddress;
        public string OwnerName
        { 
            get 
            { 
                int start = 0;
                int end = MailingFullAddress.IndexOf("\r\n", start);
                int lenght = end - start;
                string ownerName = MailingFullAddress.Substring(start, lenght);
                return ownerName.Trim(); 
            } 
        }
        public string PropertySiteAddress
        {
            get { return PropertySiteFullAddress.Substring(0, PropertySiteFullAddress.IndexOf(',')); }
        }
        public string LegalDescription;
        public string CurrentTaxLevy;
        public string CurrentAmountDue;
        public string PriorYearAmountDue;
        public string TotalAmountDue;
        public string MarketValue;
        public string LandValue;
        public string ImprovementValue;
        public string CappedValue;
        public string AgriculturalValue;
        public string Excemptions;

        public override string ToString()
        {
            return String.Format("{0}\t{1}\t\t{2}\t{3}",AccountNumber,OwnerName,PropertySiteAddress,MarketValue);
        }
       

    
    }
}
