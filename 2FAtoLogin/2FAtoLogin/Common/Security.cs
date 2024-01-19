using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace _2FAtoLogin.Common
{
    public static class Security
    {
		private static readonly byte[] IVa = new byte[] { 0x0b, 0x0c, 0x0d, 0x0e, 0x0f, 0x11, 0x11, 0x12, 0x13, 0x14, 0x0e, 0x16, 0x17 };
		private static readonly byte[] IV128 = new byte[] { 0xDB, 0x5D, 0xC0, 0xE4, 0x4F, 0x41, 0x13, 0x8E, 0xFB, 0x17, 0x9E, 0x77, 0x0B, 0x91, 0x79, 0x10 };

		private const int SALT_LENGTH = 32;
		private const int APPPASSWORD_LENGTH = 32;
		private const int ITERATION_COUNT = 1000;
		private const int AES_KEY_SIZE = 256;

		public static string GetCurrentUser(string loginSignature)
		{
			try
			{
				string user = "";
				string dcryptKey = Decrypt(loginSignature);
				if (!string.IsNullOrEmpty(dcryptKey))
				{
					string[] aKeys = dcryptKey.Split('~');
					user = aKeys[0];
					string password = aKeys[1];

				}

				return user;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		private static byte[] GenerateRandomBytes(int byteLength = 32)
		{
			var salt = new byte[byteLength];
			using (var random = new RNGCryptoServiceProvider())
			{
				random.GetNonZeroBytes(salt);
			}

			return salt;
		}

		private static string ConvertToHex(byte[] byteRepresentation)
		{
			return BitConverter.ToString(byteRepresentation).Replace("-", string.Empty);
		}
		private static byte[] ConvertFromHex(string hexString)
		{
			int numChars = hexString.Length;
			if (numChars % 2 != 0)
			{
				throw new ArgumentException($"Invalid {nameof(hexString)} length");
			}

			byte[] bytes = new byte[numChars / 2];
			for (int i = 0; i < numChars; i += 2)
				bytes[i / 2] = Convert.ToByte(hexString.Substring(i, 2), 16);
			return bytes;
		}

		public static void Encrypt(this string plainText, out string appPassword, out string salt, out string encryptedText)
		{
			var saltInByte = GenerateRandomBytes(SALT_LENGTH);
			appPassword = ConvertToHex(GenerateRandomBytes(APPPASSWORD_LENGTH));

			using (Aes aes = new AesManaged())
			{
				aes.KeySize = AES_KEY_SIZE;
				Rfc2898DeriveBytes deriveBytes = new Rfc2898DeriveBytes(appPassword, saltInByte, ITERATION_COUNT);
				aes.Key = deriveBytes.GetBytes(aes.KeySize / 8);
				aes.IV = IV128; // Using static IV since we generate the key everytime
				using (MemoryStream encryptionStream = new MemoryStream())
				{
					using (CryptoStream encrypt = new CryptoStream(encryptionStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
					{
						byte[] cleanText = Encoding.UTF8.GetBytes(plainText);
						encrypt.Write(cleanText, 0, cleanText.Length);
						encrypt.FlushFinalBlock();
					}

					byte[] encryptedData = encryptionStream.ToArray();
					deriveBytes.Reset();

					encryptedText = Convert.ToBase64String(encryptedData);
					salt = Convert.ToBase64String(saltInByte);
				}
			}
		}

		public static string Encrypt(this string text)
		{
			try
			{
				string salt = DateTime.Now.Year.ToString() + "XZ%^SDDFSF*&^0001$#";
				using (Aes aes = new AesManaged())
				{
					Rfc2898DeriveBytes deriveBytes = new Rfc2898DeriveBytes(Encoding.UTF8.GetString(IVa, 0, IVa.Length), Encoding.UTF8.GetBytes(salt));
					aes.Key = deriveBytes.GetBytes(128 / 8);
					aes.IV = aes.Key;
					using (MemoryStream encryptionStream = new MemoryStream())
					{
						using (CryptoStream encrypt = new CryptoStream(encryptionStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
						{
							byte[] cleanText = Encoding.UTF8.GetBytes(text);
							encrypt.Write(cleanText, 0, cleanText.Length);
							encrypt.FlushFinalBlock();
						}

						byte[] encryptedData = encryptionStream.ToArray();
						string encryptedText = Convert.ToBase64String(encryptedData);


						return encryptedText;
					}
				}
			}
			catch
			{
				return String.Empty;
			}
		}

		public static void Decrypt(this string encryptedText, string appPassword, string salt, out string plainText)
		{
			var saltInByte = Convert.FromBase64String(salt);

			try
			{
				using (Aes aes = new AesManaged())
				{
					aes.KeySize = AES_KEY_SIZE;
					Rfc2898DeriveBytes deriveBytes = new Rfc2898DeriveBytes(appPassword, saltInByte, ITERATION_COUNT);
					aes.Key = deriveBytes.GetBytes(aes.KeySize / 8);
					aes.IV = IV128; // Using static IV since we generate the key everytime

					using (MemoryStream decryptionStream = new MemoryStream())
					{
						using (CryptoStream decrypt = new CryptoStream(decryptionStream, aes.CreateDecryptor(), CryptoStreamMode.Write))
						{
							byte[] encryptedData = Convert.FromBase64String(encryptedText);


							decrypt.Write(encryptedData, 0, encryptedData.Length);
							decrypt.Flush();
						}

						byte[] decryptedData = decryptionStream.ToArray();
						plainText = Encoding.UTF8.GetString(decryptedData, 0, decryptedData.Length);
						deriveBytes.Reset();
					}
				}
			}
			catch (CryptographicException e)
			{
				plainText = null;
				throw e;
			}
		}

		public static string Decrypt(this string text)
		{
			try
			{
				using (Aes aes = new AesManaged())
				{
					string salt = DateTime.Now.Year.ToString() + "XZ%^SDDFSF*&^0001$#";
					Rfc2898DeriveBytes deriveBytes = new Rfc2898DeriveBytes(Encoding.UTF8.GetString(IVa, 0, IVa.Length), Encoding.UTF8.GetBytes(salt));
					aes.Key = deriveBytes.GetBytes(128 / 8);
					aes.IV = aes.Key;

					using (MemoryStream decryptionStream = new MemoryStream())
					{
						using (CryptoStream decrypt = new CryptoStream(decryptionStream, aes.CreateDecryptor(), CryptoStreamMode.Write))
						{
							byte[] encryptedData = Convert.FromBase64String(text);


							decrypt.Write(encryptedData, 0, encryptedData.Length);
							decrypt.Flush();
						}

						byte[] decryptedData = decryptionStream.ToArray();
						string decryptedText = Encoding.UTF8.GetString(decryptedData, 0, decryptedData.Length);


						return decryptedText;
					}
				}
			}
			catch
			{
				return String.Empty;
			}
		}
	}
}