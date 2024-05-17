namespace Application.Core.Domain;
public class QuestionCollection
{
    public List<Question> Paragraph { get; set; } = new List<Question>();
    public List<Question> Number { get; set; } = new List<Question>();
    public List<Question> YesNo { get; set; } = new List<Question>();
    public List<DropdownQuestion> Dropdown { get; set; } = new List<DropdownQuestion>();
    public List<MultipleChoiceQuestion> MultipleChoice { get; set; } = new List<MultipleChoiceQuestion>();
}

public class Question
{
    public string QuestionText { get; set; }
}

public class DropdownQuestion : Question
{
    public bool EnableOption { get; set; }
    public List<string> Choice { get; set; } = new List<string>();
}

public class MultipleChoiceQuestion : DropdownQuestion
{
    public int MaxChoice { get; set; }
}
