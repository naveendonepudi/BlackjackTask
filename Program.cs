namespace BlackjackTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(BlackjackHighestCount(new String[] { "ace", "queen" }));
        }

        static string BlackjackHighestCount(string[] strArr)
        {
            Card[] cards = new Card[strArr.Length];
            for (int i = 0; i < strArr.Length; i++)
            {
                cards[i] = new Card(strArr[i]);
            }

            Array.Sort(cards, (o1, o2) => o1.rating.CompareTo(o2.rating));

            int total = 0;
            bool hasAce = false, aceUsed = false;
            foreach (var card in cards)
            {
                if (card.rating == 14)
                {
                    hasAce = true;
                }

                if (total + card.topVal > 21)
                {
                    total += card.lowVal;
                }
                else
                {
                    if (card.rating == 14)
                    {
                        aceUsed = true;
                    }
                    total += card.topVal;
                }
            }

            Card highest = cards[cards.Length - 1];
            if (hasAce && !aceUsed)
            {
                highest = cards[cards.Length - 2];
            }

            if (total < 21)
            {
                return "below " + highest.repr;
            }
            else if (total == 21)
            {
                return "blackjack " + highest.repr;
            }
            return "above " + highest.repr;

        }

    }

    public class Card
    {
        public int lowVal = 0, topVal = 0, rating = 0;
        public string repr;

        public Card(string card)
        {
            card = card.ToLower();
            repr = card;

            if (card.Equals("two"))
            {
                lowVal = 2; topVal = 2; rating = 2;
            }
            else if (card.Equals("three"))
            {
                lowVal = 3; topVal = 3; rating = 3;
            }
            else if (card.Equals("four"))
            {
                lowVal = 4; topVal = 4; rating = 4;
            }
            else if (card.Equals("five"))
            {
                lowVal = 5; topVal = 5; rating = 5;
            }
            else if (card.Equals("six"))
            {
                lowVal = 6; topVal = 6; rating = 6;
            }
            else if (card.Equals("seven"))
            {
                lowVal = 7; topVal = 7; rating = 7;
            }
            else if (card.Equals("eight"))
            {
                lowVal = 8; topVal = 8; rating = 8;
            }
            else if (card.Equals("nine"))
            {
                lowVal = 9; topVal = 9; rating = 9;
            }
            else if (card.Equals("ten"))
            {
                lowVal = 10; topVal = 10; rating = 10;
            }
            else if (card.Equals("jack"))
            {
                lowVal = 10; topVal = 10; rating = 11;
            }
            else if (card.Equals("queen"))
            {
                lowVal = 10; topVal = 10; rating = 12;
            }
            else if (card.Equals("king"))
            {
                lowVal = 10; topVal = 10; rating = 13;
            }
            else if (card.Equals("ace"))
            {
                lowVal = 1; topVal = 11; rating = 14;
            }
        }
    }
}