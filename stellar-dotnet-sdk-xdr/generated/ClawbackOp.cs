// Automatically generated by xdrgen
// DO NOT EDIT or your changes may be overwritten
using System;
namespace stellar_dotnet_sdk.xdr
{

    // === xdr source ============================================================
    //  struct ClawbackOp
    //  {
    //      AssetCode asset;
    //      MuxedAccount from;
    //      int64 amount;
    //  };
    //  ===========================================================================
    public class ClawbackOp
    {
        public ClawbackOp() { }
        public AssetCode Asset { get; set; }
        public MuxedAccount From { get; set; }
        public Int64 Amount { get; set; }

        public static void Encode(XdrDataOutputStream stream, ClawbackOp encodedClawbackOp)
        {
            AssetCode.Encode(stream, encodedClawbackOp.Asset);
            MuxedAccount.Encode(stream, encodedClawbackOp.From);
            Int64.Encode(stream, encodedClawbackOp.Amount);
        }
        public static ClawbackOp Decode(XdrDataInputStream stream)
        {
            ClawbackOp decodedClawbackOp = new ClawbackOp();
            decodedClawbackOp.Asset = AssetCode.Decode(stream);
            decodedClawbackOp.From = MuxedAccount.Decode(stream);
            decodedClawbackOp.Amount = Int64.Decode(stream);
            return decodedClawbackOp;
        }
    }
}