using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace DocumentProcessing.Domain {
    public class Document {
        public static Dictionary<string, int> Process (string content, string elementTag) {

            string[] words = content.Split (new [] { " " }, StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> statistics = words
                .GroupBy (word => word)
                .ToDictionary (
                    kvp => kvp.Key, // the word itself is the key
                    kvp => kvp.Count ()); // number of occurences is the value

            return statistics;

        }
    }
}