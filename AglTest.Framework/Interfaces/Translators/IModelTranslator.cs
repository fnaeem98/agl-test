using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AglTest.Framework.Interfaces.Translators
{
    public interface IModelTranslator<Tinput,Toutput> 
        where Tinput:class
        where Toutput : class
    {
        Toutput Translate(Tinput inputModel);
    }
}
