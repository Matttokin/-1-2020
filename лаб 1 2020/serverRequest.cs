using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace лаб_1_2020
{
    static class serverRequest
    {
        static string serverhttp = "http://localhost:17619/";
        static public string Poisk_id_po_loginu(string login_local)
        {
            string url = serverhttp + "api/Poisk_id_po_loginu?login_local=" + login_local;
            using (var webClient = new WebClient())
            {
                var response = webClient.DownloadString(url);
                Console.WriteLine(response);
                return response.Substring(1, response.Length - 2);
            }
        }
        static public string Poisk_password_po_id(string id_local)
        {
            string url = serverhttp + "api/Poisk_password_po_id?id_local=" + id_local;
            using (var webClient = new WebClient())
            {
                var response = webClient.DownloadString(url);
                return response.Substring(1, response.Length - 2);
            }
        }
        static public string Get_data_izmenenia(string login_local)
        {
            string url = serverhttp + "api/Get_data_izmenenia?login_local=" + login_local;
            using (var webClient = new WebClient())
            {
                var response = webClient.DownloadString(url);
                return response.Substring(1, response.Length - 2);
            }
        }
        static public string Get_dif1(string login_local)
        {
            string url = serverhttp + "api/Get_dif1?login_local=" + login_local;
            using (var webClient = new WebClient())
            {
                var response = webClient.DownloadString(url);
                return response.Substring(1, response.Length - 2);
            }
        }
        static public void Update_password(string id_local,string new_password)
        {
            string url = serverhttp + "api/Update_password?id_local=" + id_local + "&new_password=" + new_password; ;
            using (var webClient = new WebClient())
            {
                var response = webClient.DownloadString(url);
            }
        }
        static public List<int> syshnoste(string id_pol)
        {
            string url = serverhttp + "api/syshnoste?id_pol=" + id_pol;
            using (var webClient = new WebClient())
            {
                var response = webClient.DownloadString(url);
                return JsonConvert.DeserializeObject<List<int>>(response.Substring(1, response.Length - 2));
            }
        }
        static public List<films> Get_films()
        {
            string url = serverhttp + "api/Get_films";
            using (var webClient = new WebClient())
            {
                var response = webClient.DownloadString(url);
                response = response.Substring(1, response.Length - 2);
                response = response.Replace("\\\"", "\"");
                response = response.Replace("\\", "");
                return JsonConvert.DeserializeObject<List<films>>(response);
            }
        }
        static public void Insert_film(string avtor, string nazvanie, string annotacia, string strana, int god, string zhanr)
        {
            string url = serverhttp + "api/Insert_film?avtor=" + avtor + "&nazvanie=" + nazvanie
                 + "&annotacia=" + annotacia + "&strana=" + strana
                  + "&god=" + god + "&zhanr=" + zhanr;
            using (var webClient = new WebClient())
            {
                var response = webClient.DownloadString(url);
            }
        }
        static public void Update_film(string id,string avtor, string nazvanie, string annotacia, string strana, string god, string zhanr)
        {
            string url = serverhttp + "api/Update_film?id=" + id + "&avtor =" + avtor + "&nazvanie=" + nazvanie
                 + "&annotacia=" + annotacia + "&strana=" + strana
                  + "&god=" + god + "&zhanr=" + zhanr;
            using (var webClient = new WebClient())
            {
                var response = webClient.DownloadString(url);
            }
        }
        static public void Delete_film(string id)
        {
            string url = serverhttp + "api/Delete_film?id=" + id;
            using (var webClient = new WebClient())
            {
                var response = webClient.DownloadString(url);
            }
        }
        static public string get_rules_and_othr(int id_polz, int id_table)
        {
            string url = serverhttp + "api/get_rules_and_othr?id_polz=" + id_polz + "&id_table=" + id_table;
            using (var webClient = new WebClient())
            {
                var response = webClient.DownloadString(url);
                return response.Substring(1, response.Length - 2);
            }

        }
        static public List<users> Get_users()
        {
            string url = serverhttp + "api/Get_users";
            using (var webClient = new WebClient())
            {
                var response = webClient.DownloadString(url);
                response = response.Substring(1, response.Length - 2);
                response = response.Replace("\\\"", "\"");
                response = response.Replace("\\", "");
                return JsonConvert.DeserializeObject<List<users>>(response);
            }
        }
        static public void Insert_user(string login, string password, string roleid)
        {
            string url = serverhttp + "api/Insert_user?login=" + login + "&password=" + password
                 + "&roleid=" + roleid;
            using (var webClient = new WebClient())
            {
                var response = webClient.DownloadString(url);
            }
        }
        static public void Update_user(string id, string login, string password, string roleid)
        {
            string url = serverhttp + "api/Update_user?id=" + id + "&login=" + login + "&password=" + password
                 + "&roleid=" + roleid;
            using (var webClient = new WebClient())
            {
                var response = webClient.DownloadString(url);
            }
        }
        static public void Delete_user(string id)
        {
            string url = serverhttp + "api/Delete_user?id=" + id;
            using (var webClient = new WebClient())
            {
                var response = webClient.DownloadString(url);
            }
        }
        static public List<roles> Get_role()
        {
            string url = serverhttp + "api/Get_role";
            using (var webClient = new WebClient())
            {
                var response = webClient.DownloadString(url);
                response = response.Substring(1, response.Length - 2);
                response = response.Replace("\\\"", "\"");
                response = response.Replace("\\", "");
                return JsonConvert.DeserializeObject<List<roles>>(response);
            }
        }
    }
}
