using Administrator.Contract;
using Administrator.Database;
using Administrator.Query.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Administrator.Query
{
    public class Groups_RootImp : IOperations<ViewModelGroupRoot, ViewModelReadGroup>
    {
        private Configuration _connect;

        public Groups_RootImp()
        {
            _connect = Configuration.Ctx();
        }

        public bool Create(ViewModelGroupRoot data, int hieghUser, int main)
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

                Permission_RootImp.Create(data);

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

        public ViewModelGroupRoot Read(int id)
        {
            ViewModelGroupRoot result = _connect.getConexion.Tbl_Groups.Where(w => w.Id.Equals(id))
                    .Select(s => new ViewModelGroupRoot
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

        public bool Update(ViewModelGroupRoot data, int hieghUser)
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

                Permission_RootImp.Update(data);

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
