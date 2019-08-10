using Administrator.Contract;
using Administrator.Data;
using System.Collections.Generic;
using System.Linq;

namespace Administrator.Query
{
    #region Obtiene el permisos del usuario para cada evento

    public static class PermissionImp
    {
        public static bool Check(string permision, int id)
        {   
            var _connect = Configuration.Ctx();

            return _connect.getConexion.Database
                .SqlQuery<bool>("SELECT " + permision + " Manager.Groups g " +
                "LEFT JOIN Manager.Users u ON g.id = u.id_group WHERE u.id = " + id).FirstOrDefault();
        }
    }

    #endregion

    #region Obtiene los grupos que le pertenecen a los usuarios

    public static class GroupXUserImp
    {
        public static IEnumerable<ViewModelGroupList> Read(int id)
        {
            Configuration connect = Configuration.Ctx();

            IEnumerable<ViewModelGroupList> result = connect.getConexion.Tbl_Groups
                .Where(w => w.Id_main.Equals(id) && w.Id != 1)
                .Select(s => new ViewModelGroupList
                {
                    Id = s.Id,
                    Name = s.Group
                }).ToList();

            return result;
        }
    }

    #endregion
}
