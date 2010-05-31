using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Windows.Forms;

namespace LAZYSHELL.Encryption
{
    class Cipher
    {
        byte[] data;
        byte[] encrypted = new byte[stampSize];

        public Model model;
        public State state;

        // Public encryption Data
        private string saltValue = "s@1tValue";        // can be any string
        private string hashAlgorithm = "SHA1";             // can be "MD5"
        private int passwordIterations = 2;                  // can be any number
        private string initVector = "@1B2c3D4e5F6g7H8"; // must be 16 bytes
        private int keySize = 256;                // can be 192 or 128

        private static int stampStart = 0x3DE000;
        //private static int stampEnd = 0x3DEFFF;
        private static int stampSize = 0x700;


        public Cipher(byte[] data, Model model)
        {
            this.data = data;
            this.model = model;
            this.state = State.Instance;

            // 0x3DD800 - 0x3DEFFF space available
        }

        public bool IsNewRom()
        {
            byte[] publicKey = GeneratePublicKey();
            byte[] originalHash = new byte[] { 0xA4, 0xF7, 0x53, 0x90, 0x54, 0xC3, 0x59, 0xFE, 0x3F, 0x36, 0x0B, 0x0E, 0x6B, 0x72, 0xE3, 0x94, 0x43, 0x9F, 0xE9, 0xDF };

            return CompareHashes(publicKey, originalHash);
        }
        public Stamp DecryptSignature()
        {
            Stamp stamp = new Stamp(); // Make a new stamp

            if (IsNewRom()) // If an original rom
            {
                state.PrivateKey = GeneratePrivateKey(); // Create a private key for this rom
                EncryptSignature(stamp, true);
                return stamp; // Original Rom
            }

            int offset = stampStart;

            // Get Public Buf - Contains private key and hash (of something...)
            ushort len = BitManager.GetShort(data, offset); offset += 2;
            byte[] publicBuf = BitManager.GetByteArray(data, offset, len); offset += len;
            // Get Private Buf - Contains stamp info
            len = BitManager.GetShort(data, offset); offset += 2;
            byte[] privateBuf = BitManager.GetByteArray(data, offset, len); offset += len;
            // Get Password Buf
            len = BitManager.GetShort(data, offset); offset += 2;
            byte[] pwBuf = BitManager.GetByteArray(data, offset, len); offset += len;

            byte[] publicKey = GeneratePublicKey(); // Generate Public key for private Buf based on current rom
            byte[] privateKey = state.PrivateKey; // Use the old private key if there is one

            try // Get private key
            {
                if (privateKey == null)
                {
                    // If we can decrypt a private key, save it in state for use later
                    privateKey = GetPrivateKey(publicBuf, publicKey, pwBuf);
                    state.PrivateKey = privateKey; // Saved for later use
                }
            }
            catch (Exception ex)
            {
                stamp.Invalidate(); // Our stamp is invalid
                state.PrivateKey = GeneratePrivateKey();
                return stamp;
            }

            try // Decrypt data and fill stamp
            {
                FillStamp(privateBuf, privateKey, stamp); // Get all the data
            }
            catch (Exception ex)
            {
                stamp.Invalidate();
                if (LAZYSHELL.Properties.Settings.Default.ShowEncryptionWarnings)
                {
                    HashCheckFail fail = new HashCheckFail("The Signature for this ROM is corrupt and cannot be recovered. The author stamp is invalid and most likely tampered with.");
                    fail.ShowDialog();
                }
            }

            return stamp; // return it
        }
        /*
         * To save old stamp, set saveNew to false
         * setting saveNew to true encrypts the stamp with the new password
         */
        public void EncryptSignature(Stamp stamp, bool saveNew)
        {
            /* ------------------------------
            *          Buffer - Encrypted with private key
            * ---------------------- 2
            * short - Size of encrypted publicBuf
            * byte[] - Encrypted publicBuf
            * short - Size of encrypted privateBuf
            * byte[] - Encrypted privateBuf
            * short - Size of encrypted pwBuf
            * byte[] - Encrypted pwBuf
            * ------------------------------ */

            byte[] publicBuf;
            byte[] privateBuf;
            byte[] pwBuf;

            byte[] publicKey = GeneratePublicKey(); // Private key is encrypted with this key
            // Should have a key from decryption, even if its a new rom
            byte[] privateKey = state.PrivateKey; // Data is encrypted with this key

            // Construct final buffer
            byte[] final = new byte[stampSize];

            publicBuf = CreatePublicBuf(privateKey, publicKey);
            privateBuf = CreatePrivateBuf(stamp, privateKey);

            if (saveNew) // New password
                pwBuf = CreatePWBuf(stamp, privateKey);
            else // Old Password
                pwBuf = GetOldPWBuf();

            int offset = 0;
            // Construct final
            try
            {
                BitManager.SetShort(final, offset, (ushort)publicBuf.Length); offset += 2;
                BitManager.SetByteArray(final, offset, publicBuf); offset += publicBuf.Length;

                BitManager.SetShort(final, offset, (ushort)privateBuf.Length); offset += 2;
                BitManager.SetByteArray(final, offset, privateBuf); offset += privateBuf.Length;

                BitManager.SetShort(final, offset, (ushort)pwBuf.Length); offset += 2;
                BitManager.SetByteArray(final, offset, pwBuf); offset += pwBuf.Length;
                // Done constructing final
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + (offset - stampSize) + " bytes too many to save ROM signature. Reduce content to save signature", "LAZY SHELL");
                return;
            }
            BitManager.SetByteArray(data, stampStart, final); // Write to rom

        }

        public bool CheckPassword(string password)
        {
            byte[] pwBuf = GetOldPWBuf();

            try
            {
                pwBuf = DecryptData(pwBuf, password);
                int offset = 0;
                ushort len = BitManager.GetShort(pwBuf, offset);
                offset += len + 2;

                len = BitManager.GetShort(pwBuf, offset); offset += 2;
                pwBuf = BitManager.GetByteArray(pwBuf, offset, len);

                return CompareHashes(GenerateSHA1Hash(strToByte(password)), pwBuf);
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        private byte[] GeneratePublicKey()
        {
            int offset = stampStart;

            byte[] temp = BitManager.GetByteArray(data, offset, stampSize);

            for (int i = offset; i < stampStart + stampSize; i++)
                data[i] = 0x00;

            byte[] hash = GenerateSHA1Hash(data);

            BitManager.SetByteArray(data, offset, temp);

            return hash;
        }
        private byte[] GeneratePrivateKey()
        {
            Random rand = new Random();

            DateTime time = DateTime.Now;
            ushort checksum = model.RomChecksumBin(); // 2 bytes
            long tickcount = time.Ticks; // 8 bytes

            byte[] key = new byte[rand.Next(10, 20)];
            int offset = 0;

            BitManager.SetShort(key, offset, checksum); offset += 2; // Rom Checksum
            // Tickcount
            BitManager.SetShort(key, 2, (ushort)((tickcount >> 48) & 0xFFFF)); offset += 2;
            BitManager.SetShort(key, 4, (ushort)((tickcount >> 32) & 0xFFFF)); offset += 2;
            BitManager.SetShort(key, 6, (ushort)((tickcount >> 16) & 0xFFFF)); offset += 2;
            BitManager.SetShort(key, 8, (ushort)((tickcount >> 00) & 0xFFFF)); offset += 2;
            // random
            for (; offset < key.Length; offset++) // Fill rest of key with random data
                BitManager.SetByte(key, offset, (byte)rand.Next(255)); offset++;

            return key;
        }
        private int CalculatePublicBufLen(byte[] publicKey, byte[] privateKey)
        {
            /* -----------------------------
             *       Public Buf - Encrypted with public key
             * ---------------------- 4
             * short - Size of encrypted Private Key
             * byte[] - private key
             * short - size of rom hash
             * byte[] - rom hash
             * ------------------------------------------- */
            int len = 0;

            len += 2;
            len += privateKey.Length;

            len += 2;
            len += publicKey.Length;

            return len;

        }
        private int CalculatePrivateBufLen(Stamp stamp, byte[] date, byte[] privateKey)
        {
            /* -----------------------------
             *       Private Buf - Encrypted with public key
             * ----------------------
             * byte - Published Flag
             * byte - Lock Flag
             * byte - Date Stamp Flag
             * ---------------------- *
             * short - Author Name Length
             * byte[] - Author Name
             * short - Author Comments Length
             * byte[] - Author Comments
             * short - Publish Date Length
             * byte[] - Publish Date
             * short - Private Key Hash Length
             * byte[] - Private Key Hash
             * * ---------------------------------------- */

            int len = 0;
            len += 3; // Flags

            len += 2; // Len
            len += stamp.Name.Length; // byte[]

            len += 2; // Len 
            len += stamp.Comments.Length; // byte[]

            if (stamp.DateStamp)
            {
                len += 2; // Len
                len += date.Length; // byte[]
            }

            byte[] hash = GenerateSHA1Hash(privateKey);
            len += 2;
            len += hash.Length;

            return len;


        }
        private int CalculatePWBufLen(byte[] privateKey, byte[] passHash)
        {
            int len = 0;

            len += 2; // len
            len += privateKey.Length; // private key

            len += 2;
            len += passHash.Length; // passHash

            return len;
        }
        private byte[] CreatePublicBuf(byte[] privateKey, byte[] publicKey)
        {
            /* -----------------------------
             *       Public Buf - Encrypted with public key
             * ---------------------- 4
             * short - Size of encrypted Private Key
             * byte[] - private key
             * short - size of rom hash
             * byte[] - rom hash
             * ------------------------------------------- */
            int offset = 0;

            byte[] publicBuf = new byte[CalculatePublicBufLen(publicKey, privateKey)]; // allocate space

            BitManager.SetShort(publicBuf, offset, (ushort)privateKey.Length); offset += 2; // Set length of private key
            BitManager.SetByteArray(publicBuf, offset, privateKey); offset += privateKey.Length; // Private key

            BitManager.SetShort(publicBuf, offset, (ushort)publicKey.Length); offset += 2; // Set length of rom hash(should always be 20)
            BitManager.SetByteArray(publicBuf, offset, publicKey); offset += publicKey.Length; // Rom Hash

            return EncryptData(publicBuf, byteToStr(publicKey)); // Encrypt public buf with public key
        }
        private byte[] CreatePrivateBuf(Stamp stamp, byte[] privateKey)
        {
            /* -----------------------------
             *       Private Buf - Encrypted with public key
             * ----------------------
             * byte - Published Flag
             * byte - Lock Flag
             * byte - Date Stamp Flag
             * ---------------------- *
             * short - Author Name Length
             * byte[] - Author Name
             * short - Author Comments Length
             * byte[] - Author Comments
             * short - Publish Date Length
             * byte[] - Publish Date
             * short - Private Key Hash Length
             * byte[] - Private Key Hash
             * ---------------------------------------- */
            byte[] date = null;
            if (stamp.DateStamp)
                date = strToByte(DateTime.Now.ToString());

            byte[] privateBuf = new byte[CalculatePrivateBufLen(stamp, date, privateKey)]; // Allocate space for privateBuf

            // Save flags
            int offset = 0;

            if (stamp.Published)
                BitManager.SetByte(privateBuf, offset, 1);
            offset++;

            if (stamp.Locked)
                BitManager.SetByte(privateBuf, offset, 1);
            offset++;

            if (stamp.DateStamp)
                BitManager.SetByte(privateBuf, offset, 1);
            offset++;
            // Name
            byte[] temp = strToByte(stamp.Name);
            BitManager.SetShort(privateBuf, offset, (ushort)temp.Length); offset += 2;
            BitManager.SetByteArray(privateBuf, offset, temp); offset += temp.Length;
            // Comments
            temp = strToByte(stamp.Comments);
            BitManager.SetShort(privateBuf, offset, (ushort)temp.Length); offset += 2;
            BitManager.SetByteArray(privateBuf, offset, temp); offset += temp.Length;
            // Date
            if (stamp.DateStamp)
            {
                temp = date;
                BitManager.SetShort(privateBuf, offset, (ushort)temp.Length); offset += 2;
                BitManager.SetByteArray(privateBuf, offset, temp); offset += temp.Length;
            }
            // Private Key Hash
            temp = GenerateSHA1Hash(privateKey);
            BitManager.SetShort(privateBuf, offset, (ushort)temp.Length); offset += 2;
            BitManager.SetByteArray(privateBuf, offset, temp); offset += temp.Length;

            // Encrypt
            return EncryptData(privateBuf, byteToStr(privateKey)); // Encrypt privateBuf with privateKey
        }
        private byte[] CreatePWBuf(Stamp stamp, byte[] privateKey)
        {
            // Start Password buf
            int offset = 0;
            byte[] pass = strToByte(stamp.Password);
            pass = GenerateSHA1Hash(pass);

            byte[] pwBuf = new byte[CalculatePWBufLen(privateKey, pass)]; // allocate space for pwBuf

            BitManager.SetShort(pwBuf, offset, (ushort)privateKey.Length); offset += 2;
            BitManager.SetByteArray(pwBuf, offset, privateKey); offset += privateKey.Length;

            BitManager.SetShort(pwBuf, offset, (ushort)pass.Length); offset += 2;
            BitManager.SetByteArray(pwBuf, offset, pass); offset += pass.Length;

            return EncryptData(pwBuf, stamp.Password);
        }
        private byte[] GetOldPWBuf()
        {
            int offset = stampStart;
            ushort len = BitManager.GetShort(data, offset);
            offset += len + 2;

            len = BitManager.GetShort(data, offset);
            offset += len + 2;

            len = BitManager.GetShort(data, offset); offset += 2;
            return BitManager.GetByteArray(data, offset, len);
        }
        private void FillStamp(byte[] privateBuf, byte[] privateKey, Stamp stamp)
        {
            privateBuf = DecryptData(privateBuf, byteToStr(privateKey));

            int offset = 0;
            ushort len;

            stamp.Published = (BitManager.GetByte(privateBuf, offset) == 1); offset++;
            stamp.Locked = (BitManager.GetByte(privateBuf, offset) == 1); offset++;
            stamp.DateStamp = (BitManager.GetByte(privateBuf, offset) == 1); offset++;

            len = BitManager.GetShort(privateBuf, offset); offset += 2;
            stamp.Name = byteToStr(BitManager.GetByteArray(privateBuf, offset, len)); offset += len;

            len = BitManager.GetShort(privateBuf, offset); offset += 2;
            stamp.Comments = byteToStr(BitManager.GetByteArray(privateBuf, offset, len)); offset += len;

            if (stamp.DateStamp)
            {
                len = BitManager.GetShort(privateBuf, offset); offset += 2;
                stamp.Date = byteToStr(BitManager.GetByteArray(privateBuf, offset, len)); offset += len;
            }

            len = BitManager.GetShort(privateBuf, offset); offset += 2;
            byte[] hash = BitManager.GetByteArray(privateBuf, offset, len); offset += len;

            if (!CompareHashes(GenerateSHA1Hash(privateKey), hash))
                throw new Exception();

        }
        private byte[] DecodePublicBuf(byte[] publicBuf, byte[] publicKey)
        {
            publicBuf = DecryptData(publicBuf, byteToStr(publicKey));

            int offset = 0;
            ushort len;

            len = BitManager.GetShort(publicBuf, offset); // Length of private key
            offset += 2;
            byte[] privateKey = BitManager.GetByteArray(publicBuf, offset, len); // Private key
            offset += len;

            len = BitManager.GetShort(publicBuf, offset); // Length of hash
            offset += 2;
            byte[] hash = BitManager.GetByteArray(publicBuf, offset, len); // hash
            offset += len;

            if (CompareHashes(publicKey, hash)) // Verify public buf
                return privateKey; // Valid private key
            else
                throw new Exception(); // Somethin went wrong

        }
        private byte[] DecryptPrivateKeyWithAuthorPassword(byte[] pwBuf, string password)
        {
            byte[] pass = strToByte(password);
            // Get hash of password
            pass = GenerateSHA1Hash(pass);

            byte[] pw = DecryptData(pwBuf, password);

            int offset = 0;
            ushort len = BitManager.GetShort(pw, offset); offset += 2;
            byte[] privateKey = BitManager.GetByteArray(pw, offset, len); offset += len;

            len = BitManager.GetShort(pw, offset); offset += 2;
            byte[] pwHash = BitManager.GetByteArray(pw, offset, len);

            if (CompareHashes(pass, pwHash))
                return privateKey;
            else
                throw new Exception();
        }
        private byte[] GetPrivateKey(byte[] publicBuf, byte[] publicKey, byte[] pwBuf)
        {
            try
            {
                return DecodePublicBuf(publicBuf, publicKey);
            }
            catch // Error with public Buf
            {
                Stamp pass = new Stamp();
                string msg = "This ROM has been modified outside of Lazy Shell, the ROM Signature may have been tampered with and cannot be trusted. To try and fix this, enter the Author Password (Default: \"14zy5h311\"). Hit Cancel to ignore.";

                if (LAZYSHELL.Properties.Settings.Default.ShowEncryptionWarnings)
                {
                    HashCheckFail fail = new HashCheckFail(msg, pass);
                    fail.ShowDialog();
                }
                if (pass.Password != null)
                {
                    try
                    {
                        return DecryptPrivateKeyWithAuthorPassword(pwBuf, pass.Password);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Invalid Password or Invalid Signature. ROM Signature was not restored", "LAZY SHELL");
                        throw new Exception();
                    }
                }
                else
                {
                    throw new Exception();
                }
            }
        }


        private byte[] Decode(ushort lenIndex, ushort offsetIndex, byte[] buf, ushort size)
        {
            ushort offset = buf[offsetIndex];
            int len = buf[lenIndex];

            if (buf.Length - offset - len < 0)
                throw new Exception(); // Invalid Cipher, do not provide any information on why it failed

            return BitManager.GetByteArray(buf, offset, len);
        }
        private byte[] Encode(ushort lenIndex, ushort offsetIndex, byte[] buf, ushort size)
        {
            byte[] encoded = new byte[size]; // Stores the data to encrypt
            FillWithGarbage(encoded);

            Random random = new Random();

            BitManager.SetShort(encoded, lenIndex, (ushort)buf.Length);

            ushort bufOffset = (ushort)random.Next(Math.Max(lenIndex, offsetIndex) + 1, encoded.Length - buf.Length);

            BitManager.SetShort(encoded, offsetIndex, bufOffset);
            BitManager.SetByteArray(encoded, bufOffset, buf);

            return encoded;
        }
        private byte[] GenerateMD5Hash(byte[] cipher)
        {
            MD5 md5Hasher = MD5.Create();

            return md5Hasher.ComputeHash(cipher);
        }
        private byte[] GenerateSHA1Hash(byte[] cipher)
        {
            SHA1 sha1Hasher = SHA1.Create();

            return sha1Hasher.ComputeHash(cipher);
        }
        private bool CompareHashes(byte[] hash1, byte[] hash2)
        {
            if (hash1.Length != hash2.Length) // Check lengths, if not equal invalid
                return false;

            for (int i = 0; i < hash1.Length; i++) // Bitwise Compare
                if (hash1[i] != hash2[i])
                    return false;

            return true; // Valid hash
        }
        private void FillWithGarbage(byte[] toFill)
        {
            Random r = new Random();

            for (int i = 0; i < toFill.Length; i++)
                if (toFill[i] == 0)
                    toFill[i] = (byte)r.Next(255);
        }
        private void FillWithGarbage(byte[] toFill, int start, int len)
        {
            Random r = new Random();

            try
            {
                for (int i = start; i < start + len; i++)
                    if (toFill[i] == 0)
                        toFill[i] = (byte)r.Next(255);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid Args for FillWithGarbage().", "LAZY SHELL");
            }
        }
        private byte[] EncryptData(byte[] toEncrypt, string password)
        {
            return Encrypt(toEncrypt,
                password,
                this.saltValue,
                this.hashAlgorithm,
                this.passwordIterations,
                this.initVector,
                this.keySize);
        }
        private byte[] DecryptData(byte[] toDecrypt, string password)
        {
            return Decrypt(toDecrypt,
                password,
                saltValue,
                hashAlgorithm,
                passwordIterations,
                initVector,
                keySize);
        }

        // Encrypts specified plaintext using Rijndael symmetric key algorithm
        private static byte[] Encrypt(byte[] toEncrypt,
                                     string passPhrase,
                                     string saltValue,
                                     string hashAlgorithm,
                                     int passwordIterations,
                                     string initVector,
                                     int keySize)
        {
            /*
               
             * byte[] toEncrypt - Data to be encrypted.
             
             * string passPhrase - Passphrase from which a pseudo-random password will be derived. The
               derived password will be used to generate the encryption key.
               Passphrase can be any string. In this example we assume that this
               passphrase is an ASCII string.
              
             * string saltValue - Salt value used along with passphrase to generate password. Salt can
               be any string. In this example we assume that salt is an ASCII string.
              
             * string hashAlgorithm - Hash algorithm used to generate password. Allowed values are: "MD5" and
               "SHA1". SHA1 hashes are a bit slower, but more secure than MD5 hashes.
               
             * int passwordIterations - Number of iterations used to generate password. One or two iterations
               should be enough.
               
             * string initVector - Initialization vector (or IV). This value is required to encrypt the
               first block of plaintext data. For RijndaelManaged class IV must be 
               exactly 16 ASCII characters long.
                
             * int keySize - Size of encryption key in bits. Allowed values are: 128, 192, and 256. 
               Longer keys are more secure than shorter keys.
             */


            // Convert strings into byte arrays.
            byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
            byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltValue);

            // First, we must create a password, from which the key will be derived.
            // This password will be generated from the specified passphrase and 
            // salt value. The password will be created using the specified hash 
            // algorithm. Password creation can be done in several iterations.
            PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, saltValueBytes, hashAlgorithm, passwordIterations);

            // Use the password to generate pseudo-random bytes for the encryption
            // key. Specify the size of the key in bytes (instead of bits).
            byte[] keyBytes = password.GetBytes(keySize / 8);

            // Create uninitialized Rijndael encryption object.
            RijndaelManaged symmetricKey = new RijndaelManaged();

            // Set encryption mode to Cipher Block Chaining
            symmetricKey.Mode = CipherMode.CBC;

            // Generate encryptor from the existing key bytes and initialization 
            // vector. Key size will be defined based on the number of the key 
            // bytes.
            ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);

            // Define memory stream which will be used to hold encrypted data.
            MemoryStream memoryStream = new MemoryStream();

            // Define cryptographic stream (always use Write mode for encryption).
            CryptoStream cryptoStream = new CryptoStream(memoryStream,
                                                         encryptor,
                                                         CryptoStreamMode.Write);

            // Start encrypting.
            cryptoStream.Write(toEncrypt, 0, toEncrypt.Length);

            // Finish encrypting.
            cryptoStream.FlushFinalBlock();

            // Convert our encrypted data from a memory stream into a byte array.
            byte[] cipherBytes = memoryStream.ToArray();

            // Close both streams.
            memoryStream.Close();
            cryptoStream.Close();

            return cipherBytes;
        }
        // Decrypts specified ciphertext using Rijndael symmetric key algorithm.
        private static byte[] Decrypt(byte[] cipher,
                                 string passPhrase,
                                 string saltValue,
                                 string hashAlgorithm,
                                 int passwordIterations,
                                 string initVector,
                                 int keySize)
        {
            /*
             * string cipher - cipher value.
                
             * string passPhrase - Passphrase from which a pseudo-random password will be derived. The
                derived password will be used to generate the encryption key.
                Passphrase can be any string. In this example we assume that this
                passphrase is an ASCII string.
               
             * string saltValue - Salt value used along with passphrase to generate password. Salt can
                be any string. In this example we assume that salt is an ASCII string.

             * string hashAlgorithm - Hash algorithm used to generate password. Allowed values are: "MD5" and
                "SHA1". SHA1 hashes are a bit slower, but more secure than MD5 hashes.

             * int passwordIterations - Number of iterations used to generate password. One or two iterations
                should be enough.

             * string initVector - Initialization vector (or IV). This value is required to encrypt the
                first block of plaintext data. For RijndaelManaged class IV must be
                exactly 16 ASCII characters long.

             * int keySize - Size of encryption key in bits. Allowed values are: 128, 192, and 256.
                Longer keys are more secure than shorter keys.

             * returns byte[] Decrypted string value.

             * Most of the logic in this function is similar to the Encrypt
                logic. In order for decryption to work, all parameters of this function
                - except cipher value - must match the corresponding parameters of
                the Encrypt function which was called to generate the
                cipher.
           */

            // Convert strings defining encryption key characteristics into byte
            // arrays. Let us assume that strings only contain ASCII codes.
            // If strings include Unicode characters, use Unicode, UTF7, or UTF8
            // encoding.
            byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
            byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltValue);

            // First, we must create a password, from which the key will be 
            // derived. This password will be generated from the specified 
            // passphrase and salt value. The password will be created using
            // the specified hash algorithm. Password creation can be done in
            // several iterations.
            PasswordDeriveBytes password = new PasswordDeriveBytes(
                                                            passPhrase,
                                                            saltValueBytes,
                                                            hashAlgorithm,
                                                            passwordIterations);

            // Use the password to generate pseudo-random bytes for the encryption
            // key. Specify the size of the key in bytes (instead of bits).
            byte[] keyBytes = password.GetBytes(keySize / 8);

            // Create uninitialized Rijndael encryption object.
            RijndaelManaged symmetricKey = new RijndaelManaged();

            // It is reasonable to set encryption mode to Cipher Block Chaining
            // (CBC). Use default options for other symmetric key parameters.
            symmetricKey.Mode = CipherMode.CBC;

            // Generate decryptor from the existing key bytes and initialization 
            // vector. Key size will be defined based on the number of the key 
            // bytes.
            ICryptoTransform decryptor = symmetricKey.CreateDecryptor(
                                                             keyBytes,
                                                             initVectorBytes);

            // Define memory stream which will be used to hold encrypted data.
            MemoryStream memoryStream = new MemoryStream(cipher);

            // Define cryptographic stream (always use Read mode for encryption).
            CryptoStream cryptoStream = new CryptoStream(memoryStream,
                                                          decryptor,
                                                          CryptoStreamMode.Read);

            // Since at this point we don't know what the size of decrypted data
            // will be, allocate the buffer long enough to hold ciphertext;
            // plaintext is never longer than ciphertext.
            byte[] decryptedData = new byte[cipher.Length];

            // Start decrypting.
            int decryptedByteCount = cryptoStream.Read(decryptedData,
                                                       0,
                                                       decryptedData.Length);

            // Close both streams.
            memoryStream.Close();
            cryptoStream.Close();

            return decryptedData;
        }
        private string byteToStr(byte[] toStr)
        {
            System.Text.Encoding encoding = System.Text.Encoding.UTF8;

            return encoding.GetString(toStr);
        }
        private byte[] strToByte(string toByte)
        {
            byte[] arr = new byte[toByte.Length];
            char[] str = toByte.ToCharArray();

            for (int i = 0; i < str.Length; i++)
            {
                arr[i] = (byte)str[i];
                if (arr[i] == 0x2D) arr[i] = 0x7D;
                if (arr[i] == 0x27) arr[i] = 0x7E;
                if (arr[i] == 0x5F) arr[i] = 0x7F;
            }
            return arr;
        }

    }
}
