namespace BCWilliamsDev.Client.Services.UI.Interfaces
{
    public interface IContactFormService
    {
        bool FormIsOpen();
        event EventHandler? OnFormIsOpenChanged;
    }
}
