namespace App.Wiz.Token.Service;

public interface IJwtParams
{
    string GetJwtKey();
    string GetJwtAudiance();
    string GetJwtIssuer();
}

public class JwtParams : IJwtParams
{
    private static readonly string key = "ByYM000OLlMQG6VVVp1OH7Xzyr7gHuw1qvUC5dcGt3SNM";
    private static readonly string audiance = "https://localhost:31568/";
    private static readonly string issuer = "https://localhost:31568/";



    public string GetJwtKey()
    {
        return key;
    }
    public string GetJwtAudiance()
    {
        return audiance;
    }
    public string GetJwtIssuer()
    {
        return issuer;
    }


}


