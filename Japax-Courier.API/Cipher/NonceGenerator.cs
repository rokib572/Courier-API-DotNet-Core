using System;
using System.Text;
using System.Threading.Tasks;

namespace Japax_Courier.API.Cipher
{
    public class NonceGenerator
    {
        int tempVal = 1;
        public async Task<string> charDecrypt(char str)
        {
            int val = (int)str;
            int valMod = (int)Math.Floor(((double)val / 7));
            int valAddWithMod = val + valMod;
            int newVal = (valAddWithMod + tempVal) % 16;

            tempVal = newVal;
            string strNewValHex = newVal.ToString("X");
            return await Task.FromResult(strNewValHex);
        }
        public async Task<string> keyGenerate(string deviceId)
        {
            for (int i = 0; i < deviceId.Length; i++)
            {
                string strR = await charDecrypt(deviceId[i]);
                deviceId = await ReplaceStringByIndex(deviceId, strR, i);// deviceId.replaceAt(i, strR);
            }
            return await Task.FromResult(deviceId.ToLower().ToString());
        }
        public async Task<string> ReplaceStringByIndex(string original, string replaceWith, int replaceIndex)
        {
            if (original.Length >= (replaceIndex + replaceWith.Length))
            {
                StringBuilder rev = new StringBuilder(original);
                rev.Remove(replaceIndex, replaceWith.Length);
                rev.Insert(replaceIndex, replaceWith);
                return await Task.FromResult(rev.ToString());
            }
            else
            {
                throw new Exception("Wrong lengths for the operation");
            }
        }
    }
}
