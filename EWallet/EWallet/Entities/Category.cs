using System;
using System.Collections.Generic;
using System.Text;

namespace EWallet.Entities
{
    public enum Color
    {
        red,
        green,
        blue
    }
    public class Category : EntityBase
    {
        private string _name;
        private string _description;
        private Color _color;

        private object icon;

        public string Name { get => _name; set => _name = value; }
        public string Description { get => _description; set => _description = value; }
        public Color Color { get => _color; set => _color = value; }

        public Category()
        {
        }
        public Category(string name, string description, Color color)
        {
            _name = name;
            _description = description;
            _color = color;
        }

        public override bool Validate()
        {
            bool result = true;

            if (string.IsNullOrWhiteSpace(Name))
                result = false;

            return result;
        }
    }
}
