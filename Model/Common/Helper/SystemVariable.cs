namespace Model.Common.Helper
{
    public class SystemVariable
    {
        public const string USER_ROLE_RIGHT = "UserRoleRight";
        public const string ACTIVE = "Active";
        public const string INACTIVE = "Inactive";
        public const string YES = "Yes";
        public const string NO = "No";
        public const string EDIT = "Edit";
        public const string COMPANY = "Company";
        public const string PIPE_SEPERATOR = " | ";
        public const string STATUS_ACTIVE = "90001";
        public const string SOURCE_TYPE = "SourceType";
        public const string MAPPING_TYPE = "Mapping";
        public const string DATA_TYPE = "DataType";
        public const string FILE_TYPE = "FileType";
        public const string RECONCILIATION_TYPE = "ReconciliationType";
        public const string IS_PRIMARY = "IsPrimary";
        public const string HOST = "Host";
        public const string PORT = "Port";
        public const string USER_NAME = "UserName";
        public const string PASSWORD = "Password";
        public const string LOCATION = "Location";
        public const string TABLE = "Table";
        public const string DATABSE_NAME = "Database";
        public const string SOURCE_TITLE = "SourceTitle";
        public const string SYSTEM = "System";
        public const string DESIGNATION = "Designation";
        public const string HIERARCHY = "StoreHierarchy";
        public const string DENSITY = "Density";
        public const string STORECLASS = "StoreClass";
        public const string MAPPINGTYPE = "Mapping";
        public const string PAYOUTSOURCE = "PayoutSource";
        public const string PAYOUTTYPE = "PayoutType";
        public const string CONDITIONGATES = "ConditionGates";
        public const string PAIDSTATUS = "PaidStatus";


        public const int AUDITOR_TYPE = 1;
        public const int SCHEDULE_TYPE = 2;
        public const int AUDITLOCATION_TYPE = 3;

        #region TICKET ACTIONS
        public const string INVESTIGATION_OPEN = "open";
        public const string INVESTIGATION_INPROGRESS = "inprogress";
        public const string INVESTIGATION_ONHOLD = "onhold";
        public const string INVESTIGATION_RESOLVE = "resolved";
        public const string INVESTIGATION_CLOSE = "close";
        public const string INVESTIGATION_TRANSFER = "transfer";
        #endregion

        #region BUTTON ACTION TEXT
        public const string INVESTIGATIONOPEN = "open";
        public const string INVESTIGATIONINPROGRESS = "in progress";
        public const string INVESTIGATIONASSIGN = "assign";
        public const string INVESTIGATIONONHOLD = "on hold";
        public const string INVESTIGATIONRESOLVE = "resolve";
        public const string INVESTIGATIONNOTRESOLVE = "not resolve";
        public const string INVESTIGATIONCOMMENT = "comment";
        public const string INVESTIGATIONTRANSFER = "transferred";
        public const string INVESTIGATIONPENDING = "pending";
        #endregion

        #region Operator

        public const string EQUAL = "eq";
        public const string NOT_EQUAL = "neq";
        public const string GREATER_THEN = "gt";
        public const string LESS_THEN = "lt";
        public const string GREATER_THEN_EQUAL = "gte";
        public const string LESS_THEN_EQUAL = "lte";
        public const string START_WITH = "startswith";
        public const string END_WITH = "endswith";
        public const string CONTAIN = "contains";
        public const string DOES_NOT_CONTAIN = "doesnotcontain";

        #endregion

        #region AuditList object Ids
        public const string AUDIT_LIST_FORM = "AUD001Frm001";
        public const string AUDIT_LIST_OBJECTID = "AUD001Frm001Sec001";
        public const string CREATE_AUDIT_OBJECTID = "AUD001Frm001Sec001Act001";
        public const string ADD_AUDIT_OBJECTID = "AUD001Frm001Sec001Act002";
        public const string EDIT_AUDIT_OBJECTID = "AUD001Frm001Sec001Act003";

        #endregion

        #region Home
        public const string HOME_FORM = "INVSYS001Frm001";
        #endregion

        #region Comment Text on Actions
        public const string Action_Comment = "<b> started working</b>";
        public const string Action_OnHold = "<b> held </b> with comments:";
        public const string Action_Assign = "<b> held </b> with comments:";
        public const string Action_Defer = "<b> Deferred </b> with comments:";
        public const string Action_Resolve = "<b> Resolved </b> with comments:";
        public const string Action_Close = "<b> Closed </b> with comments:";
        public const string Action_NotResolve = "<b> Not Resolved </b> with comments:";
        public const string Action_Escalate = "<b> held </b> with comments:";
        public const string Action_Transfer = "{0} <b> transferred </b> this ticket to <b>' + {1} + '</b> with comments:";
        #endregion

        #region Select2 Objects

        public const string EmailUrl = "/Form/GetforEmailTemplate";
        public const string LocationApiUrl = "/Investigation/BindLocations";
        public const string ConsultantSupervisorApiUrl = "/Investigation/BindSupervisor";
        public const string SupportPartnerApiUrl = "/Investigation/BindSupportPartner";
        #endregion

        #region Event_Codes for notification sending
        public static string SendEmailResult = "EVT_0004";
        #endregion


        #region ERROR MESSAGE

        public const string SUPPORT_MESSAGE = "Something Went Wrong.";
        public const string HEADER_NOT_MATCH = "Column Does Not Match";
        public const string SOURCE_NOT_FOUND = "Source not found";
        public const string TABLE_ERROR = "Table not created";
        public const string SOURCE_EXIST = "File is already exist! Do you want to overwrite it?";
        public const string DUPLICATE_COLUMNS = "Duplicate or Missing Column Found!";
        public const string FILE_NOT_FOUND = "File not Found!";
        public const string MISSING_FILE = "Some Files are Missing!";
        public const string HEADER_NOT_FOUND = "Please save this header against the Structure first!";
        #endregion
    }
}
