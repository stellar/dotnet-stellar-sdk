// Automatically generated by xdrgen
// DO NOT EDIT or your changes may be overwritten
using System;
namespace stellar_dotnet_sdk.xdr
{

    // === xdr source ============================================================
    //  struct ClaimableBalanceEntry
    //  {
    //      // Unique identifier for this ClaimableBalanceEntry
    //      ClaimableBalanceID balanceID;
    //  
    //      // List of claimants with associated predicate
    //      Claimant claimants<10>;
    //  
    //      // Any asset including native
    //      Asset asset;
    //  
    //      // Amount of asset
    //      int64 amount;
    //  
    //      // reserved for future use
    //      union switch (int v)
    //      {
    //      case 0:
    //          void;
    //      case 1:
    //          ClaimableBalanceEntryExtensionV1 v1;
    //      }
    //      ext;
    //  };
    //  ===========================================================================
    public class ClaimableBalanceEntry
    {
        public ClaimableBalanceEntry() { }
        public ClaimableBalanceID BalanceID { get; set; }
        public Claimant[] Claimants { get; set; }
        public Asset Asset { get; set; }
        public Int64 Amount { get; set; }
        public ClaimableBalanceEntryExt Ext { get; set; }

        public static void Encode(XdrDataOutputStream stream, ClaimableBalanceEntry encodedClaimableBalanceEntry)
        {
            ClaimableBalanceID.Encode(stream, encodedClaimableBalanceEntry.BalanceID);
            int claimantssize = encodedClaimableBalanceEntry.Claimants.Length;
            stream.WriteInt(claimantssize);
            for (int i = 0; i < claimantssize; i++)
            {
                Claimant.Encode(stream, encodedClaimableBalanceEntry.Claimants[i]);
            }
            Asset.Encode(stream, encodedClaimableBalanceEntry.Asset);
            Int64.Encode(stream, encodedClaimableBalanceEntry.Amount);
            ClaimableBalanceEntryExt.Encode(stream, encodedClaimableBalanceEntry.Ext);
        }
        public static ClaimableBalanceEntry Decode(XdrDataInputStream stream)
        {
            ClaimableBalanceEntry decodedClaimableBalanceEntry = new ClaimableBalanceEntry();
            decodedClaimableBalanceEntry.BalanceID = ClaimableBalanceID.Decode(stream);
            int claimantssize = stream.ReadInt();
            decodedClaimableBalanceEntry.Claimants = new Claimant[claimantssize];
            for (int i = 0; i < claimantssize; i++)
            {
                decodedClaimableBalanceEntry.Claimants[i] = Claimant.Decode(stream);
            }
            decodedClaimableBalanceEntry.Asset = Asset.Decode(stream);
            decodedClaimableBalanceEntry.Amount = Int64.Decode(stream);
            decodedClaimableBalanceEntry.Ext = ClaimableBalanceEntryExt.Decode(stream);
            return decodedClaimableBalanceEntry;
        }

        public class ClaimableBalanceEntryExt
        {
            public ClaimableBalanceEntryExt() { }
            public int Discriminant { get; set; } = new int();
            public ClaimableBalanceEntryExtensionV1 V1 { get; set; }
            public static void Encode(XdrDataOutputStream stream, ClaimableBalanceEntryExt encodedClaimableBalanceEntryExt)
            {
                stream.WriteInt((int)encodedClaimableBalanceEntryExt.Discriminant);
                switch (encodedClaimableBalanceEntryExt.Discriminant)
                {
                    case 0:
                        break;
                    case 1:
                        ClaimableBalanceEntryExtensionV1.Encode(stream, encodedClaimableBalanceEntryExt.V1);
                        break;
                }
            }
            public static ClaimableBalanceEntryExt Decode(XdrDataInputStream stream)
            {
                ClaimableBalanceEntryExt decodedClaimableBalanceEntryExt = new ClaimableBalanceEntryExt();
                int discriminant = stream.ReadInt();
                decodedClaimableBalanceEntryExt.Discriminant = discriminant;
                switch (decodedClaimableBalanceEntryExt.Discriminant)
                {
                    case 0:
                        break;
                    case 1:
                        decodedClaimableBalanceEntryExt.V1 = ClaimableBalanceEntryExtensionV1.Decode(stream);
                        break;
                }
                return decodedClaimableBalanceEntryExt;
            }

        }
    }
}
