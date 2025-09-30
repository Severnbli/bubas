using bubas.Source.Core.Enums;

namespace bubas.Source.Core.Entities;

public class StudentSchedule
{
    public long Id { get; set; }
    public StudentScheduleProviders Provider { get; set; } = StudentScheduleProviders.Bsuir;
}