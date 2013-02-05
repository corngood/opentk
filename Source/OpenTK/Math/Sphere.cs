using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenTK
{
	[Serializable]
	public struct Sphere
	{
		public Vector3 Center;
		public float Radius;

		public Sphere(Vector3 center, float radius)
		{
			Center = center;
			Radius = radius;
		}

		public static Sphere Enclosing(IEnumerable<Vector3> points)
		{
			var center = AlignedBox.Enclosing(points).Center;
			return new Sphere(center, points.Select(x => (center - x).Length).Max());
		}
	}
}

