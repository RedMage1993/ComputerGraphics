using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Homework_07
{
    public struct Point3D
    {
        public double X;
        public double Y;
        public double Z;

        public Point3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }

    public struct PointD
    {
        public double X;
        public double Y;

        public PointD(double x, double y)
        {
            X = x;
            Y = y;
        }
    }

    class CubicSpline
    {
        public Point3D[] ctrlPts { get; private set; }
        public Point3D[] coefficients { get; private set; }
        public int noCtrlPts { get; private set; }

        public double[,] invT { get; private set; }

        public Point3D A { get; private set; }
        public Point3D B { get; private set; }
        public Point3D C { get; private set; }
        public Point3D D { get; private set; }

        public double width { get; private set; }

        public double height { get; private set; }

        public double depth { get; private set; }

        public Camera camera { get; private set; }

        public double splineRotY { get; private set; }

        public CubicSpline(double deg, Camera cam, double w, double h, double d)
        {
            noCtrlPts = 0;

            width = w;
            height = h;
            depth = d;

            camera = cam;

            splineRotY = deg;
        }

        public PointD getScreenPts(double t, int piece)
        {
            Point3D ptOnPiece = new Point3D();
            PointD ptScreen = new PointD();
            double splineRotXrad, splineRotYrad, splineRotZrad;

            if (piece >= noCtrlPts - 1)
                return ptScreen;
            if (t < 0.0 || t > 1.0)
                return ptScreen;

            // calc 3d points
            ptOnPiece.X = (A.X + B.X * t + C.X * t * t + D.X * t * t * t);
            ptOnPiece.Y = (A.Y + B.Y * t + C.Y * t * t + D.Y * t * t * t);
            ptOnPiece.Z = (A.Z + B.Z * t + C.Z * t * t + D.Z * t * t * t);

            // determine total rotation about each axis in degrees
            // convert them all into radians
            // x
            splineRotXrad = camera.pitch;
            splineRotXrad = splineRotXrad * Math.PI / 180.0;

            // y
            splineRotYrad = -camera.yaw + splineRotY;
            splineRotYrad = splineRotYrad * Math.PI / 180.0;

            // z
            splineRotZrad = -camera.roll;
            splineRotZrad = splineRotZrad * Math.PI / 180.0;

            //rot bout y
            ptOnPiece.X = ptOnPiece.X * Math.Cos(splineRotYrad) - ptOnPiece.Z * Math.Sin(splineRotYrad);
            ptOnPiece.Z = ptOnPiece.X * Math.Sin(splineRotYrad) + ptOnPiece.Z * Math.Cos(splineRotYrad);

            // rot by x
            ptOnPiece.Y = ptOnPiece.Y * Math.Cos(splineRotXrad) + ptOnPiece.Z * Math.Sin(splineRotXrad);
            ptOnPiece.Z = -ptOnPiece.Y * Math.Sin(splineRotXrad) + ptOnPiece.Z * Math.Cos(splineRotXrad);

            // rot by z
            ptOnPiece.X = ptOnPiece.X * Math.Cos(splineRotZrad) + ptOnPiece.Y * Math.Sin(splineRotZrad);
            ptOnPiece.Y = -ptOnPiece.X * Math.Sin(splineRotZrad) + ptOnPiece.Y * Math.Cos(splineRotZrad);

            // other transformations

            // relativity
            ptOnPiece.X = ptOnPiece.X - camera.position.X;
            ptOnPiece.Y = ptOnPiece.Y - camera.position.Y;
            ptOnPiece.Z = ptOnPiece.Z - camera.position.Z;

            // 3d to 2d
            ptScreen.X = (ptOnPiece.X / ptOnPiece.Z) * width;
            ptScreen.Y = -(ptOnPiece.Y / ptOnPiece.Z) * height;

            return ptScreen;
        }
        public bool SetCoeForPiece(int piece)
        {
            if (piece >= noCtrlPts - 1)
                return false;

            A = ctrlPts[piece];
            B = coefficients[piece];
            C = new Point3D(3.0 * (ctrlPts[piece + 1].X - ctrlPts[piece].X) - 2.0 * coefficients[piece].X - coefficients[piece + 1].X,
                3.0 * (ctrlPts[piece + 1].Y - ctrlPts[piece].Y) - 2.0 * coefficients[piece].Y - coefficients[piece + 1].Y,
                3.0 * (ctrlPts[piece + 1].Z - ctrlPts[piece].Z) - 2.0 * coefficients[piece].Z - coefficients[piece + 1].Z);
            D = new Point3D(2.0 * (ctrlPts[piece].X - ctrlPts[piece + 1].X) + coefficients[piece].X + coefficients[piece + 1].X,
                2.0 * (ctrlPts[piece].Y - ctrlPts[piece + 1].Y) + coefficients[piece].Y + coefficients[piece + 1].Y,
                2.0 * (ctrlPts[piece].Z - ctrlPts[piece + 1].Z) + coefficients[piece].Z + coefficients[piece + 1].Z);

            return true;
        }

        public bool Init()
        {
            double[,] T = new double[noCtrlPts, noCtrlPts];

            if (!InitializeT(T))
                return false;

            invT = InverseT(T);

            GetCoeData();

            return true;
        }

        public bool setCtrlPts(int noCps, Point3D[] cp)
        {
            if (noCps < 3)
                return false;
            if (cp.Length < 3 || noCps != cp.Length)
                return false;

            ctrlPts = cp;
            noCtrlPts = noCps;
            coefficients = new Point3D[noCtrlPts];

            return true;
        }

        private void GetCoeData()
        {
            Point3D[] Y = new Point3D[noCtrlPts];

            // Fill Y in TD = Y
            Y[0].X = 3 * (ctrlPts[1].X - ctrlPts[0].X);
            Y[0].Y = 3 * (ctrlPts[1].Y - ctrlPts[0].Y);
            Y[0].Z = 3 * (ctrlPts[1].Z - ctrlPts[0].Z);

            for (int i = 1; i < noCtrlPts - 1; i++)
            {
                Y[i].X = 3 * (ctrlPts[i + 1].X - ctrlPts[i - 1].X);
                Y[i].Y = 3 * (ctrlPts[i + 1].Y - ctrlPts[i - 1].Y);
                Y[i].Z = 3 * (ctrlPts[i + 1].Z - ctrlPts[i - 1].Z);
            }

            Y[noCtrlPts - 1].X = 3 * (ctrlPts[noCtrlPts - 1].X - ctrlPts[noCtrlPts - 2].X);
            Y[noCtrlPts - 1].Y = 3 * (ctrlPts[noCtrlPts - 1].Y - ctrlPts[noCtrlPts - 2].Y);
            Y[noCtrlPts - 1].Z = 3 * (ctrlPts[noCtrlPts - 1].Z - ctrlPts[noCtrlPts - 2].Z);

            // Find D = coefficients
            // D = T^-1 * Y
            for (int i = 0; i < noCtrlPts; i++)
            {
                for (int j = 0; j < noCtrlPts; j++)
                {
                    coefficients[i].X += (invT[i, j] * Y[j].X);
                    coefficients[i].Y += (invT[i, j] * Y[j].Y);
                    coefficients[i].Z += (invT[i, j] * Y[j].Z);
                }
            }
        }

        private bool InitializeT(double[,] T)
        {
            if (noCtrlPts < 3)
                return false;

            for (int r = 0; r < noCtrlPts; r++)
            {
                for (int c = 0; c < noCtrlPts; c++)
                {
                    T[r, c] = 0;
                }
            }

            T[0, 0] = 2;
            for (int r = 1; r < noCtrlPts; r++)
            {
                T[r, r] = 4;
                T[r - 1, r] = 1;
                T[r, r - 1] = 1;
            }

            T[noCtrlPts - 1, noCtrlPts - 1] = 2;

            return true;
        }

        private double theta(int i, double[,] T, double[] dp)
        {
            if (dp[i] != 0)
                return dp[i];
            else
                return T[i - 1, i - 1] * theta(i - 1, T, dp) - theta(i - 2, T, dp);
        }

        private double phi(int i, double[,] T, double[] dp)
        {
            if (dp[i - 1] != 0)
            {
                return dp[i - 1];
            }
            else
                return T[i - 1, i - 1] * phi(i + 1, T, dp) - phi(i + 2, T, dp);
        }

        private int sign(int i, int j)
        {
            return (((i + j) & 1) == 1) ? -1 : 1; // (-1) ^ (i + j); test LSB of (i + j) for parity (even power => positive)
        }

        private double[,] InverseT(double[,] T)
        {
            double[,] invT = new double[noCtrlPts, noCtrlPts];
            double[] dpt = new double[noCtrlPts + 1];
            double[] dpp = new double[noCtrlPts + 1];
            double t, p;

            dpt[0] = 1;
            dpt[1] = 2;
            dpp[noCtrlPts] = 1;
            dpp[noCtrlPts - 1] = 2;

            for (int i = 1; i <= noCtrlPts; i++)
            {
                for (int j = 1; j <= noCtrlPts; j++)
                {
                    if (i < j)
                    {
                        t = theta(i - 1, T, dpt);
                        dpt[i - 1] = t;

                        p = phi(j + 1, T, dpp);
                        dpp[j] = p;

                        invT[i - 1, j - 1] = sign(i, j) * t * p / theta(noCtrlPts, T, dpt);
                    }
                    else if (i > j)
                    {
                        t = theta(j - 1, T, dpt);
                        dpt[j - 1] = t;

                        p = phi(i + 1, T, dpp);
                        dpp[i] = p;

                        invT[i - 1, j - 1] = sign(i, j) * t * p / theta(noCtrlPts, T, dpt);
                    }
                    else
                    {
                        t = theta(i - 1, T, dpt);
                        dpt[i - 1] = t;

                        p = phi(j + 1, T, dpp);
                        dpp[j] = p;

                        invT[i - 1, j - 1] = t * p / theta(noCtrlPts, T, dpt);
                    }
                }
            }

            return invT;
        }
    }
}
