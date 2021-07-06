namespace CRUD_DAL.Extensions
{
  public static class StringExtensions
  {
    public static string GetStoredProcedureName(this string fullName) =>
      fullName.Substring(0, fullName.LastIndexOf("Async"));
  }
}
