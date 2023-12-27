using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace IT_Stage_3
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class ServiceDBMS : IServiceDBMS
    {
        DataBase db;

        public bool CreateDB(string dbname)
        {
            if (dbname.Equals("")) return false;

            db = new DataBase(dbname);
            return true;
        }

        public bool AddTable(string tname)
        {
            if (tname.Equals("")) return false;
            if (db == null) return false;
            foreach (Table table in db.dbTablesList)
                if (table.tName.Equals(tname))
                    return false;

            db.dbTablesList.Add(new Table(tname));
            return true;
        }

        public List<string> GetListCNames(int index)
        {
            List<string> res = new List<string>();
            foreach (Column column in db.dbTablesList[index].tColumnsList)
                res.Add(column.cName);
            return res;
        }

        public List<string> GetListCTypes(int index)
        {
            List<string> res = new List<string>();
            foreach (Column column in db.dbTablesList[index].tColumnsList)
                res.Add(column.typeName);
            return res;
        }

        public List<List<string>> GetListRows(int index)
        {
            List<List<string>> res = new List<List<string>>();
            foreach (Row row in db.dbTablesList[index].tRowsList)
                res.Add(row.rValuesList);
            return res;
        }

        public bool AddColumn(int tIndex, string cname, string ctype, string interval)
        {
            if (db == null) return false;
            if (db.dbTablesList.Count <= 0) return false;
            if (cname == "") return false;
            foreach (Column column in db.dbTablesList[tIndex].tColumnsList)
                if (column.cName.Equals(cname))
                    return false;

            if (ctype == "CharInvl" || ctype == "String(CharInvl)")
            {
                char[] separators = new char[] { ' ' };
                List<string> words = interval.Split(separators, StringSplitOptions.RemoveEmptyEntries).ToList();

                if (words.Count != 2)
                    return false;
                if (words[0].Length != 1 || words[1].Length != 1)
                    return false;

                char s1 = words[0][0], s2 = words[1][0];
                if (s1 > s2) return false;
                db.dbTablesList[tIndex].tColumnsList.Add(new Column(cname, ctype, s1, s2));
            }
            else
                db.dbTablesList[tIndex].tColumnsList.Add(new Column(cname, ctype));

            for (int i = 0; i < db.dbTablesList[tIndex].tRowsList.Count; ++i)
                db.dbTablesList[tIndex].tRowsList[i].rValuesList.Add("");
            return true;
        }

        public bool AddRow(int tIndex)
        {
            if (db == null) return false;
            if (db.dbTablesList.Count <= 0) return false;
            if (db.dbTablesList[tIndex].tColumnsList.Count <= 0) return false;

            db.dbTablesList[tIndex].tRowsList.Add(new Row());
            for (int i = 0; i < db.dbTablesList[tIndex].tColumnsList.Count; ++i)
            {
                db.dbTablesList[tIndex].tRowsList.Last().rValuesList.Add("");
            }
            return true;
        }

        public bool ChangeValue(string newValue, int tind, int cind, int rind)
        {
            if (newValue == "" || db.dbTablesList[tind].tColumnsList[cind].cType.Validation(newValue))
            {
                db.dbTablesList[tind].tRowsList[rind].rValuesList[cind] = newValue;
                return true;
            }

            return false;
        }

        public void DeleteRow(int tind, int rind)
        {
            db.dbTablesList[tind].tRowsList.RemoveAt(rind);
        }

        public void DeleteColumn(int tind, int cind)
        {
            db.dbTablesList[tind].tColumnsList.RemoveAt(cind);
            for (int i = 0; i < db.dbTablesList[tind].tRowsList.Count; ++i)
            {
                db.dbTablesList[tind].tRowsList[i].rValuesList.RemoveAt(cind);
            }
        }

        public void DeleteTable(int tind)
        {
            db.dbTablesList.RemoveAt(tind);
        }

        char sep = '$';
        char space = '#';
        public void SaveDB(string path)
        {
            StreamWriter sw = new StreamWriter(path);

            sw.WriteLine(db.dbName);
            foreach (Table t in db.dbTablesList)
            {
                sw.WriteLine(sep);
                sw.WriteLine(t.tName);
                foreach (Column c in t.tColumnsList)
                {
                    sw.Write(c.cName + space);
                }
                sw.WriteLine();
                foreach (Column c in t.tColumnsList)
                {
                    sw.Write(c.typeName + space);
                }
                sw.WriteLine();
                foreach (Row r in t.tRowsList)
                {
                    foreach (string s in r.rValuesList)
                    {
                        sw.Write(s + space);
                    }
                    sw.WriteLine();
                }
            }

            sw.Close();
        }

        public void OpenDB(string path)
        {
            StreamReader sr = new StreamReader(path);
            string file = sr.ReadToEnd();
            string[] parts = file.Split(sep);

            db = new DataBase(parts[0]);

            for (int i = 1; i < parts.Length; ++i)
            {
                parts[i] = parts[i].Replace("\r\n", "\r");
                List<string> buf = parts[i].Split('\r').ToList();
                buf.RemoveAt(0);
                buf.RemoveAt(buf.Count - 1);

                if (buf.Count > 0)
                {
                    db.dbTablesList.Add(new Table(buf[0]));
                }
                if (buf.Count > 2)
                {
                    string[] cname = buf[1].Split(space);
                    string[] ctype = buf[2].Split(space);
                    int length = cname.Length - 1;
                    for (int j = 0; j < length; ++j)
                    {
                        db.dbTablesList[i - 1].tColumnsList.Add(new Column(cname[j], ctype[j]));
                    }

                    for (int j = 3; j < buf.Count; ++j)
                    {
                        db.dbTablesList[i - 1].tRowsList.Add(new Row());
                        List<string> values = buf[j].Split(space).ToList();
                        values.RemoveAt(values.Count - 1);
                        db.dbTablesList[i - 1].tRowsList.Last().rValuesList.AddRange(values);
                    }
                }
            }

            sr.Close();
        }

        public List<string> GetTableNameList()
        {
            List<string> res = new List<string>();
            foreach (Table t in db.dbTablesList)
                res.Add(t.tName);
            return res;
        }

        public string GetDBName()
        {
            return db.dbName;
        }

        public string NameJoinedTable(string t1name, string t2name)
        {
            string name = t1name + "_" + t2name;
            List<string> tableNameList = GetTableNameList();
            string tName = name;
            int i = 1;
            while (tableNameList.Contains(tName))
            {
                tName = name + " (" + i + ")";
                i++;
            }
            return tName;
        }

        public bool JoinTables(string t1name, string t2name)
        {
            if (db == null) return false;
            int indt1 = -1, indt2 = -1;
            for (int i = 0; i < db.dbTablesList.Count; i++)
            {
                if (db.dbTablesList[i].tName == t1name)
                    indt1 = i;
                if (db.dbTablesList[i].tName == t2name)
                    indt2 = i;
            }
            if (indt1 == -1 || indt2 == -1) return false;

            List<int> indsColT1 = new List<int>(), indsColT2 = new List<int>();

            for (int i = 0; i < db.dbTablesList[indt1].tColumnsList.Count; i++)
            {
                for (int j = 0; j < db.dbTablesList[indt2].tColumnsList.Count; j++)
                {
                    if (db.dbTablesList[indt1].tColumnsList[i].cName == db.dbTablesList[indt2].tColumnsList[j].cName &&
                        db.dbTablesList[indt1].tColumnsList[i].typeName == db.dbTablesList[indt2].tColumnsList[j].typeName)
                    {
                        indsColT1.Add(i);
                        indsColT2.Add(j);
                    }
                }
            }

            string tName = NameJoinedTable(t1name, t2name);
            db.dbTablesList.Add(new Table(tName));
            int tIndex = db.dbTablesList.Count - 1;

            for (int i = 0; i < db.dbTablesList[indt1].tColumnsList.Count; i++)
            {
                string cname = db.dbTablesList[indt1].tColumnsList[i].cName;
                string ctype = db.dbTablesList[indt1].tColumnsList[i].typeName;
                db.dbTablesList[tIndex].tColumnsList.Add(new Column(cname, ctype));
            }

            for (int i = 0; i < db.dbTablesList[indt2].tColumnsList.Count; i++)
            {
                if (indsColT2.Contains(i)) continue;
                string cname = db.dbTablesList[indt2].tColumnsList[i].cName;
                string ctype = db.dbTablesList[indt2].tColumnsList[i].typeName;
                db.dbTablesList[tIndex].tColumnsList.Add(new Column(cname, ctype));
            }

            List<int> indsRowT1 = new List<int>(), indsRowT2 = new List<int>();
            for (int i = 0; i < db.dbTablesList[indt1].tRowsList.Count; i++)
            {
                for (int j = 0; j < db.dbTablesList[indt2].tRowsList.Count; j++)
                {
                    bool f = true;
                    for (int k = 0; k < indsColT1.Count; k++)
                    {
                        int indColT1 = indsColT1[k];
                        int indColT2 = indsColT2[k];
                        string valueT1 = db.dbTablesList[indt1].tRowsList[i].rValuesList[indColT1];
                        string valueT2 = db.dbTablesList[indt2].tRowsList[j].rValuesList[indColT2];
                        if (valueT1 != valueT2 || valueT1 == "")
                        {
                            f = false;
                            break;
                        }
                    }
                    if (f && indsColT1.Count > 0)
                    {
                        indsRowT1.Add(i);
                        indsRowT2.Add(j);
                    }
                }
            }

            for (int i = 0; i < db.dbTablesList[indt1].tRowsList.Count; i++)
            {
                db.dbTablesList[tIndex].tRowsList.Add(new Row());
                for (int j = 0; j < db.dbTablesList[indt1].tRowsList[i].rValuesList.Count; j++)
                {
                    string value = db.dbTablesList[indt1].tRowsList[i].rValuesList[j];
                    db.dbTablesList[tIndex].tRowsList.Last().rValuesList.Add(value);
                }
                if (indsRowT1.Contains(i))
                {
                    int ind = indsRowT1.IndexOf(i);
                    int k = indsRowT2[ind];
                    for (int j = 0; j < db.dbTablesList[indt2].tRowsList[k].rValuesList.Count; j++)
                    {
                        if (indsColT2.Contains(j)) continue;
                        string value = db.dbTablesList[indt2].tRowsList[k].rValuesList[j];
                        db.dbTablesList[tIndex].tRowsList.Last().rValuesList.Add(value);
                    }
                }
                else
                {
                    int k = db.dbTablesList[tIndex].tColumnsList.Count - db.dbTablesList[indt1].tColumnsList.Count;
                    for (int j = 0; j < k; j++)
                        db.dbTablesList[tIndex].tRowsList.Last().rValuesList.Add("");
                }
            }

            for (int i = 0; i < db.dbTablesList[indt2].tRowsList.Count; i++)
            {
                if (indsRowT2.Contains(i)) continue;
                db.dbTablesList[tIndex].tRowsList.Add(new Row());
                int border = db.dbTablesList[indt1].tColumnsList.Count;
                for (int j = 0; j < border; j++)
                {
                    if (indsColT1.Contains(j))
                    {
                        int ind = indsColT1.IndexOf(j);
                        int k = indsColT2[ind];
                        string value = db.dbTablesList[indt2].tRowsList[i].rValuesList[k];
                        db.dbTablesList[tIndex].tRowsList.Last().rValuesList.Add(value);
                    }
                    else
                        db.dbTablesList[tIndex].tRowsList.Last().rValuesList.Add("");
                }
                for (int j = 0; j < db.dbTablesList[indt2].tColumnsList.Count; j++)
                {
                    if (indsColT2.Contains(j)) continue;
                    string value = db.dbTablesList[indt2].tRowsList[i].rValuesList[j];
                    db.dbTablesList[tIndex].tRowsList.Last().rValuesList.Add(value);
                }
            }

            return true;
        }
    }
}
