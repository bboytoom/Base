using System;
using Administrator.Contract;
using Administrator.Manager;
using NUnit.Framework;

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
        public void LoginUser()
        {
            Authentication ObjTestAuth = new Authentication();

            int id = 1;
            int main = 1;

            ViewModelClaims actual = new ViewModelClaims
            {
                Identificador = id.ToString(),
                Email = "soyroot@hotmail.es",
                Fullname = "soy root",
                MainUser = main.ToString(),
                TypeUser = 1
            };

            ViewModelClaims expectativa = ObjTestAuth.Login("soyroot@hotmail.es", "@Holamundo");
            Assert.Equals(actual, expectativa);
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
            string correo = "soyroot@hotmail.es";

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
                Assert.IsFalse(ObjTestAuth.ValidAttemps("novalido@hotmail.com"));
            }

            Assert.IsTrue(ObjTestAuth.ValidAttemps("prueba@hotmail.com"));
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

            for (int i = 0; i <= 3; i++)
            {
                Assert.IsFalse(ObjTestAuth.ValidCycle("novalido@hotmail.com"));
            }

            Assert.IsTrue(ObjTestAuth.ValidCycle("prueba@hotmail.com"));
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

            Assert.IsTrue(ObjTestAuth.ValidResetAttemp("prueba@hotmail.com"));
        }

        #endregion

    }
}