using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TowerGame.Interpreter
{
    abstract class AbstractExpression
    {
        public abstract List<String> Interpret(Context ctx);
    }
}
