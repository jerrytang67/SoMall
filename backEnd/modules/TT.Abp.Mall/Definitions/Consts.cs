namespace TT.Abp.Mall.Definitions
{
    public class MallConsts
    {
        public const string DbTablePrefix = "Mall_";

        public const string DbSchema = null;

        public const int MaxNameLength = 64;

        public const int MaxPhoneLength = 16;

        public const int MaxShortNameLength = 16;

        public const int MaxCodeLength = 32;

        public const int MaxShortDescLength = 255;

        public const int MaxImageLength = 255;

        public const int MaxOrderComentLength = 255;

        public const int MaxComentLength = 1024;

        public const int PayAutoCancelTime = 30 * 60; // 半小时关闭订单(单位:秒)
    }
}