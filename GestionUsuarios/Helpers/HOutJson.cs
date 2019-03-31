using GestionUsuarios.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionUsuarios.Helpers
{
    public class OutJsonCheck
    {
        public int Status { get; set; }
        public bool Respuesta { get; set; }
    }

    public class OutJsonGroup
    {
        public int Status { get; set; }
        public List<ViewModelGroup> Respuesta { get; set; }
    }

    public class OutJsonUser
    {
        public int Status { get; set; }
        public List<ViewModelUser> Respuesta { get; set; }
    }

    public class OutJsonEmail
    {
        public int Status { get; set; }
        public List<ViewModelEmail> Respuesta { get; set; }
    }
}
