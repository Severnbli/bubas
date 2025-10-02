using TelegramBotBase.Base;
using TelegramBotBase.Form;

namespace bubas.Source.TelegramBot.Forms;

public class StartForm : FormBase
{
    public override Task Render(MessageResult message)
    {
        Device.Send("Hello World!");
        
        return Task.CompletedTask;
    }
}