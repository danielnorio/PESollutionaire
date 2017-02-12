using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;

namespace PESollutionarie
{

    class Program
    {
        static int[] escolhasValidas = inicializaEscolhasValidas();
        static void Main(string[] args)
        {
            string[] titulos = escolhasValidas.Select(x => "[" + x.ToString() + "]").ToArray();

            Console.WriteLine("Problemas encontrados: " + titulos.Aggregate((current, next) => current + ", " + next));

            Console.WriteLine("Digite [n] para não baixar títulos e estatísticas ou qualquer outra coisa para baixar:");
            string baixar = Console.ReadLine();
            if (baixar != "n" && baixar != "N") {
                Console.WriteLine("Tentando baixar lista de títulos e estatísticas da Internet....");
                string html = baixaListaHtml();
                if (html == "")
                    Console.WriteLine("Ops. Não foi possível baixar a lista.");
                else
                {
                    Console.WriteLine("Lista baixada. Lendo dados..");
                    titulos = pegaTitulosEestatisticas(html);
                }
            }

            // Pega input do usuário
            while (true)
            {
                Console.OutputEncoding = Encoding.Unicode;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Selecione um dos problemas abaixo:");
                foreach(string e in titulos)
                {
                    Console.WriteLine("{0}", e);
                }

                string escolha = Console.ReadLine();
                int iEscolha;
                if (int.TryParse(escolha, out iEscolha) && possuiSolucao(iEscolha))
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Chamando função para problema {0}...", iEscolha);
                    Console.WriteLine("‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾");
                    //Obtém dinamicamente uma instância do problema
                    IProblem ip = CreateInstance<IProblem>(iEscolha);
                    //Executa o problema
                    string resposta = ip.Answer();
                    Console.WriteLine("_____________________________________");
                    Console.WriteLine("Resposta do problema: " + resposta);
                    Console.WriteLine("‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾" + Environment.NewLine);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Profiling do problema {0} com 20 iterações...", iEscolha);
                    Console.WriteLine("‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾");
                    double tempoMedio = ip.Profile();
                    Console.WriteLine("_____________________________________");
                    Console.WriteLine("Tempo médio: {0} ms = {1} s", tempoMedio, tempoMedio/1000);
                    Console.WriteLine(Environment.NewLine);
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                else Console.WriteLine("Entrada inválida");
            }
        }

        // Método que cria uma instância dinâmicamente concatenando Namespace + "Problem" + número do problema
        //As-is: http://www.c-sharpcorner.com/uploadfile/87b416/dynamically-create-instance-of-class-by-passing-string-as-cl/
        public static I CreateInstance<I>(int problema) where I : class
        {
            string assemblyPath = Environment.CurrentDirectory + "\\PESollutionarie.exe";
            Assembly assembly = Assembly.LoadFrom(assemblyPath);
            Type type = assembly.GetType("PESollutionarie.Sollutions.Problem" + problema.ToString());
            return Activator.CreateInstance(type) as I;
        }

        static bool possuiSolucao(int problema)
        {
            foreach (int i in escolhasValidas)
            {
                if (i == problema)
                    return true;
            }
            return false;
        }

        static int[] inicializaEscolhasValidas()
        {
            List<int> termsList = new List<int>();
            string nspace = "PESollutionarie.Sollutions";
            
            var q = from t in Assembly.GetExecutingAssembly().GetTypes()
                    where t.IsClass && t.Namespace == nspace
                    select t;
            q.ToList().ForEach(t => termsList.Add(Int32.Parse(t.ToString().Substring(34))));
            termsList.Sort();
            return termsList.ToArray();
        }

        static string baixaListaHtml()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            string urlAddress = "https://projecteuler.net/show=all";

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
        static string[] pegaTitulosEestatisticas(string data)
        {
            var doc = new HtmlDocument();
            doc.LoadHtml(data);
            List<string> termsList = new List<string>();
            foreach (int num in escolhasValidas)
            {
                string expressaoXpath = "//a[contains(@href,'problem="+num+"')]";
                string problemTitle = doc.DocumentNode.SelectSingleNode(expressaoXpath).InnerText;
                string[] parts = problemTitle.Split(new string[] { "Published" }, StringSplitOptions.None);
                string[] subpartsTitle = parts[0].Split(':');
                termsList.Add("[" + num + "] - " + subpartsTitle[1] + " - Published " + parts[1]);
            }
            return termsList.ToArray();

        }
    }
}
