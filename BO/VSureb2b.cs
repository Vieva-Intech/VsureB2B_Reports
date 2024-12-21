using Dapper;
using Logging;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.Xml;
using VSureB2b_Reports.Base;
using VSureB2b_Reports.ImportExport;

namespace VSureB2b_Reports.BO
{
    public class VSureb2b : BaseObject
    {
        private string m_ClaimNo;
        private string m_ReferenceNo;
        private DateTime? m_ClaimDate;
        private string m_ClaimType;
        private string m_PolicyNo;
        private string m_SurveyPlace;
        private string m_RepairPlaceType;
        private DateTime? m_AllotmentSurveyDate;
        private DateTime? m_SurveyDate;
        private string m_SurveyZone;
        private string m_InsurerContact;
        private string m_CCESubmitter;
        private string m_SurveyUser;
        private string m_PoliceDetails;
        private decimal? m_Towing;
        private decimal? m_ServiceTax;
        private decimal m_VAT;
        private decimal? m_WCT;
        private decimal m_HandlingCharges;
        private string m_SurveyCompanyCode;
        private string m_SurveyType;
        private string m_VehicleType;
        private string m_VB64;
        private decimal m_VoluntaryExcess;
        private decimal m_Discounts;
        private string m_AuthoSurveyor;
        private string m_ColorStatus;
        private int m_RegionID;
        private string m_ServiceProviderID;
        private DateTime? m_ModifiedDate;
        private string m_UniqueID;
        private string m_PerformerID;
        private string m_PayMode;
        private decimal m_ImposedExcess;
        private string m_DepreciationMode;
        private string m_PrimaryTypeOfLoss;
        private bool m_FastTrack;
        private string m_GarageName;
        private string m_CustomerSAPCode;
        private string m_GarageSAPCode;
        private bool m_CashLess;
        private decimal? m_NCBAmount;
        private int m_ClaimRegion;
        private int m_BrnId;
        private DateTime? m_LeadDueDate;
        private string m_ReferenceUserID;
        private bool m_LockClaim;
        private double m_Latitude;
        private double m_Longitude;
        private DateTime? m_CreatedDate;
        private string m_CreatedBy;
        private string m_ModifiedBy;
        private string m_SubAgencyCode;
        private decimal additionalExcess;
        private string paintRule;
        private string depOnPaint;
        private int settlementDetail;
        private string nilDepreciation;
        private string _Uniqueid;

        #region Properties

        public virtual string ClaimNo
        {
            get { return m_ClaimNo; }
            set { m_ClaimNo = value; }
        }

        public virtual string ReferenceNo
        {
            get { return m_ReferenceNo; }
            set { m_ReferenceNo = value; }
        }

        public virtual DateTime? ClaimDate
        {
            get { return m_ClaimDate; }
            set { m_ClaimDate = value; }
        }

        public virtual string ClaimType
        {
            get { return m_ClaimType; }
            set { m_ClaimType = value; }
        }

        public virtual string PolicyNo
        {
            get { return m_PolicyNo; }
            set { m_PolicyNo = value; }
        }

        public virtual string SurveyPlace
        {
            get { return m_SurveyPlace; }
            set { m_SurveyPlace = value; }
        }

        public virtual string RepairPlaceType
        {
            get { return m_RepairPlaceType; }
            set { m_RepairPlaceType = value; }
        }

        public virtual DateTime? AllotmentSurveyDate
        {
            get { return m_AllotmentSurveyDate; }
            set { m_AllotmentSurveyDate = value; }
        }

        public virtual DateTime? SurveyDate
        {
            get { return m_SurveyDate; }
            set { m_SurveyDate = value; }
        }

        public virtual string SurveyZone
        {
            get { return m_SurveyZone; }
            set { m_SurveyZone = value; }
        }

        public virtual string InsurerContact
        {
            get { return m_InsurerContact; }
            set { m_InsurerContact = value; }
        }

        public virtual string CCESubmitter
        {
            get { return m_CCESubmitter; }
            set { m_CCESubmitter = value; }
        }

        public string SurveyUser
        {
            get { return m_SurveyUser; }
            set { m_SurveyUser = value; }
        }

        public virtual string PoliceDetails
        {
            get { return m_PoliceDetails; }
            set { m_PoliceDetails = value; }
        }

        public virtual decimal? Towing
        {
            get { return m_Towing; }
            set { m_Towing = value; }
        }

        public virtual decimal? ServiceTax
        {
            get { return m_ServiceTax; }
            set { m_ServiceTax = value; }
        }

        public virtual decimal VAT
        {
            get { return m_VAT; }
            set { m_VAT = value; }
        }

        public virtual decimal? WCT
        {
            get { return m_WCT; }
            set { m_WCT = value; }
        }

        public virtual decimal HandlingCharges
        {
            get { return m_HandlingCharges; }
            set { m_HandlingCharges = value; }
        }

        public virtual string SurveyCompanyCode
        {
            get { return m_SurveyCompanyCode; }
            set { m_SurveyCompanyCode = value; }
        }

        public virtual string SurveyType
        {
            get { return m_SurveyType; }
            set { m_SurveyType = value; }
        }

        public virtual string VehicleType
        {
            get { return m_VehicleType; }
            set { m_VehicleType = value; }
        }

        public virtual string VB64
        {
            get { return m_VB64; }
            set { m_VB64 = value; }
        }

        public virtual decimal VoluntaryExcess
        {
            get { return m_VoluntaryExcess; }
            set { m_VoluntaryExcess = value; }
        }

        public virtual decimal Discounts
        {
            get { return m_Discounts; }
            set { m_Discounts = value; }
        }

        public virtual string AuthoSurveyor
        {
            get { return m_AuthoSurveyor; }
            set { m_AuthoSurveyor = value; }
        }

        public virtual string ColorStatus
        {
            get { return m_ColorStatus; }
            set { m_ColorStatus = value; }
        }
        public virtual int RegionID
        {
            get { return m_RegionID; }
            set { m_RegionID = value; }
        }
        public virtual string ServiceProviderID
        {
            get { return m_ServiceProviderID; }
            set { m_ServiceProviderID = value; }
        }
        public virtual DateTime? ModifiedDate
        {
            get { return m_ModifiedDate; }
            set { m_ModifiedDate = value; }
        }
        public virtual string UniqueID
        {
            get { return m_UniqueID; }
            set { m_UniqueID = value; }
        }
        public virtual string PerformerCMID
        {
            get { return m_PerformerID; }
            set { m_PerformerID = value; }
        }
        public virtual string PayMode
        {
            get { return m_PayMode; }
            set { m_PayMode = value; }
        }
        public decimal ImposedExcess
        {
            get { return m_ImposedExcess; }
            set { m_ImposedExcess = value; }
        }
        public string DepreciationMode
        {
            get { return m_DepreciationMode; }
            set { m_DepreciationMode = value; }
        }
        public string PrimaryTypeOfLoss
        {
            get { return m_PrimaryTypeOfLoss; }
            set { m_PrimaryTypeOfLoss = value; }
        }
        public bool FastTrack
        {
            get { return m_FastTrack; }
            set { m_FastTrack = value; }
        }

        public string GarageName
        {
            get { return m_GarageName; }
            set { m_GarageName = value; }
        }

        public string CustomerSAPCode
        {
            get { return m_CustomerSAPCode; }
            set { m_CustomerSAPCode = value; }
        }

        public string GarageSAPCode
        {
            get { return m_GarageSAPCode; }
            set { m_GarageSAPCode = value; }
        }

        public bool CashLess
        {
            get { return m_CashLess; }
            set { m_CashLess = value; }
        }
        public decimal? NCBAmount
        {
            get { return m_NCBAmount; }
            set { m_NCBAmount = value; }
        }

        public int ClaimRegion
        {
            get { return m_ClaimRegion; }
            set { m_ClaimRegion = value; }
        }

        //Present in MotoPI

        public int BrnId
        {
            get { return m_BrnId; }
            set { m_BrnId = value; }
        }
        public DateTime? LeadDueDate
        {
            get { return m_LeadDueDate; }
            set { m_LeadDueDate = value; }
        }
        public string ReferenceUserID
        {
            get { return m_ReferenceUserID; }
            set { m_ReferenceUserID = value; }
        }

        //End
        //Changes for Android      

        public bool LockClaim
        {
            get { return m_LockClaim; }
            set { m_LockClaim = value; }
        }
        public double Latitude
        {
            get { return m_Latitude; }
            set { m_Latitude = value; }
        }

        public double Longitude
        {
            get { return m_Longitude; }
            set { m_Longitude = value; }
        }
        public virtual DateTime? CreatedDate
        {
            get { return m_CreatedDate; }
            set { m_CreatedDate = value; }
        }

        public string CreatedBy
        {
            get { return m_CreatedBy; }
            set { m_CreatedBy = value; }
        }
        public string ModifiedBy
        {
            get { return m_ModifiedBy; }
            set { m_ModifiedBy = value; }
        }
        //sanjay
        public string SubAgencyCode
        {
            get { return m_SubAgencyCode; }
            set { m_SubAgencyCode = value; }
        }
        public decimal AdditionalExcess
        {
            get { return additionalExcess; }
            set { additionalExcess = value; }
        }
        public string PaintRule
        {
            get { return paintRule; }
            set { paintRule = value; }
        }
        public string DepOnPaint
        {
            get { return depOnPaint; }
            set { depOnPaint = value; }
        }
        public int SettlementDetail
        {
            get { return settlementDetail; }
            set { settlementDetail = value; }
        }
        public string NilDepreciation
        {
            get { return nilDepreciation; }
            set { nilDepreciation = value; }
        }
        public string Uniqueid
        {
            get
            {
                return _Uniqueid;
            }
            set
            {
                _Uniqueid = value;
            }
        }
        #endregion Properties

        public virtual void Clear()
        {

            m_ClaimNo = String.Empty;
            m_ReferenceNo = null;
            m_ClaimDate = null;
            m_ClaimType = null;
            m_PolicyNo = null;
            m_SurveyPlace = null;
            m_RepairPlaceType = null;
            m_AllotmentSurveyDate = null;
            m_SurveyDate = null;
            m_SurveyZone = null;
            m_InsurerContact = null;
            m_CCESubmitter = null;
            m_SurveyUser = null;
            m_PoliceDetails = null;
            m_Towing = null;
            m_ServiceTax = null;
            m_VAT = 0;
            m_WCT = null;
            m_HandlingCharges = 0;
            m_SurveyCompanyCode = String.Empty;
            m_SurveyType = null;
            m_VehicleType = String.Empty;
            m_VB64 = null;
            m_VoluntaryExcess = 0;
            m_Discounts = 0;
            m_AuthoSurveyor = String.Empty;
            m_ColorStatus = null;
            m_RegionID = 0;
            m_ServiceProviderID = null;
            m_ModifiedDate = null;
            m_UniqueID = null;
            m_PerformerID = null;
            m_PayMode = null;
            m_ImposedExcess = 0;
            m_DepreciationMode = null;
            m_PrimaryTypeOfLoss = null;
            m_FastTrack = false;
            m_GarageName = null;
            m_CashLess = false;
            m_CustomerSAPCode = null;
            m_GarageSAPCode = null;
            m_CashLess = false;
            m_NCBAmount = 0;
            m_ClaimRegion = 0;

            //Present in MotoPI

            m_BrnId = 0;
            m_LeadDueDate = null;
            m_ReferenceUserID = string.Empty;
            //End

            //Changes for Android            
            m_LockClaim = false;
            m_Latitude = 0;
            m_Longitude = 0;
            m_CreatedDate = null;
            m_CreatedBy = string.Empty;
            m_CreatedDate = null;
            m_ModifiedBy = string.Empty;
            //sanjay
            m_SubAgencyCode = string.Empty;
            //End
            Key = 0;
        }
    }
}
