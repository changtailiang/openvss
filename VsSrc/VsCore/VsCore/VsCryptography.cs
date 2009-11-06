// erph	 IMPORTANT: READ BEFORE DOWNLOADING, COPYING, INSTALLING OR USING. 
// mfwk	
// uhmn	 By downloading, copying, installing or using the software you agree to this license.
// jsme	 If you do not agree to this license, do not download, install,
// gzvl	 copy or use the software.
// endt	
// grqb	                          License Agreement
// nujh	         For OpenVss - Open Source Video Surveillance System
// baon	
// mxbg	Copyright (C) 2007-2009, Prince of Songkla University, All rights reserved.
// bams	
// uvgx	Third party copyrights are property of their respective owners.
// eizf	
// sduq	Redistribution and use in source and binary forms, with or without modification,
// owbv	are permitted provided that the following conditions are met:
// pvxz	
// yemj	  * Redistribution's of source code must retain the above copyright notice,
// dzsi	    this list of conditions and the following disclaimer.
// xokd	
// bkyl	  * Redistribution's in binary form must reproduce the above copyright notice,
// ksxe	    this list of conditions and the following disclaimer in the documentation
// veoy	    and/or other materials provided with the distribution.
// fyzq	
// wgrg	  * Neither the name of the copyright holders nor the names of its contributors 
// cmuq	    may not be used to endorse or promote products derived from this software 
// ixue	    without specific prior written permission.
// qrhd	
// sqpd	This software is provided by the copyright holders and contributors "as is" and
// yqkw	any express or implied warranties, including, but not limited to, the implied
// ytet	warranties of merchantability and fitness for a particular purpose are disclaimed.
// qndf	In no event shall the Prince of Songkla University or contributors be liable 
// ablr	for any direct, indirect, incidental, special, exemplary, or consequential damages
// xdao	(including, but not limited to, procurement of substitute goods or services;
// picn	loss of use, data, or profits; or business interruption) however caused
// ysnd	and on any theory of liability, whether in contract, strict liability,
// wkfo	or tort (including negligence or otherwise) arising in any way out of
// ivrg	the use of this software, even if advised of the possibility of such damage.

using System;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using System.Globalization;
using NLog;
using System.Runtime.CompilerServices;

namespace Vs.Core
{
	/// <summary>
    /// VsCryptography class
	/// </summary>
	public static class VsCryptography
	{
        static Logger logger = LogManager.GetCurrentClassLogger();

        private static string vsAlgorithm = "RC2";
        private static string vsInitVector = "Nikom SUVONVORN";
        private static string vsSecretKey = "Nikom SUVONVORN";
        private static int vsKeySize = 128;
        private static int vsBlockSize = 64;

        public static byte[] StrToBytes(string str)
        {
            //Encoder enc = Encoding.UTF8.GetEncoder();
            System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
            return encoding.GetBytes(str);
        }

        public static string BytesToStr(byte[] byt)
        {
            System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
            return encoding.GetString(byt);
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static String Encrypt(string txt, string key)
        {
            String strEncrypted = "";
            vsSecretKey = key;
            SymmetricAlgorithm vsCryptProv;
            try
            {
                vsCryptProv = SymmetricAlgorithm.Create(vsAlgorithm);

                // Size of Key and Block
                vsCryptProv.KeySize = vsKeySize;
                vsCryptProv.BlockSize = vsBlockSize;

                // Create Memory Stream
                MemoryStream vsMemStr = new MemoryStream();

                // Create the Encryptor, Passing that the Key and IV
                ICryptoTransform vsEncryptor = vsCryptProv.CreateEncryptor(StrToBytes(vsSecretKey), StrToBytes(vsInitVector));
                
                //Create the Crypto Stream, Passing that the Memory Stream and Encryptor
                CryptoStream vsCryptStr= new CryptoStream(vsMemStr, vsEncryptor, CryptoStreamMode.Write);

                //Create Stream Writer to Write Encrypted Data
                StreamWriter vsStrWri = new StreamWriter(vsCryptStr);
                vsStrWri.Write(txt);      // Encrypt the TextBox Data
                vsStrWri.Flush();     // Make Sure everything is written
                vsCryptStr.FlushFinalBlock();

                // The Data has been Encrypted in the Memory, Now get that and Display in the TexTBox
                // Create Byte Array of the Length of MemoryStream
                Byte []vsBytes = new Byte[vsMemStr.Length];
                vsMemStr.Position = 0;        //Move Cursor to Start of MemoryStream
                vsMemStr.Read(vsBytes, 0, (int)vsMemStr.Length);

                // Encode the Byte Array to UTF8 and display

                //System.Text.Encoder vsEnc = Encoding.UTF8.GetDecoder();
                strEncrypted = BytesToStr(vsBytes);
                vsBytes = StrToBytes(strEncrypted);

                //vsBytes = vsEnc.GetBytes(strEncrypted);

                vsStrWri.Close();
                vsMemStr.Close();
            }
            catch (CryptographicException err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }

            return strEncrypted;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static String Decrypt(string txt, string key)
        {
            String strDecrypted = "";
            vsSecretKey = key;
            SymmetricAlgorithm vsCryptProv;
            try
            {
                vsCryptProv = SymmetricAlgorithm.Create(vsAlgorithm);

                // Size of Key and Block
                vsCryptProv.KeySize = vsKeySize;
                vsCryptProv.BlockSize = vsBlockSize;

                // Create Memory Stream
                
                MemoryStream vsMemStr = new MemoryStream();

                // Try to Decrypt values in the memory
                // First Create the Decryptor, By Passing Key and IV
                ICryptoTransform vsDecrypt  = vsCryptProv.CreateDecryptor(StrToBytes(vsSecretKey), StrToBytes(vsInitVector));
                
                // Create Crypto Stream
                CryptoStream vsCSReader = new CryptoStream(vsMemStr, vsDecrypt, CryptoStreamMode.Read);
                
                // Create Stream Reader
                StreamReader vsStrRead = new StreamReader(vsCSReader);

                strDecrypted = vsStrRead.ReadToEnd();

                vsCSReader.Close();
                vsStrRead.Close();
                vsMemStr.Close();

                /*
                // Create the Encryptor, Passing that the Key and IV
                ICryptoTransform vsEncryptor = vsCryptProv.CreateEncryptor(StrToByteArray(vsSecretKey), StrToByteArray(vsInitVector));

                //Create the Crypto Stream, Passing that the Memory Stream and Encryptor
                CryptoStream vsCryptStr = new CryptoStream(vsMemStr, vsEncryptor, CryptoStreamMode.Write);

                //Create Stream Writer to Write Encrypted Data
                StreamWriter vsStrWri = new StreamWriter(vsCryptStr);
                vsStrWri.Write(txt);      // Encrypt the TextBox Data
                vsStrWri.Flush();     // Make Sure everything is written
                vsCryptStr.FlushFinalBlock();

                // The Data has been Encrypted in the Memory, Now get that and Display in the TexTBox
                // Create Byte Array of the Length of MemoryStream
                Byte[] vsBytes = new Byte[vsMemStr.Length - 1];
                vsMemStr.Position = 0;        //Move Cursor to Start of MemoryStream
                vsMemStr.Read(vsBytes, 0, (int)vsMemStr.Length);

                // Encode the Byte Array to UTF8 and display
                UTF8Encoding vsEnc = new UTF8Encoding();
                strEncrypted = vsEnc.GetString(vsBytes);
                */
            }
            catch (CryptographicException err)
            {
                logger.Log(LogLevel.Error, err.Message + " " + err.Source + " " + err.StackTrace); ;
            }
            return strDecrypted;
        }
	}
}
