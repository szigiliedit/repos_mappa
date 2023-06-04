using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Server.DatabaseManager
{
    public class GalambManager : BaseDatabaseManager, ISQL
    {
        public List<Record> Select(string parameter)
        {
            List<Record> records = new List<Record>();
            MySqlCommand command = new MySqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "SELECT * FROM madarak.galambok" +parameter+"ORDER BY nev";
            try
            {
                MySqlConnection connection = BaseDatabaseManager.connenction;
                connection.Open();
                command.Connection = connection;
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Galamb egyGalamb = new Galamb();
                    egyGalamb.ID = reader.GetInt32("id");
                    egyGalamb.Nev = reader.GetString("nev");
                    egyGalamb.Gazda = reader.GetString("gazda");
                    egyGalamb.Eletkor = reader.GetByte("eletkor");
                    egyGalamb.Fajta = reader.GetString("fajta");
                    egyGalamb.Nem = reader.GetBoolean("nem");
                    egyGalamb.LabakSzama = reader.GetByte("labakszama"); // mindig a db-ben szereplő col tipusanak megfelelo get
                    records.Add(egyGalamb); //lista feltoltese a rekorddal

                }
            }
            catch (Exception ex)
            {
                Galamb galamb = new Galamb();
                galamb.Nev = ex.Message;
                records.Add(galamb);
            }
            finally
            {
                connenction.Close();
            }

            return records;
        }

        public int Insert(Record record)
        {
            Galamb galamb = record as Galamb;
            int hozzaadottSorokSzama = 0;

            MySqlCommand command = new MySqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = @"INSERT INTO galambok (nev, gazda, eletkor, fajta, nem, labakszama) VALUES (@nev, @gazda, @eletkor, @fajta, @nem, @labakszama)";
            command.Parameters.Add(new MySqlParameter("@nev", MySqlDbType.VarChar)).Value = galamb.Nev;
            command.Parameters.Add(new MySqlParameter("@gazda", MySqlDbType.VarChar)).Value = galamb.Gazda;
            command.Parameters.Add(new MySqlParameter("@eletkor", MySqlDbType.Byte)).Value = galamb.Eletkor;
            command.Parameters.Add(new MySqlParameter("@fajta", MySqlDbType.VarChar)).Value = galamb.Fajta;
            command.Parameters.Add(new MySqlParameter("@nem", MySqlDbType.Byte)).Value = galamb.Nem;
            command.Parameters.Add(new MySqlParameter("@labakszama", MySqlDbType.Byte)).Value = galamb.LabakSzama;
            command.Connection = BaseDatabaseManager.connenction;

            try
            {
                command.Connection.Open();
                try
                {
                    hozzaadottSorokSzama = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    hibaUzenet = ex.Message;
                    return -1;
                }
            }
            catch (Exception ex)
            {
                hibaUzenet = ex.Message;
                return -2;
            }
            finally
            {
                command.Connection.Close();
                command.Parameters.Clear();
            }
            command.Parameters.Clear();
            hibaUzenet = "Új galamb sikeresen hozzáadva!";
            return hozzaadottSorokSzama;
        }
        public int Update(Record record)
        {
            Galamb galamb = record as Galamb;
            int modositottSorokSzama = 0;

            MySqlCommand command = new MySqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = @"UPDATE galambok SET nev=@nev, gazda=@gazda, eletkor=@eletkor, fajta=@fajta, nem=@nem, labakszama=@labakszama WHERE id=@id";
            command.Parameters.Add(new MySqlParameter("@id", MySqlDbType.VarChar)).Value = galamb.ID;
            command.Parameters.Add(new MySqlParameter("@nev", MySqlDbType.VarChar)).Value = galamb.Nev;
            command.Parameters.Add(new MySqlParameter("@gazda", MySqlDbType.VarChar)).Value = galamb.Gazda;
            command.Parameters.Add(new MySqlParameter("@eletkor", MySqlDbType.Byte)).Value = galamb.Eletkor;
            command.Parameters.Add(new MySqlParameter("@fajta", MySqlDbType.VarChar)).Value = galamb.Fajta;
            command.Parameters.Add(new MySqlParameter("@nem", MySqlDbType.Byte)).Value = galamb.Nem;
            command.Parameters.Add(new MySqlParameter("@labakszama", MySqlDbType.Byte)).Value = galamb.LabakSzama;
            command.Connection = BaseDatabaseManager.connenction;

            try
            {
                command.Connection.Open();
                try
                {
                    modositottSorokSzama = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    hibaUzenet = ex.Message;
                    return -1;
                }
            }
            catch (Exception ex)
            {
                hibaUzenet = ex.Message;
                return -2;
            }
            finally
            {
                command.Connection.Close();
                command.Parameters.Clear();
            }
            if (modositottSorokSzama > 0)
            {
                hibaUzenet = "Az adatok módosítása sikeresen megtörtént";
            }
            else
            {
                hibaUzenet = "Nem történt módosítás";
            }
                   
            return modositottSorokSzama;
        }
        public int Delete(int id)
        {
            int toroltSorokSzama = 0;

            MySqlCommand command = new MySqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = @"DELETE FROM galambok WHERE id=@id";
            command.Parameters.Add(new MySqlParameter("@id", MySqlDbType.VarChar)).Value = id;
            command.Connection = BaseDatabaseManager.connenction;

            try
            {
                command.Connection.Open();
                command.Parameters.Clear();
                try
                {
                    toroltSorokSzama = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    hibaUzenet = ex.Message;
                    return -1;
                }
            }
            catch (Exception ex)
            {
                hibaUzenet = ex.Message;
                return -2;
            }
            finally
            {
                command.Connection.Close();
                command.Parameters.Clear();
            }
            command.Parameters.Clear();
            hibaUzenet = $"(ID:{id}) Galamb sikeresen törölve!";

            return toroltSorokSzama;
        }
    }
}