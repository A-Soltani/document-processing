using System;
using System.Collections.Generic;
using System.Xml.Linq;
using DocumentProcessing.Domain;
using Xunit;

namespace DocumentProcessing.UnitTests {
    public class DocumentTests {
        [Fact]
        public void Process_JustOneWordIsProcessed_StatisticsShouldBeReturned () {

            // string elements = "p;li;";
            string elementTag = "p";
            string wordName = "Ali";
            int expectedWordTotalCount = 2;

            XDocument doc = XDocument.Load (@"../../../../../../../../doc/sample.xml");
            int wordTotalCount = 0;

            foreach (XElement element in doc.Descendants (elementTag)) {
                string words = element.Value;
                Dictionary<string, int> statistics = Document.Process (words, elementTag);

                statistics.TryGetValue (wordName, out int wordCount);
                wordTotalCount += wordCount;
            }

            Assert.Equal (expectedWordTotalCount, wordTotalCount);
        }
    }

}