﻿namespace Gu.Wpf.UiAutomation.UnitTests
{
    using Gu.Wpf.UiAutomation.Shapes;
    using NUnit.Framework;

    [TestFixture]
    public class RectangleTests
    {
        [Test]
        public void EmptyTest()
        {
            var rectangle = new Rectangle(0, 0, 0, 0);
            var rectangle2 = new Rectangle(0, 0, 1, 0);
            var rectangle3 = new Rectangle(0, 0, 0, 1);
            Assert.That(rectangle.IsEmpty, Is.True);
            Assert.That(rectangle2.IsEmpty, Is.False);
            Assert.That(rectangle3.IsEmpty, Is.False);
        }

        [Test]
        public void CenterTest()
        {
            var rectangle = new Rectangle(10, 20, 30, 40);
            this.AssertPointsAreSame(rectangle.Center, new Point(25, 40));
        }

        [Test]
        public void LocationTest()
        {
            var rectangle = new Rectangle(10, 20, 30, 40);
            this.AssertPointsAreSame(rectangle.North, new Point(25, 20));
            this.AssertPointsAreSame(rectangle.East, new Point(40, 40));
            this.AssertPointsAreSame(rectangle.South, new Point(25, 60));
            this.AssertPointsAreSame(rectangle.West, new Point(10, 40));
        }

        [Test]
        public void ExteriorTest()
        {
            var rectangle = new Rectangle(10, 20, 30, 40);
            this.AssertPointsAreSame(rectangle.ImmediateExteriorNorth, new Point(25, 19));
            this.AssertPointsAreSame(rectangle.ImmediateExteriorEast, new Point(41, 40));
            this.AssertPointsAreSame(rectangle.ImmediateExteriorSouth, new Point(25, 61));
            this.AssertPointsAreSame(rectangle.ImmediateExteriorWest, new Point(9, 40));
        }

        [Test]
        public void InteriorTest()
        {
            var rectangle = new Rectangle(10, 20, 30, 40);
            this.AssertPointsAreSame(rectangle.ImmediateInteriorNorth, new Point(25, 21));
            this.AssertPointsAreSame(rectangle.ImmediateInteriorEast, new Point(39, 40));
            this.AssertPointsAreSame(rectangle.ImmediateInteriorSouth, new Point(25, 59));
            this.AssertPointsAreSame(rectangle.ImmediateInteriorWest, new Point(11, 40));
        }

        private void AssertPointsAreSame(Point p1, Point p2)
        {
            Assert.That(p1.X, Is.EqualTo(p2.X));
            Assert.That(p1.Y, Is.EqualTo(p2.Y));
        }
    }
}