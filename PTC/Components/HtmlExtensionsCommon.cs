using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PTC
{
  public static class HtmlExtensionsCommon
  {
    public enum HtmlButtonTypes
    {
      submit,
      button,
      reset
    }

    public enum Html5InputTypes
    {
      text,
      color,
      date,
      datetime,
      email,
      month,
      number,
      password,
      range,
      search,
      tel,
      time,
      url,
      week
    }

    public static void AddName(TagBuilder tb,
      string name, string id) {

      if (!string.IsNullOrWhiteSpace(name)) {
        name = TagBuilder.CreateSanitizedId(name);

        if (string.IsNullOrWhiteSpace(id)) {
          tb.GenerateId(name);
        }
        else {
          tb.MergeAttribute("id",
            TagBuilder.CreateSanitizedId(id));
        }
      }

      tb.MergeAttribute("name", name);
    }
  }
}