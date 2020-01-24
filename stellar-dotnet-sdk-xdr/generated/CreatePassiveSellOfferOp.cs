// Automatically generated by xdrgen
// DO NOT EDIT or your changes may be overwritten
using System;

namespace stellar_dotnet_sdk.xdr {

// === xdr source ============================================================

//  struct CreatePassiveSellOfferOp
//  {
//      Asset selling; // A
//      Asset buying;  // B
//      int64 amount;  // amount taker gets. if set to 0, delete the offer
//      Price price;   // cost of A in terms of B
//  };

//  ===========================================================================
public class CreatePassiveSellOfferOp  {
  public CreatePassiveSellOfferOp () {}
  public Asset Selling {get; set;}
  public Asset Buying {get; set;}
  public Int64 Amount {get; set;}
  public Price Price {get; set;}

  public static void Encode(XdrDataOutputStream stream, CreatePassiveSellOfferOp encodedCreatePassiveSellOfferOp) {
    Asset.Encode(stream, encodedCreatePassiveSellOfferOp.Selling);
    Asset.Encode(stream, encodedCreatePassiveSellOfferOp.Buying);
    Int64.Encode(stream, encodedCreatePassiveSellOfferOp.Amount);
    Price.Encode(stream, encodedCreatePassiveSellOfferOp.Price);
  }
  public static CreatePassiveSellOfferOp Decode(XdrDataInputStream stream) {
    CreatePassiveSellOfferOp decodedCreatePassiveSellOfferOp = new CreatePassiveSellOfferOp();
    decodedCreatePassiveSellOfferOp.Selling = Asset.Decode(stream);
    decodedCreatePassiveSellOfferOp.Buying = Asset.Decode(stream);
    decodedCreatePassiveSellOfferOp.Amount = Int64.Decode(stream);
    decodedCreatePassiveSellOfferOp.Price = Price.Decode(stream);
    return decodedCreatePassiveSellOfferOp;
  }
}
}
