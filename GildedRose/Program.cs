using System;
using System.Collections.Generic;

namespace GildedRose
{
    public class Program
    {
        IList<Item> Items;
        public static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            var app = new Program()
            {
                Items = new List<Item>
                                          {
                new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 },
                new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 },
                new Item { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7 },
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 },
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80 },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 10,
                    Quality = 49
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 5,
                    Quality = 49
                },
				// this conjured item does not work properly yet
				new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 }
                                          }

            };

            for (var i = 0; i < 31; i++)
            {
                Console.WriteLine("-------- day " + i + " --------");
                Console.WriteLine("name, sellIn, quality");
                for (var j = 0; j < app.Items.Count; j++)
                {
                    Console.WriteLine(app.Items[j].Name + ", " + app.Items[j].SellIn + ", " + app.Items[j].Quality);
                }
                Console.WriteLine("");
                UpdateQuality(app.Items);
            }

        }

        public static void UpdateQuality(IList<Item> InItems)
        {
            for (var i = 0; i < InItems.Count; i++)
            {
                if (InItems[i].Name != "Aged Brie" && InItems[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                {
                    if (InItems[i].Quality > 0)
                    {
                        if (InItems[i].Name != "Sulfuras, Hand of Ragnaros")
                        {
                            InItems[i].Quality = InItems[i].Quality - 1;
                        }
                    }
                }
                else
                {
                    if (InItems[i].Quality < 50)
                    {
                        InItems[i].Quality = InItems[i].Quality + 1;

                        if (InItems[i].Name == "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (InItems[i].SellIn < 11)
                            {
                                if (InItems[i].Quality < 50)
                                {
                                    InItems[i].Quality = InItems[i].Quality + 1;
                                }
                            }

                            if (InItems[i].SellIn < 6)
                            {
                                if (InItems[i].Quality < 50)
                                {
                                    InItems[i].Quality = InItems[i].Quality + 1;
                                }
                            }
                        }
                    }
                }

                if (InItems[i].Name != "Sulfuras, Hand of Ragnaros")
                {
                    InItems[i].SellIn = InItems[i].SellIn - 1;
                }

                if (InItems[i].SellIn < 0)
                {
                    if (InItems[i].Name != "Aged Brie")
                    {
                        if (InItems[i].Name != "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (InItems[i].Quality > 0)
                            {
                                if (InItems[i].Name != "Sulfuras, Hand of Ragnaros")
                                {
                                    InItems[i].Quality = InItems[i].Quality - 1;
                                }
                            }
                        }
                        else
                        {
                            InItems[i].Quality = InItems[i].Quality - InItems[i].Quality;
                        }
                    }
                    else
                    {
                        if (InItems[i].Quality < 50)
                        {
                            InItems[i].Quality = InItems[i].Quality + 1;
                        }
                    }
                }
            }
        }
        //Items = InItems;

    }

    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
    }

}