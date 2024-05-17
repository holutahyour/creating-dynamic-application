
namespace Application.Core.Domain;

public class ProgramApplication : BaseEntity
{
    public string ProgramTitle { get; set; }
    public string ProgramDescription { get; set; }
    public PersonalInfoPreference PersonalInfoPreference { get; set; } = new PersonalInfoPreference();
    public QuestionCollection Questions { get; set; }
}

