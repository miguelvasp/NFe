using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotaEletronica.Models;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace NotaEletronica.DAL
{
    public class SQLDataLayer
    {
        DB_ERPContext db = new DB_ERPContext();
        string ConnectionString = ConfigurationManager.ConnectionStrings["DB_Context"].ConnectionString;

         
    }
}
