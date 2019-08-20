using Administrator.Contract;
using Administrator.Query;
using System;
using System.Collections.Generic;

namespace Administrator.Manager
{
    public static class Catalogs
    {
        public static IEnumerable<ViewModelCatlogs> GroupsUser(int id, int id_main)
        {
            Auxiliary ObjAux = new Auxiliary();

            if (id == 0)
                throw new ArgumentOutOfRangeException(nameof(id), "La funcion tiene un valor no permitido");

            if (id_main == 0)
                throw new ArgumentOutOfRangeException(nameof(id_main), "La funcion tiene un valor no permitido");

            return ObjAux.GroupUsers(id, id_main);
        }

        public static IEnumerable<ViewModelCatlogs> TypeUser(int id, int id_main)
        {
            Auxiliary ObjAux = new Auxiliary();

            if (id == 0)
                throw new ArgumentOutOfRangeException(nameof(id), "La funcion tiene un valor no permitido");

            if (id_main == 0)
                throw new ArgumentOutOfRangeException(nameof(id_main), "La funcion tiene un valor no permitido");

            return ObjAux.TypeUsers(id, id_main);
        }
    }
}
