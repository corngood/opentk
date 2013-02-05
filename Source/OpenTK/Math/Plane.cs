using System;

namespace OpenTK
{
	[Serializable]
	public struct Plane
	{
		// Ax + By + Cz + D = 0
		public float A, B, C, D;

		public Vector3 Normal { get { return new Vector3(A, B, C); } }

		public Plane(float a, float b, float c, float d)
		{
			A = a;
			B = b;
			C = c;
			D = d;
		}

		public Plane(Vector3 p0, Vector3 p1, Vector3 p2)
		{
			var v1 = p1 - p0;
			var v2 = p2 - p0;

			var normal = Vector3.Normalize(Vector3.Cross(v1, v2));

			A = normal.X;
			B = normal.Y;
			C = normal.Z;

			D = -Vector3.Dot(normal, p0);
		}

		public static float DotCoordinate(Plane plane, Vector3 point)
		{
			return Vector3.Dot(plane.Normal, point) + plane.D;
		}

		public static float DotNormal(Plane plane, Vector3 normal)
		{
			return Vector3.Dot(plane.Normal, normal);
		}
	}
}

