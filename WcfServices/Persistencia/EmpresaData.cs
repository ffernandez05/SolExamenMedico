using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WcfServices.Persistencia
{
    public class EmpresaData
    {
        private readonly string _connectionString;

        public EmpresaData()
        {
            _connectionString = "Data Source=localhost;Integrated Security=SSPI;Initial Catalog=DSD";
        }

        public Empresa Crear(Empresa empresaACrear)
        {
            Empresa nuevoEmpresa = null;
            string sql = "INSERT INTO t_Empresa VALUES (@nombre, @direccion, @telefono, @ruc,@estado)";
            using (SqlConnection conexion = new SqlConnection(_connectionString))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@nombre", empresaACrear.Nombre.Trim()));
                    comando.Parameters.Add(new SqlParameter("@direccion", empresaACrear.Direccion.Trim()));
                    comando.Parameters.Add(new SqlParameter("@telefono", empresaACrear.Telefono.Trim()));
                    comando.Parameters.Add(new SqlParameter("@ruc", empresaACrear.RUC.Trim()));
                    comando.Parameters.Add(new SqlParameter("@estado", empresaACrear.Estado.Trim()));
                    comando.ExecuteNonQuery();
                }
            }
            nuevoEmpresa = Obtener(empresaACrear.Nombre);
            return empresaACrear;
        }

        public Empresa Obtener(string nombre)
        {
            Empresa empresaEncontrado = null;
            string sql = "SELECT * FROM t_empresa WHERE nombre=@nombre";
            using (SqlConnection conexion = new SqlConnection(_connectionString))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@nombre", nombre));
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            empresaEncontrado = new Empresa()
                            {
                                Nombre = (string)resultado["Nombre"],
                                Direccion = (string)resultado["Direccion"],
                                Telefono = (string)resultado["Telefono"],
                                RUC = (string)resultado["RUC"],
                                Estado = (string)resultado["Estado"]
                            };
                        }
                    }
                }
            }
            return empresaEncontrado;
        }

        public Empresa Modificar(Empresa empresaAModificar)
        {
            Empresa empresaModificado = null;
            string sql = "UPDATE t_empresa SET Direccion=@Direccion,Telefono=@Telefono,RUC=@RUC, estado=@estado WHERE nombre=@nombre";
            using (SqlConnection conexion = new SqlConnection(_connectionString))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@Nombre", empresaAModificar.Nombre.Trim()));
                    comando.Parameters.Add(new SqlParameter("@Direccion", empresaAModificar.Direccion.Trim()));
                    comando.Parameters.Add(new SqlParameter("@Telefono", empresaAModificar.Telefono.Trim()));
                    comando.Parameters.Add(new SqlParameter("@RUC", empresaAModificar.RUC.Trim()));
                    comando.Parameters.Add(new SqlParameter("@estado", empresaAModificar.Estado.Trim()));
                    comando.ExecuteNonQuery();
                }
            }
            empresaModificado = Obtener(empresaAModificar.Nombre);
            return empresaModificado;
        }

        public void Eliminar(string nombre)
        {
            string sql = "DELETE FROM t_empresa WHERE nombre=@nombre";
            using (SqlConnection conex = new SqlConnection(_connectionString))
            {
                conex.Open();
                using (SqlCommand comando = new SqlCommand(sql, conex))
                {
                    comando.Parameters.Add(new SqlParameter("@nombre", nombre));
                    comando.ExecuteNonQuery();
                }
            }
        }

        public List<Empresa> Listar()
        {
            List<Empresa> empresasEncontrados = new List<Empresa>();
            Empresa empresaEncontrado = null;
            string sql = "select * from t_empresa";
            using (SqlConnection conex = new SqlConnection(_connectionString))
            {
                conex.Open();
                using (SqlCommand comando = new SqlCommand(sql, conex))
                {
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        while (resultado.Read())
                        {
                            empresaEncontrado = new Empresa()
                            {
                                Nombre = (string)resultado["Nombre"],
                                Direccion = (string)resultado["Direccion"],
                                Telefono = (string)resultado["Telefono"],
                                RUC = (string)resultado["RUC"],
                                Estado = (string)resultado["Estado"]
                            };
                            empresasEncontrados.Add(empresaEncontrado);
                        }
                    }
                }
            }
            return empresasEncontrados;
        }

    }
}