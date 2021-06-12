using System;

namespace NationalParkSystem.Authorization
{
  [AttributeUsage(AttributeTargets.Method)]
  public class AllowAnonymousAttribute : Attribute
  { }
}