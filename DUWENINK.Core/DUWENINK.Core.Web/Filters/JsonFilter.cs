using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace DUWENINK.Core.Web.Filters
{
    /// <summary>
    /// Json配置
    /// </summary>
    public class JsonFilter:ActionFilterAttribute
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public override void OnResultExecuting(ResultExecutingContext context)
         {
            if (context.HttpContext.Request.Path.HasValue)
            {
                if (context.HttpContext.Request.Path.Value.ToLower().IndexOf(".inside.") < 0)
                {
                    if (context.Result is FileContentResult || context.Result is EmptyResult)
                    {
                        return;
                    }
                    if (context.Result is ObjectResult)
                    {
                        var objectResult = context.Result as ObjectResult;
                        var settings = new JsonSerializerSettings()
                        {
                            ContractResolver = new NullToEmptyStringResolver(),
                            DateFormatString = "yyyy-MM-dd HH:mm"
                        };
                        context.Result = new JsonResult(new { data = objectResult.Value }, settings);
                    }
                    else if (context.Result is ViewResult)
                    {

                    }
                    else
                    {
                        context.Result = new ObjectResult(new { data = new { } });
                    }

                    //JsonResult jsonResult = context.Result switch
                    //{
                    //    ObjectResult _ => new JsonResult(new { data = (context.Result as ObjectResult).Value }, new JsonSerializerSettings()
                    //    {
                    //        ContractResolver = new NullToEmptyStringResolver(),
                    //        DateFormatString = "yyyy-MM-dd HH:mm"
                    //    }),



                    //};
                    //context.Result = jsonResult;
                   
                };


                }
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class NullToEmptyStringResolver : Newtonsoft.Json.Serialization.DefaultContractResolver
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="memberSerialization"></param>
        /// <returns></returns>
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            return type.GetProperties()
                    .Select(p => {
                        var jp = base.CreateProperty(p, memberSerialization);
                        jp.ValueProvider = new NullToEmptyStringValueProvider(p);
                        return jp;
                    }).ToList();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class NullToEmptyStringValueProvider : IValueProvider
    {
        PropertyInfo _MemberInfo;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="memberInfo"></param>
        public NullToEmptyStringValueProvider(PropertyInfo memberInfo)
        {
            _MemberInfo = memberInfo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public object GetValue(object target)
        {
            object result = _MemberInfo.GetValue(target);
            if (result == null) result = "";
            return result;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="target"></param>
        /// <param name="value"></param>
        public void SetValue(object target, object value)
        {
            _MemberInfo.SetValue(target, value);
        }


    }

