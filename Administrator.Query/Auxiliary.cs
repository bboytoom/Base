using Administrator.Contract;
using Administrator.Database;
using System.Collections.Generic;
using System.Linq;

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

        public IEnumerable<ViewModelCatlogs> TypeUsers(int id, int id_main)
        {
            IEnumerable<ViewModelCatlogs> result = _connect.getConexion.Cat_Users
                .Where(w => w.Id.Equals(id) && w.Id_main.Equals(id_main))
                .Select(s => new ViewModelCatlogs
                {
                    Value = s.Id,
                    Text = s.Name
                }).ToList();

            return result;
        }

        public IEnumerable<ViewModelCatlogs> GroupUsers(int id, int id_main)
        {
            IEnumerable<ViewModelCatlogs> result = _connect.getConexion.Tbl_Groups
                .Where(w => w.Id.Equals(id) && w.Id_main.Equals(id_main))
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
