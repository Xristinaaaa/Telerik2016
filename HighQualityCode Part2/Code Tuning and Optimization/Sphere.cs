using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace Surfaces
{
    public sealed class Sphere : Surface
    {
        private Point3D GetPosition(double angle, double y)
        {
            double r = radius * Math.Sqrt(1 - y * y);
            double x = r * Math.Cos(angle);
            double z = r * Math.Sin(angle);

            return new Point3D(position.X + x, position.Y + radius * y, position.Z + z);
        }

        private Vector3D GetNormal(double angle, double y)
        {
            return (Vector3D) GetPosition(angle, y);
        }

        private Point GetTextureCoordinate(double angle, double y)
        {
            Matrix map = new Matrix();
            map.Scale(1 / (2 * Math.PI), -0.5);

            Point p = new Point(angle, y);
            p = p * map;

            return p;
        }

        protected override Geometry3D CreateMesh()
        {
            radius = Radius;
            position = Position;

            const int angleSteps = 32;
            const double minAngle = 0;
            const double maxAngle = 2 * Math.PI;
            const double dAngle = (maxAngle-minAngle) / angleSteps;

            const int ySteps = 32;
            const double minY = -1.0;
            const double maxY = 1.0;
            const double dy = (maxY - minY) / ySteps;

            MeshGeometry3D mesh = new MeshGeometry3D();

            for (int yi = 0; yi <= ySteps; yi++)
            {
                double y = minY + yi * dy;

                for (int ai = 0; ai <= angleSteps; ai++)
                {
                    double angle = ai * dAngle;

                    mesh.Positions.Add(GetPosition(angle, y));
                    mesh.Normals.Add(GetNormal(angle, y));
                    mesh.TextureCoordinates.Add(GetTextureCoordinate(angle, y));
                }
            }

            for (int yi = 0; yi < ySteps; yi++)
            {
                for (int ai = 0; ai < angleSteps; ai++)
                {
                    int a1 = ai;
                    int a2 = (ai + 1);
                    int y1 = yi * (angleSteps + 1);
                    int y2 = (yi + 1) * (angleSteps + 1);

                    mesh.TriangleIndices.Add(y1 + a1);
                    mesh.TriangleIndices.Add(y2 + a1);
                    mesh.TriangleIndices.Add(y1 + a2);

                    mesh.TriangleIndices.Add(y1 + a2);
                    mesh.TriangleIndices.Add(y2 + a1);
                    mesh.TriangleIndices.Add(y2 + a2);
                }
            }

            mesh.Freeze();
            return mesh;
        }
    }
}
