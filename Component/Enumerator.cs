using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Component
{
    public enum Status
    {
        [Description("Active")]
        Active = 90001,
        [Description("Inactive")]
        Inactive = 90002
    }
    public enum Action
    {
        [Description("Create")]
        Create = 1,
        [Description("Update")]
        Update = 2,
        [Description("Delete")]
        Delete = 3,
        [Description("View")]
        View = 4

    }
    public enum PrivilegeStatus
    {
        [Description("Enabled")]
        Enable = 120001,
        [Description("Disabled")]
        Disable = 120002,
        [Description("Hidden")]
        Hidden = 120003,
        [Description("Full Access")]
        FullAccess = 120004,
        [Description("Read Only")]
        ReadOnly = 120005
    }
    public enum ApplicationObjectType
    {
        [Description("Form")]
        Form = 20001,
        [Description("Section")]
        Section = 20002,
        [Description("Field")]
        Field = 20003,
        [Description("Action")]
        Action = 20004,
        [Description("Group")]
        Group = 20005,
        [Description("Master Menu Group")]
        MasterMenuGroup = 20006,
        [Description("Menu Group")]
        MenuGroup = 20007,
        [Description("Sub Menu")]
        SubMenu = 20008,
    }

    public enum AuditorType
    {
        [Description("User")]
        User = 100001,
        [Description("UserGroup")]
        UserGroup = 100002,
    }

    public enum ScheduleType
    {
        [Description("User")]
        User = 200001,
        [Description("UserGroup")]
        UserGroup = 200002,
    }

    public enum AuditLocationType
    {
        [Description("Assigned")]
        Assigned = 300001,
        [Description("All")]
        All = 300002,
    }

    public enum AuditResult
    {
        [Description("Pending")]
        Pending = 400001,
        [Description("Failed")]
        Failed = 400002,
        [Description("Passed")]
        Passed = 400003,

    }

    public enum AuditStatus
    {
        [Description("Open")]
        Open = 500001,
        [Description("Expired")]
        Expired = 500002,
        [Description("Draft")]
        Draft = 500003,
        [Description("Completed")]
        Completed = 500004,
        [Description("Reschedule Requested")]
        RescheduleRequested = 500005,
        [Description("Reset")]
        Reset = 500006, 
        [Description("Cancelled")]
        Cancelled = 500007

    }

    public enum ITPriority
    {
        [Description("1-2 days")]
        High = 10001,
        [Description("2-3 days")]
        Medium = 10002,
        [Description("3-4 days")]
        Low = 10003

    }
    public enum ITStatus
    {
        [Description("Open")]
        Open = 20001,
        [Description("Pending")]
        Pending = 20002,
        [Description("Resolved")]
        Resolved = 20003,
        [Description("Closed")]
        Closed = 20004,
        [Description("Transferred")]
        Transferred = 20005
    }
    public enum ITRole
    {
        [Description("Supervisor")]
        Supervisor = 30001,
        [Description("Support Partner")]
        SupportPartner = 30002,
        [Description("Both")]
        Both = 30003,
        [Description("Moderator")]
        Moderator = 30004
    }
    public enum UploadFrom
    {
        [Description("Investigation Generate")]
        InvestigationGenerate = 21001,
        [Description("Investigation Detail")]
        InvestigationDetail = 21002
    }

    public static class Enumerator
    {
        public static string GetDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

            if (attributes != null && attributes.Any())
            {
                return attributes.First().Description;
            }

            return value.ToString();
        }
        public static List<EnumDropdownBinder> GetEnumValuesWithDescription<T>(this Type type) where T : struct, IConvertible
        {
            if (!type.IsEnum)
            {
                throw new ArgumentException("T must be an enumerated type");
            }
            return type.GetEnumValues()
                    .OfType<T>()
                    .Select(x => new EnumDropdownBinder { Value = Convert.ToInt32(x).ToString(), Text = (x as Enum).GetEnumDescription() }
                    ).ToList();
        }
        public static string GetEnumDescription(this Enum enumValue)
        {
            string output = null;
            Type type = enumValue.GetType();
            FieldInfo fi = type.GetField(enumValue.ToString());
            var attrs = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];
            if (attrs.Length > 0) output = attrs[0].Description;
            return output;
        }
    }
    public partial class EnumDropdownBinder
    {
        public string Value { get; set; }
        public string Text { get; set; }
    }
}
