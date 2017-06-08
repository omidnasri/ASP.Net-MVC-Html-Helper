using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace PTC
{
  public static class HtmlExtensionsRadioButton
  {
    public static MvcHtmlString BootstrapRadioButtonFor<TModel>(
      this HtmlHelper<TModel> htmlHelper,
      Expression<Func<TModel, bool>> expression,
      string text,
      object htmlAttributes = null) {
      return HtmlExtensionsRadioButton.BootstrapRadioButtonFor(
        htmlHelper, expression, text, string.Empty, false, false, null);
    }

    public static MvcHtmlString BootstrapRadioButtonFor<TModel>(
      this HtmlHelper<TModel> htmlHelper,
      Expression<Func<TModel, bool>> expression,
      string text,
      string title,
      bool isAutoFocus,
      object htmlAttributes = null) {
      return HtmlExtensionsRadioButton.BootstrapRadioButtonFor(
        htmlHelper, expression, text, title, isAutoFocus, false, null);
    }

    public static MvcHtmlString BootstrapRadioButtonFor<TModel>(
      this HtmlHelper<TModel> htmlHelper,
      Expression<Func<TModel, bool>> expression,
      string text,
      string title,
      bool isAutoFocus,
      bool useInline,
      object htmlAttributes = null) {

      StringBuilder sb = new StringBuilder(512);
      RouteValueDictionary rvd;

      rvd = new RouteValueDictionary(
        HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));

      if (string.IsNullOrWhiteSpace(title)) {
        title = text;
      }
      rvd.Add("title", title);
      if (isAutoFocus) {
        rvd.Add("autofocus", "autofocus");
      }

      // Open the RadioButton element
      if (useInline) {
        sb.Append("<label class='radio-inline'>");
      }
      else {
        sb.Append("<div class='radio'>");
        sb.Append("<label>");
      }

      // Build the RadioButton using InputExtensions class
      sb.Append(InputExtensions.RadioButtonFor(
        htmlHelper, expression, rvd));

      // Add the Text
      sb.Append(text);

      // Close the RadioButton element
      if (useInline) {
        sb.Append("</label>");
      }
      else {
        sb.Append("</label>");
        sb.Append("</div>");
      }

      return MvcHtmlString.Create(sb.ToString());
    }
  }
}