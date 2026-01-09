namespace RifqiAmmarR.ApiSkeleton.Application.Services.Masters.Constants;

public static class ApiEndPoint
{
    public const string AuthorizePolicy = "RequireManager";
    public static class V1
    {
        public static class RouteTemplateFor
        {
            //public const string Segment = $"{nameof(V1)}/{nameof(Masters)}";
            public static class Masters
            {
                public static class Roles
                {
                    //public const string Segment = nameof(Roles);
                    public const string RoleId = "{RoleId}";
                }
            }
        }
    }
}
