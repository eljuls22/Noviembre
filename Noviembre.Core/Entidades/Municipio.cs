using MySql.Data.MySqlClient;
using Noviembre.Core.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noviembre.Core.Entidades
{
    public class Municipio
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public Estado Estado { get; set; }

        public static List<Municipio> GetAll()
        {
            List<Municipio> municipios = new List<Municipio>();
            try
            {
                Conexion conexion = new Conexion();
                if (conexion.OpenConnection())
                {
                    string query = "SELECT m.id, m.nombre as municipio, e.nombre as estado\r\nFROM municipio m INNER JOIN estado e ON m.idEstado = e.id;";
                    MySqlCommand command = new MySqlCommand(query, conexion.connection);

                    MySqlDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        Municipio municipio = new Municipio();
                        municipio.Id = int.Parse(dataReader["id"].ToString());
                        municipio.Nombre = dataReader["nombre"].ToString();
                        Estado estado = new Estado();
                        estado.Nombre = dataReader["estado"].ToString();
                        municipio.Estado = estado;


                        municipios.Add(municipio);
                    }
                    dataReader.Close();
                    conexion.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return municipios;
        }
        
    }
}
