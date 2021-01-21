using stellar_dotnet_sdk.xdr;
using System;
using System.Text;
using stellar_dotnet_sdk.xdr;
using Int64 = stellar_dotnet_sdk.xdr.Int64;

namespace stellar_dotnet_sdk
{
    /// <summary>
    /// Represents a <see cref="ClawbackOp"/>.
    /// Use <see cref="Builder"/> to create a new ClawbackOperation.
    ///
    /// See also: <see href="https://www.stellar.org/developers/guides/concepts/list-of-operations.html#clawback">Clawback</see>
    /// </summary>
    public class ClawbackOperation : Operation
    {
        private ClawbackOperation(string assetCode, IAccountId from, string amount)
        {
            AssetCode = assetCode ?? throw new ArgumentNullException(nameof(assetCode), "assetCode cannot be null");
            From = from ?? throw new ArgumentNullException(nameof(from), "from cannot be null");
            Amount = amount;
        }

        /// <summary>
        /// The asset code being clawed back.
        /// </summary>
        public string AssetCode { get; }

        /// <summary>
        /// The from account (the account the asset is being clawed back from)
        /// </summary>
        public IAccountId From { get; }

        /// <summary>
        /// The amount of the asset being clawed back.
        /// </summary>
        public string Amount { get; }

        public override OperationThreshold Threshold
        {
            get => OperationThreshold.Medium;
        }

        /// <summary>
        /// Returns the Clawback XDR Operation Body
        /// </summary>
        /// <returns></returns>
        public override xdr.Operation.OperationBody ToOperationBody()
        {
            var op = new ClawbackOp();

            // from
            op.From = From.MuxedAccount;

            // asset
            var asset = new AssetCode();
            if (AssetCode.Length <= 4)
            {
                asset.Discriminant = AssetType.Create(AssetType.AssetTypeEnum.ASSET_TYPE_CREDIT_ALPHANUM4);
                asset.AssetCode4 = new AssetCode4(Util.PaddedByteArray(AssetCode, 4));
            }
            else
            {
                asset.Discriminant = AssetType.Create(AssetType.AssetTypeEnum.ASSET_TYPE_CREDIT_ALPHANUM12);
                asset.AssetCode12 = new AssetCode12(Util.PaddedByteArray(AssetCode, 12));
            }

            op.Asset = asset;

            // amount
            var amount = new Int64();
            amount.InnerValue = ToXdrAmount(Amount);
            op.Amount = amount;

            var body = new xdr.Operation.OperationBody();
            body.Discriminant = OperationType.Create(OperationType.OperationTypeEnum.CLAWBACK);
            body.ClawbackOp = op;
            return body;
        }

        /// <summary>
        ///     Builds Clawback operation.
        /// </summary>
        /// <see cref="ClawbackOperation" />
        public class Builder
        {
            private readonly string _assetCode;
            private readonly IAccountId _from;
            private readonly string _amount;

            private KeyPair _sourceAccount;

            /// <summary>
            /// Builder to build the Clawback Operation given an XDR ClawbackOp
            /// </summary>
            /// <param name="op"></param>
            /// <exception cref="Exception"></exception>
            public Builder(ClawbackOp op)
            {
                switch (op.Asset.Discriminant.InnerValue)
                {
                    case AssetType.AssetTypeEnum.ASSET_TYPE_CREDIT_ALPHANUM4:
                        _assetCode = Encoding.UTF8.GetString(op.Asset.AssetCode4.InnerValue);
                        break;
                    case AssetType.AssetTypeEnum.ASSET_TYPE_CREDIT_ALPHANUM12:
                        _assetCode = Encoding.UTF8.GetString(op.Asset.AssetCode12.InnerValue);
                        break;
                    default:
                        throw new Exception("Unknown asset code");
                }
                _from = MuxedAccount.FromXdrMuxedAccount(op.From);
                _amount = FromXdrAmount(op.Amount.InnerValue);
            }

            /// <summary>
            ///     Creates a new Clawback builder.
            /// </summary>
            ///<param name="assetCode">The asset to clawback.</param>
            ///<param name="from">The account to clawback the asset from.</param>
            ///<param name="amount">The amount to clawback.</param>
            public Builder(string assetCode, IAccountId from, string amount)
            {
                _assetCode = assetCode;
                _from = from;
                _amount = amount;
            }

            /// <summary>
            ///     Set source account of this operation
            /// </summary>
            /// <param name="sourceAccount">Source account</param>
            /// <returns>Builder object so you can chain methods.</returns>
            public Builder SetSourceAccount(KeyPair sourceAccount)
            {
                _sourceAccount = sourceAccount;
                return this;
            }

            /// <summary>
            ///     Builds an operation
            /// </summary>
            public ClawbackOperation Build()
            {
                var operation = new ClawbackOperation(_assetCode, _from, _amount);
                if (_sourceAccount != null)
                    operation.SourceAccount = _sourceAccount;
                return operation;
            }
        }
    }
}
