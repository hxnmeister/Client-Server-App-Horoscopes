using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Server
{
    internal sealed class ConnectToDB
    {
        DataTable dt;
        SqlConnection conn;
        SqlDataAdapter dataAdapter;

        public ConnectToDB(string connectionName)
        {
            dt = new DataTable();
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings[connectionName].ConnectionString);
            dataAdapter = new SqlDataAdapter();
        }

        public string GetPrediction(string zodiacName)
        {
            try
            {
                dataAdapter.SelectCommand = new SqlCommand(@"select ZS.Name as [Zodiac Name], P.Content as Prediction
                                                             from ZodiacSigns as ZS join ZodiacsPredictions as ZP
                                                             on ZS.Id = ZP.ZodiacSignId join Predictions as P
                                                             on P.Id = ZP.PredictionId
                                                             where ZS.Name = @ZodiacName", conn);
                dataAdapter.SelectCommand.Parameters.Add("@ZodiacName", SqlDbType.VarChar).Value = zodiacName;
                dataAdapter.Fill(dt);

                return $"{dt.Rows[0]["Zodiac Name"]} - {dt.Rows[0]["Prediction"]}";
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Error text: {ex.Message}\n");
                return " Check your input and try again!";
            }
        }
    }
}
