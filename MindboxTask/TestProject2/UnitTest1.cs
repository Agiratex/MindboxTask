using Figure;

namespace Tests
{
    [TestClass]
    public class FigureTests
    {
        [TestMethod]
        public void TestCircle()
        {
            var c = new Circle(3);
            double a = c.Area();
            double expected = 28.2743334;
            Assert.AreEqual(a, expected, 0.0001);
        }

        [TestMethod]
        public void TestTriangle()
        {

            double x = 3;
            double y = 4;
            double z = 5;

            var t = new Triangle(x, y, z);
            Assert.IsTrue(t.IsRight);

            double a = t.Area();
            double expected = 6;
            Assert.AreEqual(a, expected, 0.0001);


            x = 2;
            y = 4;
            z = 5;

            t = new Triangle(x, y, z);
            Assert.IsFalse(t.IsRight);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
                "Invalid sizes for triangle")]
        public void InvalidSizesTest1()
        {
            var t = new Triangle(-1, 1, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
                "Invalid sizes for triangle")]
        public void InvalidSizesTest2()
        {
            var t = new Triangle(4, 1, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
                "Invalid radius")]
        public void InvalidRadiusTest()
        {
            var c = new Circle(-1);
        }

        [TestMethod]
        public void ChangeSizesTest1()
        {
            var t = new Triangle(1, 1, 1);
            t.x = 1.5;
            double a = t.Area();
            double expected = 0.49607;
            Assert.AreEqual(a, expected, 0.0001);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
                "Invalid sizes for triangle")]
        public void ChangeSizesTest2()
        {
            var t = new Triangle(1, 1, 1);
            t.x = 4;
        }

        [TestMethod]
        public void CalcTest()
        {
            var t = new Triangle(1, 1, 1);
            t.x = 1.5;
            double a = Calc.Area(t);
            double expected = 0.49607;
            Assert.AreEqual(a, expected, 0.0001);

            var c = new Circle(3);
            a = Calc.Area(c);
            expected = 28.2743334;
            Assert.AreEqual(a, expected, 0.0001);
        }
    }
}