/*******************************************************************************
* Copyright (C) AspxPet.Com
* 
* Author: DUWENINK
* Create Date: 09/04/2015 11:47:14
* Description: Automated building by service@aspxpet.com 
* 
* Revision History:
* Date         Author               Description
*
*********************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;


namespace DUWENINK.Core.Infrastructure.Extentions
{
    /// <summary>
    ///     枚举扩展方法类
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// 获取描述
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetDescriptionForEnum(this object value)
        {
            try
            {
                if (value == null) return string.Empty;
                var type = value.GetType();
                var field = type.GetField(Enum.GetName(type, value));

                if (field == null) return value.ToString();

                var des = CustomAttributeData.GetCustomAttributes(type.GetMember(field.Name)[0]);

                return des.AnyOne() && des[0].ConstructorArguments.AnyOne()
                    ? des[0].ConstructorArguments[0].Value.ToString()
                    : value.ToString();
            }
            catch
            {
                return string.Empty;
            }
        }


        // Get the value of the description attribute if the   
        // enum has one, otherwise use the value.  
        public static string GetDescription<TEnum>(this TEnum value)
        {
            var fi = value.GetType().GetField(value.ToString());

            if (fi != null)
            {
                var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attributes.Length > 0)
                {
                    return attributes[0].Description;
                }
            }

            return value.ToString();
        }

        /// <summary>
        /// Build a select list for an enum
        /// </summary>
        public static SelectList SelectListFor<T>() where T : struct
        {
            Type t = typeof(T);
            return !t.IsEnum ? null
                : new SelectList(BuildSelectListItems(t), "Value", "Text");
        }

        /// <summary>
        /// Build a select list for an enum with a particular value selected 
        /// </summary>
        public static SelectList SelectListFor<T>(T selected) where T : struct
        {
            Type t = typeof(T);
            return !t.IsEnum ? null
                : new SelectList(BuildSelectListItems(t), "Value", "Text", selected.ToString());
        }

        private static IEnumerable<SelectListItem> BuildSelectListItems(Type t)
        {
            return Enum.GetValues(t)
                .Cast<Enum>()
                .Select(e => new SelectListItem { Value = Convert.ToInt32(e).ToString(), Text = e.GetDescription() });
        }
    }
}