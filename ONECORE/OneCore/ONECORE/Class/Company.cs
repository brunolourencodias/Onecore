using OneCore.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OneCore.Class
{
    public class Company
    {
        internal const string Retun_data = @"SELECT
                                                CPY_ID,
                                                CPY_NAME,
                                                CPY_DOCUMENT,
                                                CPY_END,
                                                CPY_EMAIL,
                                                CPY_TEL,
                                                CPY_DATECREATE,
                                                USS_ID
                                             FROM
                                                 COMPANY WITH(NOLOCK)
                                             WHERE
                                                1=1";
        public Company()
        {

        }
        public Company(decimal pCPY_ID)
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
                        cmd.CommandText = $" SELECT * FROM COMPANY WHERE CPY_ID= {pCPY_ID}";

                        IDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            CPY_ID = Convert.ToDecimal(dr["CPY_ID"]);
                            CPY_NAME = Convert.ToString(dr["CPY_NAME"]);
                            CPY_DOCUMENT = Convert.ToString(dr["CPY_DOCUMENT"]);
                            CPY_END = Convert.ToString(dr["CPY_END"]);
                            CPY_EMAIL = Convert.ToString(dr["CPY_EMAIL"]);
                            CPY_TEL = Convert.ToString(dr["CPY_TEL"]);
                            CPY_DATECREATE = Convert.ToDateTime(dr["CPY_DATECREATE"]);
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
                        cmd.CommandText = " INSERT INTO VAGANCY VALUES (@CPY_ID,@CPY_NAME,@CPY_DOCUMENT,@CPY_END,@CPY_EMAIL,@CPY_TEL,@CPY_DATECREATE,@USS_ID)";
                        cmd.Parameters.Add(new SqlParameter("@CPY_ID", Convert.ToDecimal(this.CPY_ID)));
                        cmd.Parameters.Add(new SqlParameter("@CPY_NAME", Convert.ToString(this.CPY_NAME)));
                        cmd.Parameters.Add(new SqlParameter("@CPY_DOCUMENT", Convert.ToString(this.CPY_DOCUMENT)));
                        cmd.Parameters.Add(new SqlParameter("@CPY_END", Convert.ToString(this.CPY_END)));
                        cmd.Parameters.Add(new SqlParameter("@CPY_EMAIL", Convert.ToString(this.CPY_EMAIL)));
                        cmd.Parameters.Add(new SqlParameter("@CPY_TEL", Convert.ToString(CPY_TEL)));
                        cmd.Parameters.Add(new SqlParameter("@CPY_DATECREATE", Convert.ToDateTime(this.CPY_DATECREATE)));
                        cmd.Parameters.Add(new SqlParameter("@USS_ID", Convert.ToDateTime(this.USS_ID)));
                        cmd.ExecuteNonQuery();

                        sqlTransaction.Commit();
                    }
                    catch (Exception Exp)
                    {
                        sqlTransaction.Rollback();

                        throw Exp;
                    }
                    finally
                    {
                        con.Close();
                    }
                }

            }

        }
        public void Update(decimal pCPY_ID, Transaction ltransaction = null)
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
                        cmd.CommandText = $" UPDATE VAGANCY SET CPY_NAME=@CPY_NAME,CPY_EMAIL=@CPY_EMAIL,CPY_TEL=@CPY_TEL WHERE CPY_ID ={pCPY_ID}";
                        cmd.Parameters.Add(new SqlParameter("@CPY_NAME", Convert.ToString(this.CPY_NAME)));
                        cmd.Parameters.Add(new SqlParameter("@CPY_EMAIL", Convert.ToString(this.CPY_EMAIL)));
                        cmd.Parameters.Add(new SqlParameter("@CPY_TEL", Convert.ToString(CPY_TEL)));
                        cmd.ExecuteNonQuery();

                        sqlTransaction.Commit();
                    }
                    catch (Exception Exp)
                    {
                        sqlTransaction.Rollback();

                        throw Exp;
                    }
                    finally
                    {
                        con.Close();
                    }
                }

            }

        }
        public void Delete(decimal pCPY_ID, Transaction ltransaction = null)
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
                        cmd.CommandText = $" DELETE FROM COMPANY WHERE CPY_ID= {pCPY_ID}";
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
        public DataTable ReturnCompany(string lQuery = "")
        {
            // Cria um novo data table
            DataTable lCheckDt = new DataTable();
            //Faz conexão com o banco
            Transaction lTransaction = new Transaction();

            SqlCommand lSqlCommand = new SqlCommand();
            //Abre a conexão
            using (var con = lTransaction.Connection())
            {
                con.Open();
                //PassaValores  
                SqlDataAdapter sda = new SqlDataAdapter(string.Format(Retun_data, lQuery), con.ConnectionString);

                sda.Fill(lCheckDt);
            }
            return lCheckDt;
        }

        public decimal CPY_ID { get; set; }
        public string CPY_NAME { get; set; }
        public string CPY_DOCUMENT { get; set; }
        public string CPY_END { get; set; }
        public string CPY_EMAIL { get; set; }
        public string CPY_TEL{ get; set; }
        public DateTime CPY_DATECREATE { get; set; }
        public decimal USS_ID { get; set; }


    }
}