using Administrator.Contract;
using Administrator.Database;
using Administrator.Query.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Administrator.Query
{
    #region ABC de la clase Group

    public class Groups_UserImp : IOperations<ViewModelGroupUser, ViewModelReadGroup>
    {
        private Configuration _connect;
        public Groups_UserImp()
        {
            _connect = Configuration.Ctx();
        }

        public bool Create(ViewModelGroupUser data, int hieghUser, int main)
        {
            try
            {
                var create_group = new Tbl_Groups
                {
                    Id = data.Id,
                    Id_main = main,
                    Group = data.Group,
                    Description = data.Description,
                    Status = true,
                    Generate_user = hieghUser,
                    Generate_date = DateTime.Now
                };

                _connect.getConexion.Tbl_Groups.Add(create_group);
                _connect.getConexion.SaveChanges();

                Permission_UserImp.Create(data);

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Delete(int id, int hieghUser)
        {
            try
            {
                var search_group = _connect.getConexion.Tbl_Groups.Find(id);

                var delete_group = new Tbl_Groups
                {
                    Id = search_group.Id,
                    Id_main = search_group.Id_main,
                    Group = search_group.Group,
                    Description = search_group.Description,
                    Status = false,
                    Generate_user = search_group.Generate_user,
                    Generate_date = search_group.Generate_date,
                    Remove_user = hieghUser,
                    Remove_date = DateTime.Now,
                    Remove_status = true
                };

                _connect.getConexion.Entry(search_group).CurrentValues.SetValues(delete_group);
                _connect.getConexion.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ViewModelGroupUser Read(int id)
        {
            ViewModelGroupUser result = _connect.getConexion.Tbl_Groups.Where(w => w.Id.Equals(id))
                    .Select(s => new ViewModelGroupUser
                    {
                        Id = s.Id,
                        Group = s.Group,
                        Description = s.Description,
                        Status = s.Status
                    }).FirstOrDefault();

            return result;
        }

        public IEnumerable<ViewModelReadGroup> ReadAll(int id_main)
        {
            IEnumerable<ViewModelReadGroup> result = _connect.getConexion
                .Tbl_Groups.Where(w => w.Id_main.Equals(id_main))
                .Select(s => new ViewModelReadGroup
                {
                    Id = s.Id,
                    Group = s.Group,
                    Description = s.Description,
                    Status = s.Status
                }).ToList();

            return result;
        }

        public bool Update(ViewModelGroupUser data, int hieghUser)
        {
            try
            {
                var search_group = _connect.getConexion.Tbl_Groups.Find(data.Id);

                var update_group = new Tbl_Groups
                {
                    Id = data.Id,
                    Id_main = search_group.Id_main,
                    Group = data.Group,
                    Description = data.Description,
                    Status = data.Status,
                    Generate_user = search_group.Generate_user,
                    Generate_date = search_group.Generate_date,
                    Edit_user = hieghUser,
                    Edit_date = DateTime.Now
                };

                _connect.getConexion.Entry(search_group).CurrentValues.SetValues(update_group);
                _connect.getConexion.SaveChanges();

                Permission_UserImp.Update(data);

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

    #endregion
}