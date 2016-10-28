using System;
using System.Windows.Media.Media3D;

namespace Surfaces
{
    public sealed class Circle : Surface
    {
        private Point3D PointForAngle(double angle)
        {
            return new Point3D(position.X + radius * Math.Cos(angle), position.Y + radius * Math.Sin(angle), position.Z);
        }

        protected override Geometry3D CreateMesh()
        {
            radius = Radius;
            position = Position;

            MeshGeometry3D mesh = new MeshGeometry3D();
            Point3D prevPoint = PointForAngle(0);
            Vector3D normal = new Vector3D(0,0,1);

            const int div = 180;
            for (int i = 1; i <= div; ++i)
            {
                double angle = 2 * Math.PI / div * i;
                Point3D newPoint = PointForAngle(angle);
                mesh.Positions.Add(prevPoint);
                mesh.Positions.Add(position);
                mesh.Positions.Add(newPoint);
                mesh.Normals.Add(normal);
                mesh.Normals.Add(normal);
                mesh.Normals.Add(normal);
                prevPoint = newPoint;
            }

            mesh.Freeze();
            return mesh;
        }
    }
}
