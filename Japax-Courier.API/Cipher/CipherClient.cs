using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Japax_Courier.API.Cipher;
using Japax_Courier_DB.DBModels.CommonModels.Response;

namespace Japax_Courier.API.Cipher
{
    public class CipherClient
    {
        private string DeviceID;
        private string PrivateKey;
        public CipherClient(string deviceId, string SecretKey)
        {
            DeviceID = deviceId;
            PrivateKey = SecretKey;
        }
        public async Task<CipherPayload> EncryptText(string PayLoad)
        {
            try
            {
                CipherAgent _cipherAgent = new CipherAgent();
                HexGenerator _hexGenerator = new HexGenerator();
                NonceGenerator _NonceGenerator = new NonceGenerator();
                string _Nonce = await _NonceGenerator.keyGenerate(DeviceID);

                string secretKey = _hexGenerator.Generate_StringToHex(PrivateKey + _Nonce);

                string result = await _cipherAgent.encryptData(PayLoad, secretKey);

                if(result == "Error")
                {
                    CipherPayload _Payload = new CipherPayload
                    {
                        Status = "Failed"
                    };

                    return await Task.FromResult(_Payload);
                } else
                {
                    CipherPayload _Payload = new CipherPayload
                    {
                        Status = "Success",
                        PayLoad = result
                    };

                    return await Task.FromResult(_Payload);
                }                
            } catch (Exception ex)
            {
                CipherPayload _Payload = new CipherPayload
                {
                    Status = "Failed",
                    Error = new ErrorModel
                    {
                        ErrorCode = "505",
                        InnerException = (ex.InnerException != null) ? ex.InnerException.Message.ToString() : "",
                        Message = (ex.Message != null) ? ex.Message.ToString() : "",
                        StackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : ""
                    }
                };
                return await Task.FromResult(_Payload);
            }
        }
        public async Task<CipherPayload> DecryptText(string PayLoad)
        {
            try
            {
                CipherAgent _cipherAgent = new CipherAgent();
                HexGenerator _hexGenerator = new HexGenerator();
                NonceGenerator _NonceGenerator = new NonceGenerator();
                string _Nonce = await _NonceGenerator.keyGenerate(DeviceID);

                string secretKey = _hexGenerator.Generate_StringToHex(PrivateKey + _Nonce);

                string result = await _cipherAgent.decryptData(PayLoad, secretKey);

                CipherPayload _Payload = new CipherPayload
                {
                    Status = "Success",
                    PayLoad = result
                };

                return await Task.FromResult(_Payload);
            } catch (Exception ex)
            {
                CipherPayload _Payload = new CipherPayload
                {
                    Status = "Failed",
                    Error = new ErrorModel
                    {
                        ErrorCode = "505",
                        InnerException = (ex.InnerException != null) ? ex.InnerException.Message.ToString() : "",
                        Message = (ex.Message != null) ? ex.Message.ToString() : "",
                        StackTrace = (ex.StackTrace != null) ? ex.StackTrace.ToString() : ""
                    }
                };
                return await Task.FromResult(_Payload);
            }
        }
    }
}
