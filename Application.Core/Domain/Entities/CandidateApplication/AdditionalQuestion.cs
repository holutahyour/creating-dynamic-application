namespace Application.Core.Domain;

public class AdditionalQuestion
{
    public List<ParagraphAnswer> Paragraph { get; set; }
    public List<NumberAnswer> Number { get; set; }
    public List<YesNoAnswer> YesNo { get; set; }
    public List<DropdownAnswer> Dropdown { get; set; }
    public List<MultipleChoiceAnswer> MultipleChoice { get; set; }
    public List<DateAnswer> Date { get; set; }
}


public class ParagraphAnswer : Question
{
    public string Answer { get; set; }
}

public class NumberAnswer : Question
{
    public int Answer { get; set; }
}

public class YesNoAnswer : Question
{
    public bool Answer { get; set; }
}

public class DropdownAnswer : Question
{
    public string Answer { get; set; }
    public bool ChooseOther { get; set; }
    public string Other { get; set; }
}

public class MultipleChoiceAnswer : Question
{
    public List<string> Answer { get; set; } = new List<string>();

    public int MaxChoice { get; set; }
}

public class DateAnswer : Question
{
    public DateTime Answer { get; set; }
}