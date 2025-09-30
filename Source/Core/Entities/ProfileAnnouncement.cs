namespace bubas.Source.Core.Entities;

public class ProfileAnnouncement
{
    public long Id { get; set; }
    public TimeOnly TimeOfAnnouncement { get; set; }
    public int UtcFactor { get; set; }
    public bool IsEnabled { get; set; }
}