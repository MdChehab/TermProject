using System;
using System.Security.Cryptography;
using System.Text;

namespace TermProject2025.Services
{
    public class EncryptionService
    {
        private const int KeySize = 32; // 256 bits
        private const int NonceSize = 12; // 96 bits for GCM
        private const int TagSize = 16; // 128 bits authentication tag
        private const int SaltSize = 16; // 128 bits
        private const int Iterations = 100000; // PBKDF2 iterations

        #region Key Derivation
        public byte[] DeriveKey(string masterPassword, byte[] salt, int iterations = Iterations)
        {
            using (var pbkdf2 = new Rfc2898DeriveBytes(
                masterPassword,
                salt,
                iterations,
                HashAlgorithmName.SHA256))
            {
                return pbkdf2.GetBytes(KeySize);
            }
        }
        public byte[] GenerateSalt()
        {
            byte[] salt = new byte[SaltSize];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }

        #endregion

        #region Encryption / Decryption
        public string Encrypt(string plaintext, byte[] key)
        {
            if (string.IsNullOrEmpty(plaintext))
                return string.Empty;

            if (key == null || key.Length != KeySize)
                throw new ArgumentException($"Key must be {KeySize} bytes");

            // Generate random nonce
            byte[] nonce = new byte[NonceSize];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(nonce);
            }

            // Prepare buffers
            byte[] plaintextBytes = Encoding.UTF8.GetBytes(plaintext);
            byte[] ciphertext = new byte[plaintextBytes.Length];
            byte[] tag = new byte[TagSize];

            // Encrypt using AES-GCM
            using (var aesGcm = new AesGcm(key, TagSize))
            {
                aesGcm.Encrypt(nonce, plaintextBytes, ciphertext, tag);
            }

            // Combine nonce + tag + ciphertext
            byte[] result = new byte[NonceSize + TagSize + ciphertext.Length];
            Buffer.BlockCopy(nonce, 0, result, 0, NonceSize);
            Buffer.BlockCopy(tag, 0, result, NonceSize, TagSize);
            Buffer.BlockCopy(ciphertext, 0, result, NonceSize + TagSize, ciphertext.Length);

            return Convert.ToBase64String(result);
        }
        public string Decrypt(string encryptedData, byte[] key)
        {
            if (string.IsNullOrEmpty(encryptedData))
                return string.Empty;

            if (key == null || key.Length != KeySize)
                throw new ArgumentException($"Key must be {KeySize} bytes");

            try
            {
                // Decode from Base64
                byte[] data = Convert.FromBase64String(encryptedData);

                if (data.Length < NonceSize + TagSize)
                    throw new ArgumentException("Invalid encrypted data format");

                // Extract nonce, tag, and ciphertext
                byte[] nonce = new byte[NonceSize];
                byte[] tag = new byte[TagSize];
                byte[] ciphertext = new byte[data.Length - NonceSize - TagSize];

                Buffer.BlockCopy(data, 0, nonce, 0, NonceSize);
                Buffer.BlockCopy(data, NonceSize, tag, 0, TagSize);
                Buffer.BlockCopy(data, NonceSize + TagSize, ciphertext, 0, ciphertext.Length);

                // Decrypt using AES-GCM
                byte[] plaintext = new byte[ciphertext.Length];
                using (var aesGcm = new AesGcm(key, TagSize))
                {
                    aesGcm.Decrypt(nonce, ciphertext, tag, plaintext);
                }

                return Encoding.UTF8.GetString(plaintext);
            }
            catch (CryptographicException)
            {
                throw new CryptographicException("Decryption failed. Invalid key or corrupted data.");
            }
        }

        #endregion

        #region Utilities
        public string BytesToBase64(byte[] bytes)
        {
            return Convert.ToBase64String(bytes);
        }
        public byte[] Base64ToBytes(string base64)
        {
            return Convert.FromBase64String(base64);
        }

        #endregion
    }
}
