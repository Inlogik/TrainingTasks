using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace TrainingTasks4
{
    [TestFixture]
    public class HtmlTests
    {
        [Test]
        public void BasicHtmlBuilder()
        {
            Html html = Html.Tag("div").Attr("test", "testvalue");
            Assert.AreEqual("<div test=\"testvalue\"></div>", html.ToString());
        }

        [Test]
        public void BasicHtmlBuilderMultipleAttributes()
        {
            Html html = Html.Tag("div").Attr("test", "testvalue").Attr("test1", "testvalue1");
            Assert.AreEqual("<div test=\"testvalue\" test1=\"testvalue1\"></div>", html.ToString());
        }

        [Test]
        public void BasicHtmlBuilderAddClass()
        {
            Html html = Html.Tag("span").Attr("test", "testvalue").AddClass("wow");
            Assert.AreEqual("<span test=\"testvalue\" class=\"wow\"></span>", html.ToString());
        }

        [Test]
        public void BasicHtmlBuilderModify()
        {
            Html html = Html.Tag("div").Attr("test", "testvalue").Modify(x => x.AddClass("wow"));
            Assert.AreEqual("<div test=\"testvalue\" class=\"wow\"></div>", html.ToString());
        }

        [Test]
        public void BasicHtmlBuilderWithoutToString()
        {
            Html html = Html.Tag("span").Attr("test", "testvalue");
            Assert.True("<span test=\"testvalue\"></span>" == html);
        }
    }
}
