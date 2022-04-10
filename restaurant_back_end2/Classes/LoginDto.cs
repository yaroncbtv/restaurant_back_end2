namespace restaurant_back_end2.Classes
{
    public class LoginDto
    {
        public LoginDto(string fullname, string phone, string password)
        {
            this.phone = phone;
            this.password = password;
        }

        public LoginDto() { }
       
        public string phone { get; set; }
        public string password { get; set; }
        public bool stayLogin { get; set; }


    }
}
