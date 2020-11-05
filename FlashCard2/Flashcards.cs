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

using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCard2
{

    public class CardDeck
    {

        public CardCollection cards { get; set; }

        public int count { get; set; }

        public CardDeck()
        {
            string path = ".\\Data\\Flashcards.xml";

            XmlSerializer serializer = new XmlSerializer(typeof(CardCollection));

            using (StreamReader reader = new StreamReader(path))
            {
                cards = (CardCollection)serializer.Deserialize(reader);
                count = cards.card.Length;
                reader.Close();
            }
        }

        public void SortAndSave()
        {
            string path = ".\\Data\\Flashcards.xml";

            List<Card> srtCardsList = new List<Card>();
            foreach (Card c in cards.card)
                srtCardsList.Add(c);

            srtCardsList.Sort();

            cards.card = srtCardsList.ToArray();

            //rename
            if (File.Exists(path + ".bak"))
                File.Delete(path + ".bak");

            File.Move(path, path + ".bak");

            XmlSerializer serializer = new XmlSerializer(typeof(CardCollection));
            StreamWriter sw = new StreamWriter(path);
            serializer.Serialize(sw, cards);
        }
    }

    [Serializable()]
    [System.Xml.Serialization.XmlRoot("CardCollection")]
    public class CardCollection
    {
        [XmlArray("Cards")]
        [XmlArrayItem("Card", typeof(Card))]
        public Card[] card { get; set; }
    }

    [Serializable()]
    public class Card : IComparable
    {
        [System.Xml.Serialization.XmlElement("name")]
        public string name { get; set; }

        [System.Xml.Serialization.XmlElement("value")]
        public string value { get; set; }

        public int CompareTo(object obj)
        {
            return this.name.CompareTo(((Card)obj).name);
        }
    }
}
