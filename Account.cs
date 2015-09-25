using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProtecting
{
  
    public class Account
    {
        public string bName;
        public string bPassword;
        public bool bLock;
        public bool bRestrictionPassword;
        public Account() { } 
    }

    public Account(
    	string bName;
        string bPassword;
        bool bLock;
        bool bRestrictionPassword;
    	)
    {
        this.bName = bName;
        this.bPassword = bPassword;
        this.bLock = bLock;
        this.bRestrictionPassword = bRestrictionPassword; 
    }

    public string bName
		{
			get
			{
				return this.bName;
			}
			set
			{
				this.bName = value;
			}
		}
		
    public string bPassword
		{
			get
			{
				return this.bPassword;
			}
			set
			{
				this.bPassword = value;
			}
		}

	public bool bLock
		{
			get
			{
				return this.bLock;
			}
			set
			{
				this.bLock = value;
			}
		} 
		
	public bool bRestrictionPassword
		{
			get
			{
				return this.bRestrictionPassword;
			}
			set
			{
				this.bRestrictionPassword = value;
			}
		}           
}
