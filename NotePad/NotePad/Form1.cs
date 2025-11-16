using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotePad
{
    public partial class Form1 : Form
    {
        // Mevcut dosya yolu
        private string currentFilePath = null;
        
        // Dosyanın kaydedilip kaydedilmediğini takip eden değişken
        private bool isSaved = true;
        
        // Mevcut tema durumu (true = koyu tema, false = açık tema)
        private bool isDarkTheme = false;

        public Form1()
        {
            InitializeComponent();
            
            // Başlangıçta açık tema ayarla
            ApplyLightTheme();
            
            // RichTextBox için başlangıç ayarları
            richTextBox1.WordWrap = true;
            richTextBox1.AcceptsTab = true;
            
            // Başlangıç başlığını ayarla
            this.Text = "Notepad - Yeni Dosya";
        }

        #region Dosya İşlemleri

        /// <summary>
        /// Yeni dosya oluşturma işlemi
        /// </summary>
        private void YeniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Kaydedilmemiş değişiklik varsa kullanıcıya sor
            if (!isSaved)
            {
                DialogResult result = MessageBox.Show(
                    "Kaydedilmemiş değişiklikler var. Yeni dosya oluşturmak istiyor musunuz?",
                    "Uyarı",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Cancel)
                    return;
                else if (result == DialogResult.Yes)
                {
                    // Önce mevcut dosyayı kaydet
                    if (currentFilePath != null)
                        SaveFile(currentFilePath);
                    else
                        KaydetToolStripMenuItem_Click(sender, e);
                }
            }

            // Yeni dosya oluştur
            richTextBox1.Clear();
            currentFilePath = null;
            isSaved = true;
            UpdateTitle();
        }

        /// <summary>
        /// Dosya açma işlemi
        /// </summary>
        private void AçToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Kaydedilmemiş değişiklik varsa kullanıcıya sor
            if (!isSaved)
            {
                DialogResult result = MessageBox.Show(
                    "Kaydedilmemiş değişiklikler var. Dosya açmak istiyor musunuz?",
                    "Uyarı",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Cancel)
                    return;
                else if (result == DialogResult.Yes)
                {
                    // Önce mevcut dosyayı kaydet
                    if (currentFilePath != null)
                        SaveFile(currentFilePath);
                    else
                        KaydetToolStripMenuItem_Click(sender, e);
                }
            }

            // Dosya aç dialog'unu göster
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // UTF-8 encoding ile dosyayı oku
                    string content = File.ReadAllText(openFileDialog1.FileName, Encoding.UTF8);
                    richTextBox1.Text = content;
                    currentFilePath = openFileDialog1.FileName;
                    isSaved = true;
                    UpdateTitle();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Dosya açılırken hata oluştu: " + ex.Message,
                        "Hata",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Dosya kaydetme işlemi
        /// </summary>
        private void KaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentFilePath != null)
            {
                // Mevcut dosyaya kaydet
                SaveFile(currentFilePath);
            }
            else
            {
                // Yeni dosya olarak kaydet
                FarklıKaydetToolStripMenuItem_Click(sender, e);
            }
        }

        /// <summary>
        /// Farklı kaydet işlemi
        /// </summary>
        private void FarklıKaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                SaveFile(saveFileDialog1.FileName);
                currentFilePath = saveFileDialog1.FileName;
                UpdateTitle();
            }
        }

        /// <summary>
        /// Dosyayı kaydetme yardımcı metodu
        /// </summary>
        private void SaveFile(string filePath)
        {
            try
            {
                // UTF-8 encoding ile dosyayı kaydet
                File.WriteAllText(filePath, richTextBox1.Text, new UTF8Encoding(false));
                isSaved = true;
                UpdateTitle();
                MessageBox.Show("Dosya başarıyla kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Dosya kaydedilirken hata oluştu: " + ex.Message,
                    "Hata",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Çıkış işlemi
        /// </summary>
        private void ÇıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Düzenleme İşlemleri

        /// <summary>
        /// Kopyala işlemi
        /// </summary>
        private void KopyalaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionLength > 0)
            {
                richTextBox1.Copy();
            }
        }

        /// <summary>
        /// Kes işlemi
        /// </summary>
        private void KesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionLength > 0)
            {
                richTextBox1.Cut();
            }
        }

        /// <summary>
        /// Yapıştır işlemi
        /// </summary>
        private void YapıştırToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                richTextBox1.Paste();
            }
        }

        /// <summary>
        /// Hepsini seç işlemi
        /// </summary>
        private void HepsiniSeçToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        #endregion

        #region Görünüm Ayarları

        /// <summary>
        /// Yazı tipi ayarlama işlemi
        /// </summary>
        private void YazıTipiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Mevcut yazı tipini dialog'a yükle
            fontDialog1.Font = richTextBox1.Font;
            fontDialog1.Color = richTextBox1.ForeColor;

            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Font = fontDialog1.Font;
                richTextBox1.ForeColor = fontDialog1.Color;
            }
        }

        /// <summary>
        /// Açık tema uygulama
        /// </summary>
        private void AçıkTemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplyLightTheme();
            açıkTemaToolStripMenuItem.Checked = true;
            koyuTemaToolStripMenuItem.Checked = false;
        }

        /// <summary>
        /// Koyu tema uygulama
        /// </summary>
        private void KoyuTemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplyDarkTheme();
            açıkTemaToolStripMenuItem.Checked = false;
            koyuTemaToolStripMenuItem.Checked = true;
        }

        /// <summary>
        /// Açık tema stillerini uygular
        /// </summary>
        private void ApplyLightTheme()
        {
            isDarkTheme = false;
            this.BackColor = Color.White;
            richTextBox1.BackColor = Color.White;
            richTextBox1.ForeColor = Color.Black;
            menuStrip1.BackColor = SystemColors.Menu;
            menuStrip1.ForeColor = SystemColors.ControlText;
        }

        /// <summary>
        /// Koyu tema stillerini uygular
        /// </summary>
        private void ApplyDarkTheme()
        {
            isDarkTheme = true;
            this.BackColor = Color.FromArgb(30, 30, 30);
            richTextBox1.BackColor = Color.FromArgb(30, 30, 30);
            richTextBox1.ForeColor = Color.White;
            menuStrip1.BackColor = Color.FromArgb(45, 45, 45);
            menuStrip1.ForeColor = Color.White;
        }

        /// <summary>
        /// Başlık çubuğunu günceller
        /// </summary>
        private void UpdateTitle()
        {
            string fileName = currentFilePath != null 
                ? Path.GetFileName(currentFilePath) 
                : "Yeni Dosya";
            
            this.Text = (isSaved ? "" : "*") + "Notepad - " + fileName;
        }

        #endregion

        #region Event Handlers

        /// <summary>
        /// Metin değiştiğinde çağrılır - kaydedilmemiş değişiklik durumunu günceller
        /// </summary>
        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (isSaved)
            {
                isSaved = false;
                
                // Başlık çubuğuna yıldız ekle
                if (!this.Text.StartsWith("*"))
                {
                    this.Text = "*" + this.Text;
                }
            }
        }

        /// <summary>
        /// Form kapanırken kaydedilmemiş değişiklik kontrolü yapar
        /// </summary>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isSaved)
            {
                DialogResult result = MessageBox.Show(
                    "Kaydedilmemiş değişiklikler var. Çıkmak istediğinize emin misiniz?",
                    "Uyarı",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Cancel || result == DialogResult.No)
                {
                    e.Cancel = true; // Form kapanmasını iptal et
                }
                else if (result == DialogResult.Yes)
                {
                    // Kullanıcı kaydetmek istiyorsa kaydet
                    if (currentFilePath != null)
                        SaveFile(currentFilePath);
                    else
                    {
                        // Yeni dosya olarak kaydetmeyi dene
                        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            SaveFile(saveFileDialog1.FileName);
                        }
                    }
                }
            }
        }

        #endregion
    }
}
