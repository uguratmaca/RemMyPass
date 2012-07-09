using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Text;

namespace DataLayer
{
    public static class GeneralOperations
    {
        public static RMPEntities dbContext = new RMPEntities();

        public static DataTable LINQToDataTable<T>(IEnumerable<T> varlist, int page = 0, int rowCount = 10)
        {
            DataTable dtReturn = new DataTable();

            //varlist = varlist.Skip(page).Take(rowCount);
            // column names 
            PropertyInfo[] oProps = null;

            if (varlist == null) return dtReturn;

            foreach (T rec in varlist)
            {
                // Use reflection to get property names, to create table, Only first time, others will follow 
                if (oProps == null)
                {
                    oProps = ((Type)rec.GetType()).GetProperties();
                    foreach (PropertyInfo pi in oProps)
                    {
                        Type colType = pi.PropertyType;

                        if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition() == typeof(Nullable<>)))
                        {
                            colType = colType.GetGenericArguments()[0];
                        }

                        dtReturn.Columns.Add(new DataColumn(pi.Name, colType));
                    }
                }

                DataRow dr = dtReturn.NewRow();

                foreach (PropertyInfo pi in oProps)
                {
                    dr[pi.Name] = pi.GetValue(rec, null) == null ? DBNull.Value : pi.GetValue(rec, null);
                }

                dtReturn.Rows.Add(dr);
            }
            return dtReturn;
        }

        public static string GeneratePassword(string username, string website, int numberofchars, string algorithmhardness, long userId)
        {
            SaveQuery(username, website, numberofchars, algorithmhardness, userId);

            int hardness = 0;
            string generatedpassword = string.Empty;

            string[] usingChars = new string[4];
            int[,] asciiofChars;

            switch (algorithmhardness)
            {
                case "Easy":
                    hardness = 2;
                    asciiofChars = new int[2, 2];
                    break;
                case "Medium":
                    hardness = 3;
                    asciiofChars = new int[3, 2];
                    break;
                case "Hard":
                    hardness = 4;
                    asciiofChars = new int[4, 2];
                    break;
                default:
                    hardness = 4;
                    asciiofChars = new int[4, 2];
                    break;
            }


            usingChars[0] = Constants.easychars;
            usingChars[1] = Constants.easynumberchars;
            usingChars[2] = Constants.mediumchars;
            usingChars[3] = Constants.hardchars;


            for (int i = 0; i < hardness; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    asciiofChars[i, j] = 1;
                }
            }


            for (int i = 0; i < username.Length; i++)
            {
                asciiofChars[i % hardness, 0] *= (int)username[i];
            }


            for (int i = 0; i < website.Length; i++)
            {
                asciiofChars[i % hardness, 1] *= (int)website[i];
            }

            for (int i = 0; i < numberofchars; i++)
            {
                int multiple = (asciiofChars[i % hardness, 0] * asciiofChars[i % hardness, 1]);

                if (multiple < 0)
                {
                    multiple *= -1;
                }
                char c = usingChars[i % hardness][multiple % usingChars[i % hardness].Length];

                int index = generatedpassword.IndexOf(c);

                if (index != -1)
                {
                    asciiofChars[i % hardness, 0] -= numberofchars;
                    asciiofChars[i % hardness, 1] -= numberofchars;
                    i--;
                    continue;
                }

                generatedpassword += c;
                asciiofChars[i % hardness, 0] /= numberofchars;
                asciiofChars[i % hardness, 1] /= numberofchars;
            }

            return generatedpassword;
        }

        public static DataTable GetUserQueries(long userId)
        {
            var table = (from list in dbContext.GetUserSavedWebSites
                         where list.UserId == userId
                         select list);

            // && (list.Description.Contains(searchtext) || list.Name.Contains(searchtext) || list.UserName.Contains(searchtext)
            return LINQToDataTable(table);
        }

        public static DataTable GetUserQueries2(long userId, string searchtext)
        {
            var table = (from list in dbContext.GetUserSavedWebSites
                         where list.UserId == userId && (list.Description.Contains(searchtext) || list.Name.Contains(searchtext) || list.UserName.Contains(searchtext))
                         select list);
            return LINQToDataTable(table);
        }

        public static string GetUserQueryById(long Id, long userId)
        {
            var table = (from list in dbContext.GetUserSavedWebSites
                         where list.Id == Id && list.UserId == userId
                         select list);

            DataTable dt = LINQToDataTable(table);
            return GetJSONString(dt);
        }

        public static bool SavePassQuery(string websitename, long userId, string description, string username, string name, int charcount, string algorithmlevel)
        {
            try
            {
                long websiteId = GetWebsiteId(websitename);

                SavedUserQuery suq = new SavedUserQuery();
                suq.WebSiteId = websiteId;
                suq.UserId = userId;
                suq.UserName = username;
                suq.Description = description;
                suq.CharCount = charcount;
                suq.AlgorithmLevel = algorithmlevel;
                suq.CreatedAt = DateTime.Now;
                suq.Name = name;
                suq.ApplicationSource = "Web";

                dbContext.SavedUserQueries.AddObject(suq);
                dbContext.SaveChanges();

                return true;
            }
            catch { return false; }
        }

        private static void SaveQuery(string username, string websitename, int numberofchars, string algorithmhardness, long userId)
        {
            long websiteId = GetWebsiteId(websitename);

            PasswordQuery pq = new PasswordQuery();

            if (userId != 0)
            {
                pq.UserId = userId;
            }

            pq.WebSiteId = websiteId;

            pq.UserName = username;
            pq.AlgorithmType = algorithmhardness;
            pq.CharCount = numberofchars;

            pq.GeneratedAt = DateTime.Now;

            dbContext.PasswordQueries.AddObject(pq);
            dbContext.SaveChanges();
        }

        private static long GetWebsiteId(string websitename)
        {
            WebSite website = dbContext.WebSites.Where(ws => ws.Name == websitename).FirstOrDefault();

            if (website == null)
            {
                website = new WebSite();
                website.Name = websitename;
                dbContext.WebSites.AddObject(website);
                dbContext.SaveChanges();
            }

            return website.Id;
        }

        public static string GetJSONString(DataTable Dt)
        {

            string[] StrDc = new string[Dt.Columns.Count];

            string HeadStr = string.Empty;
            for (int i = 0; i < Dt.Columns.Count; i++)
            {

                StrDc[i] = Dt.Columns[i].Caption;
                HeadStr += "\"" + StrDc[i] + "\" : \"" + StrDc[i] + i.ToString() + "¾" + "\",";

            }

            HeadStr = HeadStr.Substring(0, HeadStr.Length - 1);
            StringBuilder Sb = new StringBuilder();

            Sb.Append("{\"" + "query" + "\" : [");
            for (int i = 0; i < Dt.Rows.Count; i++)
            {

                string TempStr = HeadStr;

                Sb.Append("{");
                for (int j = 0; j < Dt.Columns.Count; j++)
                {

                    TempStr = TempStr.Replace(Dt.Columns[j] + j.ToString() + "¾", Dt.Rows[i][j].ToString());

                }
                Sb.Append(TempStr + "},");

            }
            Sb = new StringBuilder(Sb.ToString().Substring(0, Sb.ToString().Length - 1));

            Sb.Append("]}");
            return Sb.ToString();

        }
    }
}