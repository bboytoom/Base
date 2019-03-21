using GestionUsuarios.Data;
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
        public string CreateGroup(ViewModelGroup Data)
        {
            if (Data.Name == "" || Data.HighUser == 0)
                return JsonConvert.SerializeObject(
                    new OutJsonCheck
                    {
                        Status = 404,
                        Respuesta = false
                    }
                );
            
            using (DataModels ctx = new DataModels())
            {
                string nameClean = WebUtility.HtmlEncode(Data.Name.ToLower());
                string descriptionClean = WebUtility.HtmlEncode(Data.Description);

                try
                {
                    ctx.Database.ExecuteSqlCommand("EXECUTE STR_CRUDGROUP @token, @idgrupo, @name, @description, " +
                        "@readuser, @createuser, @updateuser, @deleteuser," +
                        "@readgroup, @creategroup, @updategroup, @deletegroup, " +
                        "@readpermission, @createpermission, @updatepermission, @deletepermission," +
                        "@reademail, @createemail, @updateemail, @deleteemail, " +
                        "@status, @highUser",
                        new SqlParameter("token", 1),
                        new SqlParameter("idgrupo", Data.Id),
                        new SqlParameter("name", nameClean),
                        new SqlParameter("description", descriptionClean),
                        new SqlParameter("readuser", Data.Readuser),
                        new SqlParameter("createuser", Data.Createuser),
                        new SqlParameter("updateuser", Data.Updateuser),
                        new SqlParameter("deleteuser", Data.Deleteuser),
                        new SqlParameter("readgroup", Data.Readgroup),
                        new SqlParameter("creategroup", Data.Creategroup),
                        new SqlParameter("updategroup", Data.Updategroup),
                        new SqlParameter("deletegroup", Data.Deletegroup),
                        new SqlParameter("readpermission", Data.Readpermission),
                        new SqlParameter("createpermission", Data.Createpermission),
                        new SqlParameter("updatepermission", Data.Updatepermission),
                        new SqlParameter("deletepermission", Data.Deletepermission),
                        new SqlParameter("reademail", Data.Reademail),
                        new SqlParameter("createemail", Data.Createemail),
                        new SqlParameter("updateemail", Data.Updateemail),
                        new SqlParameter("deleteemail", Data.Deleteemail),
                        new SqlParameter("status", Data.Status),
                        new SqlParameter("highUser", Data.HighUser)
                    );

                    return JsonConvert.SerializeObject(
                        new OutJsonCheck
                        {
                            Status = 200,
                            Respuesta = true
                        }
                    );
                }
                catch (Exception)
                {
                    throw;
                }   
            }          
        }
    }

    public class UpdateGroupImp : IUpdateGroup
    {
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

            using (DataModels ctx = new DataModels())
            {
                string nameClean = WebUtility.HtmlEncode(Data.Name.ToLower());
                string descriptionClean = WebUtility.HtmlEncode(Data.Description);

                try
                {
                    ctx.Database.ExecuteSqlCommand("EXECUTE STR_CRUDGROUP @token, @idgrupo, @name, @description, " +
                        "@readuser, @createuser, @updateuser, @deleteuser," +
                        "@readgroup, @creategroup, @updategroup, @deletegroup, " +
                        "@readpermission, @createpermission, @updatepermission, @deletepermission," +
                        "@reademail, @createemail, @updateemail, @deleteemail, " +
                        "@status, @highUser",
                        new SqlParameter("token", 2),
                        new SqlParameter("idgrupo", Data.Id),
                        new SqlParameter("name", nameClean),
                        new SqlParameter("description", descriptionClean),
                        new SqlParameter("readuser", Data.Readuser),
                        new SqlParameter("createuser", Data.Createuser),
                        new SqlParameter("updateuser", Data.Updateuser),
                        new SqlParameter("deleteuser", Data.Deleteuser),
                        new SqlParameter("readgroup", Data.Readgroup),
                        new SqlParameter("creategroup", Data.Creategroup),
                        new SqlParameter("updategroup", Data.Updategroup),
                        new SqlParameter("deletegroup", Data.Deletegroup),
                        new SqlParameter("readpermission", Data.Readpermission),
                        new SqlParameter("createpermission", Data.Createpermission),
                        new SqlParameter("updatepermission", Data.Updatepermission),
                        new SqlParameter("deletepermission", Data.Deletepermission),
                        new SqlParameter("reademail", Data.Reademail),
                        new SqlParameter("createemail", Data.Createemail),
                        new SqlParameter("updateemail", Data.Updateemail),
                        new SqlParameter("deleteemail", Data.Deleteemail),
                        new SqlParameter("status", Data.Status),
                        new SqlParameter("highUser", Data.HighUser)
                    );

                    return JsonConvert.SerializeObject(
                        new OutJsonCheck
                        {
                            Status = 200,
                            Respuesta = true
                        }
                    );
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }

    public class DeleteGroupImp : IDeleteGroup
    {
        public string DeleteGroup(int Id, int HighUser)
        {
            if (Id == 0 || HighUser == 0)
                return JsonConvert.SerializeObject(
                    new OutJsonCheck
                    {
                        Status = 404,
                        Respuesta = false
                    }
                );

            using (DataModels ctx = new DataModels())
            {
                try
                {
                    ctx.Database.ExecuteSqlCommand("EXECUTE STR_CRUDGROUP @token, @idgrupo, @name, @description, " +
                        "@readuser, @createuser, @updateuser, @deleteuser," +
                        "@readgroup, @creategroup, @updategroup, @deletegroup, " +
                        "@readpermission, @createpermission, @updatepermission, @deletepermission," +
                        "@reademail, @createemail, @updateemail, @deleteemail, " +
                        "@status, @highUser",
                        new SqlParameter("token", 3),
                        new SqlParameter("idgrupo", Id),
                        new SqlParameter("name", false),
                        new SqlParameter("description", false),
                        new SqlParameter("readuser", false),
                        new SqlParameter("createuser", false),
                        new SqlParameter("updateuser", false),
                        new SqlParameter("deleteuser", false),
                        new SqlParameter("readgroup", false),
                        new SqlParameter("creategroup", false),
                        new SqlParameter("updategroup", false),
                        new SqlParameter("deletegroup", false),
                        new SqlParameter("readpermission", false),
                        new SqlParameter("createpermission", false),
                        new SqlParameter("updatepermission", false),
                        new SqlParameter("deletepermission", false),
                        new SqlParameter("reademail", false),
                        new SqlParameter("createemail", false),
                        new SqlParameter("updateemail", false),
                        new SqlParameter("deleteemail", false),
                        new SqlParameter("status", false),
                        new SqlParameter("highUser", HighUser)
                    );

                    return JsonConvert.SerializeObject(
                        new OutJsonCheck
                        {
                            Status = 200,
                            Respuesta = true
                        }
                    );
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }

    public class ReadGroupImp : IReadGroup
    {
        public List<ViewModelGroup> ReadGroup(int Id)
        {
            using (DataModels ctx = new DataModels())
            {
                try
                {
                    throw new NotImplementedException();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }

    public class ReadAllGroupImp : IReadAllGroup
    {
        public List<ViewModelGroup> ReadAllGroup()
        {
            using (DataModels ctx = new DataModels())
            {
                try
                {
                    throw new NotImplementedException();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
