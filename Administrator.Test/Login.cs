using Administrator.Contract;
using Administrator.Manager;
using NUnit.Framework;
using System;

namespace Tests
{
    public class Login
    {
        [SetUp]
        public void Setup()
        {

        }

        #region Test de la funcion Login

        [Test]
        public void LoginEmailEmpty()
        {
            Authentication ObjTestAuth = new Authentication();

            Assert.Throws<ArgumentNullException>(delegate
            {
                ObjTestAuth.Login("", "holapassword");
            });
        }

        [Test]
        public void LoginEmailNovalid()
        {
            Authentication ObjTestAuth = new Authentication();

            Assert.Throws<ArgumentOutOfRangeException>(delegate
            {
                ObjTestAuth.Login("prueba.com", "holapassword");
            });
        }

        [Test]
        public void LoginPasswordEmpty()
        {
            Authentication ObjTestAuth = new Authentication();

            Assert.Throws<ArgumentNullException>(delegate
            {
                ObjTestAuth.Login("prueba@hotmail.es", "");
            });
        }

        [Test]
        public void LoginUserNoExist()
        {
            Authentication ObjTestAuth = new Authentication();

            ViewModelClaims expectativa = ObjTestAuth.Login("noexiste@hotmail.es", "holamundo");
            Assert.IsNull(expectativa);
        }

        [Test]
        public void LoginUser()
        {
            Authentication ObjTestAuth = new Authentication();

            ViewModelClaims expectativa = ObjTestAuth.Login("root@hotmail.es", "holamundo");
            Assert.IsNotNull(expectativa);
        }


        #endregion

        #region Test de la funcion CheckUser

        [Test]
        public void UserEmailEmpty()
        {
            Authentication ObjTestAuth = new Authentication();

            Assert.Throws<ArgumentNullException>(delegate
            {
                ObjTestAuth.CheckUser("");
            });
        }

        [Test]
        public void UserEmailNovalid()
        {
            Authentication ObjTestAuth = new Authentication();

            Assert.Throws<ArgumentOutOfRangeException>(delegate
            {
                ObjTestAuth.CheckUser("prueba.com");
            });
        }

        [Test]
        public void UserExistFail()
        {
            Authentication ObjTestAuth = new Authentication();
            string correo = "noexiste@hola.com";

            Assert.IsFalse(ObjTestAuth.CheckUser(correo));
        }

        public void UserExistSuccess()
        {
            Authentication ObjTestAuth = new Authentication();
            string correo = "administrador@hotmail.es";

            Assert.IsTrue(ObjTestAuth.CheckUser(correo));
        }

        #endregion

        #region Test de la funcion Attemps

        [Test]
        public void AttempEmailEmpty()
        {
            Authentication ObjTestAuth = new Authentication();

            Assert.Throws<ArgumentNullException>(delegate
            {
                ObjTestAuth.ValidAttemps("");
            });
        }

        [Test]
        public void AttempEmailNovalid()
        {
            Authentication ObjTestAuth = new Authentication();

            Assert.Throws<ArgumentOutOfRangeException>(delegate
            {
                ObjTestAuth.ValidAttemps("prueba.com");
            });
        }

        [Test]
        public void AttempInsert()
        {
            Authentication ObjTestAuth = new Authentication();

            for (int i = 0; i <= 2; i++)
            {
                ObjTestAuth.ValidAttemps("administrador@hotmail.es");
            }

            Assert.IsTrue(ObjTestAuth.ValidAttemps("administrador@hotmail.es"));
        }

        #endregion

        #region Test de la funcion Cycle

        [Test]
        public void CycleEmailEmpty()
        {
            Authentication ObjTestAuth = new Authentication();

            Assert.Throws<ArgumentNullException>(delegate
            {
                ObjTestAuth.ValidCycle("");
            });
        }

        [Test]
        public void CycleEmailNovalid()
        {
            Authentication ObjTestAuth = new Authentication();

            Assert.Throws<ArgumentOutOfRangeException>(delegate
            {
                ObjTestAuth.ValidCycle("prueba.com");
            });
        }

        [Test]
        public void CycleInsert()
        {
            Authentication ObjTestAuth = new Authentication();

            for (int i = 0; i <= 2; i++)
            {
                ObjTestAuth.ValidCycle("administrador@hotmail.es");
            }

            Assert.IsTrue(ObjTestAuth.ValidCycle("administrador@hotmail.es"));
        }

        #endregion

        #region Test de la funcion Reset Attemps

        [Test]
        public void ResetAttempEmailEmpty()
        {
            Authentication ObjTestAuth = new Authentication();

            Assert.Throws<ArgumentNullException>(delegate
            {
                ObjTestAuth.ValidResetAttemp("");
            });
        }

        [Test]
        public void ResetAttempEmailNovalid()
        {
            Authentication ObjTestAuth = new Authentication();

            Assert.Throws<ArgumentOutOfRangeException>(delegate
            {
                ObjTestAuth.ValidResetAttemp("prueba.com");
            });
        }

        [Test]
        public void ResetAttempInsert()
        {
            Authentication ObjTestAuth = new Authentication();

            Assert.IsTrue(ObjTestAuth.ValidResetAttemp("administrador@hotmail.es"));
        }

        #endregion

        #region Test de la bitacora de ingreso

        [Test]
        public void CreateLog()
        {
            Authentication ObjTestAuth = new Authentication();

            ViewModelEntryUser result = new ViewModelEntryUser
            {
                Id_user = 1,
                FullName = "soy root paterno materno",
                IP_User = "132.160.80.206",
                Browser = "Chrome 76.0.3809.100 en OS X 10.14.5 64-bit"
            };

            Assert.IsTrue(ObjTestAuth.CreateEntry(result));
        }

        #endregion
    }
}