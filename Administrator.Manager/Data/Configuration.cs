using System;

namespace Administrator.Manager.Data
{
    public class Configuration : IDisposable
    {
        private static Configuration _Ctx = null;
        private DataModels conexion;

        private Configuration()
        {
            try
            {
                conexion = new DataModels();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataModels getConexion
        {
            get { return conexion; }
            set { conexion = value; }
        }

        public static Configuration Ctx()
        {
            if (_Ctx == null)
                _Ctx = new Configuration();

            return _Ctx;
        }

        public void Dispose()
        {
            _Ctx.Dispose();
        }
    }
}
