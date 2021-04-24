using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organizador_de_tarefas
{
    public class Table
    {
        private readonly string[] _columns;
        private readonly int _maxWidth;
        private List<int> _columnsWidth = new List<int>();
        public Table( int maxWidth, params string[] columns)
        {
            _columns = columns;
            _maxWidth = maxWidth;
            foreach(string column in columns)
            {
                _columnsWidth.Add(column.Length);
            }
        }

        public void printTable(List<string[]> table)
        {
            if(table != null)
            {
                foreach (string[] line in table)
                {
                    getColumnsWidth(line);
                }
            }            

            PrintLine();
            PrintRow(_columns);
            PrintLine();

            if(table != null)
            {
                foreach (string[] row in table)
                {
                    PrintRow(row);
                    PrintLine();
                }
            }
        }       

        private void getColumnsWidth(string[] line)
        {
            if (line.Length > _columns.Length || line.Length < _columns.Length)
            {
                throw new Exception("O numero de colunas não bate com o que foi instaciado no objeto");
            }
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i].Length > _maxWidth)
                {
                    _columnsWidth[i] = _maxWidth;
                    
                }
                else if (line[i].Length > _columnsWidth[i])
                {
                    _columnsWidth[i] = line[i].Length;
                }
            }

        }

        private void PrintLine()
        {
            int width = _columns.Length+1;
            foreach(int num in _columnsWidth)
            {
                width += num;
            }
            Console.WriteLine(new string('-', width));
        }

        private void PrintRow(string[] columns)
        {
            string row = "|";

            for (int i = 0; i < columns.Length; i++)
            {
                int width = _columnsWidth[i];
                row += AlignCentre(columns[i], width) + "|";
            }

            Console.WriteLine(row);
        }

        private string AlignCentre(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }




    }
}
