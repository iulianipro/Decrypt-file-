using System;
using System.IO;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private string keyFilePath;
        private string selectedFilePath;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnSelectKeyFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Key Files (*.key)|*.key";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    keyFilePath = openFileDialog.FileName;
                    txtKeyFile.Text = Path.GetFileName(keyFilePath);
                }
            }
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Encrypted Files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedFilePath = openFileDialog.FileName;
                    txtSelectedFile.Text = Path.GetFileName(selectedFilePath);
                }
            }
        }

        private async void btnDecrypt_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(keyFilePath) || string.IsNullOrEmpty(selectedFilePath))
            {
                MessageBox.Show("Please select a key file and an encrypted file.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                btnDecrypt.Enabled = false;
                progressBar1.Value = 0;
                lblStatus.Text = "Decrypting...";

                await DecryptFileAsync(selectedFilePath, keyFilePath);

                lblStatus.Text = "Decryption Successful!";
                progressBar1.Value = 100;
                MessageBox.Show("File decrypted successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Decryption Failed";
                MessageBox.Show($"Decryption error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnDecrypt.Enabled = true;
            }
        }

        private async Task DecryptFileAsync(string inputFile, string keyFile)
        {
            byte[] keyBytes = File.ReadAllBytes(keyFile);

            string outputFile = Path.Combine(
                Path.GetDirectoryName(inputFile),
                Path.GetFileNameWithoutExtension(inputFile) + "_decrypted" + Path.GetExtension(inputFile)
            );

            using (Aes aesAlg = Aes.Create())
            {
                using (var deriveBytes = new Rfc2898DeriveBytes(keyBytes,
                    new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 }, 1000))
                {
                    aesAlg.Key = deriveBytes.GetBytes(32);
                    aesAlg.IV = deriveBytes.GetBytes(16);
                }

                aesAlg.Mode = CipherMode.CBC;
                aesAlg.Padding = PaddingMode.PKCS7;

                using (var inputFileStream = new FileStream(inputFile, FileMode.Open))
                using (var outputFileStream = new FileStream(outputFile, FileMode.Create))
                using (var decryptor = aesAlg.CreateDecryptor())
                using (var cryptoStream = new CryptoStream(outputFileStream, decryptor, CryptoStreamMode.Write))
                {
                    long totalBytes = inputFileStream.Length;
                    long processedBytes = 0;
                    byte[] buffer = new byte[4096];
                    int bytesRead;

                    while ((bytesRead = await inputFileStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                    {
                        await cryptoStream.WriteAsync(buffer, 0, bytesRead);
                        processedBytes += bytesRead;
                        UpdateProgress((int)((double)processedBytes / totalBytes * 100));
                    }
                }
            }
        }

        private void UpdateProgress(int percentage)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<int>(UpdateProgress), percentage);
                return;
            }
            progressBar1.Value = percentage;
        }

        private void btnBatchDecrypt_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(keyFilePath))
            {
                MessageBox.Show("Please select a key file first.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Select folder with files to decrypt";
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string[] encryptedFiles = Directory.GetFiles(folderDialog.SelectedPath, "*.*");
                        int successCount = 0, failureCount = 0;

                        foreach (string file in encryptedFiles)
                        {
                            try
                            {
                                DecryptFileAsync(file, keyFilePath).Wait();
                                successCount++;
                            }
                            catch
                            {
                                failureCount++;
                            }
                        }

                        MessageBox.Show(
                            $"Batch Decryption Complete\nSuccessful: {successCount}\nFailed: {failureCount}",
                            "Batch Decryption",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Batch decryption error: {ex.Message}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}