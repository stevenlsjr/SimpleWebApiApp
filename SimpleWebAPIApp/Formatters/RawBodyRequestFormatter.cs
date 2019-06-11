using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;

namespace SimpleWebAPIApp.Formatters
{
  public class RawBodyRequestFormatter : InputFormatter
  {
    public RawBodyRequestFormatter()
    {
      SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/plain"));
      SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/markdown"));
    }

    protected override bool CanReadType(Type type)
    {
      if (type == typeof(byte[]))
      {
        return true;
      }
      return false;
    }

     

    public override async Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context)
    {
      var request = context.HttpContext.Request;
      using (var reader = new StreamReader(request.Body))
      {
        var content = await reader.ReadToEndAsync();
        return await InputFormatterResult.SuccessAsync(Encoding.UTF8.GetBytes(content));
      }
    }
  }
}