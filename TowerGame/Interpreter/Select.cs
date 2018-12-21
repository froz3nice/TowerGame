using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerGame.Interpreter
{
    class Select : AbstractExpression
    {
        private string column;
        private From from;

        public Select(string column, From from)
        {
            this.column = column;
            this.from = from;
        }

        public override List<string> Interpret(Context ctx)
        {
            ctx.setColumn(column);
            return from.Interpret(ctx);
        }
    }
}
