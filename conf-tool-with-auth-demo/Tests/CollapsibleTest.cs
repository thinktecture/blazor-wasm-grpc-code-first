using Bunit;
using ConfTool.Client.Common;
using Xunit;

namespace ConfTool.Tests
{
    public class CollapsibleTest
    {
        [Fact]
        public void TestContentIsCollapsedAfterClicked()
        {
            // Arrange
            using var ctx = new TestContext();

            var cut = ctx.RenderComponent<Collapsible>(parameters => parameters
                .Add(p => p.Collapsed, false)
                .AddChildContent("<h1>Hello World</h1>")
            );

            var aHrefElement = cut.Find("a");

            // Act
            aHrefElement.Click();

            // Assert
            Collapsible component = cut.Instance;

            Assert.True(component.Collapsed);
        }
    }
}
