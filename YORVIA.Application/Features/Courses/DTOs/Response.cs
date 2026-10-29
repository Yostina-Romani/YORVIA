using System;
using System.Collections.Generic;

using YORVIA.Application.Common;

namespace YORVIA.Application.Features.Courses.DTOs
{
    public class Response<T>
    {
      public  bool Success { get; init; }

       public string Message { get; init; } = string.Empty;
        public ErrorType ErrorType { get; set; } = ErrorType.None;

        public T? Data { get; init; }
    }
}
