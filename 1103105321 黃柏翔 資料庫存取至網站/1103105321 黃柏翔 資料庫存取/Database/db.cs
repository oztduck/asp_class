using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace database
{
   public class db
    { private const string _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\Desktop\asp_class-master\asp_class-master\1103105321 黃柏翔 資料庫存取\1103105321 黃柏翔 資料庫存取\Database\data\homework.mdf;Integrated Security=True";

        public void Creat(homework sb)
        {
            var connection = new System.Data.SqlClient.SqlConnection();
            connection.ConnectionString = _connectionString;
            connection.Open();

            var command = new System.Data.SqlClient.SqlCommand("", connection);
            command.CommandText = string.Format(@"

INSERT   INTO homework(name,address,openTime,phone)

VALUES        (N'{0}',N'{1}',N'{2}',N'{3}')

",sb.name.Replace("'","''") , sb.address ,sb.openTime,sb.phone);

            command.ExecuteNonQuery();

            connection.Close();
        }

        public List<homework> Readhomework()
        {
            var result = new List<homework>();

            var connection = new System.Data.SqlClient.SqlConnection();
            connection.ConnectionString = _connectionString;
            connection.Open();

            var command = new System.Data.SqlClient.SqlCommand("", connection);
            command.CommandText = string.Format(@"Select  *from homework");

            var reader_ = command.ExecuteReader();

            while (reader_.Read())
            {
                homework item = new homework();
                item.name = reader_["name"].ToString();
                item.address = reader_["address"].ToString();
                item.openTime = reader_["openTime"].ToString();
                item.phone = reader_["phone"].ToString();

                result.Add(item);
            }
            connection.Close();
            return result;
        }

    }
}
