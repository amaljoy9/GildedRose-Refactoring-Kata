using Xunit;
using System.Collections.Generic;
using GildedRoseKata;

namespace GildedRoseTests;

public class GildedRoseTest
{
    [Fact]
    public void foo()
    {
        IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
        GildedRose app = new GildedRose(Items);
        app.UpdateQuality();
        Assert.Equal("foo", Items[0].Name);
    }
    
     [Fact]
        public void UpdateQuality_NormalItem_BeforeSellInDate()
        {
            var items = new List<Item>
            {
                new Item { Name = "Normal Item", SellIn = 10, Quality = 20 }
            };
            var app = new GildedRose(items);

            app.UpdateQuality();

            Assert.Equal(9, items[0].SellIn);
            Assert.Equal(19, items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_NormalItem_AfterSellInDate()
        {
            var items = new List<Item>
            {
                new Item { Name = "Normal Item", SellIn = 0, Quality = 20 }
            };
            var app = new GildedRose(items);

            app.UpdateQuality();

            Assert.Equal(-1, items[0].SellIn);
            Assert.Equal(18, items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_AgedBrie_BeforeSellInDate()
        {
            var items = new List<Item>
            {
                new Item { Name = "Aged Brie", SellIn = 10, Quality = 20 }
            };
            var app = new GildedRose(items);

            app.UpdateQuality();

            Assert.Equal(9, items[0].SellIn);
            Assert.Equal(21, items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_AgedBrie_AfterSellInDate()
        {
            var items = new List<Item>
            {
                new Item { Name = "Aged Brie", SellIn = 0, Quality = 20 }
            };
            var app = new GildedRose(items);

            app.UpdateQuality();

            Assert.Equal(-1, items[0].SellIn);
            Assert.Equal(22, items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_BackstagePasses_LongBeforeConcert()
        {
            var items = new List<Item>
            {
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 20 }
            };
            var app = new GildedRose(items);

            app.UpdateQuality();

            Assert.Equal(14, items[0].SellIn);
            Assert.Equal(21, items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_BackstagePasses_CloseToConcert()
        {
            var items = new List<Item>
            {
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 20 }
            };
            var app = new GildedRose(items);

            app.UpdateQuality();

            Assert.Equal(9, items[0].SellIn);
            Assert.Equal(22, items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_BackstagePasses_VeryCloseToConcert()
        {
            var items = new List<Item>
            {
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 20 }
            };
            var app = new GildedRose(items);

            app.UpdateQuality();

            Assert.Equal(4, items[0].SellIn);
            Assert.Equal(23, items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_BackstagePasses_AfterConcert()
        {
            var items = new List<Item>
            {
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 20 }
            };
            var app = new GildedRose(items);

            app.UpdateQuality();

            Assert.Equal(-1, items[0].SellIn);
            Assert.Equal(0, items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_Sulfuras()
        {
            var items = new List<Item>
            {
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 10, Quality = 80 }
            };
            var app = new GildedRose(items);

            app.UpdateQuality();

            Assert.Equal(10, items[0].SellIn);
            Assert.Equal(80, items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_QualityDoesNotExceedFifty()
        {
            var items = new List<Item>
            {
                new Item { Name = "Aged Brie", SellIn = 10, Quality = 50 }
            };
            var app = new GildedRose(items);

            app.UpdateQuality();

            Assert.Equal(9, items[0].SellIn);
            Assert.Equal(50, items[0].Quality);
        }

        [Fact]
        public void UpdateQuality_QualityDoesNotDropBelowZero()
        {
            var items = new List<Item>
            {
                new Item { Name = "Normal Item", SellIn = 10, Quality = 0 }
            };
            var app = new GildedRose(items);

            app.UpdateQuality();

            Assert.Equal(9, items[0].SellIn);
            Assert.Equal(0, items[0].Quality);
        }
}