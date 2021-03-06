﻿// Automatically generated by xdrgen
// DO NOT EDIT or your changes may be overwritten
using System;
namespace stellar_dotnet_sdk.xdr
{

    // === xdr source ============================================================
    //  enum TrustLineFlags
    //  {
    //      // issuer has authorized account to perform transactions with its credit
    //      AUTHORIZED_FLAG = 1,
    //      // issuer has authorized account to maintain and reduce liabilities for its
    //      // credit
    //      AUTHORIZED_TO_MAINTAIN_LIABILITIES_FLAG = 2
    //  };
    //  ===========================================================================
    public class TrustLineFlags
    {
        public enum TrustLineFlagsEnum
        {
            AUTHORIZED_FLAG = 1,
            AUTHORIZED_TO_MAINTAIN_LIABILITIES_FLAG = 2,
        }
        public TrustLineFlagsEnum InnerValue { get; set; } = default(TrustLineFlagsEnum);
        public static TrustLineFlags Create(TrustLineFlagsEnum v)
        {
            return new TrustLineFlags
            {
                InnerValue = v
            };
        }
        public static TrustLineFlags Decode(XdrDataInputStream stream)
        {
            int value = stream.ReadInt();
            switch (value)
            {
                case 1: return Create(TrustLineFlagsEnum.AUTHORIZED_FLAG);
                case 2: return Create(TrustLineFlagsEnum.AUTHORIZED_TO_MAINTAIN_LIABILITIES_FLAG);
                default:
                    throw new Exception("Unknown enum value: " + value);
            }
        }
        public static void Encode(XdrDataOutputStream stream, TrustLineFlags value)
        {
            stream.WriteInt((int)value.InnerValue);
        }
    }
}
