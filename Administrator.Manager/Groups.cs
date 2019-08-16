using Administrator.Contract;
using Administrator.Query;
using System;
using System.Collections.Generic;

namespace Administrator.Manager
{
    public class Groups
    {
        private GroupsImp _ObjGroup;

        public Groups()
        {
            _ObjGroup = new GroupsImp();
        }

        public bool Create(ViewModelGroup data, int hieghUser, int main)
        {
            if (hieghUser == 0 && main == 0)
                throw new ArgumentOutOfRangeException("hieghUser", "La funcion tiene un valor no permitido");

            if (string.IsNullOrEmpty(data.Group))
                throw new ArgumentNullException(data.Group);

            return _ObjGroup.Create(data, hieghUser, main);
        }

        public bool Delete(int id, int hieghUser)
        {
            if (id == 0 && hieghUser == 0)
                throw new ArgumentOutOfRangeException("id, hieghUser", "La funcion tiene un valor no permitido");

            return _ObjGroup.Delete(id, hieghUser);
        }

        public ViewModelGroup Read(int id)
        {
            if (id == 0)
                throw new ArgumentOutOfRangeException("id", "La funcion tiene un valor no permitido");

            return _ObjGroup.Read(id);
        }

        public IEnumerable<ViewModelReadGroup> ReadAll(int id_main)
        {
            if (id_main == 0)
                throw new ArgumentOutOfRangeException("id_main", "La funcion tiene un valor no permitido");

            return _ObjGroup.ReadAll(id_main);
        }

        public bool Update(ViewModelGroup data, int hieghUser)
        {
            if (hieghUser == 0 && data.Id == 0)
                throw new ArgumentOutOfRangeException("hieghUser", "La funcion tiene un valor no permitido");

            if (string.IsNullOrEmpty(data.Group))
                throw new ArgumentNullException(data.Group);

            return _ObjGroup.Update(data, hieghUser);
        }
    }
}