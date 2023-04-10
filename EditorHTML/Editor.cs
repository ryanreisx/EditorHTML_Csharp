using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace EditorHTML
{
    public static class Editor
    {
        public static void Show()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine("MODO EDITOR");
            Console.WriteLine("----------------");
            Start();
        }
        public static void Start() 
        {
            var file = new StringBuilder();

            do
            {
                file.Append(Console.ReadLine());
                file.Append(Environment.NewLine);
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
            Console.WriteLine("---------------");
            Console.WriteLine(" Deseja salvar o arquivo?");
            var salvarArq = Console.ReadLine();
            bool comparacao = salvarArq.Equals("sim", StringComparison.OrdinalIgnoreCase);
            if (comparacao == true)
            {
                Salvar(file.ToString());
            }else if (comparacao == false) {
                Menu.Show();
            }
     
            View.Show(file.ToString());

        }
        public static void Salvar(string text)
        {
            Console.WriteLine("Digite o caminho do arquivo: ");    
            var path = Console.ReadLine();

            using (var file = new StreamWriter(path))
            {
                file.Write(text);
            }
            Console.WriteLine($"Arquivo {path} salvo com sucesso!");
            Console.ReadLine();
            Menu.Show();
        }
    }
}
