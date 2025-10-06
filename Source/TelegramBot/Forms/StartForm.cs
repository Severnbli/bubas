using bubas.Source.Shared.Extensions;
using TelegramBotBase.Args;
using TelegramBotBase.Base;
using TelegramBotBase.DependencyInjection;
using TelegramBotBase.Enums;
using TelegramBotBase.Form;

namespace bubas.Source.TelegramBot.Forms;

public class StartForm : AutoCleanForm
{
    public StartForm()
    {
        DeleteMode = EDeleteMode.None;
        DeleteSide = EDeleteSide.BotOnly;

        Init += StartForm_Init;
    }

    private Dictionary<string, Func<Task>> _navigationCases = new();
    private ButtonForm _buttonForm = new();

    private async Task StartForm_Init(object sender, InitEventArgs e)
    {
        _navigationCases.TryAdd("letsgo", async () =>
        {
            await this.NavigateTo<MainMenuForm>();
        });
        
        _buttonForm.AddButtonRow(new ButtonBase("За справу!", new CallbackData("a", "letsgo").Serialize()));
        
        await Task.CompletedTask;
    }

    public override async Task Action(MessageResult message)
    {
        await message.ProcessCallbackData(_navigationCases);
    }
    
    public override async Task Render(MessageResult message)
    {
        await Device.Send("Прывітанне, сябрук! ⚡ Усё гатова для старту – за табой чарга!", _buttonForm);
    }
}