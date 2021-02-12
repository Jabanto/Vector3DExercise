//---------------------------------------------------------------------------- 
//
// 
// Description: 3D vector implementation. 
//
// History:
// 08/02/2021 : Jabanto - Created
// 
//---------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vector3DLibraries
{
    /// <summary>
    /// Vector 3D Struct representation
    /// 
    /// Implementierung des 3D-Vektor als Klasse oder Struktur?
    /// 
    /// Hier verwende ich Structs auf folgende Grunde.
    /// 
    /// 1.-Durch Strukt wird der Aufwand von collection overheads verringern.
    /// 2.-Structs werden schnell und effizient erstellt und entsorgt.
    /// 3.-Sind nur für Typen mit einer geringen Anzahl von Variablen geeignet. Microsoft empfiehlt, dass eine Struct kleiner als 16 Byte sein sollte. 
    /// 
    /// Soll der Vektor nach seiner Erzeugung unveränderlich sein oder sollen sich seine Komponenten nachträglichändern lassen?
    /// 
    /// In dieser Fall wo wir Structs nutzen ja also nicht mutable , da Structs als Wert übergeben werden. Dies bedeutet, dass sie kopiert werden, wenn sie an eine andere Methode übergeben werden.
    /// Wenn Sie die Werte in einer anderen Methode ändern (oder mutieren), gehen die Änderungen verloren, wenn Sie zur aufrufenden Methode zurückkehren.
    /// Deshalb alle Operationen hier, erzeugen eine andere Struct.
    /// 
    /// In welcher Art und Weise erfolgt die Prüfung auf Gleichheit und Ungleichheit? Überladen Sie dieentsprechenden Operatoren oder nicht?
    ///  
    /// Wenn wir überprüfen moechten dass zwei Vektoren gleich sind dann überprüfen wir die Komponentenpaare so dass jedes Paar, das nicht gleich ist, zu falsch führt.
    /// Ja Operatoren == und != werden  überladen aber die Equals wird nicht ersetz denn diese implementiert IEquitable.
    /// 
    /// Wie wird der Hashcode eines Vektors bestimmt?
    /// Die Hash-Codes der einzelnen Bestandteile des 3DVektors werden bitweise mit XOR kombiniert.
    ///
    /// </summary>
    public struct Vector3D
    {
        #region Properties

        private readonly double _x, _y, _z;
        private const string THREE_ELEMENTS = "Array must contain exactly three elements, (x,y,z)";

        // Four  four standard vector constants

        public static readonly Vector3D Origin = new Vector3D(0, 0, 0);
        public static readonly Vector3D XAxis = new Vector3D(1, 0, 0);
        public static readonly Vector3D YAxis = new Vector3D(0, 1, 0);
        public static readonly Vector3D ZAxis = new Vector3D(0, 0, 1);

        public static readonly Vector3D NaN = new Vector3D(double.NaN, double.NaN, double.NaN);

        #endregion

        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public Vector3D(double x, double y,double z)
        {
            _x = x;
            _y = y;
            _z = z;
        
        }
        #endregion

        #region Public Methods 

        public double X
        {
            get { return this._x; }
        }

        public double Y
        {
            get { return this._y; }
        }

        public double Z
        {
            get { return this._z; }
        }

        /// <summary>
        /// Return the Vector as double array
        /// </summary>
        public double[] ArrayVector
        {
            get { return new double[] { _x, _y, _z }; }
        }

        /// <summary>
        /// Return the value of vector using index
        /// </summary>
        /// <param name="index">of the vector</param>
        /// <returns>Element of the 3D Vector</returns>
        public double this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0: { return X; }
                    case 1: { return Y; }
                    case 2: { return Z; }
                    default: throw new ArgumentException(THREE_ELEMENTS, "index");
                }
            }
        }

        /// <summary>
        /// Return the invert value of a 3DVector
        /// </summary>
        /// <param name="v1">Vector to negate</param>
        /// <returns>inverted Vector</returns>
        public static Vector3D Negation(Vector3D v1)
        {
            return new Vector3D(
               -v1.X,
               -v1.Y,
               -v1.Z);
        }

        /// <summary>
        /// Addition of two  3D Vectors. 
        /// </summary>
        /// <param name="vector1">First vector to add. 
        /// <param name="vector2">Second vectorto add. 
        /// <returns>Result of addition.</returns>
        public static Vector3D Add(Vector3D vector1, Vector3D vector2)
        {
            return new Vector3D(vector1.X + vector2.X,
                                vector1.Y + vector2.Y,
                                vector1.Z + vector2.Z);
        }


        /// <summary>
        /// Substraction of two  3D Vectors. 
        /// </summary>
        /// <param name="vector1">First vector to add. 
        /// <param name="vector2">Second vectorto add. 
        /// <returns>Result of Substraction.</returns>
        public static Vector3D Substration(Vector3D vector1, Vector3D vector2)
        {
            return new Vector3D(vector1.X - vector2.X,
                                vector1.Y - vector2.Y,
                                vector1.Z - vector2.Z);
        }


        #region Operator overloading
  
        /// <summary> 
        /// Multiplication by a scalar using operator
        /// </summary> 
        /// <param name="vector">Vector being multiplied. 
        /// <param name="scalar">Scalar value.
        /// <returns>Result of multiplication.</returns> 
        public static Vector3D operator *(Vector3D vector, double scalar)
        {
            return new Vector3D(vector.X * scalar,
                                vector.Y * scalar,
                                vector.Z * scalar);
        }


        /// <summary> 
        /// Division of a 3Dvector by a scalar number
        /// </summary> 
        /// <param name="vector">Vector being divided. 
        /// <param name="scalar">Scalar value.
        /// <returns>Result of scalar division.</returns>
        public static Vector3D operator /(Vector3D vector, double scalar)
        {
            return
            (
               new Vector3D
               (
                  vector.X * (1.0 / scalar),
                  vector.Y * (1.0 / scalar),
                  vector.Z * (1.0 / scalar)
               )
            );
        }

        /// <summary>
        /// To check if two vectors are equal we simply check the component pairs.
        /// </summary>
        /// <param name="v1">Vector 1</param>
        /// <param name="v2">Vector 2 </param>
        /// <returns></returns>
        public static bool operator ==(Vector3D v1, Vector3D v2)
        {
            return
               v1.X == v2.X &&
               v1.Y == v2.Y &&
               v1.Z == v2.Z;
        }

        /// <summary>
        /// Inverse Check that Equals Operator overload
        /// </summary>
        /// <param name="v1">Vector 1</param>
        /// <param name="v2">Vector </param>
        /// <returns></returns>
        public static bool operator !=(Vector3D v1, Vector3D v2)
        {
            return !(v1 == v2);
        }
        #endregion


        /// <summary> 
        /// The dot product of two 3Dvectors 
        /// </summary> 
        /// <param name="vector1">First vector. 
        /// <param name="vector2">Second vector. 
        /// <returns>A scalar as the result.</returns>
        public static double DotProduct(Vector3D vector1, Vector3D vector2)
        {
            return
            (
               vector1.X * vector2.X +
               vector1.Y * vector2.Y +
               vector1.Z * vector2.Z
            );
        }

        public double DotProduct(Vector3D other)
        {
            return DotProduct(this, other);
        }

        /// <summary>
        /// The cross product of two vectors thst produces a normal to the plane 
        /// </summary>
        /// <param name="other"></param>
        /// <returns>a new Normal Vector result od the CrossProduct</returns>
        public Vector3D CrossProduct(Vector3D other)
        {
            return CrossProduct(this, other);
        }


        /// <summary> 
        /// Vector cross product. 
        /// </summary>
        /// <param name="v1">First vector. 
        /// <param name="v2">Second vector.
        /// <returns>Cross product of two vectors.</returns>
        public static Vector3D CrossProduct(Vector3D v1, Vector3D v2)
        {
            return
               new Vector3D
               (
                  v1.Y * v2.Z - v1.Z * v2.Y,
                  v1.Z * v2.X - v1.X * v2.Z,
                  v1.X * v2.Y - v1.Y * v2.X
               );
        }


        /// <summary> 
        /// Length of the 3Dvector.
        /// </summary> 
        public double Length
        {
            get
            {
                return Math.Sqrt(_x * _x + _y * _y + _z * _z);
            }
        }

        public static double Angle(Vector3D v1, Vector3D v2)
        {
            if (v1==v2)
            {
                return 0;
            }

            return Math.Acos(Math.Min(1.0f, NormalizeOrDefault(v1).DotProduct(NormalizeOrDefault(v2))));
        }

        /// <summary>
        /// finds the angle between two vectors using normalization and dot product.
        /// </summary>
        /// <param name="other">Other Vector</param>
        /// <returns>Angle in Rad</returns>
        public double Angle(Vector3D other)
        {
            return Angle(this, other);
        }


        public static Vector3D NormalizeOrDefault(Vector3D v1)
        {
            /* Check that we are not attempting to normalize a vector of magnitude 1;
               if we are then return v(0,0,0) */
            if (v1.Magnitude == 0)
            {
                return Origin;
            }

            /* Check that we are not attempting to normalize a vector with NaN components;
               if we are then return v(NaN,NaN,NaN) */
            if (v1.IsNaN())
            {
                return NaN;
            }

            // Special Cases
            if (double.IsInfinity(v1.Magnitude))
            {
                var x =
                    v1.X == 0 ? 0 :
                        v1.X == -0 ? -0 :
                            double.IsPositiveInfinity(v1.X) ? 1 :
                                double.IsNegativeInfinity(v1.X) ? -1 :
                                    double.NaN;
                var y =
                    v1.Y == 0 ? 0 :
                        v1.Y == -0 ? -0 :
                            double.IsPositiveInfinity(v1.Y) ? 1 :
                                double.IsNegativeInfinity(v1.Y) ? -1 :
                                    double.NaN;

                var z =
                    v1.Z == 0 ? 0 :
                        v1.Z == -0 ? -0 :
                            double.IsPositiveInfinity(v1.Z) ? 1 :
                                double.IsNegativeInfinity(v1.Z) ? -1 :
                                    double.NaN;

                var result = new Vector3D(x, y, z);

                // If this was a special case return the special case result otherwise return NaN
                return result.IsNaN() ? NaN : result;
            }

            // Run the normalization as usual
            return NormalizeOrNaN(v1);
        }


        public Vector3D NormalizeOrDefault()
        {
            return NormalizeOrDefault(this);
        }


        private static Vector3D NormalizeOrNaN(Vector3D v1)
        {
            // find the inverse of the vectors magnitude
            double inverse = 1 / v1.Magnitude;

            return new Vector3D(
                // multiply each component by the inverse of the magnitude
                v1.X * inverse,
                v1.Y * inverse,
                v1.Z * inverse);
        }

        public double Magnitude
        {
            get
            {
                return Math.Sqrt(SumComponentSqrs());
            }
        }

        public static double SumComponentSqrs(Vector3D v1)
        {
            Vector3D v2 = SqrComponents(v1);
            return v2.SumComponents();
        }

        public double SumComponentSqrs()
        {
            return SumComponentSqrs(this);
        }

        public static Vector3D SqrComponents(Vector3D v1)
        {
            return
            (
               new Vector3D
               (
                   v1.X * v1.X,
                   v1.Y * v1.Y,
                   v1.Z * v1.Z
               )
             );
        }

        public static double SumComponents(Vector3D v1)
        {
            return (v1.X + v1.Y + v1.Z);
        }

        public double SumComponents()
        {
            return SumComponents(this);
        }

        public static bool IsNaN(Vector3D v1)
        {
            return double.IsNaN(v1.X) || double.IsNaN(v1.Y) || double.IsNaN(v1.Z);
        }

        public bool IsNaN()
        {
            return IsNaN(this);
        }
    
        #endregion

    }
}



       


    
