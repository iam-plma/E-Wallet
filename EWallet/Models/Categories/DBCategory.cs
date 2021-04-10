using DataStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Categories
{
    public class DBCategory : IStorable
    {
        public Guid Guid { get; }
        public string FileName { get; set; }
        public string Label { get; }
        public string Description { get; }

        public DBCategory(string label, string description, string fileName = "")
        {
            Guid = Guid.NewGuid();
            Label = label;
            Description = description;

            if (String.IsNullOrEmpty(fileName))
                FileName = Guid.ToString("N");
            else
                FileName = fileName;
        }
    }
}
