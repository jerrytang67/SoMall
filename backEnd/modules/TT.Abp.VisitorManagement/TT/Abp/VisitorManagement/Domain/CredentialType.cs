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
            TextArea = 1,
            Radio = 2
        }

        public enum FormTheme
        {
            red = 0,
            black = 1,
            green = 2
        }
    }
}