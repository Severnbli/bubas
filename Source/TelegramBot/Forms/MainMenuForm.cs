using bubas.Source.Shared.Extensions;
using TelegramBotBase.Args;
using TelegramBotBase.Base;
using TelegramBotBase.DependencyInjection;
using TelegramBotBase.Enums;
using TelegramBotBase.Form;

namespace bubas.Source.TelegramBot.Forms;

public class MainMenuForm : AutoCleanForm
{
    public MainMenuForm()
    {
        DeleteMode = EDeleteMode.OnEveryCall;
        DeleteSide = EDeleteSide.Both;
        
        Init += MainMenuForm_Init;
    }

    private Dictionary<string, Func<Task>> _navigationCases = new();
    private ButtonForm _buttonForm = new();

    private async Task MainMenuForm_Init(object sender, InitEventArgs e)
    {
        _navigationCases.TryAdd("profile", async () =>
        {
            await this.NavigateTo<ProfileForm>();
        });
        _navigationCases.TryAdd("announcement", async () =>
        {
            await this.NavigateTo<AnnouncementForm>();
        });
        _navigationCases.TryAdd("student_schedule", async () =>
        {
            await this.NavigateTo<StudentScheduleForm>();
        });
        _navigationCases.TryAdd("weather_data", async () =>
        {
            await this.NavigateTo<WeatherDataForm>();
        });
        
        _buttonForm.AddButtonRow(
            new ButtonBase("Профіль 👤", new CallbackData("a", "profile").Serialize()),
            new ButtonBase("Апавяшчэнні 🔔", new CallbackData("a", "announcement").Serialize())
            );
        _buttonForm.AddButtonRow(
            new ButtonBase("Заняткі 📚", new CallbackData("a", "student_schedule").Serialize()),
            new ButtonBase("Надвор’е ☀️", new CallbackData("a", "weather_data").Serialize())
        );
        
        await Task.CompletedTask;
    }
    
    public override async Task Action(MessageResult message)
    {
        await message.ProcessCallbackData(_navigationCases);
    }

    public override async Task Render(MessageResult message)
    {
        await Device.Send("Ты ў галоўным меню. Абяры, што хочаш наладзіць.", _buttonForm);
    }
}