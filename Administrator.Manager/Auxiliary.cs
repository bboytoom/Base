using Administrator.Contract;
using Administrator.Query;
using System;
using System.Collections.Generic;

namespace Administrator.Manager
{
    public static class Auxiliary
    {
        public static bool Permission(string permision, int id)
        {
            if (id == 0)
                throw new ArgumentOutOfRangeException(nameof(id), "La funcion tiene un valor no permitido");

            if (string.IsNullOrEmpty(permision))
                throw new ArgumentNullException(permision);

            return PermissionImp.Check(permision, id);
        }

        public static IEnumerable<ViewModelGroupList> Groups(int id)
        {
            if (id == 0)
                throw new ArgumentOutOfRangeException(nameof(id), "La funcion tiene un valor no permitido");

            return GroupXUserImp.Read(id);
        }
    }
}
