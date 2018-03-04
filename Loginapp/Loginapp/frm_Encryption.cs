using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace Loginapp
{
    public partial class frm_Encryption : Form
    {
        public frm_Encryption()
        {
            InitializeComponent();
            desObj = Rijndael.Create();
        }

        string cipherd;
        byte[] cypherb;
        byte[] plainb;
        byte[] plainb2            ;
        byte[] playnk;
        SymmetricAlgorithm desObj;

        //Encrypt string
        private void btn_encrypt_Click(object sender, EventArgs e)
        {
            cipherd = txt_sample.Text;
            plainb = Encoding.ASCII.GetBytes(cipherd);
            playnk = Encoding.ASCII.GetBytes("0123456789abcdef");
            //desObj.BlockSize = 256;
            desObj.Key = playnk;

            desObj.Mode = CipherMode.CBC;
            desObj.Padding = PaddingMode.PKCS7;
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            CryptoStream cs = new CryptoStream(ms, desObj.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(plainb, 0, plainb.Length);
            cs.Close();
            cypherb = ms.ToArray();
            ms.Close();
            txt_encrypt.Text = Encoding.ASCII.GetString(cypherb);



        }

        //Decrypt string
        private void btn_decrypt_Click(object sender, EventArgs e)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream(cypherb);
            CryptoStream cs = new CryptoStream(ms, desObj.CreateDecryptor(), CryptoStreamMode.Read);
            cs.Read(cypherb, 0, cypherb.Length);
            plainb2 = ms.ToArray();
            cs.Close();
            ms.Close();
            txt_decrypt.Text = Encoding.ASCII.GetString(plainb2);

        }
    }
}
