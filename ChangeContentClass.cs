using System.IO;
using System;

namespace ChangeContentSpace
{
    public class ChangeContentClass
    {
        public string ChangeContentVoid(string a_file, string b_file, string c_file)
        {
            try
            {
                string content_a = ContentReturn(a_file),
                       content_b = ContentReturn(b_file),
                       content_c = ContentReturn(c_file),
                       result = "";
                if ((content_a.Length >= content_b.Length) && (content_a.Length >= content_c.Length))
                {
                    if (content_b.Length > content_c.Length)
                    {
                        File.WriteAllText(c_file, content_a);
                        result = $"Содержимое третьего файла: {content_c} было изменено на содержимое первого файла: {content_a}";
                    }
                    else
                    {
                        File.WriteAllText(b_file, content_a);
                        result = $"Содержимое второго файла: {content_b} было изменено на содержимое первого файла: {content_a}";
                    }
                }
                if ((content_b.Length >= content_a.Length) && (content_b.Length >= content_c.Length))
                {
                    if (content_a.Length > content_c.Length)
                    {
                        File.WriteAllText(c_file, content_b);
                        result = $"Содержимое третьего файла: {content_c} было изменено на содержимое второго файла: {content_b}";
                    }
                    else
                    {
                        File.WriteAllText(a_file, content_b);
                        result = $"Содержимое первого файла: {content_a} было изменено на содержимое второго файла: {content_b}";
                    }
                }
                if ((content_c.Length >= content_a.Length) && (content_c.Length >= content_b.Length))
                {
                    if (content_b.Length > content_a.Length)
                    {
                        File.WriteAllText(a_file, content_c);
                        result = $"Содержимое первого файла: {content_a} было изменено на содержимое третьего файла: {content_c}";
                    }
                    else
                    {
                        File.WriteAllText(b_file, content_c);
                        result = $"Содержимое второго файла: {content_b} было изменено на содержимое третьего файла: {content_c}";
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public string ContentReturn(string file)
        {
            StreamReader sr = File.OpenText(file);
            string content = sr.ReadToEnd();
            sr.Close();
            return content;
        }
        static void Main()
        {
            while(true){
                try
                {
                    Console.WriteLine("Введите пути к трем файлам:");
                    string a_file = Console.ReadLine(),
                           b_file = Console.ReadLine(),
                           c_file = Console.ReadLine();
                    ChangeContentClass change = new ChangeContentClass();
                    Console.WriteLine(change.ChangeContentVoid(a_file, b_file, c_file) + "\nНажмите чтобы повторить\n");
                    Console.ReadKey();
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}