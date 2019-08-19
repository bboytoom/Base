using System.Collections.Generic;
using System.Linq;
using Administrator.Contract;
using Administrator.Database;

namespace Administrator.Query
{
    #region Catalogos

    public class Auxiliary
    {
        private Configuration _connect;

        public Auxiliary()
        {
            _connect = Configuration.Ctx();
        }

        public IEnumerable<ViewModelCatlogs> GroupUsers(int id)
        {
            IEnumerable<ViewModelCatlogs> result = _connect.getConexion.Tbl_Groups
                .Where(w => w.Id_main.Equals(id) && w.Id != 1)
                .Select(s => new ViewModelCatlogs
                {
                    Value = s.Id,
                    Text = s.Group
                }).ToList();

            return result;
        }
    }

    #endregion
}
