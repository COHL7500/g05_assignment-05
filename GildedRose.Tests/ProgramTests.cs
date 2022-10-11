namespace GildedRose.Tests;

public class ProgramTests
{
    private List<Item> Items;
   
    public ProgramTests()
    {
        Items = new List<Item>
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
                    Quality = 30
                },
                new()
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 5,
                    Quality = 30
                },
				// this conjured item does not work properly yet
				new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 }
                                          };
    }

    [Fact]
    public void UpdateQualityDexVestTest()
    {
        // Given
        var expected = new Item { Name = "+5 Dexterity Vest", SellIn = 9, Quality = 19 };
        // When
        Program.UpdateQuality(Items);
        // Then
        Items[0].Quality.Should().Be(expected.Quality);
        Items[0].SellIn.Should().Be(expected.SellIn);
    }
    [Fact]
    public void UpdateQualityElixer()
    {
        // Given
        var expected = new Item { Name = "Elixir of the Mongoose", SellIn = 4, Quality = 6 };
        // When
        Program.UpdateQuality(Items);
        // Then
        Items[2].Quality.Should().Be(expected.Quality);
        Items[2].SellIn.Should().Be(expected.SellIn);
    }
    [Fact]
    public void UpdateQualityAgedBrie()
    {
        // Given
        var expected = new Item { Name = "Aged Brie", SellIn = 1, Quality = 1 };
        // When
        Program.UpdateQuality(Items);
        
        // Then
        Items[1].Quality.Should().Be(expected.Quality);
        Items[1].SellIn.Should().Be(expected.SellIn);
    }

    [Fact]
    public void UpdateQualityAgedBrieMoreUpdates()
    {
        // Given
        var expected = new Item { Name = "Aged Brie", SellIn = -1, Quality = 4 };
        // When
        Program.UpdateQuality(Items);
        Program.UpdateQuality(Items);
        Program.UpdateQuality(Items);
        
        // Then
        Items[1].Quality.Should().Be(expected.Quality);
        Items[1].SellIn.Should().Be(expected.SellIn);
    }
    [Fact]
    public void UpdateSulfurasTest()
    {
        // Given
        var expected = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 }; 
        // When
        Program.UpdateQuality(Items);
        // Then
        Items[3].Quality.Should().Be(expected.Quality);
        Items[3].SellIn.Should().Be(expected.SellIn);
    }

    [Fact]
    public void UpdateQualityBackStage()
    {
        // Given
        var expected1 = new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 14,
                    Quality = 21
                };
        var expected2 = new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 9,
                    Quality = 32
                };
        var expected3 = new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 4,
                    Quality = 33
                };
        // When
        Program.UpdateQuality(Items);
        
        // Then
        Items[5].Quality.Should().Be(expected1.Quality);
        Items[5].SellIn.Should().Be(expected1.SellIn);
        Items[6].Quality.Should().Be(expected2.Quality);
        Items[6].SellIn.Should().Be(expected2.SellIn);
        Items[7].Quality.Should().Be(expected3.Quality);
        Items[7].SellIn.Should().Be(expected3.SellIn);
    }
    [Fact]
    public void UpdateTicketQuality0WhenSellinIsPassedDate()
    {
        // Given
        var expected3 = new Item
        {
            Name = "Backstage passes to a TAFKAL80ETC concert",
            SellIn = -1,
            Quality = 0
        };
        // When
        Program.UpdateQuality(Items);
        Program.UpdateQuality(Items);
        Program.UpdateQuality(Items);
        Program.UpdateQuality(Items);
        Program.UpdateQuality(Items);
        Program.UpdateQuality(Items);
        // Then
        Items[7].Quality.Should().Be(expected3.Quality);
        Items[7].SellIn.Should().Be(expected3.SellIn);   
    }
    [Fact]
    public void TestConsoleOutput()
    {
        // Given
        using var writer =  new StringWriter();
        Console.SetOut(writer);
        // When
        Program.Main(new String [0]);
        var output = writer.GetStringBuilder().ToString();  
        // Then
        output.Length.Should().Be(File.ReadAllText("../../../output.txt").Length);
    }
}
//dotnet test /p:CollectCoverage=true