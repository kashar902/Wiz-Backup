using Newtonsoft.Json;

namespace App.Wiz.Common.Helper;

public static class JsonHelper
{
    public static async Task<T?> DeserializeObjectAsync<T>(string jsonString)
    {
        return await Task.Run(() => {
            return JsonConvert.DeserializeObject<T>(jsonString);
        });
    }
}
