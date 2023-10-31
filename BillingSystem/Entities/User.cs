using System;
using System.Collections.Generic;

namespace BillingSystem.Entities;

public partial class User
{
    public int Id { get; set; }

    public string? FirstName { get; set; } = null!;

    public string? LastName { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public DateTime EnrollmentDate { get; set; }

    public string? PasswordSalt { get; set; } = null!;
    public string? PrimaryEmail { get; set; }

    public string? SecondaryEmail { get; set; }



}
