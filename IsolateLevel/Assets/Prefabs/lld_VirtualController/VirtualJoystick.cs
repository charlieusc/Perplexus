using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;

namespace VirtualController
{
	public static class Joysticks
	{
		static private Dictionary<string, float> data = new Dictionary<string, float> ();

		static internal void RegisterAxis (string name)
		{
			if (!data.ContainsKey (name)) {
				data.Add (name, 0.0f);
			}
		}

		static internal void UpdateAxis (string name, float val)
		{
			data [name] = val;
		}

		static public float GetAxis (string name)
		{
			return data [name];
		}
	}

	public class VirtualJoystick : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
	{
		public string horizontalName = "Horizontal";
		public string verticalName = "Vertical";
		public GameObject boundaryImage;
		public float area = 50.0f;
		/************************/
		private Vector3 canvasPos;
		private bool notzero = true;
		private Vector2 canvasOffsetPos;
		private bool draging = false;
		private Vector2 canvasLastOffset;
		private Vector2 dragstartPos;
		private Vector2 dragOffsetPos;

		void Start ()
		{
			canvasPos = transform.position;
			canvasOffsetPos = Vector2.zero;
			Joysticks.RegisterAxis (horizontalName);
			Joysticks.RegisterAxis (verticalName);
			boundaryImage.transform.SetParent (transform.parent);
		}

		void FixedUpdate ()
		{
			if (notzero || draging) {
				Joysticks.UpdateAxis (horizontalName, canvasOffsetPos.x / area);
				Joysticks.UpdateAxis (verticalName, canvasOffsetPos.y / area);
				if (!draging) {
					if (canvasOffsetPos.Equals (Vector2.zero)) {
						notzero = false;
					} else {
						canvasOffsetPos *= 0.85f;
						if (canvasOffsetPos.sqrMagnitude < 2.0f) {
							canvasOffsetPos = Vector2.zero;
						}
					}
				}
				Vector3 offsetcache = new Vector3 (canvasOffsetPos.x, canvasOffsetPos.y, 0.0f);
				transform.position = canvasPos + offsetcache;
			}
		}

		public void OnBeginDrag (PointerEventData eventData)
		{
			canvasLastOffset = canvasOffsetPos;
			dragstartPos = eventData.position;
			draging = true;
			notzero = true;
		}

		public void OnDrag (PointerEventData eventData)
		{
			dragOffsetPos = eventData.position - dragstartPos;
			canvasOffsetPos = Vector2.ClampMagnitude (canvasLastOffset + dragOffsetPos, area);
		}
		
		public void OnEndDrag (PointerEventData eventData)
		{
			draging = false;
		}
	}
}