using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Japax_Courier.API.Cipher
{
    public class CipherAgent
    {
        public async Task<string> generateRandomHex(int byteLength)
        {
            int stringLength = byteLength * 2;

            string alphabet = "abcdef0123456789";
            string s = "";

            Random rnd = new Random();

            for (int i = 0; i < stringLength; i++)
            {
                int r = rnd.Next(0, alphabet.Length);

                s += alphabet[r];
            }

            //prevent NULL byte block.
            s = s.Replace("00", "11");

            return await Task.FromResult(s);
        }

        private async Task<byte[]> dataFromHexString(string hexString)
        {
            hexString = hexString.Trim();
            hexString = hexString.Replace(" ", "");

            byte[] data = Enumerable.Range(0, hexString.Length / 2)
                                    .Select(x => Convert.ToByte(hexString.Substring(x * 2, 2), 16))
                                    .ToArray();

            return await Task.FromResult(data);
        }

        private async Task<string> dataToHexString(byte[] data)
        {
            string hexString = String.Concat(Array.ConvertAll(data, x => x.ToString("X2")));

            return await Task.FromResult(hexString);
        }

        public async Task<string> encryptData(string text, string hexKey)
        {
            if(await checkKey(hexKey) == true)
            {
                //generate random IV (16 bytes)
                string hexIV = await generateRandomHex(16);

                //convert plainText to hex string.
                byte[] bytesData = System.Text.Encoding.UTF8.GetBytes(text);
                string hexStr = await dataToHexString(bytesData);

                string cipherHexStr = await __encryptData(hexStr, hexKey, hexIV);

                string hmacHexKey = await generateRandomHex(16);
                string hmacHexStr = await __computeHMAC(hexIV, cipherHexStr, hexKey, hmacHexKey);

                string encryptedHexStr = hexIV + hmacHexKey + hmacHexStr + cipherHexStr;
                return await Task.FromResult(encryptedHexStr);
            } else
            {
                return await Task.FromResult("Error");
            }            
        }

        public async Task<string> decryptData(string hexStr, string hexKey)
        {
            if(await checkKey(hexKey) == true)
            {
                string plainText = null;

                if (hexStr.Length > 128)
                {
                    string hexIV = hexStr.Substring(0, 32);
                    string hmacHexKey = hexStr.Substring(32, 32);
                    string hmacHexStr = hexStr.Substring(64, 64);
                    string cipherHexStr = hexStr.Substring(128);

                    string computedHmacHexStr = await __computeHMAC(hexIV, cipherHexStr, hexKey, hmacHexKey);

                    if (computedHmacHexStr.ToLower() == hmacHexStr.ToLower())
                    {
                        string decryptedStr = await __decryptData(cipherHexStr, hexKey, hexIV);

                        byte[] data = await dataFromHexString(decryptedStr);
                        plainText = System.Text.Encoding.UTF8.GetString(data);
                    }
                }
                return await Task.FromResult(plainText);
            } else
            {
                return await Task.FromResult("Error");
            }           
        }

        private async Task<bool> checkKey(string hexKey)
        {
            hexKey = hexKey.Trim();
            hexKey = hexKey.Replace(" ", "");
            hexKey = hexKey.ToLower();

            if (hexKey.Length != 64)
            {
                return await Task.FromResult(false);
            }

            int i;
            for (i = 0; i < hexKey.Length; i += 2)
            {
                if (hexKey[i] == '0' && hexKey[i + 1] == '0')
                {
                    return await Task.FromResult(false);
                }
            }
            return await Task.FromResult(true);
        }

        private async Task<string> __computeHMAC(string hexIV, string cipherHexStr, string hexKey, string hmacHexKey)
        {
            hexKey = hexKey.Trim();
            hexKey = hexKey.Replace(" ", "");
            hexKey = hexKey.ToLower();

            hmacHexKey = hmacHexKey.ToLower();

            string hexString = hexIV + cipherHexStr + hexKey;
            hexString = hexString.ToLower();

            byte[] data = System.Text.Encoding.UTF8.GetBytes(hexString);
            byte[] hmacKey = System.Text.Encoding.UTF8.GetBytes(hmacHexKey);

            HMACSHA256 hmac = new HMACSHA256(hmacKey);
            byte[] hashbytes = hmac.ComputeHash(data);
            string hashHexStr = await dataToHexString(hashbytes);

            return await Task.FromResult(hashHexStr);
        }

        public async Task<string> __encryptData(string hexString, string hexKey, string hexIV)
        {
            byte[] data = await dataFromHexString(hexString);
            byte[] key = await dataFromHexString(hexKey);
            byte[] iv = await dataFromHexString(hexIV);

            var aes = Aes.Create();
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;
            var encryptor = aes.CreateEncryptor(key, iv);

            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
            cryptoStream.Write(data, 0, data.Length);
            cryptoStream.FlushFinalBlock();

            byte[] encryptData = memoryStream.ToArray();

            string encryptHexData = await dataToHexString(encryptData);
            return await Task.FromResult(encryptHexData);
        }

        private async Task<string> __decryptData(string hexString, string hexKey, string hexIV)
        {
            byte[] data = await dataFromHexString(hexString);
            byte[] key = await dataFromHexString(hexKey);
            byte[] iv = await dataFromHexString(hexIV);

            var aes = Aes.Create();
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;
            var decryptor = aes.CreateDecryptor(key, iv);

            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Write);
            cryptoStream.Write(data, 0, data.Length);
            cryptoStream.FlushFinalBlock();

            byte[] decryptData = memoryStream.ToArray();

            string decryptHexData = await dataToHexString(decryptData);
            return await Task.FromResult(decryptHexData);
        }
    }
}
