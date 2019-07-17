using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Administrator.Manager.Helpers
{
    public static class HCatalogs
    {
        public static List<SelectListItem> GetTypeUser()
        {
            List<SelectListItem> typeuser = new List<SelectListItem>();

            typeuser.Add(new SelectListItem() { Text = "Root", Value = "1" });
            typeuser.Add(new SelectListItem() { Text = "Staff", Value = "2" });
            typeuser.Add(new SelectListItem() { Text = "Administrador", Value = "3" });
            typeuser.Add(new SelectListItem() { Text = "Usuario", Value = "4" });
            typeuser.Add(new SelectListItem() { Text = "Proveedor", Value = "5" });
            typeuser.Add(new SelectListItem() { Text = "Cliente", Value = "6" });

            return typeuser;
        }

        public static List<SelectListItem> GetTypeData()
        {
            List<SelectListItem> typedata = new List<SelectListItem>();

            typedata.Add(new SelectListItem() { Text = "Usuario", Value = "1" });
            typedata.Add(new SelectListItem() { Text = "Oficina", Value = "2" });
            typedata.Add(new SelectListItem() { Text = "Casa", Value = "3" });
            typedata.Add(new SelectListItem() { Text = "Negocio", Value = "4" });

            return typedata;
        }

        public static List<SelectListItem> GetTypePhone()
        {
            List<SelectListItem> typephono = new List<SelectListItem>();

            typephono.Add(new SelectListItem() { Text = "Fijo", Value = "1" });
            typephono.Add(new SelectListItem() { Text = "Movil", Value = "2" });

            return typephono;
        }
    }
}
