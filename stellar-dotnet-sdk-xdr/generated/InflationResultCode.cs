// Automatically generated by xdrgen
// DO NOT EDIT or your changes may be overwritten
using System;
namespace stellar_dotnet_sdk.xdr
{

    // === xdr source ============================================================
    //  enum InflationResultCode
    //  {
    //      // codes considered as "success" for the operation
    //      INFLATION_SUCCESS = 0,
    //      // codes considered as "failure" for the operation
    //      INFLATION_NOT_TIME = -1
    //  };
    //  ===========================================================================
    public class InflationResultCode
    {
        public enum InflationResultCodeEnum
        {
            INFLATION_SUCCESS = 0,
            INFLATION_NOT_TIME = -1,
        }
        public InflationResultCodeEnum InnerValue { get; set; } = default(InflationResultCodeEnum);
        public static InflationResultCode Create(InflationResultCodeEnum v)
        {
            return new InflationResultCode
            {
                InnerValue = v
            };
        }
        public static InflationResultCode Decode(XdrDataInputStream stream)
        {
            int value = stream.ReadInt();
            switch (value)
            {
                case 0: return Create(InflationResultCodeEnum.INFLATION_SUCCESS);
                case -1: return Create(InflationResultCodeEnum.INFLATION_NOT_TIME);
                default:
                    throw new Exception("Unknown enum value: " + value);
            }
        }
        public static void Encode(XdrDataOutputStream stream, InflationResultCode value)
        {
            stream.WriteInt((int)value.InnerValue);
        }
    }
}