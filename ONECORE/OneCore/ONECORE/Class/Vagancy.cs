using OneCore.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OneCore.Class
{
    public class Vagancy
    {
        [Serializable]
        public enum status
        {
            Ativo = 'A',
            Inativo = 'I'
        }

        internal const string Retun_data = @"SELECT
                                                VAGANCY_ID,
                                                VG_TITLE,
                                                CPY_ID,
                                                VG_DATE_FINALLY,
                                                VG_OBS,
                                                VG_STATUS,
                                                VG_DATECREATE,
                                                VG_VALUE,
                                                USS_ID
                                             FROM
                                                 VAGANCY WITH(NOLOCK)
                                             WHERE
                                                1=1";


        public Vagancy()
        {

        }
        public Vagancy(decimal pVAGANCY_ID)
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
                        cmd.CommandText = string.Format(Retun_data,"AND VAGANCY_ID = " + pVAGANCY_ID);

                        IDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            VAGANCY_ID = Convert.ToDecimal(dr["VAGANCY_ID"]);
                            CPY_ID = Convert.ToDecimal(dr["CPY_ID"]);
                            VG_TITLE = Convert.ToString(dr["VG_TITLE"]);
                            VG_DATE_FINALLY = Convert.ToDateTime(dr["VG_DATE_FINALLY"]);
                            VG_OBS = Convert.ToString(dr["VG_OBS"]);
                            if (Convert.ToString(dr["VG_STATUS"]) == "A")
                                VG_STATUS = status.Ativo;
                            else if (Convert.ToString(dr["VG_STATUS"]) == "I")
                                VG_STATUS = status.Inativo;
                            VG_DATECREATE = Convert.ToDateTime(dr["VG_DATECREATE"]);
                            VG_VALUE = Convert.ToDecimal(dr["VG_VALUE"]);
                            USS_ID = Convert.ToDecimal(dr["USS_ID"]);
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
                        cmd.CommandText = " INSERT INTO VAGANCY VALUES (@VG_TITLE,@CPY_ID,@VG_DATE_FINALLY,@VG_OBS,@VG_STATUS,@VG_DATECREATE,@VG_VALUE,@USS_ID)";
                        cmd.Parameters.Add(new SqlParameter("@VG_TITLE", Convert.ToString(this.VG_TITLE)));
                        cmd.Parameters.Add(new SqlParameter("@CPY_ID", Convert.ToInt32(this.CPY_ID)));
                        cmd.Parameters.Add(new SqlParameter("@VG_DATE_FINALLY", Convert.ToDateTime(this.VG_DATE_FINALLY)));
                        cmd.Parameters.Add(new SqlParameter("@VG_OBS", Convert.ToString(this.VG_OBS)));
                        cmd.Parameters.Add(new SqlParameter("@VG_STATUS", Convert.ToString((char)status.Ativo)));
                        cmd.Parameters.Add(new SqlParameter("@VG_DATECREATE", Convert.ToDateTime(this.VG_DATECREATE)));
                        cmd.Parameters.Add(new SqlParameter("@VG_VALUE", Convert.ToDecimal(this.VG_VALUE)));
                        cmd.Parameters.Add(new SqlParameter("@USS_ID", Convert.ToDecimal(this.USS_ID)));
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

        public void Update(decimal pVAGANCY_ID,  Transaction ltransaction = null)
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
                        cmd.CommandText = $" UPDATE VAGANCY SET VG_TITLE = @VG_TITLE, VG_DATE_FINALLY= @VG_DATE_FINALLY, VG_OBS = @VG_OBS, VG_STATUS= @VG_STATUS,VG_DATECREATE=@VG_DATECREATE,VG_VALUE=@VG_VALUE  WHERE VAGANCY_ID = {pVAGANCY_ID}";

                        cmd.Parameters.Add(new SqlParameter("@VG_TITLE", Convert.ToString(this.VG_TITLE)));
                        cmd.Parameters.Add(new SqlParameter("@VG_DATE_FINALLY", Convert.ToDateTime(this.VG_DATE_FINALLY)));
                        cmd.Parameters.Add(new SqlParameter("@VG_OBS", Convert.ToString(this.VG_OBS)));
                        cmd.Parameters.Add(new SqlParameter("@VG_STATUS", Convert.ToString((char)status.Ativo)));
                        cmd.Parameters.Add(new SqlParameter("@VG_DATECREATE", Convert.ToDateTime(this.VG_DATECREATE)));
                        cmd.Parameters.Add(new SqlParameter("@VG_VALUE", Convert.ToDecimal(this.VG_VALUE)));
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

        public void Delete(decimal pVAGANCY_ID, Transaction ltransaction = null)
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
                        cmd.CommandText = $" DELETE FROM VAGANCY WHERE VAGANCY_ID= {pVAGANCY_ID}";
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

        public DataTable ReturnVagancy(string lQuery = "")
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
                SqlDataAdapter sda = new SqlDataAdapter(string.Format(Retun_data +"{0}", lQuery), con.ConnectionString);

                sda.Fill(lCheckDt);
            }

            return lCheckDt;
        }

        public decimal VAGANCY_ID { get; set; }
        public decimal USS_ID { get; set; }
        public decimal CPY_ID { get; set; }
        public string VG_TITLE { get; set; }
        public DateTime VG_DATE_FINALLY { get; set; }
        public string VG_OBS { get; set; }
        public status VG_STATUS { get; set; }
        public DateTime VG_DATECREATE { get; set; }
        public decimal VG_VALUE { get; set; }

    }
}