using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShapesLibrary;

namespace pdPartAShapes
{
    [TestClass]
    public class partAShapes
    {
        [TestMethod]
        public void testConstructors() {
            Shapes defaultConstructor = new Shapes();
            Assert.AreEqual(1, defaultConstructor.side1);
            Assert.AreEqual(1, defaultConstructor.side2);
            Assert.AreEqual(0, defaultConstructor.side3);
            Assert.AreEqual(0, defaultConstructor.shape);

            Shapes equivalentConstructor = new Shapes(2, 1);
            Assert.AreEqual(2, equivalentConstructor.side1);
            Assert.AreEqual(0, equivalentConstructor.side2);
            Assert.AreEqual(0, equivalentConstructor.side3);
            Assert.AreEqual(1, equivalentConstructor.shape);

            Shapes fullShapeConstructor = new Shapes(2, 3, 1);
            Assert.AreEqual(2, fullShapeConstructor.side1);
            Assert.AreEqual(3, fullShapeConstructor.side2);
            Assert.AreEqual(0, fullShapeConstructor.side3);
            Assert.AreEqual(1, fullShapeConstructor.shape);

            Shapes polygonConstructor = new Shapes(2, 3, 2, 1);
            Assert.AreEqual(2, polygonConstructor.side1);
            Assert.AreEqual(3, polygonConstructor.side2);
            Assert.AreEqual(2, polygonConstructor.side3);
            Assert.AreEqual(1, polygonConstructor.shape);
        }

        [TestMethod]
        public void testArea() {
            Shapes square = new Shapes(2, 1);
            //areaOfSquare
            Assert.AreEqual(4, square.Area());
            //perimeterOfSquare
            Assert.AreEqual(8, square.Perimeter());

            Shapes cube = new Shapes(2,2,2,1);
            //volumeOfSquareCube
            Assert.AreEqual(8, cube.Volume());

            Shapes rect = new Shapes(2,3,1);
            //areaOfRectangle
            Assert.AreEqual(6, rect.Area());
            //perimeterOfRectangle
            Assert.AreEqual(10, rect.Perimeter());

            Shapes rectPrism = new Shapes(1,2,3,1);
            //volumeOfRectangularCube
            Assert.AreEqual(6, rectPrism.Volume());
            
            Shapes circle = new Shapes();
            //areaOfCircle
            Assert.AreEqual(Math.PI, circle.Area());
            //perimeterOfCirlce
            Assert.AreEqual(Math.PI*2, circle.Perimeter());

            Shapes sphere = new Shapes(2, 0);
            //volumeOfSphere
            Assert.AreEqual((4.0/3.0 * Math.PI * (2*2*2)) , sphere.Volume());

            Shapes triangle = new Shapes(2,3,2,2);
            //areaOfTriangle
            Assert.AreEqual(3, triangle.Area());
            //perimeterOfTriangle
            Assert.AreEqual(7, triangle.Perimeter());
        }
    }
}
