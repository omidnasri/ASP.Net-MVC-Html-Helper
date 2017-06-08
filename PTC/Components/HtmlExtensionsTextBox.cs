using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace PTC
{
  public static class HtmlExtensionsTextBox
  {
    public static MvcHtmlString BootstrapTextBoxFor<TModel, TValue>(
      this HtmlHelper<TModel> htmlHelper,
      Expression<Func<TModel, TValue>> expression,
      HtmlExtensionsCommon.Html5InputTypes type,    
      object htmlAttributes = null
      ) {
      return HtmlExtensionsTextBox.BootstrapTextBoxFor(htmlHelper,
        expression, type, string.Empty, string.Empty, false, false,
        string.Empty, htmlAttributes);
    }

    public static MvcHtmlString BootstrapTextBoxFor<TModel, TValue>(
      this HtmlHelper<TModel> htmlHelper,
      Expression<Func<TModel, TValue>> expression,
      HtmlExtensionsCommon.Html5InputTypes type,
      string cssClass,
      object htmlAttributes = null
      ) {
      return HtmlExtensionsTextBox.BootstrapTextBoxFor(htmlHelper,
        expression, type, string.Empty, string.Empty, false, false,
        cssClass, htmlAttributes);
    }
    public static MvcHtmlString BootstrapTextBoxFor<TModel, TValue>(
     this HtmlHelper<TModel> htmlHelper,
     Expression<Func<TModel, TValue>> expression,
     HtmlExtensionsCommon.Html5InputTypes type,
     string title,
     string placeholder,
     bool isRequired,
     bool isAutoFocus,
     object htmlAttributes = null
     ) {
      return HtmlExtensionsTextBox.BootstrapTextBoxFor(htmlHelper,
        expression, type, title, placeholder, isRequired, isAutoFocus,
        string.Empty, htmlAttributes);
    }

    public static MvcHtmlString BootstrapTextBoxFor<TModel, TValue>(
      this HtmlHelper<TModel> htmlHelper,
      Expression<Func<TModel, TValue>> expression,
      HtmlExtensionsCommon.Html5InputTypes type,
      string title,
      string placeholder,
      bool isRequired,
      bool isAutoFocus,
      string cssClass,
      object htmlAttributes = null
      ) {
      RouteValueDictionary rvd;

      // Creates the route value dictionary
      rvd = new RouteValueDictionary(
        HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));

      // Add all other attributes below here
      rvd.Add("type", type.ToString());
      if (!string.IsNullOrWhiteSpace(title)) {
        rvd.Add("title", title);
      }
      if (!string.IsNullOrWhiteSpace(placeholder)) {
        rvd.Add("placeholder", placeholder);
      }
      if (isRequired) {
        rvd.Add("required", "required");
      }
      if (isAutoFocus) {
        rvd.Add("autofocus", "autofocus");
      }
      if (string.IsNullOrWhiteSpace(cssClass)) {
        cssClass = "form-control";
      }
      else {
        cssClass = "form-control " + cssClass;
      }
      rvd.Add("class", cssClass);

      return InputExtensions.TextBoxFor(htmlHelper, 
        expression, rvd);
    }
  }
}