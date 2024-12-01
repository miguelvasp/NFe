using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace NotaEletronica.DAL
{
    public class ObjDAL
    {
        private SqlConnection Con = null;
        private SqlCommand cmd = new SqlCommand();
        private SqlDataAdapter da = new SqlDataAdapter();
        private SqlTransaction tr = null;
        private List<SqlParameter> Parametros = new List<SqlParameter>();

        /// <summary>
        /// Implementa o construtor e instancia, caso nao exista a conexão com
        /// o banco de dados, e instancia o sqlcommand
        /// </summary>        
        public ObjDAL()
        {
            string Server = Util.Util.GetAppSettings("Server");
            string Banco = Util.Util.GetAppSettings("Banco");
            string Usuario = Util.Util.GetAppSettings("Usuario");
            string Senha = Util.Util.GetAppSettings("Senha");
            string sqlConnection = string.Format("Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}", Server, Banco, Usuario, Senha);
            Con = new SqlConnection(sqlConnection);
            cmd.Connection = Con;
        }

        public void AddParameter(IDataParameter Param)
        {
            cmd.Parameters.Add(Param);
        }


        /// <summary>
        /// Executa uma procedure do banco de dados retornando um datatable
        /// </summary>
        /// <param name="NomeProcedimento"></param>
        /// <returns></returns>
        public ObjReturn ExecDataTableProc(string NomeProcedimento)
        {
            ObjReturn obj = new ObjReturn();
            try
            {
                cmd.CommandText = NomeProcedimento;
                cmd.CommandType = CommandType.StoredProcedure;
                da.SelectCommand = cmd;
                da.Fill(obj.ObjDataTable);
                cmd.Parameters.Clear();
            }
            catch (Exception ex)
            {
                cmd.Parameters.Clear();
                obj.ObjException = ex;
            }
            return obj;
        }

        /// <summary>
        /// Executa um comando SQL do banco de dados retornando um datatable
        /// </summary>
        /// <param name="NomeProcedimento"></param>
        /// <returns></returns>
        public ObjReturn ExecDataTableSQL(string SQL)
        {
            ObjReturn obj = new ObjReturn();
            try
            {
                cmd.CommandText = SQL;
                cmd.CommandType = CommandType.Text;
                da.SelectCommand = cmd;
                da.Fill(obj.ObjDataTable);
                cmd.Parameters.Clear();
            }
            catch (Exception ex)
            {
                cmd.Parameters.Clear();
                obj.ObjException = ex;
            }

            return obj;
        }


        public ObjReturn ExecScalarProc(string NomeProcedimento)
        {
            ObjReturn obj = new ObjReturn();
            try
            {
                cmd.CommandText = NomeProcedimento;
                cmd.CommandType = CommandType.StoredProcedure;

                Con.Open();
                obj.ObjScalar = cmd.ExecuteScalar();
                Con.Close();
                cmd.Parameters.Clear();

            }
            catch (Exception ex)
            {
                Con.Close();
                cmd.Parameters.Clear();
                obj.ObjException = ex;
            }
            return obj;
        }





        /// <summary>
        /// Executa uma procedure que nao tem nenhum retorno
        /// </summary>
        /// <param name="NomeProcedimento"></param>
        public ObjReturn ExecProcNonQuery(string NomeProcedimento)
        {
            ObjReturn obj = new ObjReturn();
            try
            {
                cmd.CommandText = NomeProcedimento;
                cmd.CommandType = CommandType.StoredProcedure;
                Con.Open();
                cmd.ExecuteNonQuery();
                Con.Close();
                cmd.Parameters.Clear();

            }
            catch (Exception ex)
            {
                Con.Close();
                cmd.Parameters.Clear();
                obj.ObjException = ex;
            }
            return obj;
        }


        /// <summary>
        /// Executa um commando SQL que nao tem nenhum retorno
        /// </summary>
        /// <param name="NomeProcedimento"></param>
        public ObjReturn ExecSQLNonQuery(string SQL)
        {
            ObjReturn obj = new ObjReturn();
            try
            {
                cmd.CommandText = SQL;
                cmd.CommandType = CommandType.Text;
                Con.Open();
                cmd.ExecuteNonQuery();
                Con.Close();
                cmd.Parameters.Clear();
            }
            catch (Exception ex)
            {
                Con.Close();
                cmd.Parameters.Clear();
                obj.ObjException = ex;
            }
            return obj;
        }


        public void BeginTransaction()
        {
            Con.Open();
            tr = Con.BeginTransaction();
        }

        public void CommitTransaction()
        {
            tr.Commit();
        }

        public void RollBackTransaction()
        {
            tr.Rollback();
        }
    }
}
