namespace TT.Abp.VisitorManagement
{
    public class VisitorEnums
    {
        public enum CredentialType
        {
            Default = 0,
            Code = 1,
            Image = 1 << 1,
            IdCard = 1 << 1
        }

        public enum FormItemType
        {
            Input = 0,
            TextArea = 1
        }

        public enum FormTheme
        {
            Default = 0,
            Read = 1,
            Black = 2
        }
    }
}