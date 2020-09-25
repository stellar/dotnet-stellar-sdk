// Automatically generated by xdrgen
// DO NOT EDIT or your changes may be overwritten

using System;

namespace stellar_dotnet_sdk.xdr
{
// === xdr source ============================================================
//  struct ClaimOfferAtom
//  {
//      // emitted to identify the offer
//      AccountID sellerID; // Account that owns the offer
//      int64 offerID;
//  
//      // amount and asset taken from the owner
//      Asset assetSold;
//      int64 amountSold;
//  
//      // amount and asset sent to the owner
//      Asset assetBought;
//      int64 amountBought;
//  };
//  ===========================================================================
    public class ClaimOfferAtom
    {
        public ClaimOfferAtom()
        {
        }

        public AccountID SellerID { get; set; }
        public Int64 OfferID { get; set; }
        public Asset AssetSold { get; set; }
        public Int64 AmountSold { get; set; }
        public Asset AssetBought { get; set; }
        public Int64 AmountBought { get; set; }

        public static void Encode(XdrDataOutputStream stream, ClaimOfferAtom encodedClaimOfferAtom)
        {
            AccountID.Encode(stream, encodedClaimOfferAtom.SellerID);
            Int64.Encode(stream, encodedClaimOfferAtom.OfferID);
            Asset.Encode(stream, encodedClaimOfferAtom.AssetSold);
            Int64.Encode(stream, encodedClaimOfferAtom.AmountSold);
            Asset.Encode(stream, encodedClaimOfferAtom.AssetBought);
            Int64.Encode(stream, encodedClaimOfferAtom.AmountBought);
        }

        public static ClaimOfferAtom Decode(XdrDataInputStream stream)
        {
            ClaimOfferAtom decodedClaimOfferAtom = new ClaimOfferAtom();
            decodedClaimOfferAtom.SellerID = AccountID.Decode(stream);
            decodedClaimOfferAtom.OfferID = Int64.Decode(stream);
            decodedClaimOfferAtom.AssetSold = Asset.Decode(stream);
            decodedClaimOfferAtom.AmountSold = Int64.Decode(stream);
            decodedClaimOfferAtom.AssetBought = Asset.Decode(stream);
            decodedClaimOfferAtom.AmountBought = Int64.Decode(stream);
            return decodedClaimOfferAtom;
        }
    }
}