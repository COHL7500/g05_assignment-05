namespace GildedRose.Tests;

public class ProgramTests
{
    private readonly List<Item> _items;
   
    public ProgramTests()
    {
        _items = new List<Item>
                                          {
                new NormalItem { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 },
                new BrieItem { Name = "Aged Brie", SellIn = 2, Quality = 0 },
                new NormalItem { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7 },
                new LegendaryItem { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 },
                new LegendaryItem { Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80 },
                new PassItem {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20},
                new PassItem {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 30},
                new PassItem {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 30},
                new ConjuredItem {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6},
                new ConjuredItem {Name = "Conjured Mana Biscuit", SellIn = 2, Quality = 1}
                                          };
    }
    [Fact]
    public void UpdateQuality_decrements_NormalItem_Quality_and_sellIn_by_1()
    {
        // Given
        var expected1 = new NormalItem { Name = "+5 Dexterity Vest", SellIn = 9, Quality = 19 };
        var expected2 = new NormalItem { Name = "Elixir of the Mongoose", SellIn = 4, Quality = 6 };
        // When
        Program.UpdateQuality(_items);
        // Then
        _items[0].Quality.Should().Be(expected1.Quality);
        _items[0].SellIn.Should().Be(expected1.SellIn);
        
        _items[2].Quality.Should().Be(expected2.Quality);
        _items[2].SellIn.Should().Be(expected2.SellIn);
    }
    
    [Fact]
    public void UpdateQuality_increases_quality_by_1_given_AgedBrie()
    {
        // Given
        var expected = new BrieItem { Name = "Aged Brie", SellIn = 1, Quality = 1 };
        // When
        Program.UpdateQuality(_items);
        
        // Then
        _items[1].Quality.Should().Be(expected.Quality);
        _items[1].SellIn.Should().Be(expected.SellIn);
    }
    
    [Fact]
    public void UpdateQuality_no_effect_given_LegendaryItem()
    {
        // Given
        var expected = new LegendaryItem { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 }; 
        // When
        Program.UpdateQuality(_items);
        // Then
        _items[3].Quality.Should().Be(expected.Quality);
        _items[3].SellIn.Should().Be(expected.SellIn);
    }

    [Fact]
    public void UpdateQuality_given_PassItem_increases_Quality_getting_closer_to_SellIn_0()
    {
        // Given
        var expected1 = new PassItem { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 14, Quality = 21};
        var expected2 = new PassItem {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 9, Quality = 32};
        var expected3 = new PassItem {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 4, Quality = 33};

        // When
        Program.UpdateQuality(_items);
        
        // Then
        _items[5].Quality.Should().Be(expected1.Quality);
        _items[5].SellIn.Should().Be(expected1.SellIn);
        
        _items[6].Quality.Should().Be(expected2.Quality);
        _items[6].SellIn.Should().Be(expected2.SellIn);
        
        _items[7].Quality.Should().Be(expected3.Quality);
        _items[7].SellIn.Should().Be(expected3.SellIn);
    }
    
    [Fact]
    public void UpdateQuality_given_PassItem_decreases_Quality_to_0_given_SellIn_is_0()
    {
        // Given
        var expected3 = new PassItem
        {
            Name = "Backstage passes to a TAFKAL80ETC concert",
            SellIn = -1,
            Quality = 0
        };
        // When

        for (int i = 0; i < 6; i++)
        {
            Program.UpdateQuality(_items);
        }
        
        // Then
        _items[7].Quality.Should().Be(expected3.Quality);
        _items[7].SellIn.Should().Be(expected3.SellIn);   
    }
    
    [Fact]
    public void UpdateQuality_given_ConjuredItem_decreases_Quality_double_NormalItem()
    {
        // Given
        var expected = new ConjuredItem
        {
            Name = "Conjured Mana Cake",
            SellIn = 2,
            Quality = 4
        };
        
        var expected2 = new ConjuredItem
        {
            Name = "Conjured Mana Biscuit",
            SellIn = 1,
            Quality = 0
        };
        
        // When
        Program.UpdateQuality(_items);
        // Then
        _items[8].Quality.Should().Be(expected.Quality);
        _items[8].SellIn.Should().Be(expected.SellIn);
        
        _items[9].Quality.Should().Be(expected2.Quality);
        _items[9].SellIn.Should().Be(expected2.SellIn);   
    }
    
    [Fact]
    public void ConsoleOutput_is_equal_given_output_txt_file()
    {
        // Given
        using var writer =  new StringWriter();
        Console.SetOut(writer);
        // When
        Program.Main();
        string output = writer.GetStringBuilder().ToString();  
        // Then
        output.Length.Should().Be(File.ReadAllText("../../../output.txt").Length + 1);
    }
}
//dotnet test /p:CollectCoverage=true
