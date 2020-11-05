using System;
using System.Windows.Forms;

/*
 * THIS SOFTWARE IS PROVIDED BY golfb4nafter “AS IS'' AND ANY EXPRESS OR IMPLIED WARRANTIES, 
 * INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR
 * PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL golfb4nafter BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, 
 * SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE
 * GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY 
 * THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE)
 * ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 * 
 */

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
