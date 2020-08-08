namespace NabDeviceServices.Infrastructure
{
    public class Security
    {
        protected byte[] KIv = { 110, 2, 40, 7, 58, 14, 114, 5 };
        protected byte[] KKey = { 255, 110, 78, 3, 0, 12, 124, 1 };

        public byte[] Kiv
        {
            get { return KIv; }
        }
        public byte[] Kkey
        {
            get { return KKey; }
        }

        public byte[] StringEncrypt(string txt, System.Security.Cryptography.ICryptoTransform key)
        {
            using (System.IO.MemoryStream output = new System.IO.MemoryStream())
            {
                using (System.Security.Cryptography.CryptoStream strum = new System.Security.Cryptography.CryptoStream(output, key, System.Security.Cryptography.CryptoStreamMode.Write))
                {
                    using (System.IO.StreamWriter writer = new System.IO.StreamWriter(strum))
                    {
                        writer.Write(txt);
                        writer.Close();
                        strum.Close();
                        return output.ToArray();
                    }
                }
            }
        }

        public string StringDecrypt(byte[] cryptodata, System.Security.Cryptography.ICryptoTransform key)
        {
            using (System.IO.MemoryStream inputelem = new System.IO.MemoryStream(cryptodata))
            {
                using (System.Security.Cryptography.CryptoStream strum = new System.Security.Cryptography.CryptoStream(inputelem, key, System.Security.Cryptography.CryptoStreamMode.Read))
                {
                    using (System.IO.StreamReader reader = new System.IO.StreamReader(strum))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
        }
    }
}
