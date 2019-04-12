using OneCore.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using OneCore.Class;

namespace OneCore.Class
{
    public class Users
    {
        public enum status
        {
            Ativo = 'A',
            Inativo = 'I'
        }

        Suporte suporte = new Suporte();

        internal const string Retun_data = @"SELECT
                                                USS_ID,
                                                USS_NAME,
                                                USS_EMAIL,
                                                USS_PASSWORD,
                                                USS_STATUS
                                             FROM
                                                 USERS WITH(NOLOCK)
                                             WHERE
                                                1=1";

        public Users()
        {

        }
        public Users(decimal pUSS_ID)
        {
            Transaction lTransaction = new Transaction();

            using (var con = lTransaction.Connection())
            {
                con.Open();

                using (var sqlTransaction = con.BeginTransaction())
                {
                    var cmd = con.CreateCommand();

                    cmd.Transaction = sqlTransaction;
                    try
                    {
                        cmd.CommandText = string.Format(Retun_data + $"AND USS_ID = {pUSS_ID}");

                        IDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            USS_ID = Convert.ToInt32(dr["USS_ID"]);
                            USS_NAME = Convert.ToString(dr["USS_NAME"]);
                            USS_EMAIL = Convert.ToString(dr["USS_EMAIL"]);
                            USS_PASSWORD = Convert.ToString(dr["USS_DATECREATE"]);
                            if (Convert.ToString(dr["USS_STATUS"]) == "A")
                                USS_STATUS = status.Ativo;
                            else if (Convert.ToString(dr["USS_STATUS"]) == "I")
                                USS_STATUS = status.Inativo;
                            USS_DATECREATE = Convert.ToDateTime(dr["USS_DATECREATE"]);
                        }

                        con.Close();
                    }
                    catch (Exception pEx)
                    {

                        throw pEx;

                    }

                }
            }
        }

        public void Add(Transaction ltransaction = null)
        {
            using (var con = ltransaction.Connection())
            {
                con.Open();

                using (var sqlTransaction = con.BeginTransaction())
                {
                    var cmd = con.CreateCommand();

                    cmd.Transaction = sqlTransaction;

                    try
                    {
                        cmd.CommandText = " INSERT INTO USERS (USS_ID,USS_NAME,USS_EMAIL,USS_PASSWORD,USS_STATUS) VALUES (@USS_ID,@USS_NAME,@USS_EMAIL,@USS_PASSWORD,@USS_STATUS) ";
                        cmd.Parameters.Add(new SqlParameter("@USS_ID", Convert.ToInt16(USS_ID)));
                        cmd.Parameters.Add(new SqlParameter("@USS_NAME", Convert.ToString(USS_NAME)));
                        cmd.Parameters.Add(new SqlParameter("@USS_EMAIL", Convert.ToString(this.USS_EMAIL)));
                        cmd.Parameters.Add(new SqlParameter("@USS_PASSWORD", Convert.ToString(this.USS_PASSWORD)));
                        cmd.Parameters.Add(new SqlParameter("@USS_STATUS", Convert.ToString((char)status.Ativo)));
                        cmd.ExecuteScalar();
         
                        sqlTransaction.Commit();

                                               
                    }
                    catch (Exception Exp)
                    {
                         sqlTransaction.Rollback();

                        throw Exp;
                    }
                }

            }

        }

        public void Delete(decimal pUSS_ID, Transaction ltransaction = null)
        {
            using (var con = ltransaction.Connection())
            {
                con.Open();

                using (var sqlTransaction = con.BeginTransaction())
                {
                    var cmd = con.CreateCommand();

                    cmd.Transaction = sqlTransaction;
                    try
                    {
                        cmd.CommandText = $" DELETE FROM USERS WHERE VAGANCY_ID= {pUSS_ID}";
                        cmd.ExecuteNonQuery();

                        sqlTransaction.Commit();
                    }
                    catch (Exception pEx)
                    {
                        sqlTransaction.Rollback();

                        throw pEx;

                    }
                    finally
                    {

                        con.Close();
                    }

                }
            }
        }

        public DataTable Return(string lQuery = "")
        {
            // Cria um novo data table
            DataTable lCheckDt = new DataTable();
            //string de conexão...
            Transaction lTransaction = new Transaction();

            SqlCommand lSqlCommand = new SqlCommand();
            //Abre a conexão
            using (var con = lTransaction.Connection())
            {
                con.Open();
                //PassaValores  
                SqlDataAdapter sda = new SqlDataAdapter(string.Format(Retun_data + "{0}", lQuery), con.ConnectionString);

                sda.Fill(lCheckDt);
            }
            return lCheckDt;
        }

        public decimal USS_ID { get; set; }
        public string USS_NAME { get; set; }
        public string USS_EMAIL { get; set; }
        public string USS_PASSWORD { get; set; }
        public status USS_STATUS { get; set; }
        public DateTime USS_DATECREATE{ get; set; }
    }
}