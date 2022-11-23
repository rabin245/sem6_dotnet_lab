namespace Delegate
{
    delegate void FileIO(string path);

    class Program
    {
        static void Main(string[] args)
        {
            string path = @"E:\fileio.txt";
            Console.WriteLine("\nEnter option:\n1: Write to file\n2: Read from file\n3: Exit\n");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    FileIO fileWrite = new FileIO(WriteFile);
                    fileWrite(path);
                    break;
                case 2:
                    FileIO fileRead = new FileIO(ReadFromFile);
                    fileRead(path);
                    break;
                default:
                    break;
            }
        }
        public static void WriteFile(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write);
            Console.WriteLine("Enter text: ");
            string msg = Console.ReadLine();
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(msg);
            sw.Close();
            fs.Close();
            Console.WriteLine("File written...");
        }
        public static void ReadFromFile(string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    string[] lines = File.ReadAllLines(path);
                    foreach(string line in lines)
                    {
                        Console.WriteLine(line);
                    }
                }
                //StreamReader sr = File.OpenText(path);
                //string s;
                //while ((s = sr.ReadLine()) != null)
                //{
                //    Console.WriteLine(s);
                //}

            }
            catch
            {
                Console.WriteLine("File Not Found");
            }
        }
        
    }
}