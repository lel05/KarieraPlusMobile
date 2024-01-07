using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace KarieraPlusMobile.Classes
{
    internal class Database
    {
        static string OffersFilepath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "karieraplusofferss.json");
        static string UsersFilepath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "karieraplususerss.json");

        public static void InitializeDatabase()
        {
            if (!File.Exists(OffersFilepath))
            {
                File.WriteAllText(OffersFilepath, "[]");
            }
            if(!File.Exists(UsersFilepath))
            {
                File.WriteAllText(UsersFilepath, "[]");
            }
        }

        public List<Offers> Offers_GetData()
        {
            List<Offers> tmp = new List<Offers>();
            try
            {
                string read = File.ReadAllText(OffersFilepath);
                tmp = JsonConvert.DeserializeObject<List<Offers>>(read);
            }
            catch
            {
                tmp = new List<Offers>();

                string read = JsonConvert.SerializeObject(tmp);
                File.WriteAllText(OffersFilepath, read);
            }

            return tmp;
        }

        public void Offer_AddData(Offers offer)
        {
            List<Offers> tmp = Offers_GetData();


            if (tmp.Count > 0) offer.Offer_id = tmp[tmp.Count - 1].Offer_id + 1;
            else offer.Offer_id = 0;


            tmp.Add(offer);

            string read = JsonConvert.SerializeObject(tmp);
            File.WriteAllText(OffersFilepath, read);
        }

        public void Offer_EditData(Offers offer)
        {
            List<Offers> tmp = Offers_GetData();

            for (int i = 0; i < tmp.Count; i++)
            {
                if (tmp[i].Offer_id == offer.Offer_id)
                {
                    tmp[i] = offer;
                }
            }

            string read = JsonConvert.SerializeObject(tmp);
            File.WriteAllText(OffersFilepath, read);
        }

        public void Offer_DeleteData(Offers offer)
        {
            List<Offers> tmp = Offers_GetData();

            for (int i = 0; i < tmp.Count; i++)
            {
                if (tmp[i].Offer_id == offer.Offer_id)
                {
                    tmp.RemoveAt(i);
                }
            }

            string read = JsonConvert.SerializeObject(tmp);
            File.WriteAllText(OffersFilepath, read);
        }

        public List<User> Users_GetData()
        {
            List<User> tmp = new List<User>();
            try
            {
                string read = File.ReadAllText(UsersFilepath);
                tmp = JsonConvert.DeserializeObject<List<User>>(read);
            }
            catch
            {
                tmp = new List<User>();

                string read = JsonConvert.SerializeObject(tmp);
                File.WriteAllText(UsersFilepath, read);
            }

            return tmp;
        }

        public void User_AddData(User user)
        {
            List<User> tmp = Users_GetData();


            if (tmp.Count > 0) user.User_id = tmp[tmp.Count - 1].User_id + 1;
            else user.User_id = 0;


            tmp.Add(user);

            string read = JsonConvert.SerializeObject(tmp);
            File.WriteAllText(UsersFilepath, read);
        }

        public void User_EditData(User user)
        {
            List<User> tmp = Users_GetData();

            for (int i = 0; i < tmp.Count; i++)
            {
                if (tmp[i].User_id == user.User_id)
                {
                    tmp[i] = user;
                }
            }

            string read = JsonConvert.SerializeObject(tmp);
            File.WriteAllText(UsersFilepath, read);
        }

        public void User_DeleteData(User user)
        {
            List<User> tmp = Users_GetData();

            for (int i = 0; i < tmp.Count; i++)
            {
                if (tmp[i].User_id == user.User_id)
                {
                    tmp.RemoveAt(i);
                }
            }

            string read = JsonConvert.SerializeObject(tmp);
            File.WriteAllText(UsersFilepath, read);
        }

        public static bool IsLoginValid(string email, string password)
        {
            List<User> users = JsonConvert.DeserializeObject<List<User>>(File.ReadAllText(UsersFilepath));
            return users.Exists(user => user.Email == email && user.Password == password);
        }
    }
}
