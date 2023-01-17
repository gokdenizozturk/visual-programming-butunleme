using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace visual_programming_final
{
    public class DbClass
    {
        public static MySqlConnection dbconnect = new MySqlConnection("Server=localhost;Database=movie;Uid=root;Pwd='';");
    }
}
