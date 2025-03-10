﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesLibrary
{
    public class Shapes
    {
        public const int CIRCLE = 0;
        public const int RECTANGLE = 1;
        public const int TRIANGLE = 2;

        public int side1 { get; set; }
        public int side2 { get; set; }
        public int side3 { get; set; }
        public int shape { get; set; }
        // shape is as follows:
        // 0 - circle/sphere
        // 1 - rectangle/cube
        // 2 - triangle/tringular prism

        public Shapes() {
            this.side1 = 1;
            this.side2 = 1; 
            this.side3 = 0;
            //changes to be circle
            this.shape = 0; 
        }

        public Shapes(int _side1, int _side2, int _side3, int _shape) {
            this.side1 = _side1;
            this.side2 = _side2;
            this.side3 = _side3;
            this.shape = _shape;
        }

        public Shapes(int _side1, int _side2, int _shape) {
            this.side1 = _side1;
            this.side2 = _side2;
            this.side3 = 0;
            this.shape = _shape;
        }

        public Shapes(int _side1, int _shape) {
            this.side1 = _side1;
            this.side2 = 0;
            this.side3 = 0;
            this.shape = _shape;
        }

        private int areaOfSquare(int length) {
            return length * length;
        }

        private int perimeterOfSquare(int length) {
            //was + 4
            return length * 4;
        }

        private int volumeOfSquareCube(int length) {
            //was length * length
            return length * length * length;
        }

        private int areaOfRectangle(int length, int width) {
            return length * width;
        }

        private int perimeterOfRectangle(int length, int width) {
            //was area + 2
            return (length * 2) + (width * 2);
        }

        private int volumeofRectangularCube(int length, int width, int height) {
            return length * width * height;
        }

        private double areaOfCircle(int radius) {
            return Math.PI * (radius * radius);
        }

        private double perimeterOfCircle(int radius) {
            return Math.PI * radius * 2;
        }

        private double volumeOfSphere(int radius) {
            //Change to doubles to avoid integer division
            return 4.0 / 3.0 * Math.PI * (radius * radius * radius);
        }

        private double areaOfTriangle(int baseSide, int height) {
            return 0.5 * baseSide * height;
        }

        private int perimeterOfTriangle(int side1, int side2, int side3) {
            int[] checkSides = { side1, side2, side3 };

            Array.Sort(checkSides);
            //If sum of shorter side is less than or equal to third side then is not a valid triangle
            if ((side1 + side2) >= side3)
                return side1 + side2 + side3;
            else
                return -1;
        }

        public double Area() {
            double theResult = 0;

            switch (shape)
            {
                case CIRCLE:
                    theResult = areaOfCircle(side1);
                    break;
                case RECTANGLE:
                    if ((side1 == side2) || (side2 == 0))
                        theResult = areaOfSquare(side1);
                    else
                        theResult = areaOfRectangle(side1, side2);
                    break;
                case TRIANGLE:
                    theResult = areaOfTriangle(side1, side2);
                    break;
                default:
                    break;
            }
            return theResult;
        }

        public double Volume()
        {
            double theResult = 0;

            switch (shape)
            {
                case CIRCLE:
                    theResult = volumeOfSphere(side1);
                    break;
                case RECTANGLE:
                    //Was && not ||
                    if ((side1 == side2) || (side2 == 0))
                        theResult = volumeOfSquareCube(side1);
                    else
                        //Last param was side2 again, not side3
                        theResult = volumeofRectangularCube(side1, side2, side3);
                    break;
                case TRIANGLE:
                    theResult = -1;
                    break;
                default:
                    break;
            }
            return theResult;
        }

        public double Perimeter()
        {
            double theResult = 0;

            switch (shape)
            {
                case CIRCLE:
                    theResult = perimeterOfCircle(side1);
                    break;
                case RECTANGLE:
                    if ((side1 == side2) || (side2 == 0))
                        theResult = perimeterOfSquare(side1);
                    else
                        theResult = perimeterOfRectangle(side1, side2);
                    break;
                case TRIANGLE:
                    theResult = perimeterOfTriangle(side1, side2, side3);
                    break;
                default:
                    break;
            }
            return theResult;

        }

    }
}
