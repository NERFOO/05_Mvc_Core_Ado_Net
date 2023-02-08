using _05_Mvc_Core_Ado_Net.Models;
using System.Data;
using System.Data.SqlClient;

namespace _05_Mvc_Core_Ado_Net.Repositories
{
    public class RepositoryDoctor
    {

        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader reader;

        public RepositoryDoctor()
        {
            string connectionString = @"Data Source=LOCALHOST\DESARROLLO;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=sa;Password=MCSD2022";

            this.connection = new SqlConnection(connectionString);
            this.command = new SqlCommand();
            this.command.Connection = this.connection;
        }

        public List<Doctor> GetDoctores()
        {
            string consulta = "SELECT * FROM DOCTOR";
            this.command.CommandType = CommandType.Text;
            this.command.CommandText = consulta;

            this.connection.Open();
            this.reader = this.command.ExecuteReader();

            List<Doctor> doctores = new List<Doctor>();

            while (this.reader.Read())
            {
                Doctor doctor = new Doctor();
                doctor.HospitalCod = reader["HOSPITAL_COD"].ToString();
                doctor.NumDoctor = reader["DOCTOR_NO"].ToString();
                doctor.Apellido = reader["APELLIDO"].ToString();
                doctor.Especialidad= reader["ESPECIALIDAD"].ToString();
                doctor.Salario = int.Parse(reader["SALARIO"].ToString());

                doctores.Add(doctor);
            }

            this.connection.Close();
            this.reader.Close();

            return doctores;
        }

        public List<Doctor> GetDoctores(string especialidad)
        {
            string consulta = "SELECT * FROM DOCTOR WHERE ESPECIALIDAD = @ESPECIALIDAD";

            this.command.Parameters.AddWithValue("@ESPECIALIDAD", especialidad);

            this.command.CommandType = CommandType.Text;
            this.command.CommandText = consulta;

            this.connection.Open();
            this.reader = this.command.ExecuteReader();

            List<Doctor> doctores = new List<Doctor>();

            while (this.reader.Read())
            {
                Doctor doctor = new Doctor();
                doctor.HospitalCod = reader["HOSPITAL_COD"].ToString();
                doctor.NumDoctor = reader["DOCTOR_NO"].ToString();
                doctor.Apellido = reader["APELLIDO"].ToString();
                doctor.Especialidad = reader["ESPECIALIDAD"].ToString();
                doctor.Salario = int.Parse(reader["SALARIO"].ToString());

                doctores.Add(doctor);
            }

            this.connection.Close();
            this.reader.Close();
            this.command.Parameters.Clear();

            return doctores;
        }

        public List<Doctor> GetDoctores(int idHospital)
        {
            string consulta = "SELECT * FROM DOCTOR WHERE HOSPITAL_COD = @IDHOSPITAL";

            this.command.Parameters.AddWithValue("@IDHOSPITAL", idHospital);

            this.command.CommandType = CommandType.Text;
            this.command.CommandText = consulta;

            this.connection.Open();
            this.reader = this.command.ExecuteReader();

            List<Doctor> doctores = new List<Doctor>();

            while (this.reader.Read())
            {
                Doctor doctor = new Doctor();
                doctor.HospitalCod = reader["HOSPITAL_COD"].ToString();
                doctor.NumDoctor = reader["DOCTOR_NO"].ToString();
                doctor.Apellido = reader["APELLIDO"].ToString();
                doctor.Especialidad = reader["ESPECIALIDAD"].ToString();
                doctor.Salario = int.Parse(reader["SALARIO"].ToString());

                doctores.Add(doctor);
            }

            this.connection.Close();
            this.reader.Close();
            this.command.Parameters.Clear();

            return doctores;
        }

        public List<string> GetEspecialidades()
        {
            string consulta = "SELECT DISTINCT ESPECIALIDAD FROM DOCTOR";

            this.command.CommandType = CommandType.Text;
            this.command.CommandText = consulta;

            this.connection.Open();
            this.reader = this.command.ExecuteReader();

            List<string> especialidades = new List<string>();

            while (this.reader.Read())
            {
                string especialidad = reader["ESPECIALIDAD"].ToString();

                especialidades.Add(especialidad);
            }

            this.connection.Close();
            this.reader.Close();

            return especialidades;
        }

        public List<string> GetHospitales()
        {
            string consulta = "SELECT DISTINCT HOSPITAL.HOSPITAL_COD, NOMBRE FROM HOSPITAL INNER JOIN DOCTOR ON HOSPITAL.HOSPITAL_COD = DOCTOR.HOSPITAL_COD";

            this.command.CommandType = CommandType.Text;
            this.command.CommandText = consulta;

            this.connection.Open();
            this.reader = this.command.ExecuteReader();

            List<string> idHospitales = new List<string>();

            while (this.reader.Read())
            {
                string especialidad = reader["ESPECIALIDAD"].ToString();

                especialidades.Add(especialidad);
            }

            this.connection.Close();
            this.reader.Close();

            return especialidades;
        }
    }
}
