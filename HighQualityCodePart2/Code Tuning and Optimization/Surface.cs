using System;
using System.Windows;
using System.Windows.Media.Media3D;

namespace Surfaces
{
    public abstract class Surface : ModelVisual3D
    {
        private readonly GeometryModel3D content = new GeometryModel3D();

        public static PropertyHolder<double, Surface> RadiusProperty =
            new PropertyHolder<double, Surface>("Radius", 1.0, OnGeometryChanged);

        public static PropertyHolder<Point3D, Surface> PositionProperty =
            new PropertyHolder<Point3D, Surface>("Position", new Point3D(0, 0, 0), OnGeometryChanged);

        public static PropertyHolder<Material, Surface> MaterialProperty =
            new PropertyHolder<Material,Surface>("Material", null, OnMaterialChanged);

        public static PropertyHolder<Material, Surface> BackMaterialProperty =
            new PropertyHolder<Material, Surface>("BackMaterial", null, OnBackMaterialChanged);

        public static PropertyHolder<bool, Surface> VisibleProperty =
            new PropertyHolder<bool, Surface>("Visible", true, OnVisibleChanged);

        public double radius;
        public Point3D position;

        public Surface()
        {
            Content = content;
            content.Geometry = CreateMesh();
        }

        public double Radius
        {
            get { return RadiusProperty.Get(this); }
            set { RadiusProperty.Set(this, value); }
        }

        public Point3D Position
        {
            get { return PositionProperty.Get(this); }
            set { PositionProperty.Set(this, value); }
        }

        public Material Material
        {
            get { return MaterialProperty.Get(this); }
            set { MaterialProperty.Set(this, value); }
        }

        public Material BackMaterial
        {
            get { return BackMaterialProperty.Get(this); }
            set { BackMaterialProperty.Set(this, value); }
        }

        public bool Visible
        {
            get { return VisibleProperty.Get(this); }
            set { VisibleProperty.Set(this, value); }
        }

        private static void OnMaterialChanged(Object sender, DependencyPropertyChangedEventArgs e)
        {
            ((Surface)sender).OnMaterialChanged();
        }

        private static void OnBackMaterialChanged(Object sender, DependencyPropertyChangedEventArgs e)
        {
            ((Surface)sender).OnBackMaterialChanged();
        }

        private static void OnVisibleChanged(Object sender, DependencyPropertyChangedEventArgs e)
        {
            ((Surface)sender).OnVisibleChanged();
        }

        protected static void OnGeometryChanged(Object sender, DependencyPropertyChangedEventArgs e)
        {
            ((Surface)sender).OnGeometryChanged();
        }

        private void OnMaterialChanged()
        {
            SetContentMaterial();
        }

        private void OnBackMaterialChanged()
        {
            SetContentBackMaterial();
        }

        private void OnVisibleChanged()
        {
            SetContentMaterial();
            SetContentBackMaterial();
        }

        private void SetContentMaterial()
        {
            content.Material = Visible ? Material : null;
        }

        private void SetContentBackMaterial()
        {
            content.BackMaterial = Visible ? BackMaterial : null;
        }

        private void OnGeometryChanged()
        {
            content.Geometry = CreateMesh();
        }

        protected abstract Geometry3D CreateMesh();
    }
}
