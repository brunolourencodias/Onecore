using OneCore.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OneCore.Class
{
    public class RegisterClient
    {

        public enum genre
        {
            Masculino = 'M',
            Feminino = 'F'
        }
        internal const string Retun_data = @"SELECT
                                                        RST_ID,
                                                        USS_ID,
                                                        RST_NAME,
                                                        RST_GENRE,
                                                        RST_DATEBIRTH,
                                                        RST_DOCUMENT
                                                     FROM
                                                        REGISTERCLIENT WITH(NOLOCK)
                                                     WHERE
                                                        1=1";

        public RegisterClient()
        {

        }
        public RegisterClient(decimal pRST_ID)
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
                        cmd.CommandText = string.Format(Retun_data, "AND RST_ID = " + pRST_ID);

                        IDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            RST_ID = Convert.ToInt32(dr["RST_ID"]);
                            USS_ID = Convert.ToInt32(dr["USS_ID"]);
                            RST_NAME = Convert.ToString(dr["RST_NAME"]);
                            USS_PASSWORD = Convert.ToString(dr["USS_DATECREATE"]);
                            if (Convert.ToString(dr["RST_GENRE"]) == "M")
                                RST_GENRE = genre.Masculino;
                            else if (Convert.ToString(dr["RST_GENRE"]) == "F")
                                RST_GENRE = genre.Feminino;
                            RST_DATEBIRTH = Convert.ToDateTime(dr["RST_DATEBIRTH"]);
                            RST_DOCUMENT = Convert.ToString(dr["RST_DOCUMENT"]);
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
                        cmd.CommandText = " INSERT INTO REGISTERCLIENT VALUES (@USS_ID,@RST_NAME,@RST_GENRE,@RST_DATEBIRTH,@RST_DOCUMENT)";
                        cmd.Parameters.Add(new SqlParameter("@RST_NAME", Convert.ToString(this.RST_NAME)));
                        cmd.Parameters.Add(new SqlParameter("@USS_ID", Convert.ToString(this.USS_ID)));
                        if (Convert.ToString(RST_GENRE) == "Masculino")
                            cmd.Parameters.Add(new SqlParameter("@RST_GENRE", Convert.ToString((char)genre.Masculino)));
                        else
                            cmd.Parameters.Add(new SqlParameter("@RST_GENRE", Convert.ToString((char)genre.Feminino)));
                        cmd.Parameters.Add(new SqlParameter("@RST_DATEBIRTH", Convert.ToDateTime(this.RST_DATEBIRTH)));
                        cmd.Parameters.Add(new SqlParameter("@RST_DOCUMENT", Convert.ToString(this.RST_DOCUMENT)));
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

        public void Delete(decimal pRST_ID, Transaction ltransaction = null)
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
                        cmd.CommandText = $" DELETE FROM REGISTERCLIENT WHERE RST_ID= {pRST_ID}";
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
            //Faz conexão com o banco
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


        public int RST_ID { get; set; }
        public int USS_ID { get; set; }
        public string RST_NAME { get; set; }
        public string USS_PASSWORD { get; set; }
        public genre RST_GENRE { get; set; }
        public DateTime RST_DATEBIRTH { get; set; }
        public string RST_DOCUMENT { get; set; }
    }
}