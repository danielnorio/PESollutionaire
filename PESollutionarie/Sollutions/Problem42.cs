using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace PESollutionarie.Sollutions
{
    class Problem42 : Problem
    {
        string rawList;
        public override string Answer()
        {
            // Mine solution depends on Internet connection. Sorry.
            Console.WriteLine("Trying to download list from Web...");
            rawList = Download();
            if (rawList != "") Console.WriteLine("Download ok!");
            else
            {
                Console.WriteLine("Sorry.. Couldn't download the file. Abort.");
                return "Failure on download.";
            }
            
            List<string> list = new List<string>(rawList.Split(new string[] { "\",\"" }, StringSplitOptions.None));
            list[0] = list[0].Substring(1);
            list[list.Count - 1] = list[list.Count - 1].Substring(0, list[list.Count - 1].Length - 1);

            int countTriangle = 0;
            // Theorem: for any k, if k=(n+1)n/2 then  sqrt(2k)-1/2 <= n < sqrt(2k)+1/2  ---> n = ceiling (sqrt(2k)-1/2) = floor (sqrt(2k)+1/2)
            // I will demonstrate this fabulous theorem very soon!!
            foreach (string candidate in list)
            {
                double charSum = 0;
                foreach (char c in candidate) charSum += c - 'A' + 1;

                double possibleN = Math.Ceiling(Math.Sqrt(2 * charSum) - 0.5);

                if ((possibleN * (possibleN + 1)) == 2*charSum)
                {
                    countTriangle++;
                }

            }
            return countTriangle.ToString();
        }

        public override void Solve()
        {

        }

        private string Download()
        {

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                string urlAddress = "https://projecteuler.net/project/resources/p042_words.txt";

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress);
                try
                {
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        Stream receiveStream = response.GetResponseStream();
                        StreamReader readStream = null;

                        if (response.CharacterSet == null)
                        {
                            readStream = new StreamReader(receiveStream);
                        }
                        else
                        {
                            readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                        }

                        string data = readStream.ReadToEnd();

                        response.Close();
                        readStream.Close();
                        return data;
                    }
                }
                catch (WebException)
                {

                }
                return "";

            
        }
    }
}
