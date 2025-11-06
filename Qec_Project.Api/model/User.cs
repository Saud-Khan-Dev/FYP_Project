using System.ComponentModel.DataAnnotations;

public class User
{

  public int Id { get; set; }


  public string Name { get; set; }


  public string Email { get; set; }


  public string PhoneNumber { get; set; }

  public string PasswordHash { get; set; }

  public string Role { get; set; }

  public string Gender { get; set; }

  public DateTime DateOfJoining { get; set; }

  public bool IsActive { get; set; } = true;
}