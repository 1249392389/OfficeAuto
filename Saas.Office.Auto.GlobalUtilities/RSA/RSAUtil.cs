using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Saas.Office.Auto.GlobalUtilities.RSA
{
    /// <summary>
    /// Security utils
    /// </summary>
    public class RSAUtil
    {
        /// <summary>
        /// Encrypt
        /// </summary>
        /// <param name="dataString"></param>
        /// <returns></returns>
        public static string Encrypt(string dataString)
        {
            string encryptedString = "";

            try
            {
                ASCIIEncoding byteConverter = new ASCIIEncoding();
                byte[] dataToEncrypt = byteConverter.GetBytes(dataString);
                RSACryptoServiceProvider RSA = GetRSA("public");
                byte[] encryptedData = RSA.Encrypt(dataToEncrypt, true);
                encryptedString = Convert.ToBase64String(encryptedData);
            }
            catch (CryptographicException e)
            {
                encryptedString = "";
            }
            catch (Exception e)
            {
                encryptedString = "";
            }

            return encryptedString;
        }

        /// <summary>
        /// Decrypt
        /// </summary>
        /// <param name="encryptedString"></param>
        /// <returns></returns>
        public static string Decrypt(string encryptedString)
        {
            string decryptedString = "";
            try
            {

                byte[] encryptedData = Convert.FromBase64String(encryptedString);
                RSACryptoServiceProvider RSA = GetRSA("private");
                byte[] decryptedData = RSA.Decrypt(encryptedData, true);
                ASCIIEncoding byteConverter = new ASCIIEncoding();
                decryptedString = byteConverter.GetString(decryptedData);
            }
            catch (CryptographicException e)
            {
                decryptedString = "";
            }
            catch (Exception e)
            {
                decryptedString = "";
            }

            return decryptedString;
        }

        private static RSACryptoServiceProvider GetRSA(string keyType)
        {
            RSACryptoServiceProvider provider = null;

            try
            {
                provider = new RSACryptoServiceProvider();

                //provider.ToXmlString(true);//Save keystore file
                //provider.ToXmlString(false);//Save public key file

                if (keyType.Equals("private"))
                {
                    provider.FromXmlString("<RSAKeyValue><Modulus>uWiFgtBaORBstfs/EfVELIWzJkOM921stei5RDGa11YNz3or0VEX8rJagUWjux+ciYKJHi/BVxjVFEFtTJk2s/pAulG6aXPIn+11Ucqtr59/yXKUMlooAbVVff9nZXEx7Bcu46RfYh5M5v9yn/9WPpKXzuy4fTa7+BbEJ07u+h8=</Modulus><Exponent>AQAB</Exponent><P>4g2vRGiBjyzfH9pPOjqXrwOQH9unAfhGgtq+Lb8rNxwwnGeO24BGZN36kNrxjnKN3RT3ZBCwEEJCNgwbrPq23Q==</P><Q>0fhoX9MvrRnlLA9wIPgP3mbkijQQtRsq2LltBTPgXVLX7ogBDyLMhA7fpGSDNEpNbq3Zvg6HkTsank9wKMufKw==</Q><DP>iFTigGpawOO6CXbbU23k7ztB38TUWz7GH8MW8XYa9Ri+RIW8Rat+SPULWfOBvXxfDJfJgAMEfDnJvtjclB18zQ==</DP><DQ>aHOkqJbMTtZk9QgxBZWhf0e8RSwla5K6O9nya/YklQhTNuwdasQq7T7g7ky6IFceMgL2IN/lfM/kLADkkMbKxQ==</DQ><InverseQ>yUhm9O3nb9QNHcPMvHlqtSPBVQvF3mfoJkRapXC5j8k/ZoJWJkUl7ToNffsh72zWhLdfOLunIepr8vfE22dq0A==</InverseQ><D>qbCkyRYCDUogBOpfTgNJEuqHDVUz1lya616E+Yng6oaC+0oYgmmS3ngn5zqiYKfM7/m9nxgb/qfmlLRQ4ZM0gTNPhQX+/YEn46jVgf9v/fH2/fLLdSZ+sqLDEhG3x2sKH5KDfxB17ZSvROVmsYKz7C2u0Fy1rP6sHxNHhEv+Szk=</D></RSAKeyValue>");
                }
                else if (keyType.Equals("public"))
                {
                    provider.FromXmlString("<RSAKeyValue><Modulus>uWiFgtBaORBstfs/EfVELIWzJkOM921stei5RDGa11YNz3or0VEX8rJagUWjux+ciYKJHi/BVxjVFEFtTJk2s/pAulG6aXPIn+11Ucqtr59/yXKUMlooAbVVff9nZXEx7Bcu46RfYh5M5v9yn/9WPpKXzuy4fTa7+BbEJ07u+h8=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>");
                }
            }
            catch (CryptographicException e)
            {
                provider = null;
            }

            return provider;
        }
    }
}
