namespace FilmDat.App.Services
{
    public interface IMessageDialogService
    {
        MessageDialogResult Show(
            string title,
            string caption,
            MessageDialogButtonConfiguration buttonConfiguration,
            MessageDialogResult defaultResult);
    }
}