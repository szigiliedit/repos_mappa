using Server.DatabaseManager;
using System;
using System.Collections.Generic;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Server
{
    public class Service1 : IService1
    {
        public static List<Galamb> galambokLista = new List<Galamb>();
        //1. ID legyen egyedi, hogy a megfelelo elemet modosithassuk (relacios db alapok). Egyedi ID-k halmaza:
        public static HashSet<int> galambokIndex = new HashSet<int>();
        Random random = new Random();

        public string hibaUzenet = "";


        public List<Galamb> GalambListaDB()
        {
            List<Galamb> lista = new List<Galamb>();
            DatabaseManager.ISQL tableGalambManager = new DatabaseManager.GalambManager();
            List<Record> records = tableGalambManager.Select("WHERE ID=16");
            foreach (Record record in records)
            {
                if (record is Galamb)
                {
                    lista.Add(record as Galamb); 
                }
            }
            return lista;
        }

        public List<Galamb> GalambListaDBCS()
        {
            return GalambListaDB();
        }

        public string GalambPostDB(Galamb galamb)
        {
            DatabaseManager.GalambManager tableGalambManager = new DatabaseManager.GalambManager();
            tableGalambManager.Insert(galamb);
            /*  int eredmeny = tableGalambManager.Insert(galamb);
            if (eredmeny > 0)
            {
                return "A galamb adatainak a tárolása sikeresen megtörtént.";
            }
            else if (eredmeny == -1)
            {
                return "Már van nevű galamb az adatbázisban!";
            }
            else if (eredmeny == -2)
            {
                return "Hiba az adatbáziskapcsolatban!";
            }
            else
            {
                return $"Egyéb hiba! Pl.: típuskonverzió. Hibakód: {eredmeny}";
            }*/
            return BaseDatabaseManager.hibaUzenet;
        }

        public string GalambPostDBCS(Galamb galamb)
        {
            return GalambPostDB(galamb);
        }

        public string GalambPutDB(Galamb galamb)
        {
            DatabaseManager.GalambManager tableGalambManager = new DatabaseManager.GalambManager();
            tableGalambManager.Update(galamb);
            return BaseDatabaseManager.hibaUzenet;
            /*int valami = tableGalambManager.Update(galamb);
            if (valami > 0)
            {
                return ("Adatok módosítása sikeresen megtörtént.");
            }
            else if(valami == -1)
            {
                return ("Nincs ilyen azonosítóval galamb!");
            }
            else
            {
                return ("Hiba az SQL adatbázis megnyitásakor!");
            }*/
        }

        public string GalambPutDBCS(Galamb galamb)
        {
            return GalambPutDB(galamb);
        }

        public string GalambDeleteDB(int id)
        {
            DatabaseManager.GalambManager tableGalambManager = new DatabaseManager.GalambManager();
            tableGalambManager.Delete(id);
            return BaseDatabaseManager.hibaUzenet;
            /*int valami = tableGalambManager.Delete(id);
            if (valami > 0)
            {
                return ("Adatok törlése sikeresen megtörtént.");
            }
            else if(valami == -1)
            {
                return ("Nincs ilyen azonosítóval galamb!");
            }
            else
            {
                return ("Hiba az SQL adatbázis megnyitásakor!");
            }*/
        }

        public string GalambDeleteDBCS(int id)
        {
            return GalambDeleteDB(id);
        }

        public Galamb EgyGalambGet()
        {
            Galamb egyGalamb = new Galamb();
            egyGalamb.ID = 1;
            egyGalamb.Nev = "Gizi";
            egyGalamb.Gazda = "Backend Elek";
            egyGalamb.Eletkor = 2;
            egyGalamb.Fajta = "Vad";
            egyGalamb.Nem = false; //fiú
            egyGalamb.LabakSzama = 2;
            return egyGalamb;
        }
        public Galamb EgyGalambGetCS()
        {
            return EgyGalambGet();
        }
        public Galamb EgyGalambPost()
        {
            Galamb egyGalamb = new Galamb();
            egyGalamb.ID = random.Next(1, 1001);
            egyGalamb.Nev = "Jani";
            egyGalamb.Gazda = "Tóth Oszkár";
            egyGalamb.Eletkor = 3;
            egyGalamb.Fajta = "Örvös";
            egyGalamb.Nem = true; //lány
            egyGalamb.LabakSzama = 1;
            galambokLista.Add(egyGalamb);
            return egyGalamb;
        }
        public Galamb EgyGalambPostCS()
        {
            return EgyGalambPost();
        }

        public List<Galamb> GalambLista()
        {
            return galambokLista;
        }
        public List<Galamb> GalambListaCS()
        {
            return GalambLista();
        }

        //2. van-e mar ilyen ID-vel adatunk? uzenet; ha van, akkor hibauzenet, ha nincs, tarolas es uzenet hogy kesz
        public string GalambPostCS(Galamb galamb)
        {

            if (galamb != null)
            {
                int id = (int)galamb.ID;
                if (!galambokIndex.Contains(id))
                {
                    galambokLista.Add(galamb);
                    galambokIndex.Add(id);
                    Console.WriteLine("Adat hozzaadas sikeres");
                    return "Adatok tárolása sikeseren megtörtént.";
                }
            }
            Console.WriteLine("Mar van ilyen adatom");
            return "Már van ilyen ID-vel galamb az adatbázisban";
        }

        //3. GalambPostCs meghivasa
        public string GalambPost(Galamb galamb)
        {
            return GalambPostCS(galamb);
        }

        //6. put metódusok megirasa
        public string GalambPutCS(Galamb galamb)
        {

            if (galamb != null)
            {
                int id = (int)galamb.ID;
                if (galambokIndex.Contains(id))
                {
                    int index = 0;
                    foreach (Galamb egyGalamb in galambokLista)
                    {
                        if (egyGalamb.ID == id)
                        {
                            break;
                        }
                        index++;
                    }
                    galambokLista[index] = galamb;
                    Console.WriteLine("Adat modositasa sikeres");
                    return "Adatok módosítása sikeseren megtörtént.";
                }
            }
            Console.WriteLine("Nincs ilyen adatom");
            return "Nincs ID-vel galamb az adatbázisban";
        }

        public string GalambPut(Galamb galamb)
        {
            return GalambPutCS(galamb);
        }

        //8. delete metódusok megirasa
        public string GalambDeleteCS(int id)
        {
            if (galambokLista.Count > 0)
            {
                if (galambokIndex.Contains(id))
                {
                    int index = 0;
                    foreach (Galamb egyGalamb in galambokLista)
                    {
                        if (egyGalamb.ID == id)
                        {
                            break;
                        }
                        index++;
                    }
                    galambokLista.RemoveAt(index);
                    galambokIndex.Remove(id);
                    Console.WriteLine("Adat torlese sikeres");
                    return "Adatok törlése sikeseren megtörtént.";
                }
            }
            Console.WriteLine("Nincs ilyen adatom");
            return "Nincs ID-vel galamb az adatbázisban";
        }

        public string GalambDelete(int id)
        {
            return GalambDeleteCS(id);
        }

        public string GalambDeleteParameter(int id)
        {
            return GalambDeleteCS(id);
        }

        public Galamb GalambGetIDCS(int id)
        {
            int Id = (int)id;
            if (galambokIndex.Contains(id))
            {
                int index = 0;
                foreach (Galamb egyGalamb in galambokLista)
                {
                    if (egyGalamb.ID == id)
                    {
                        break;
                    }
                    index++;
                }
                Galamb vissza = new Galamb();
                vissza = galambokLista[index];
                Console.WriteLine($"Galamb {id}-es ID-vel megtalálva");
                return vissza;
            }
            Console.WriteLine("Nincs ilyen ID-vel galamb");
            return null;
        }

        public Galamb GalambGetID(int id)
        {
            return GalambGetIDCS(id);
        }


    }
}
