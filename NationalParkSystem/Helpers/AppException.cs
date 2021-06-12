using System;
using System.Globalization;

namespace NationalParkSystem.Helpers
{
  public class AppException : Exception                                                 // this class catches application-specific, unhandled exceptions
  {
    public AppException() : base() {}

    public AppException(string message) : base(message) { }

    public AppException(string message, params object[] args)
        : base(String.Format(CultureInfo.CurrentCulture, message, args))
    {

    }
  }
}