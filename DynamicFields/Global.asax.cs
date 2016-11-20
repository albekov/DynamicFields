﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using DynamicFields.Controllers;
using DynamicFields.Data.Model;
using DynamicFields.Data.Services.Fields;
using DynamicFields.Models;

namespace DynamicFields
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            InitMapper();

            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        private static void InitMapper()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<DynamicField, FieldViewModel>();

                config.CreateMap<DynamicField, EditFieldViewModel>();
                config.CreateMap<EditFieldViewModel, DynamicField>();

                config.CreateMap<FieldInfoViewModel, DynamicFieldInfo>();
                config.CreateMap<DynamicFieldInfo, FieldInfoViewModel>();

                config.CreateMap<DynamicFormField, FormFieldViewModel>();
                config.CreateMap<FormFieldViewModel, DynamicFormField>();

                config.CreateMap<DynamicForm, FormViewModel>();

                config.CreateMap<DynamicForm, EditFormViewModel>();
                config.CreateMap<EditFormViewModel, DynamicForm>();
            });
        }
    }
}
