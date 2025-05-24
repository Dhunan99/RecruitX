using RecruitX.Models;
using System.ComponentModel.DataAnnotations;

public class JobSkill
{
    public int JobSkill_Id { get; set; }
    public int SkillId { get; set; }

    public string SkillType { get; set; } = "Pending";

    public JobRequisition JobRequisition { get; set; } = null!;
    public Skill Skill { get; set; } = null!;
}

