using GestionUsuarios.Data;
using GestionUsuarios.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionUsuarios.Flyweight
{
    abstract class AbstractEmail
    {
        protected ViewModelEmail data;
        public abstract string Query(int token, DataModels ctx);
    }

    class QueryEmail : AbstractEmail
    {
        public QueryEmail(ViewModelEmail Data)
        {
            data = Data;
        }

        public override string Query(int token, DataModels ctx)
        {
            throw new NotImplementedException();
        }
    }
}
