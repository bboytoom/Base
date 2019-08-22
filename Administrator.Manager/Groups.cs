﻿using Administrator.Contract;
using Administrator.Query;
using System;
using System.Collections.Generic;

namespace Administrator.Manager
{
    public class Groups
    {
        private Groups_UserImp _ObjGroup;

        public Groups()
        {
            _ObjGroup = new Groups_UserImp();
        }

        public bool Create(ViewModelGroupUser data, int hieghUser, int main)
        {
            if (hieghUser == 0)
                throw new ArgumentOutOfRangeException(nameof(hieghUser), "La funcion tiene un valor no permitido");

            if (main == 0)
                throw new ArgumentOutOfRangeException(nameof(main), "La funcion tiene un valor no permitido");

            if (string.IsNullOrEmpty(data.Group))
                throw new ArgumentNullException(data.Group);

            return _ObjGroup.Create(data, hieghUser, main);
        }

        public bool Delete(int id, int hieghUser)
        {
            if (id == 0)
                throw new ArgumentOutOfRangeException(nameof(id), "La funcion tiene un valor no permitido");

            if (hieghUser == 0)
                throw new ArgumentOutOfRangeException(nameof(hieghUser), "La funcion tiene un valor no permitido");

            return _ObjGroup.Delete(id, hieghUser);
        }

        public ViewModelGroupUser Read(int id)
        {
            if (id == 0)
                throw new ArgumentOutOfRangeException(nameof(id), "La funcion tiene un valor no permitido");

            return _ObjGroup.Read(id);
        }

        public IEnumerable<ViewModelReadGroup> ReadAll(int id_main)
        {
            if (id_main == 0)
                throw new ArgumentOutOfRangeException(nameof(id_main), "La funcion tiene un valor no permitido");

            return _ObjGroup.ReadAll(id_main);
        }

        public bool Update(ViewModelGroupUser data, int hieghUser)
        {
            if (hieghUser == 0 && data.Id == 0)
                throw new ArgumentOutOfRangeException(nameof(hieghUser), "La funcion tiene un valor no permitido");

            if (string.IsNullOrEmpty(data.Group))
                throw new ArgumentNullException(data.Group);

            return _ObjGroup.Update(data, hieghUser);
        }
    }
}
