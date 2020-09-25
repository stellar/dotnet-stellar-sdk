// Automatically generated by xdrgen
// DO NOT EDIT or your changes may be overwritten

using System;

namespace stellar_dotnet_sdk.xdr
{
// === xdr source ============================================================
//  struct AccountEntry
//  {
//      AccountID accountID;      // master public key for this account
//      int64 balance;            // in stroops
//      SequenceNumber seqNum;    // last sequence number used for this account
//      uint32 numSubEntries;     // number of sub-entries this account has
//                                // drives the reserve
//      AccountID* inflationDest; // Account to vote for during inflation
//      uint32 flags;             // see AccountFlags
//  
//      string32 homeDomain; // can be used for reverse federation and memo lookup
//  
//      // fields used for signatures
//      // thresholds stores unsigned bytes: [weight of master|low|medium|high]
//      Thresholds thresholds;
//  
//      Signer signers<MAX_SIGNERS>; // possible signers for this account
//  
//      // reserved for future use
//      union switch (int v)
//      {
//      case 0:
//          void;
//      case 1:
//          AccountEntryExtensionV1 v1;
//      }
//      ext;
//  };
//  ===========================================================================
    public class AccountEntry
    {
        public AccountEntry()
        {
        }

        public AccountID AccountID { get; set; }
        public Int64 Balance { get; set; }
        public SequenceNumber SeqNum { get; set; }
        public Uint32 NumSubEntries { get; set; }
        public AccountID InflationDest { get; set; }
        public Uint32 Flags { get; set; }
        public String32 HomeDomain { get; set; }
        public Thresholds Thresholds { get; set; }
        public Signer[] Signers { get; set; }
        public AccountEntryExt Ext { get; set; }

        public static void Encode(XdrDataOutputStream stream, AccountEntry encodedAccountEntry)
        {
            AccountID.Encode(stream, encodedAccountEntry.AccountID);
            Int64.Encode(stream, encodedAccountEntry.Balance);
            SequenceNumber.Encode(stream, encodedAccountEntry.SeqNum);
            Uint32.Encode(stream, encodedAccountEntry.NumSubEntries);
            if (encodedAccountEntry.InflationDest != null)
            {
                stream.WriteInt(1);
                AccountID.Encode(stream, encodedAccountEntry.InflationDest);
            }
            else
            {
                stream.WriteInt(0);
            }

            Uint32.Encode(stream, encodedAccountEntry.Flags);
            String32.Encode(stream, encodedAccountEntry.HomeDomain);
            Thresholds.Encode(stream, encodedAccountEntry.Thresholds);
            int signerssize = encodedAccountEntry.Signers.Length;
            stream.WriteInt(signerssize);
            for (int i = 0; i < signerssize; i++)
            {
                Signer.Encode(stream, encodedAccountEntry.Signers[i]);
            }

            AccountEntryExt.Encode(stream, encodedAccountEntry.Ext);
        }

        public static AccountEntry Decode(XdrDataInputStream stream)
        {
            AccountEntry decodedAccountEntry = new AccountEntry();
            decodedAccountEntry.AccountID = AccountID.Decode(stream);
            decodedAccountEntry.Balance = Int64.Decode(stream);
            decodedAccountEntry.SeqNum = SequenceNumber.Decode(stream);
            decodedAccountEntry.NumSubEntries = Uint32.Decode(stream);
            int InflationDestPresent = stream.ReadInt();
            if (InflationDestPresent != 0)
            {
                decodedAccountEntry.InflationDest = AccountID.Decode(stream);
            }

            decodedAccountEntry.Flags = Uint32.Decode(stream);
            decodedAccountEntry.HomeDomain = String32.Decode(stream);
            decodedAccountEntry.Thresholds = Thresholds.Decode(stream);
            int signerssize = stream.ReadInt();
            decodedAccountEntry.Signers = new Signer[signerssize];
            for (int i = 0; i < signerssize; i++)
            {
                decodedAccountEntry.Signers[i] = Signer.Decode(stream);
            }

            decodedAccountEntry.Ext = AccountEntryExt.Decode(stream);
            return decodedAccountEntry;
        }

        public class AccountEntryExt
        {
            public AccountEntryExt()
            {
            }

            public int Discriminant { get; set; } = new int();

            public AccountEntryExtensionV1 V1 { get; set; }

            public static void Encode(XdrDataOutputStream stream, AccountEntryExt encodedAccountEntryExt)
            {
                stream.WriteInt((int) encodedAccountEntryExt.Discriminant);
                switch (encodedAccountEntryExt.Discriminant)
                {
                    case 0:
                        break;
                    case 1:
                        AccountEntryExtensionV1.Encode(stream, encodedAccountEntryExt.V1);
                        break;
                }
            }

            public static AccountEntryExt Decode(XdrDataInputStream stream)
            {
                AccountEntryExt decodedAccountEntryExt = new AccountEntryExt();
                int discriminant = stream.ReadInt();
                decodedAccountEntryExt.Discriminant = discriminant;
                switch (decodedAccountEntryExt.Discriminant)
                {
                    case 0:
                        break;
                    case 1:
                        decodedAccountEntryExt.V1 = AccountEntryExtensionV1.Decode(stream);
                        break;
                }

                return decodedAccountEntryExt;
            }
        }
    }
}