using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlashCard2
{
    public partial class Form1 : Form
    {
        CardDeck cardDeck = null;
        int number = -1;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cardDeck = new CardDeck();

            tbText.MouseLeave += TbText_MouseLeave;
            tbText.MouseEnter += TbText_MouseEnter;
        }

        private void TbText_MouseEnter(object sender, EventArgs e)
        {
            if (number == -1)
                return;

            tbText.Text = cardDeck.cards.card[number - 1].value.Trim();
        }

        private void TbText_MouseLeave(object sender, EventArgs e)
        {
            tbText.Text = "";
        }

        private void btnStartStop_Click(object sender, EventArgs e)
        {

            int min = 1;
            int max = cardDeck.count;

            Random random = new Random();
            number = random.Next(min, max);

            tbName.Text = cardDeck.cards.card[number - 1].name.Trim();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cardDeck.SortAndSave();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
