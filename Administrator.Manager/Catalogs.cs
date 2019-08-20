using Administrator.Contract;
using Administrator.Query;
using System;
using System.Collections.Generic;

namespace Administrator.Manager
{
    public static class Catalogs
    {
        public static IEnumerable<ViewModelCatlogs> Groups(int id)
        {
            Auxiliary ObjAux = new Auxiliary();

            if (id == 0)
                throw new ArgumentOutOfRangeException(nameof(id), "La funcion tiene un valor no permitido");

            return ObjAux.GroupUsers(id);
        }

        public static List<ViewModelCatlogs> GetTypeUserSuper()
        {
            List<ViewModelCatlogs> typeuser = new List<ViewModelCatlogs>();

            typeuser.Add(new ViewModelCatlogs { Text = "Staff", Value = 2 });
            typeuser.Add(new ViewModelCatlogs { Text = "Administrador", Value = 1 });
            return typeuser;
        }

        public static List<ViewModelCatlogs> GetTypeUser()
        {
            List<ViewModelCatlogs> typeuser = new List<ViewModelCatlogs>();

            typeuser.Add(new ViewModelCatlogs { Text = "Usuario", Value = 4 });
            return typeuser;
        }

        public static List<ViewModelCatlogs> GetTypeData()
        {
            List<ViewModelCatlogs> typedata = new List<ViewModelCatlogs>();

            typedata.Add(new ViewModelCatlogs { Text = "Usuario", Value = 1 });
            typedata.Add(new ViewModelCatlogs { Text = "Oficina", Value = 2 });
            typedata.Add(new ViewModelCatlogs { Text = "Casa", Value = 3 });
            typedata.Add(new ViewModelCatlogs { Text = "Negocio", Value = 4 });

            return typedata;
        }

        public static List<ViewModelCatlogs> GetTypePhone()
        {
            List<ViewModelCatlogs> typephono = new List<ViewModelCatlogs>();

            typephono.Add(new ViewModelCatlogs { Text = "Fijo", Value = 1 });
            typephono.Add(new ViewModelCatlogs { Text = "Movil", Value = 2 });

            return typephono;
        }
    }
}
