using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace FirstLab_DataProtecting
{
    public static class ListOfAccount
    {
        
        public static List<Account> account;
        public static string strLogin;
        public static bool bCheakAdmin = false;
        public static int iCheck = 1;
        //ListOfAccount() { }

        static public void writeFromFileToList()
        {
            string strDataFile = AppDomain.CurrentDomain.BaseDirectory + "DataAccount.dat";
            BinaryReader br = new BinaryReader(File.Open(strDataFile, FileMode.Open));
            account.Clear();

            while (br.PeekChar() >= 0)
            {
                Account newAccount = new Account();
                newAccount.bName = br.ReadString();
                newAccount.bPassword = br.ReadString();
                newAccount.bLock = br.ReadBoolean();
                newAccount.bRestrictionPassword = br.ReadBoolean();
                account.Add(newAccount);
            }
            br.Close();
        }

        static public void writeFromListToFile()
        {
            string strDataFile = AppDomain.CurrentDomain.BaseDirectory + "DataAccount.dat";
            BinaryWriter bw = new BinaryWriter(File.Open(strDataFile, FileMode.Create));

            Account newAccount = new Account();
            for (int i = 0; i < account.Count; i++)
            {
                newAccount = account[i];
                bw.Write(newAccount.bName);
                bw.Write(newAccount.bPassword);
                bw.Write(newAccount.bLock);
                bw.Write(newAccount.bRestrictionPassword);
            }
            bw.Close();
        } 

        static public void CreateFile()
        {
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory + "DataAccount.dat";
            if (!File.Exists(currentDirectory))
            {
                BinaryWriter outBin = new BinaryWriter(File.Open(currentDirectory, FileMode.Create));
                outBin.Write("ADMIN");          // Имя администратора
                outBin.Write("");               // Пароль администратора по умолчанию            
                outBin.Write(false);            // Блокировки нет
                outBin.Write(true); 
                outBin.Close();
            }
        }

        static public int Authorization(string strName, string strPassword)
        {
            for (int i = 0; i < account.Count; i++)
            {
                Account newAccount = new Account();
                newAccount = account[i];
                if (newAccount.bName == strName && newAccount.bPassword == strPassword)
                {
                    strLogin = strName;
                    if (newAccount.bLock == true)
                    {
                        return 2;
                    }
                    else
                    {
                        return 1;
                    }
                }
                
            }
            return 0;
        }

        static public bool Search(string strName)
        {
            for (int i = 0; i < account.Count; i++)
            {
                Account newAccount = new Account();
                newAccount = account[i];
                if (newAccount.bName == strName)
                {
                    return true;
                }
            }
            return false;
        }

        static public bool Restriction(string strPassword)
        {
            char currentChar = '\0';
            bool bCheck = false;
            bool a = false;
            bool b = false;
            bool c = false;

            for (int i = 0; i < strPassword.Length; i++)
            {
                currentChar = Convert.ToChar(strPassword.Substring(i, 1));
                if (char.IsUpper(currentChar))
                {
                    a = true;    
                }
                if (char.IsLower(currentChar))
                {
                    b = true;
                }
                
                if (char.IsPunctuation(currentChar))
                {
                    c = true;    
                }
                
                if (a && b && c)
                {
                    bCheck = true;
                }
            }
            return bCheck;
        }

        static public int Count()
        {
            return account.Count;
        }
    
    }
}
