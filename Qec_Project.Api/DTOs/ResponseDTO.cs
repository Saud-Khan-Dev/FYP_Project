
namespace Qec_Project.Api.model;

public class ResponseDTO
{
  public bool success { get; set; }
  public string message { get; set; }
  
  public ResponseDTO(bool success, string message)
  {
    this.success = success;
    this.message = message;
  }

}
