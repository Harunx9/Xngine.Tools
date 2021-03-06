﻿using System.Collections.Generic;
using System.Xml.Serialization;
using Xngine.Packer.Model.ImageProcessing;

namespace Xngine.Packer.Model.SerializableEntities
{
    // Animation xml scheme with names
    //<spritesheet>
    //    <item name="anim_1" x="0" y="0" width="50" height="50" offsetx="0" offsety="0"/>
    //    <item name="anim_2" x="0" y="0" width="50" height="50" offsetx="0" offsety="0"/>
    //    <item name="anim_3" x="0" y="0" width="50" height="50" offsetx="0" offsety="0"/>
    //    <item name="anim_4" x="0" y="0" width="50" height="50" offsetx="0" offsety="0"/>
    //    <item name="anim_5" x="0" y="0" width="50" height="50" offsetx="0" offsety="0"/>
    //    <item name="anim_6" x="0" y="0" width="50" height="50" offsetx="0" offsety="0"/>
    //    <item name="anim_7" x="0" y="0" width="50" height="50" offsetx="0" offsety="0"/>
    //    <item name="anim_8" x="0" y="0" width="50" height="50" offsetx="0" offsety="0"/>
    //</spritesheet>

    [XmlRoot("spritesheet")]
    public class SpriteSheet
    {
        [XmlElement("item")]
        public List<Item> Items { get; set; }

        public SpriteSheet()
        {
            Items = new List<Item>();
        }

        public SpriteSheet Add(Item item)
        {
            Items.Add(item);
            return this;
        }

        public static SpriteSheet Create<T>(SpriteSheetConfig<T> spriteSheetConfig)
        {
            var sheet = new SpriteSheet();

            foreach (var descriptor in spriteSheetConfig.Descriptors)
            {
                sheet.Add(new Item(descriptor.Name,
                    descriptor.X, descriptor.Y,
                    descriptor.Width, descriptor.Height,
                    spriteSheetConfig.OffsetX, spriteSheetConfig.OffsetY));
            }

            return sheet;
        }
    }

    public class Item
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("x")]
        public int X { get; set; }

        [XmlAttribute("y")]
        public int Y { get; set; }

        [XmlAttribute("width")]
        public int Width { get; set; }

        [XmlAttribute("height")]
        public int Height { get; set; }

        [XmlAttribute("offsetx")]
        public int OffsetX { get; set; }

        [XmlAttribute("offsety")]
        public int OffsetY { get; set; }

        private Item() { }

        public Item(string name,
            int x, int y,
            int width, int height,
            int offsetX, int offsetY)
        {
            Name = name;
            X = x;
            Y = y;
            Width = width;
            Height = height;
            OffsetX = offsetX;
            OffsetY = offsetY;
        }
    }
}
