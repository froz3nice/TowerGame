using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerGame.Interpreter
{
    class From : AbstractExpression
    {
        private string table;

        public From(string table)
        {
            this.table = table;
        }

        public override List<string> Interpret(Context ctx)
        {
            ctx.setTable(table);
            return ctx.search();
        }
    }
}
