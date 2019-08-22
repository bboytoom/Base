using Administrator.Manager;
using NUnit.Framework;
using System;

namespace Administrator.Test
{
    public class Profile
    {
        [SetUp]
        public void Setup()
        {

        }

        #region Test de la funcion que verifica el password actual

        [Test]
        public void CheckPassEmpty()
        {
            ProfilesImp ObjPerfil = new ProfilesImp();

            Assert.Throws<ArgumentNullException>(delegate
            {
                ObjPerfil.Check(2, "");
            });
        }

        [Test]
        public void CheckIdNovalid()
        {
            ProfilesImp ObjPerfil = new ProfilesImp();

            Assert.Throws<ArgumentOutOfRangeException>(delegate
            {
                ObjPerfil.Check(0, "holamundo");
            });
        }

        [Test]
        public void CheckSuccess()
        {
            ProfilesImp ObjPerfil = new ProfilesImp();

            Assert.IsTrue(ObjPerfil.Check(2, "prueba123"));
        }

        #endregion

        #region Test de la funcion para realizar el cambio del correo

        [Test]
        public void ChangeEmailEmpty()
        {
            ProfilesImp ObjPerfil = new ProfilesImp();

            Assert.Throws<ArgumentNullException>(delegate
            {
                ObjPerfil.ChangeEmail(2, "");
            });
        }

        [Test]
        public void ChangeEmailNoValid()
        {
            ProfilesImp ObjPerfil = new ProfilesImp();

            Assert.Throws<ArgumentOutOfRangeException>(delegate
            {
                ObjPerfil.ChangeEmail(2, "admin.com");
            });
        }

        [Test]
        public void ChangeIdNull()
        {
            ProfilesImp ObjPerfil = new ProfilesImp();

            Assert.Throws<ArgumentOutOfRangeException>(delegate
            {
                ObjPerfil.ChangeEmail(0, "admin@correo.com");
            });
        }

        [Test]
        public void ChangeSuccess()
        {
            ProfilesImp ObjPerfil = new ProfilesImp();

            Assert.IsTrue(ObjPerfil.ChangeEmail(2, "admin@correo.com"));
        }

        #endregion

        #region Test de la funcion para realizar el cambio del passsword

        [Test]
        public void ChangePassEmpty()
        {
            ProfilesImp ObjPerfil = new ProfilesImp();

            Assert.Throws<ArgumentNullException>(delegate
            {
                ObjPerfil.ChangePassword(2, "");
            });
        }

        [Test]
        public void ChangePassIdNull()
        {
            ProfilesImp ObjPerfil = new ProfilesImp();

            Assert.Throws<ArgumentOutOfRangeException>(delegate
            {
                ObjPerfil.ChangePassword(0, "prueba123");
            });
        }

        [Test]
        public void ChangePassSuccess()
        {
            ProfilesImp ObjPerfil = new ProfilesImp();

            Assert.IsTrue(ObjPerfil.ChangePassword(2, "prueba123"));
        }

        #endregion
    }
}
