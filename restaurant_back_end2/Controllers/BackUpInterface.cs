namespace restaurant_back_end2.Controllers
{
    public interface IserviceResApp
    {
        string backUp();
    }
    public class BackUpInterface : IserviceResApp
    {
        public string backUp()
        {
            throw new System.NotImplementedException();
        }
    }
}
