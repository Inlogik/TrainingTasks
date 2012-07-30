using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace TrainingTasks3
{
    [TestFixture]
    public class MenuBuilderTests
    {
        [Test]
        public void MenuTestStatic()
        {
            var config = Menu.Config(x =>
            {
                x.AddStatic("/url/1", "test1");
                x.AddStatic("/admin/2", "admin2");
            });

            var context = new MenuContext() { CurrentUrl = "/admin/3", IsUserAdmin = true };
            var menuBuilder = new MenuBuilder(context, config);
            var items = menuBuilder.Build();

            Assert.AreEqual(2, items.Count);
        }

        [Test]
        public void MenuTestDynamic1()
        {
            var config = Menu.Config(x =>
            {
                x.AddStatic("/anon/1", "anon1");
                x.AddDynamic(cont =>
                {
                    if (cont.IsUserAdmin)
                    {
                        return new List<MenuItem>()
                        {
                            new MenuItem() {Url = "/admin/special", Text = "adminspecial"}
                        };
                    }
                    return Enumerable.Empty<MenuItem>();
                });
            });

            var context = new MenuContext() { CurrentUrl = "/admin/3", IsUserAdmin = true };
            var menuBuilder = new MenuBuilder(context, config);
            var items = menuBuilder.Build();

            Assert.AreEqual(2, items.Count);
        }

        [Test]
        public void MenuTestDynamic2()
        {
            var config = Menu.Config(x =>
            {
                x.AddStatic("/anon/1", "anon1");
                x.AddDynamic(cont =>
                {
                    if (cont.IsUserAdmin)
                    {
                        return new List<MenuItem>()
                        {
                            new MenuItem() {Url = "/admin/special", Text = "adminspecial"}
                        };
                    }
                    return Enumerable.Empty<MenuItem>();
                });
            });

            var context = new MenuContext() { CurrentUrl = "/admin/3", IsUserAdmin = false };
            var menuBuilder = new MenuBuilder(context, config);
            var items = menuBuilder.Build();

            Assert.AreEqual(1, items.Count);
            Assert.AreEqual(items[0].Text, "anon1");
        }

        [Test]
        public void MenuTestVisible()
        {
            var config = Menu.Config(x =>
            {
                x.AddStatic("/url/1", "test1");
                x.AddStatic("/admin/2", "admin2");
                x.Visible((cont, item) =>
                {
                    if (cont.IsUserAdmin && !item.Url.StartsWith("/admin"))
                        return false;

                    return true;
                });
            });

            var context = new MenuContext() {CurrentUrl = "/admin/3", IsUserAdmin = true};
            var menuBuilder = new MenuBuilder(context, config);
            var items = menuBuilder.Build();

            Assert.AreEqual(1, items.Count);
            Assert.AreEqual("admin2", items[0].Text);
        }
    }
}
