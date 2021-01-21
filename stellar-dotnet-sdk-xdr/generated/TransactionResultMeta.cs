// Automatically generated by xdrgen
// DO NOT EDIT or your changes may be overwritten
using System;
namespace stellar_dotnet_sdk.xdr
{

    // === xdr source ============================================================
    //  struct TransactionResultMeta
    //  {
    //      TransactionResultPair result;
    //      LedgerEntryChanges feeProcessing;
    //      TransactionMeta txApplyProcessing;
    //  };
    //  ===========================================================================
    public class TransactionResultMeta
    {
        public TransactionResultMeta() { }
        public TransactionResultPair Result { get; set; }
        public LedgerEntryChanges FeeProcessing { get; set; }
        public TransactionMeta TxApplyProcessing { get; set; }

        public static void Encode(XdrDataOutputStream stream, TransactionResultMeta encodedTransactionResultMeta)
        {
            TransactionResultPair.Encode(stream, encodedTransactionResultMeta.Result);
            LedgerEntryChanges.Encode(stream, encodedTransactionResultMeta.FeeProcessing);
            TransactionMeta.Encode(stream, encodedTransactionResultMeta.TxApplyProcessing);
        }
        public static TransactionResultMeta Decode(XdrDataInputStream stream)
        {
            TransactionResultMeta decodedTransactionResultMeta = new TransactionResultMeta();
            decodedTransactionResultMeta.Result = TransactionResultPair.Decode(stream);
            decodedTransactionResultMeta.FeeProcessing = LedgerEntryChanges.Decode(stream);
            decodedTransactionResultMeta.TxApplyProcessing = TransactionMeta.Decode(stream);
            return decodedTransactionResultMeta;
        }
    }
}
