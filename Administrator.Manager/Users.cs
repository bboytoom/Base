using System;
using System.Collections.Generic;
using Administrator.Contract;
using Administrator.Query;

namespace Administrator.Manager
{
    public class Users
    {
        private UsersImp _ObjUser;

        public Users()
        {
            _ObjUser = new UsersImp();
        }

        public bool Create(ViewModelUser data, int hieghUser, int main)
        {
            if (hieghUser == 0 && main == 0)
                throw new ArgumentOutOfRangeException(nameof(hieghUser), "La funcion tiene un valor no permitido");

            if (string.IsNullOrEmpty(data.Email))
                throw new ArgumentNullException(data.Email);

            if (string.IsNullOrEmpty(data.Password))
                throw new ArgumentNullException(data.Password);

            if (string.IsNullOrEmpty(data.Name))
                throw new ArgumentNullException(data.Name);

            if (string.IsNullOrEmpty(data.Lnamep))
                throw new ArgumentNullException(data.Lnamep);

            return _ObjUser.Create(data, hieghUser, main);
        }

        public bool Delete(int id, int hieghUser)
        {
            if (id == 0)
                throw new ArgumentOutOfRangeException(nameof(id), "La funcion tiene un valor no permitido");

            if (hieghUser == 0)
                throw new ArgumentOutOfRangeException(nameof(hieghUser), "La funcion tiene un valor no permitido");

            return _ObjUser.Delete(id, hieghUser);
        }

        public ViewModelUser Read(int id)
        {
            if (id == 0)
                throw new ArgumentOutOfRangeException(nameof(id), "La funcion tiene un valor no permitido");

            return _ObjUser.Read(id);
        }

        public IEnumerable<ViewModelReadUser> ReadAll(int id_main)
        {
            if (id_main == 0)
                throw new ArgumentOutOfRangeException(nameof(id_main), "La funcion tiene un valor no permitido");

            return _ObjUser.ReadAll(id_main);
        }

        public bool Update(ViewModelUser data, int hieghUser)
        {
            if (hieghUser == 0 && data.Id == 0)
                throw new ArgumentOutOfRangeException(nameof(hieghUser), "La funcion tiene un valor no permitido");

            if (string.IsNullOrEmpty(data.Email))
                throw new ArgumentNullException(data.Email);

            if (string.IsNullOrEmpty(data.Password))
                throw new ArgumentNullException(data.Password);

            if (string.IsNullOrEmpty(data.Name))
                throw new ArgumentNullException(data.Name);

            if (string.IsNullOrEmpty(data.Lnamep))
                throw new ArgumentNullException(data.Lnamep);

            return _ObjUser.Update(data, hieghUser);
        }
    }
}
