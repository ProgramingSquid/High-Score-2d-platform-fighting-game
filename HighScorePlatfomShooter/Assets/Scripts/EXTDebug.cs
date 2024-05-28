using UnityEngine;

public static class EXTDebug

	public static void DrawBoxCastBox(Vector3 origin, Vector3 halfExtents, Quaternion orientation, Vector3 direction, float distance, float duration)

		Debug.DrawLine(bottomBox.backBottomLeft, topBox.backBottomLeft, Color.red, duration);
		Debug.DrawLine(bottomBox.frontTopRight, topBox.frontTopRight, Color.red, duration);

		DrawBox(bottomBox, Color.green, duration);

	public static void DrawBox(Box box, Color color, float duration)
		Debug.DrawLine(box.backTopLeft, box.backTopRight, color, duration);

		Debug.DrawLine(box.frontTopLeft, box.backTopLeft, color, duration);
	public struct Box
		public Vector3 frontTopLeft { get { return localFrontTopLeft + origin; } }
		public Box(Vector3 origin, Vector3 halfExtents)
	static Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Quaternion rotation)