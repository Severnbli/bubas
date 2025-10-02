using TelegramBotBase.Base;
using TelegramBotBase.DependencyInjection;
using TelegramBotBase.Enums;
using TelegramBotBase.Form;

namespace bubas.Source.TelegramBot.Forms;

public class StartForm : AutoCleanForm
{
    public StartForm()
    {
        DeleteMode = EDeleteMode.OnLeavingForm;
        DeleteSide = EDeleteSide.BotOnly;
    }

    public override async Task Action(MessageResult message)
    {
        var call = message.GetData<CallbackData>();
        await message.ConfirmAction();

        if (call == null) return;
        
        message.Handled = true;

        switch (call.Value)
        {
            case "letsgo":
            {
                await this.NavigateTo<MainMenuForm>();
                break;
            }
            default:
            {
                message.Handled = false;
                break;
            }
        }
    }
    
    public override Task Render(MessageResult message)
    {
        var btn = new ButtonForm();
        
        btn.AddButtonRow(new ButtonBase("За справу!", new CallbackData("a", "letsgo").Serialize()));
        
        Device.Send("Прывітанне, сябрук! ⚡ Усё гатова для старту – за табой чарга!", btn);
        
        return Task.CompletedTask;
    }
}