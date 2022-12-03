using MySql.Data.MySqlClient;
using Noviembre.Core.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Noviembre.Core.Entidades
{
    internal class Modulo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public string Direccion { get; set; }
        public string Horario { get; set; }
        public string Referencias { get; set; }

        public Municipio Municipio { get; set; }

        public static List<Modulo> GetAll()
        {
            List<Modulo> modulos = new List<Modulo>();


            return modulos;
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    string query = "SELECT mo.id, mo.nombre, mo.direccion, mo.horario, mo.referencias as modulo, mu.nombre as municipio\r\nFROM modulo mo INNER JOIN municipio mu ON mo.idMunicipio = mu.id;";
                    MySqlCommand command = new MySqlCommand(query, conexion.connection);

                    MySqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Modulo modulo = new Modulo();
                        modulo.Id = int.Parse(dataReader["id"].ToString());
                        modulo.Nombre = dataReader["nombre"].ToString();
                        modulo.Horario = dataReader["horario"].ToString();
                        modulo.Nombre = dataReader["referencia"].ToString();
                        Municipio municipio = new Municipio();
                        municipio.Nombre = dataReader["municipio"].ToString();
                        modulo.Municipio = municipio;


                        modulos.Add(modulo);
                    }
                    dataReader.Close();
                    conexion.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
