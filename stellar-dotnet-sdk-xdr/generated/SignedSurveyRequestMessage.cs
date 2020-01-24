// Automatically generated by xdrgen
// DO NOT EDIT or your changes may be overwritten
using System;

namespace stellar_dotnet_sdk.xdr {

// === xdr source ============================================================

//  struct SignedSurveyRequestMessage
//  {
//      Signature requestSignature;
//      SurveyRequestMessage request;
//  };

//  ===========================================================================
public class SignedSurveyRequestMessage  {
  public SignedSurveyRequestMessage () {}
  public Signature RequestSignature {get; set;}
  public SurveyRequestMessage Request {get; set;}

  public static void Encode(XdrDataOutputStream stream, SignedSurveyRequestMessage encodedSignedSurveyRequestMessage) {
    Signature.Encode(stream, encodedSignedSurveyRequestMessage.RequestSignature);
    SurveyRequestMessage.Encode(stream, encodedSignedSurveyRequestMessage.Request);
  }
  public static SignedSurveyRequestMessage Decode(XdrDataInputStream stream) {
    SignedSurveyRequestMessage decodedSignedSurveyRequestMessage = new SignedSurveyRequestMessage();
    decodedSignedSurveyRequestMessage.RequestSignature = Signature.Decode(stream);
    decodedSignedSurveyRequestMessage.Request = SurveyRequestMessage.Decode(stream);
    return decodedSignedSurveyRequestMessage;
  }
}
}
