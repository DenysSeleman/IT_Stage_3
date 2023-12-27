using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace IT_Stage_3
{
    [ServiceContract]
    public interface IServiceDBMS
    {
        [OperationContract]
        bool CreateDB(string dbname);

        [OperationContract]
        bool AddTable(string tname);

        [OperationContract]
        List<string> GetListCNames(int index);

        [OperationContract]
        List<string> GetListCTypes(int index);

        [OperationContract]
        List<List<string>> GetListRows(int index);

        [OperationContract]
        bool AddColumn(int tIndex, string cname, string ctype, string interval);

        [OperationContract]
        bool AddRow(int tIndex);

        [OperationContract]
        bool ChangeValue(string newValue, int tind, int cind, int rind);

        [OperationContract]
        void DeleteRow(int tind, int rind);

        [OperationContract]
        void DeleteColumn(int tind, int cind);

        [OperationContract]
        void DeleteTable(int tind);

        [OperationContract]
        void SaveDB(string path);

        [OperationContract]
        void OpenDB(string path);

        [OperationContract]
        List<string> GetTableNameList();

        [OperationContract]
        string GetDBName();

        [OperationContract]
        bool JoinTables(string t1name, string t2name);
    }
}
