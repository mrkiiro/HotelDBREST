using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using ModelLib.model;

namespace HotelDBREST.DBUtil
{
    public class ManageFacilitet : IManage<Facilitet>
    {
        private const String GET_ALL = "select * from Faciliteter";
        private const String GET_ONE = "select * from Faciliteter WHERE Faciliteter = @ID";
        private const String DELETE = "delete from Faciliteter WHERE Faciliteter = @ID";
        private const String INSERT = "insert into Faciliteter values (@Name)";
        private const String UPDATE = "update Faciliteter " +
                                      "SET Navn = @Name " +
                                      "WHERE Faciliteter = @ID";

        protected Facilitet ReadNextElement(SqlDataReader reader)
        {
            Facilitet f = new Facilitet();

            f.Faciliteter = reader.GetInt32(0);
            f.Navn = reader.GetString(1);

            return f;
        }

        public IEnumerable<Facilitet> Get()
        {
            List<Facilitet> liste = new List<Facilitet>();

            SqlCommand cmd = new SqlCommand(GET_ALL, SQLConnectionSingleton.Instance.DbConnection);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Facilitet f = ReadNextElement(reader);
                liste.Add(f);
            }
            reader.Close();

            return liste;
        }

        public Facilitet Get(int id)
        {
            Facilitet f = null;

            SqlCommand cmd = new SqlCommand(GET_ONE, SQLConnectionSingleton.Instance.DbConnection);
            cmd.Parameters.AddWithValue("@ID", id);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                f = ReadNextElement(reader);
            }
            reader.Close();

            return f;
        }

        public bool Post(Facilitet elem)
        {
            SqlCommand cmd = new SqlCommand(INSERT, SQLConnectionSingleton.Instance.DbConnection);
            cmd.Parameters.AddWithValue("@Name", elem.Navn);

            int noOfRows = cmd.ExecuteNonQuery();

            return noOfRows == 1;
        }

        public bool Put(int id, Facilitet elem)
        {
            SqlCommand cmd = new SqlCommand(UPDATE, SQLConnectionSingleton.Instance.DbConnection);
            cmd.Parameters.AddWithValue("@Name", elem.Navn);
            cmd.Parameters.AddWithValue("@ID", id);

            int noOfRows = cmd.ExecuteNonQuery();

            return noOfRows == 1;
        }

        public bool Delete(int id)
        {
            SqlCommand cmd = new SqlCommand(DELETE, SQLConnectionSingleton.Instance.DbConnection);
            cmd.Parameters.AddWithValue("@ID", id);

            int noOfRows = cmd.ExecuteNonQuery();

            return noOfRows == 1;
        }
    }
}