namespace RVTR.Account.WebApi.ResponseObjects
{
  /// <summary>
  /// Represents the _Error Object_ class
  /// </summary>
  public class ErrorObject : MessageObject
  {
    /// <summary>
    /// Used to display an error message alongside a status code
    /// </summary>
    public string ErrorMessage { get; set; }

    /// <summary>
    /// The _Error Object_ constructor
    /// </summary>
    /// <param name="message"></param>
    public ErrorObject(string message) : base ("")
    {
      ErrorMessage = message;
    }
  }
}