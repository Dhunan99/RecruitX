using RecruitX.Models;
using System.ComponentModel.DataAnnotations;

public class JobSkill
{
    public int JrId { get; set; }
    public int SkillId { get; set; }

    [Required]
    [EnumDataType(typeof(SkillType))]
    public SkillType SkillType { get; set; }

    public JobRequisition JobRequisition { get; set; } = null!;
    public Skill Skill { get; set; } = null!;
}

public enum SkillType
{
    MANDATORY,
    PRIMARY,
    GOOD_TO_HAVE
}