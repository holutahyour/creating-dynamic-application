
namespace Application.Core.Domain;

public class PersonalInfoPreference
{
    public FieldPreference FirstName { get; set; } = new FieldPreference { Mandatory = true };
    public FieldPreference LastName { get; set; } = new FieldPreference { Mandatory = true };
    public FieldPreference Email { get; set; } = new FieldPreference { Mandatory = true };
    public FieldPreference Phone { get; set; }
    public FieldPreference Nationality { get; set; }
    public FieldPreference CurrentResidence { get; set; }
    public FieldPreference IdNumber { get; set; }
    public FieldPreference DateOfBirth { get; set; }
    public FieldPreference Gender { get; set; }
}

public class FieldPreference
{
    public bool Mandatory { get; set; }
    public bool Internal { get; set; } = false;
    public bool Hide { get; set; } = false;
}
