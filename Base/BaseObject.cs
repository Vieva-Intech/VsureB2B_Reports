using System;
using System.Data.Common;
using System.Text;
using System.IO;
using System.Collections.Specialized;
using System.Web;
using System.Data;


namespace VSureB2b_Reports.Base
{
    public class BaseObject
    {
        private System.String m_CreatedBy;
        private System.DateTime m_CreatedOn;
        private System.String m_ModifiedBy;
        private System.DateTime? m_ModifiedOn;
        private int m_Key;
        private DQ m_Query;

        public BaseObject()
        {
        }
        //ticket no 200958
        public int Key
        {
            get { return m_Key; }
            set { m_Key = value; }
        }


        public DQ Query { get { return m_Query; } protected set { m_Query = value; } }

        public virtual System.String CreatedBy
        {
            get { return m_CreatedBy; }
            set { m_CreatedBy = value; }
        }

        public virtual System.DateTime CreatedOn
        {
            get { return m_CreatedOn; }
            set { m_CreatedOn = value; }
        }

        public virtual System.String ModifiedBy
        {
            get { return m_ModifiedBy; }
            set { m_ModifiedBy = value; }
        }

        public virtual System.DateTime? ModifiedOn
        {
            get { return m_ModifiedOn; }
            set { m_ModifiedOn = value; }
        }
    }
}
