namespace RifqiAmmarR.ApiSkeleton.Application.Services.Authentications.Constants;

public static class ApiEndPoint
{
    public static class V1
    {
        public static class Authentications  
        {
            public const string Segment = $"{nameof(V1)}/{nameof(Authentications)}";
            public static class RouteTemplateFor
            {
                //public const string CategoryId = "{CategoryId}";
                public const string Register = nameof(Register);
                public const string Login = nameof(Login);
                public const string Logut = nameof(Logout);
                public const string Me = nameof(Me);
                public const string RefreshToken = nameof(RefreshToken);
            }
        }
    }
}
