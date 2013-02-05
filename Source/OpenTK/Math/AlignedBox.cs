using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenTK
{
	[Serializable]
	public struct AlignedBox
	{
		public Vector3 Min, Max;

		public Vector3 Center { get { return (Min + Max) / 2f; } }

		public AlignedBox(Vector3 min, Vector3 max)
		{
			System.Diagnostics.Debug.Assert(
				max.X >= min.X &&
				max.Y >= min.Y &&
				max.Z >= min.Z);

			Min = min;
			Max = max;
		}

		public static AlignedBox Enclosing(IEnumerable<Vector3> points)
		{
			return new AlignedBox(
				points.Aggregate(points.First(), (x, y) => Vector3.ComponentMin(x, y)),
				points.Aggregate(points.First(), (x, y) => Vector3.ComponentMax(x, y)));
		}
	}
}

