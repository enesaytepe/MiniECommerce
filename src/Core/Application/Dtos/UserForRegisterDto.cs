namespace Application.Dtos;

/// <summary>
/// Data Transfer Object for user registration.
/// </summary>
public class UserForRegisterDto : IDto
{
    /// <summary>
    /// Gets or sets the email of the user.
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Gets or sets the username of the user.
    /// </summary>
    public string UserName { get; set; }

    /// <summary>
    /// Gets or sets the password of the user.
    /// </summary>
    public string Password { get; set; }

    /// <summary>
    /// Gets or sets the first name of the user.
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// Gets or sets the last name of the user.
    /// </summary>
    public string LastName { get; set; }
}
