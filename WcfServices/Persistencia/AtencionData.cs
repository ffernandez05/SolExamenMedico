using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace WcfServices.Persistencia
{
    public class AtencionData
    {
        private readonly string _connectionString;
        public AtencionData()
        {
            _connectionString = "Data Source=localhost;Integrated Security=SSPI;Initial Catalog=DSD";
        }

        public Atencion Crear(Atencion AtencionACrear)
        {
            Atencion nuevoAtencion = null;
            string sql = "INSERT INTO t_Atencion VALUES (@dni, @fecha, @estado)";
            using (SqlConnection conexion = new SqlConnection(_connectionString))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@dni", AtencionACrear.Dni.Trim()));
                    comando.Parameters.Add(new SqlParameter("@fecha", AtencionACrear.Fecha.Trim()));
                    comando.Parameters.Add(new SqlParameter("@estado", AtencionACrear.Estado.Trim()));                    
                    comando.ExecuteNonQuery();
                }
            }
            nuevoAtencion = Obtener(AtencionACrear.Dni);
            return AtencionACrear;
        }

        public Atencion Obtener(string dni)
        {
            Atencion AtencionEncontrado = null;
            string sql = "SELECT * FROM t_Atencion WHERE dni=@dni";
            using (SqlConnection conexion = new SqlConnection(_connectionString))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@dni", dni));
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            AtencionEncontrado = new Atencion()
                            {
                                Dni = (string)resultado["dni"],
                                Fecha = (string)resultado["fecha"],
                                Estado = (string)resultado["estado"]
                            };
                        }
                    }
                }
            }
            return AtencionEncontrado;
        }

        public Atencion Modificar(Atencion AtencionAModificar)
        {
            Atencion AtencionModificado = null;
            string sql = "UPDATE t_Atencion SET fecha=@fecha,estado=@estado WHERE dni=@dni";
            using (SqlConnection conexion = new SqlConnection(_connectionString))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@dni", AtencionAModificar.Dni.Trim()));
                    comando.Parameters.Add(new SqlParameter("@fecha", AtencionAModificar.Fecha.Trim()));
                    comando.Parameters.Add(new SqlParameter("@estado", AtencionAModificar.Estado.Trim()));
                    comando.ExecuteNonQuery();
                }
            }
            AtencionModificado = Obtener(AtencionAModificar.Dni);
            return AtencionModificado;
        }

        public void Eliminar(string dni)
        {
            string sql = "DELETE FROM t_Atencion WHERE dni=@dni";
            using (SqlConnection conex = new SqlConnection(_connectionString))
            {
                conex.Open();
                using (SqlCommand comando = new SqlCommand(sql, conex))
                {
                    comando.Parameters.Add(new SqlParameter("@dni", dni));
                    comando.ExecuteNonQuery();
                }
            }
        }

        public List<Atencion> Listar()
        {
            List<Atencion> AtencionsEncontrados = new List<Atencion>();
            Atencion AtencionEncontrado = null;
            string sql = "select * from t_Atencion";
            using (SqlConnection conex = new SqlConnection(_connectionString))
            {
                conex.Open();
                using (SqlCommand comando = new SqlCommand(sql, conex))
                {
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        while (resultado.Read())
                        {
                            AtencionEncontrado = new Atencion()
                            {
                                Dni= (string)resultado["Dni"],
                                Fecha = (string)resultado["Fecha"],
                                Estado = (string)resultado["Estado"]
                            };
                            AtencionsEncontrados.Add(AtencionEncontrado);
                        }
                    }
                }
            }
            return AtencionsEncontrados;
        }

    }
}