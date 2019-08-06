using System;

namespace Administrator.Data
{
    public class Configuration
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
            ((IDisposable)conexion).Dispose();
        }
    }
}
