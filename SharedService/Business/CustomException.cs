namespace SharedService.Business
{
    public class CustomException : Exception
    {
        public string UnmatchData(string error)
        {
            return error;
        }
    }
}
