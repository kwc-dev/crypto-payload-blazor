using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Collections.Generic;

namespace CryptoPayloadBlazorApp.Services

{
    public class CryptoConsumer
    {
        public static Dictionary<string, object> DecryptPayload(string jsonPayload, string base64Key)
        {
            // Parse JSON payload
            var doc = JsonDocument.Parse(jsonPayload);
            string? cipherTextBase64 = doc.RootElement.GetProperty("ciphertext").GetString();
            string? ivBase64 = doc.RootElement.GetProperty("iv").GetString();
            string? algorithm = doc.RootElement.GetProperty("algorithm").GetString();

            if (cipherTextBase64 is null)
                throw new InvalidOperationException("Payload missing 'ciphertext' property or value is null.");
            if (ivBase64 is null)
                throw new InvalidOperationException("Payload missing 'iv' property or value is null.");
            if (algorithm is null)
                throw new InvalidOperationException("Payload missing 'algorithm' property or value is null.");

            Console.WriteLine($"Ciphertext from payload: {cipherTextBase64}");

            // Decode Base64 values
            byte[] cipherBytes = Convert.FromBase64String(cipherTextBase64);
            byte[] ivBytes = Convert.FromBase64String(ivBase64);
            byte[] keyBytes = Convert.FromBase64String(base64Key);

            using var aes = Aes.Create();
            aes.Key = keyBytes;
            aes.IV = ivBytes;

            // Configure based on algorithm metadata
            if (algorithm.Contains("CBC")) aes.Mode = CipherMode.CBC;
            if (algorithm.Contains("PKCS5Padding") || algorithm.Contains("PKCS7")) aes.Padding = PaddingMode.PKCS7;

            using var decryptor = aes.CreateDecryptor();
            byte[] plainBytes = decryptor.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);
            string json = Encoding.UTF8.GetString(plainBytes);

            // Deserialize JSON back into a dictionary
            var restored = JsonSerializer.Deserialize<Dictionary<string, object>>(json);
            return restored is null ? throw new InvalidOperationException("Decrypted payload could not be deserialized.") : restored;
        }
    }

}
