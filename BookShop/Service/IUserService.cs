namespace BookShop.Service
{
    public interface IUserService
    {
        string GetUserId();
        bool IsAuthenticated();
    }
}