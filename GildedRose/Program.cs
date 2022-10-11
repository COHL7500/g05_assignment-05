namespace GildedRose
{
    public class Program
    {
        private IList<Item> _items = null!;
        public static void Main(string[] args)
        {
            Console.WriteLine("OMGHAI!");

            var app = new Program()
            {
                _items = new List<Item>
                                          {
                new() { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 },
                new() { Name = "Aged Brie", SellIn = 2, Quality = 0 },
                new() { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7 },
                new() { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 },
                new() { Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80 },
                new()
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20
                },
                new()
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 10,
                    Quality = 49
                },
                new()
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 5,
                    Quality = 49
                },
				// this conjured item does not work properly yet
				new() { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 }
                                          }

            };

            for (var i = 0; i < 31; i++)
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

        public static void UpdateQuality(IList<Item> inItems)
        {
            foreach (var t in inItems)
            {
                if (t.Name != "Aged Brie" && t.Name != "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (t.Quality > 0)
                    {
                        if (t.Name != "Sulfuras, Hand of Ragnaros")
                        {
                            t.Quality -= 1;
                        }
                    }
                }
                else
                {
                    if (t.Quality < 50)
                    {
                        t.Quality += 1;

                        if (t.Name == "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (t.SellIn < 11)
                            {
                                if (t.Quality < 50)
                                {
                                    t.Quality += 1;
                                }
                            }

                            if (t.SellIn < 6)
                            {
                                if (t.Quality < 50)
                                {
                                    t.Quality += 1;
                                }
                            }
                        }
                    }
                }

                if (t.Name != "Sulfuras, Hand of Ragnaros")
                {
                    t.SellIn -= 1;
                }

                if (t.SellIn < 0)
                {
                    if (t.Name != "Aged Brie")
                    {
                        if (t.Name != "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (t.Quality > 0)
                            {
                                if (t.Name != "Sulfuras, Hand of Ragnaros")
                                {
                                    t.Quality -= 1;
                                }
                            }
                        }
                        else
                        {
                            t.Quality -= t.Quality;
                        }
                    }
                    else
                    {
                        if (t.Quality < 50)
                        {
                            t.Quality += 1;
                        }
                    }
                }
            }
        }
        //Items = InItems;

    }

    public class Item
    {
        public string Name { get; set; } = null!;

        public int SellIn { get; set; }

        public int Quality { get; set; }
    }

}