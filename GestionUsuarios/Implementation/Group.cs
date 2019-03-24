using GestionUsuarios.Data;
using GestionUsuarios.Flyweight;
using GestionUsuarios.Helpers;
using GestionUsuarios.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GestionUsuarios.Implementation
{
    public class CreateGroupImp : ICreateGroup
    {
        private DataModels ctx;
        private QueryGroup objetcQuery;
        private CreateGroupImp()
        {
            ctx = new DataModels();
        }

        public string CreateGroup(ViewModelGroup Data)
        {
            string name_clean = "";

            if (Data.Name == "" || Data.HighUser == 0)
                return JsonConvert.SerializeObject(
                    new OutJsonCheck
                    {
                        Status = 404,
                        Respuesta = false
                    }
                );

            name_clean = WebUtility.HtmlEncode(Data.Name.ToLower());

            var search_group = ctx.Tbl_Grupos
                        .Where(w => w.nombre_grupo == name_clean).FirstOrDefault();

            if (search_group != null)
                return JsonConvert.SerializeObject(
                    new OutJsonCheck
                    {
                        Status = 404,
                        Respuesta = false
                    }
                );

            objetcQuery = new QueryGroup(Data);
            return objetcQuery.Query(1, ctx);
        }
    }

    public class UpdateGroupImp : IUpdateGroup
    {
        private DataModels ctx;
        private QueryGroup objetcQuery;
        private UpdateGroupImp()
        {
            ctx = new DataModels();
        }

        public string UpdateGroup(ViewModelGroup Data)
        {         
            if (Data.Name == "" || Data.HighUser == 0 || Data.Id == 0)
                return JsonConvert.SerializeObject(
                    new OutJsonCheck
                    {
                        Status = 404,
                        Respuesta = false
                    }
                );
            
            var search_group = ctx.Tbl_Grupos
                        .Where(w => w.id == Data.Id).FirstOrDefault();

            if (search_group == null)
                return JsonConvert.SerializeObject(
                    new OutJsonCheck
                    {
                        Status = 404,
                        Respuesta = false
                    }
                );

            objetcQuery = new QueryGroup(Data);
            return objetcQuery.Query(2, ctx);
        }
    }

    public class DeleteGroupImp : IDeleteGroup
    {
        private DataModels ctx;
        private QueryGroup objetcQuery;
        private DeleteGroupImp()
        {
            ctx = new DataModels();
        }

        public string DeleteGroup(ViewModelGroup Data)
        {
            if (Data.Id == 0 || Data.HighUser == 0)
                return JsonConvert.SerializeObject(
                    new OutJsonCheck
                    {
                        Status = 404,
                        Respuesta = false
                    }
                );

            var search_group = ctx.Tbl_Grupos
                        .Where(w => w.id == Data.Id).FirstOrDefault();

            if (search_group == null)
                return JsonConvert.SerializeObject(
                    new OutJsonCheck
                    {
                        Status = 404,
                        Respuesta = false
                    }
                );

            objetcQuery = new QueryGroup(Data);
            return objetcQuery.Query(3, ctx);
        }
    }

    public class ReadGroupImp : IReadGroup
    {
        private DataModels ctx;
        private ReadGroupImp()
        {
            ctx = new DataModels();
        }

        public List<ViewModelGroup> ReadGroup(int Id)
        {
            throw new NotImplementedException();
        }
    }

    public class ReadAllGroupImp : IReadAllGroup
    {
        private DataModels ctx;
        private ReadAllGroupImp()
        {
            ctx = new DataModels();
        }

        public List<ViewModelGroup> ReadAllGroup()
        {
            throw new NotImplementedException();
        }
    }
}
