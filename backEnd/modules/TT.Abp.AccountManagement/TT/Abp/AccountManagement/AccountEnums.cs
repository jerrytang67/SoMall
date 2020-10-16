namespace TT.Abp.AccountManagement
{
    public class AccountEnums
    {
        public enum RealNameInfoState : byte
        {
            未认证 = 0,
            个人认证 = 1,
            企业认证 = 2
        }

        public enum RealNameInfoType : byte
        {
            个人 = 0,
            企业 = 1
        }
    }
}