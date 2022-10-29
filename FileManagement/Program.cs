using FileManagement.DoublyLinkedList;

namespace FileManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DLList<char> FileList = new();
            StreamReader reader;
            int TotalCharCount = 0;
            char ch;

            string file = @"C:\tmp\file.txt";
            GenericNode<char> node;
            
            try
            {
                reader = new StreamReader(file);

                while (reader.Peek() >= 0)
                {
                    ch = (char)reader.Read();
                    if ((Convert.ToInt32(ch) == 13) || (Convert.ToInt32(ch) == 10))
                    {
                        reader.Read();
                        continue;
                    }

                    node = FileList.GetNodePosition(ch)!;
                    if (node != null)
                    {
                        FileList.IncreaseCount(node);
                    }
                    else
                    {
                        FileList.InsertLast(ch);
                    }

                    TotalCharCount++;
                }
                reader.Close();
                Console.WriteLine("Traverse...");
                FileList.Traverse(TotalCharCount);

                Console.WriteLine("Traverse by char asc");
                FileList.SortByValAsc();
                FileList.Traverse(TotalCharCount);

                Console.WriteLine("Traverse by char frequency");
                FileList.SortyByFrequencyDesc();
                FileList.Traverse(TotalCharCount);
            } 
            catch (FileNotFoundException e1)
            {
                Console.WriteLine(e1.Message);
            }
            catch (IOException e2)
            {
                Console.WriteLine(e2.Message);
            }

        }
    }
}