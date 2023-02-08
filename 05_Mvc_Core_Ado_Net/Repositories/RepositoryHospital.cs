using System.Data;
using System.Data.SqlClient;
using _05_Mvc_Core_Ado_Net.Models;

namespace _05_Mvc_Core_Ado_Net.Repositories
{
    public class RepositoryHospital
    {

        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader reader;

        public RepositoryHospital()
        {
            string connectionString = @"Data Source=LOCALHOST\DESARROLLO;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=sa;Password=MCSD2022";

            this.connection = new SqlConnection(connectionString);
            this.command = new SqlCommand();
            this.command.Connection = this.connection;
        }

        public List<Hospital> GetHospitales()
        {
            string consulta = "SELECT * FROM HOSPITAL";
            this.command.CommandType = CommandType.Text;
            this.command.CommandText = consulta;

            this.connection.Open();
            this.reader = this.command.ExecuteReader();

            List<Hospital> hospitales = new List<Hospital>();

            while(this.reader.Read())
            {
                Hospital hospital = new Hospital();
                hospital.IdHospital = int.Parse(reader["HOSPITAL_COD"].ToString());
                hospital.Nombre = reader["NOMBRE"].ToString();
                hospital.Direccion = reader["DIRECCION"].ToString();
                hospital.Telefono = reader["TELEFONO"].ToString();
                hospital.Camas = int.Parse(reader["NUM_CAMA"].ToString());

                hospitales.Add(hospital);
            }

            this.connection.Close();
            this.reader.Close();

            return hospitales;
        }

        public Hospital FindHospital(int idHospital)
        {
            string consulta = "SELECT * FROM HOSPITAL WHERE HOSPITAL_COD = @IDHOSPITAL";
            SqlParameter paramId = new SqlParameter("@IDHOSPITAL", idHospital);
            this.command.Parameters.Add(paramId);

            this.command.CommandType = CommandType.Text;
            this.command.CommandText = consulta;

            this.connection.Open();
            this.reader = this.command.ExecuteReader();

            Hospital hospital = new Hospital();

            this.reader.Read();

            hospital.IdHospital = int.Parse(reader["HOSPITAL_COD"].ToString());
            hospital.Nombre = reader["NOMBRE"].ToString();
            hospital.Direccion = reader["DIRECCION"].ToString();
            hospital.Telefono = reader["TELEFONO"].ToString();
            hospital.Camas = int.Parse(reader["NUM_CAMA"].ToString());

            this.connection.Close();
            this.reader.Close();
            this.command.Parameters.Clear();

            return hospital;
        }

        public void CreateHospital(int idHospital, string nombre, string direccion, string telefono, int camas)
        {
            string consulta = "INSERT INTO HOSPITAL VALUES (@ID, @NOMBRE, @DIRECCION, @TELEFONO, @CAMAS)";

            this.command.Parameters.AddWithValue("@ID", idHospital);
            this.command.Parameters.AddWithValue("@NOMBRE", nombre);
            this.command.Parameters.AddWithValue("@DIRECCION", direccion);
            this.command.Parameters.AddWithValue("@TELEFONO", telefono);
            this.command.Parameters.AddWithValue("@CAMAS", camas);

            this.command.CommandType = CommandType.Text;
            this.command.CommandText = consulta;

            this.connection.Open();
            this.command.ExecuteNonQuery();

            this.connection.Close();
            this.command.Parameters.Clear();
        }

    }
}
