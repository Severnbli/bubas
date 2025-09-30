namespace bubas.Source.Core.Entities;

public class Profile
{
    public long Id { get; set; }
    public long ChatId { get; set; }
    public string? Name { get; set; }
    public ProfileAnnouncement Announcement { get; set; } = new();
    public WeatherData? WeatherData { get; set; }
    public StudentSchedule? Schedule { get; set; }
}