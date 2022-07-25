using Newtonsoft.Json;
using System.Net;

namespace DeckOfCardsAPILab.Models
{
    public class DeckOfCardsDAL
    {
        public DeckOfCardsModel GetDeckOfCards()     //Adjustments needed if used later
        {
            //Adjustments needed if used later
            //API URL
            string key = "64eighp6she7";     //this should be hidden in a real program
            string url = $"https://deckofcardsapi.com/api/deck/{key}/draw/?count=5";

            //setup request
            HttpWebRequest request = WebRequest.CreateHttp(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            //save response data
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string JSON = reader.ReadToEnd();

            //Adjustments needed if used later
            //convert JSON to a C# object
            DeckOfCardsModel result = JsonConvert.DeserializeObject<DeckOfCardsModel>(JSON);
            return result;
        }
        public void ShuffleCards()
        {
            string url = $"https://deckofcardsapi.com/api/deck/64eighp6she7/shuffle/";

            HttpWebRequest request = WebRequest.CreateHttp(url);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        }
    }
}
