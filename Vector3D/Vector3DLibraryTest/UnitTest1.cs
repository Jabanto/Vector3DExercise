using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Vector3DLibraries;

namespace Vector3DLibraryTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestBasicOperatorsMethod()
        {
            Vector3D vectorA = new Vector3D(1, 2, 3);
            Vector3D vectorB = new Vector3D(1, 4, 6);

            Vector3D vectorAdd = new Vector3D(2, 6, 9);
            Assert.IsTrue(vectorAdd == Vector3D.Add(vectorA, vectorB), String.Format("Expected for '{0}': true; Actual: {1}",vectorAdd, true));

            Vector3D substrationResult = new Vector3D(0, -2, -3);
            Assert.IsTrue(substrationResult== Vector3D.Substration(vectorA, vectorB), String.Format("Expected for '{0}': true; Actual: {1}", substrationResult, true));

            Vector3D negationResult = new Vector3D(-1, -2, -3);
            Assert.IsTrue(negationResult == Vector3D.Negation(vectorA));

            Vector3D multiByScalarResult = new Vector3D(2,4,6);
            Assert.IsTrue(multiByScalarResult == vectorA*(2));


            Vector3D dividedByScalarResult = new Vector3D(1,2,3);
            Assert.IsTrue(dividedByScalarResult == (vectorA * (3)) / (3) );

        }

        [TestMethod]
        public void TestDotProductMethod()
        {
            Vector3D vectorA = new Vector3D(1, 2, 3);
            Vector3D another = new Vector3D(4, 8, 6);
            Double expected = 38;
            Assert.IsTrue(expected == vectorA.DotProduct(another));
        }

        [TestMethod]
        public void TestCrossProductMethod()
        {
            Vector3D vectorA = new Vector3D(1, 2, 3);
            Vector3D another = new Vector3D(4, 8, 6);
            Vector3D expected = new Vector3D(-12,6,0);
            Assert.IsTrue(expected == vectorA.CrossProduct(another));
        }


        [DataRow(2, 1, 2)]
        [DataTestMethod]
        public void TestAccesToProperties(double x,double y,double z)
        {
            Vector3D vector3DToTest = new Vector3D(2, 1, 2);
            Assert.IsTrue(vector3DToTest.X == x && vector3DToTest.Y == y && vector3DToTest.Z == z);
        }


        [DataRow(19)]
        [DataTestMethod]
        public void TestAngleMethod(int angle)
        {
            Vector3D vectorA = new Vector3D(2, 2, 3);
            Vector3D another = new Vector3D(4, 4, 3);

            double result = (vectorA.Angle(another) * 180)/ Math.PI;
            Assert.IsTrue( Math.Round(result,0) == angle , String.Format("Expected for '{0}': true; Actual: {1}", angle, result));
        }
    }
}