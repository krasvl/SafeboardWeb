namespace SafeboardKernel.ResponseBuilder
{
    internal interface IResponseBuilder
    {
        void AddDanger(string type);
        string[] GetResponse();
        void SetError();
        void SetFileChecked();
    }
}