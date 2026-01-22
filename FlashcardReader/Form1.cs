using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FlashcardReader
{
    public partial class Form1 : Form
    {
        private List<Flashcard> cards = new List<Flashcard>();
        private int currentIndex = 0;
        private bool isShowingMeaning = false;

        private Label lblCount;

        private Color colorBackground = Color.FromArgb(54, 57, 63);
        private Color colorTextEng = Color.FromArgb(220, 221, 222);
        private Color colorTextVN = Color.FromArgb(88, 101, 242);
        private Color colorCounter = Color.FromArgb(114, 118, 125);

        public Form1()
        {
            InitializeComponent();
            SetupCustomUI();
        }

        private void SetupCustomUI()
        {
            this.BackColor = colorBackground;
            this.Text = "Flashcard Learning";
            this.KeyPreview = true;

            lblWord.ForeColor = colorTextEng;
            lblWord.Font = new Font("Calibri", 48, FontStyle.Regular);
            lblWord.Dock = DockStyle.Fill;
            lblWord.TextAlign = ContentAlignment.MiddleCenter;
            lblWord.Text = "Open File to Start";
            lblWord.MouseClick += LblWord_MouseClick;

            lblCount = new Label();
            lblCount.ForeColor = colorCounter;
            lblCount.Font = new Font("Consolas", 14, FontStyle.Bold);
            lblCount.Location = new Point(10, 30);
            lblCount.AutoSize = true;
            lblCount.Text = "";
            this.Controls.Add(lblCount);
            lblCount.BringToFront();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files (*.txt)|*.txt";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                LoadFile(openFileDialog.FileName);
            }
        }

        private void shuffleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cards.Count == 0) return;

            Random rng = new Random();
            int n = cards.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Flashcard value = cards[k];
                cards[k] = cards[n];
                cards[n] = value;
            }

            isShowingMeaning = false;
            UpdateDisplay();
        }

        private void LoadFile(string path)
        {
            try
            {
                var lines = File.ReadAllLines(path).Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
                cards.Clear();

                int idCounter = 1;
                for (int i = 0; i < lines.Count - 1; i += 2)
                {
                    cards.Add(new Flashcard
                    {
                        OriginalId = idCounter++,
                        English = lines[i].Trim(),
                        Vietnamese = lines[i + 1].Trim()
                    });
                }

                if (cards.Count > 0)
                {
                    currentIndex = 0;
                    isShowingMeaning = false;
                    UpdateDisplay();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void UpdateDisplay()
        {
            if (cards.Count == 0) return;

            Flashcard currentCard = cards[currentIndex];

            lblCount.Text = $"#{currentCard.OriginalId}  ({currentIndex + 1}/{cards.Count})";

            if (!isShowingMeaning)
            {
                lblWord.ForeColor = colorTextEng;
                lblWord.Text = currentCard.English;
            }
            else
            {
                lblWord.ForeColor = colorTextVN;
                lblWord.Text = currentCard.Vietnamese;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (cards.Count > 0)
            {
                if (keyData == Keys.Space)
                {
                    ToggleMeaning();
                    return true;
                }

                if (keyData == Keys.Enter)
                {
                    NextCard();
                    return true;
                }

                if (keyData == Keys.Left)
                {
                    PrevCard();
                    return true;
                }

                if (keyData == Keys.Right)
                {
                    NextCard();
                    return true;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void LblWord_MouseClick(object sender, MouseEventArgs e)
        {
            if (cards.Count == 0) return;

            if (e.Button == MouseButtons.Left)
            {
                ToggleMeaning();
            }
            else if (e.Button == MouseButtons.Right)
            {
                NextCard();
            }
        }

        private void ToggleMeaning()
        {
            isShowingMeaning = !isShowingMeaning;
            UpdateDisplay();
        }

        private void NextCard()
        {
            if (currentIndex < cards.Count - 1)
            {
                currentIndex++;
                isShowingMeaning = false;
                UpdateDisplay();
            }
            else
            {
                MessageBox.Show("Done.", "Flashcard");
            }
        }

        private void PrevCard()
        {
            if (currentIndex > 0)
            {
                currentIndex--;
                isShowingMeaning = false;
                UpdateDisplay();
            }
        }
    }

    public class Flashcard
    {
        public int OriginalId { get; set; }
        public string English { get; set; }
        public string Vietnamese { get; set; }
    }
}