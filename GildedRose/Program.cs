namespace GildedRose
{
    public class Program
    {
        private IList<Item> _items = null!;
        public static void Main()
        {
            Console.WriteLine("OMGHAI!");

            var app = new Program
            {
                _items = new List<Item>
                                          {
                new NormalItem { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 },
                new BrieItem { Name = "Aged Brie", SellIn = 2, Quality = 0 },
                new NormalItem { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7 },
                new LegendaryItem { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 },
                new LegendaryItem { Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80 },
                
                new PassItem
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20
                },
                new PassItem
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 10,
                    Quality = 49
                },
                new PassItem
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 5,
                    Quality = 49
                },
                
				new ConjuredItem { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 }
                                          }
            };

            for (int i = 0; i < 31; i++)
            {
                Console.WriteLine("-------- day " + i + " --------");
                Console.WriteLine("name, sellIn, quality");
                foreach (var t in app._items)
                {
                    Console.WriteLine(t.Name + ", " + t.SellIn + ", " + t.Quality);
                }
                Console.WriteLine("");
                UpdateQuality(app._items);
            }

        }
        
        private static void UpdateSellIn(Item item)
        {
            if (item is not LegendaryItem)
            {
                item.SellIn -= 1;
            }
        }
        
        public static void UpdateQuality(IEnumerable<Item> inItems)
        {
            foreach (var t in inItems)
            {
                UpdateSellIn(t);
                
                    t.UpdateQuality();
            }
        }
        //Items = InItems;

    }

    /*  JUSTIFICATION FOR CHANGING "ITEM" TO THE GOBLIN:
     * 
     * The "Item" class represents a highly abstract and generic definition of a particular item.
     * If we narrow down the abstraction level, we would - in this scenario - have:
     * NormalItem, LegendaryItem, BrieItem, ConjuredItem and PassItem.
     * 
     * Each categorization of item possesses an unique set of rules, though all with identical attributes:
     * Name, SellIn, Quality and a method for updating quality.
     * 
     * If we make small classes for each category of item, we can easily distinguish between these items!
     * Furthermore, we can also easily add new categories later, as "Item" is now abstract.
     *
     * Worth mentioning, this could also be done with an:
     * - Item Factory: Another obvious solution. 
     * - Wrapper for Item: We could prevent touching item altogether then.
     */
    public abstract class Item
    {
        public string Name { get; set; } = null!;

        public int SellIn { get; set; }

        public int Quality { get; set; }

        public abstract void UpdateQuality();
    }

    public class NormalItem : Item
    {
        public override void UpdateQuality()
        {
            if (Quality <= 0)
            {
                return;
            }

            if (SellIn < 0)
            {
                Quality -= 1;
            }

            Quality -= 1;
        }
    }

    public class PassItem : Item
    {
        public override void UpdateQuality()
        {
            switch (SellIn)
            {
                case < 0:
                    Quality -= Quality;

                    return;

                case < 11:
                {
                    if (Quality < 50)
                    {
                        Quality += 1;
                    }

                    if (Quality < 50 && SellIn < 6)
                    {
                        Quality += 1;
                    }

                    break;
            }
            }

            if (Quality < 50)
            {
                Quality += 1;
            }
        }
    }

    public class BrieItem : Item
    {
        public override void UpdateQuality()
        {
            Quality += 1;
        }
    }

    public class ConjuredItem : Item
    {
        public override void UpdateQuality()
        {
            switch (Quality)
            {
                case 1:
                    Quality -= 1;

                    break;

                case >= 2:
                    Quality -= 2;

                    break;
            }
        }
    }

    public class LegendaryItem : Item
    {
        // LegendaryItem never needs its quality to be updated. 
        public override void UpdateQuality()
        {
            Quality += 0;
        }
    }

}
