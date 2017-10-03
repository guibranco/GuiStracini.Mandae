namespace GuiStracini.Mandae.Models
{
    using System;
    using ValueObject;

    public sealed class ItemModel
    {
        public Guid Identifier { get; set; }

        public Item Item { get; set; }
    }
}
