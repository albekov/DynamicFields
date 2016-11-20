using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Builders;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using DynamicFields.Data.Model;
using JetBrains.Annotations;

namespace DynamicFields.Helpers
{
    public static class FormsExtensions
    {
        public static DynamicMvcForm<T> BeginDynamicForm<T>(
            this HtmlHelper helper,
            [AspMvcAction] string actionName,
            [AspMvcController] string controllerName,
            DynamicForm dynamicForm,
            T data,
            object routeValues)
        {
            var mvcForm = helper.BeginForm(actionName, controllerName, routeValues, FormMethod.Post);

            var context = helper.ViewContext;

            var form = new DynamicMvcForm<T>(context, mvcForm, dynamicForm, data);
            return form;
        }

        public static void DynamicFields<T>(DynamicMvcForm<T> form)
        {
            form.Fields();
        }
    }

    public class DynamicMvcForm<T> : MvcForm
    {
        private ViewContext _viewContext;
        private MvcForm _mvcForm;
        private readonly DynamicForm _dynamicForm;
        private readonly T _data;

        public DynamicMvcForm(ViewContext viewContext, MvcForm mvcForm, DynamicForm dynamicForm, T data)
            : base(viewContext)
        {
            _viewContext = viewContext;
            _mvcForm = mvcForm;
            _dynamicForm = dynamicForm;
            _data = data;
        }

        public ViewContext ViewContext { get; set; }

        public MvcForm Form { get; set; }

        public string Name => _dynamicForm.Name;

        public string Description => _dynamicForm.Description;

        public IEnumerable<MvcField> Fields()
        {
            var mvcFields = _dynamicForm.FormFields
                .Select(f => new MvcField(_dynamicForm, f))
                .ToList();
            return mvcFields;
        }
    }

    public class MvcField
    {
        private readonly DynamicForm _dynamicForm;
        private readonly DynamicFormField _field;

        public bool IsHeadline => _field.FieldType == FieldType.Headline;

        public string Label => _field.Label;

        public MvcField(DynamicForm dynamicForm, DynamicFormField field)
        {
            _dynamicForm = dynamicForm;
            _field = field;
        }

        public MvcHtmlString Render(object htmlAttributes = null)
        {
            switch (_field.FieldType)
            {
                case FieldType.Headline:
                    return MvcHtmlString.Create(_field.Label);

                case FieldType.Field:
                    var tag = new TagBuilder("input");
                    var attributes = (IDictionary<string, object>)HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
                    tag.MergeAttributes(attributes);

                    var fieldName = $"field_{_dynamicForm.Id}_{_field.FieldId}";

                    tag.Attributes["name"] = fieldName;
                    tag.Attributes["id"] = fieldName;

                    return new MvcHtmlString(tag.ToString(TagRenderMode.Normal));

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}