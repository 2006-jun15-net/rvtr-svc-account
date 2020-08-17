namespace RVTR.Account.WebApi.ResponseObjects
{
  /// <summary>
  /// Represents the _Message Object_ class
  /// </summary>
  public class MessageObject
  {
    /// <summary>
    /// Used to display a successful repsonse message alongside a status code
    /// </summary>
    public static readonly MessageObject Success = new MessageObject("Success");

    /// <summary>
    /// The _Message Object_ has a message
    /// </summary>
    public string Message { get; set; }

    /// <summary>
    /// The _Message Object_ constructor
    /// </summary>
    /// <param name="message"></param>
    public MessageObject(string message)
    {
      Message = message;
    }
  }
}