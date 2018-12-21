using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerGame.Interpreter
{
    class Context
    {
        private string column;
        private string table;
        private string select = "select ";
        private string from = "from ";
        private int colIndex = 0;

        public void setColumn(string column)
        {
            this.column = column;
            setColumnMapper();

        }

        public void setTable(string table)
        {
            this.table = table;
        }

        private void setColumnMapper()
        {
            switch (column)
            {
                case "*":
                    colIndex = 0;
                    break;
                case "name":
                    colIndex = 1;
                    break;
            }
        }

        public List<string> search()
        {
            List<string> s = new List<string>();
            string sql = select + column + " " + from + " " + table;
            s.Add(sql);
            return s;
        }
    }
}
