﻿using Guts.Client.Classic.TestTools.WPF;
using Guts.Client.Shared;
using NUnit.Framework;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace Exercise5.Tests
{
    //[ExerciseTestFixture("dotnet2", "H03", "Exercise05", @"Exercise5\GridWindow.xaml")]
    [TestFixture]
    [Apartment(ApartmentState.STA)]
    public class GridWindowTests
    {
        private TestWindow<GridWindow> _window;
        private Grid _grid, _innerGrid;
        private StackPanel _stackPanel;
        private Button _button;

        [OneTimeSetUp]
        public void Setup()
        {
            _window = new TestWindow<GridWindow>();
            _grid = _window.GetUIElements<Grid>().FirstOrDefault();
            _innerGrid = _grid.Children.OfType<Grid>().FirstOrDefault();
            _stackPanel = _window.GetUIElements<StackPanel>().FirstOrDefault();
            _button = _window.GetUIElements<Button>().FirstOrDefault();           
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            Dispatcher.CurrentDispatcher.InvokeShutdown();
            _window.Dispose();
        }

        [MonitoredTest("Grid Should have 3 rows"), Order(1)]
        public void _01_GridShouldHave3Rows()
        {
            AssertGridHas3Cells();
        }

        [MonitoredTest("First Row should contain a stackpanel with 2 TextBoxes, 2 TextBlocks and a Button"), Order(2)]
        public void _01_FirstRowOfGridShouldContainAStackPanel()
        {
            AssertGridHasHorizontalStackPanelInHisFirstRow();
        }

        private void AssertGridHasHorizontalStackPanelInHisFirstRow()
        {
            Assert.That(_stackPanel, Is.Not.Null, "Outer Grid should contain a StackPanel");
            Assert.That(_stackPanel.GetValue(Grid.RowProperty), Is.EqualTo(0),"Grid should contain a StackPanel in its first row");
            Assert.That(_stackPanel.Orientation, Is.EqualTo(Orientation.Horizontal), "The stackpanel inside the first row of the grid must have an horizontal orientation");
        }

        [MonitoredTest("First Row should contain a stackpanel with 2 TextBoxes, 2 TextBlocks and a Button"), Order(2)]
        public void _02_StackPanelShouldContain5Controls()
        {
            UIElementCollection stackPanelChildren= _stackPanel.Children;
            Assert.That(stackPanelChildren.Count, Is.EqualTo(5), "The stackPanel within the first row of the Grid should contain 5 controls.");

            Assert.That(stackPanelChildren.OfType<TextBlock>().Count(), Is.EqualTo(2),"The StackPanel has to contain 2 TextBlocks.");
            Assert.That(stackPanelChildren.OfType<TextBox>().Count(), Is.EqualTo(2), "The StackPanel has to contain 2 TextBoxex.");
            Assert.That(stackPanelChildren.OfType<Button>().Count(), Is.EqualTo(1), "The StackPanel has to contain 1 Button.");

        }

        private bool VerifyClickEventHandler(object objectWithEvent, string eventName)
        {
            var eventStore = objectWithEvent.GetType()
            .GetProperty("EventHandlersStore", BindingFlags.Instance | BindingFlags.NonPublic)
            .GetValue(objectWithEvent, null);

            if (eventStore != null)
            {
                var clickEvent = ((RoutedEventHandlerInfo[])eventStore
                .GetType()
                .GetMethod("GetRoutedEventHandlers", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                .Invoke(eventStore, new object[] { Button.ClickEvent }))
                .First();
                return clickEvent.Handler.Method.Name == null ? false : true;

            }
            return false;
        }

        [MonitoredTest("Button in StackPanel should a have Click event handler"), Order(3)]
        public void _03_ButtonInStackPanelShouldHaveClickEventHandler()
        {
            Assert.That(VerifyClickEventHandler(_button, "Click"), Is.True, "The button in the StackPanel should have a click event handler.");
        }

        [MonitoredTest("Inner Grid has 4 rows and 4 columns"), Order(4)]
        public void _04_InnerGridShouldHave4RowsAnd4Columns()
        {
            AssertHasInnerGrid();
            AssertInnerGridHas4RowsAnd4Columns();
        }

        [MonitoredTest("Inner Grid contains a lightgreen Button"), Order(5)]
        public void _05_InnerGridContainsAButton()
        {
            Assert.That(_innerGrid.Children.OfType<Button>().Count(), Is.EqualTo(1), "Inner Grid should contain a Button");
            Button button = (Button)_innerGrid.Children[0];
            Assert.That((button.Background as SolidColorBrush).Color, Is.EqualTo(Colors.LightGreen), "The button should have a LightGreen backColor");
        }


        private void AssertGridHas3Cells()
        {
            AssertHasOuterGrid();

            Assert.That(_grid.RowDefinitions, Has.Count.EqualTo(3), () => "The 'Grid' should have 3 rows defined.");

            Assert.That(_grid.RowDefinitions[0].Height.IsAuto, Is.True, "The first row of the outer grid should adjust to the height of its children.");
            Assert.That(_grid.RowDefinitions[1].Height.Value, Is.EqualTo(20), "The second row (empty row) of the outer grid should be set to 20.");
            Assert.That(_grid.RowDefinitions[2].Height.IsStar, Is.True, "The third row of the outer grid should be a star.");
            Assert.That(_grid.ColumnDefinitions, Has.Count.EqualTo(0), () => "The 'Grid' should have no columns defined.");
        }

        private void AssertHasOuterGrid()
        {
            Assert.That(_grid, Is.Not.Null, "No 'Grid' could be found.");
            Assert.That(_grid.Parent, Is.SameAs(_window.Window),
                "The 'Grid' should be the child control of the 'Window'.");
        }

        private void AssertHasInnerGrid()
        {
            Assert.That(_innerGrid, Is.Not.Null, "No inner 'Grid' could be found.");
            Assert.That(_innerGrid.Parent, Is.SameAs(_grid),
                "The 'inner Grid' should be the child control of the outer 'Grid'.");
        }

        private void AssertInnerGridHas4RowsAnd4Columns()
        {
            AssertHasInnerGrid();

            Assert.That(_innerGrid.RowDefinitions, Has.Count.EqualTo(4), () => "The 'Grid' should have 4 rows defined.");
            Assert.That(_innerGrid.ColumnDefinitions, Has.Count.EqualTo(4), () => "The 'Grid' should have 4 columns defined.");
        }



    }
}
