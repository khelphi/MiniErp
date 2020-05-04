
using System;
using System.ComponentModel;
using System.Reflection;


namespace MiniErp.Application.Helpers
{
    public static class EnumExtencions
    {

        public static string Description(this Enum value)
        {
            if (value == null)
                throw new ArgumentException("value");

            var _attribute = value.GetCustomAttribute<DescriptionAttribute>();

            if (_attribute == null)
                return value.ToString();

            return _attribute.Description;
        }

        public static T GetCustomAttribute<T>(this Enum value) where T : Attribute
        {
            if (value == null)
                throw new ArgumentException("value");

            var _x = value.GetType().GetField(value.ToString());

            return _x.GetCustomAttribute<T>();
        }


        public static MetaError ErrorDescription(this Enum errorItem, params object[] parameters)
        {
            string description = errorItem.Description();
            string message = string.Empty;

            if (parameters == null)
                message = description;
            else
                message = string.Format(description, parameters);

            int code = (int)Convert.ChangeType(errorItem, errorItem.GetTypeCode());
            var _x = errorItem.ToString().Split("_");

            int? protocolCode = null;

            if (_x.Length >= 3 && !string.IsNullOrWhiteSpace(_x[2]))
                if (int.TryParse(_x[2], out int _y))
                    protocolCode = _y;

            return new MetaError(new ErrorReturn()
            {
                Code = code.ToString("000"),
                Message = message
            },
            protocolCode
            );
        }

        public static MetaError ErrorDescription(this object errorItem, params object[] parameters)
        {
            return ErrorDescription((Enum)errorItem, parameters);
        }

    }
}
