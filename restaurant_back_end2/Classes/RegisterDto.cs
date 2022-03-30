namespace restaurant_back_end2.Classes
{
    public class RegisterDto
    {
        public RegisterDto(string fullname, string phone, string password)
        {
            this.fullname = fullname;
            this.phone = phone;
            this.password = password;
        }

        public RegisterDto() { }
        public string fullname { get; set; }
        public string phone { get; set; }
        public string password { get; set; }
    }
}
