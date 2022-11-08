namespace QandQ.Application.LoginSecurity.Entity
{
    public class AccessToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
