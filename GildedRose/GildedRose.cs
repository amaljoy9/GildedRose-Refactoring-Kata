using System.Collections.Generic;

namespace GildedRoseKata
{
    public class GildedRose
    {
        IList<Item> Items;

        public GildedRose(IList<Item> items)
        {
            Items = items;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                UpdateItemQuality(item);
                UpdateItemSellIn(item);

                if (item.SellIn < 0)
                {
                    HandleExpiredItem(item);
                }
            }
        }

        private void UpdateItemQuality(Item item)
        {
            switch (item.Name)
            {
                case "Aged Brie":
                    IncreaseQuality(item, 1);
                    break;
                case "Backstage passes to a TAFKAL80ETC concert":
                    IncreaseQuality(item, 1);
                    if (item.SellIn < 11)
                    {
                        IncreaseQuality(item, 1);
                    }
                    if (item.SellIn < 6)
                    {
                        IncreaseQuality(item, 1);
                    }
                    break;
                case "Sulfuras, Hand of Ragnaros":
                    // Sulfuras does not change in quality or sell-in
                    break;
                default:
                    DecreaseQuality(item, 1);
                    break;
            }
        }

        private void UpdateItemSellIn(Item item)
        {
            if (item.Name != "Sulfuras, Hand of Ragnaros")
            {
                item.SellIn -= 1;
            }
        }

        private void HandleExpiredItem(Item item)
        {
            switch (item.Name)
            {
                case "Aged Brie":
                    IncreaseQuality(item, 1);
                    break;
                case "Backstage passes to a TAFKAL80ETC concert":
                    item.Quality = 0;
                    break;
                case "Sulfuras, Hand of Ragnaros":
                    // Sulfuras does not change in quality or sell-in
                    break;
                default:
                    DecreaseQuality(item, 1);
                    break;
            }
        }

        private void IncreaseQuality(Item item, int amount)
        {
            if (item.Quality < 50)
            {
                item.Quality += amount;
            }
        }

        private void DecreaseQuality(Item item, int amount)
        {
            if (item.Quality > 0)
            {
                item.Quality -= amount;
            }
        }
    }
}