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
				data.Add (name, 0f);
			} else {
				Debug.LogError (name + " Axis register twice");
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
		public float area = 50f;
		/************************/
		private bool horizontalLock = true;
		private bool verticalLock = true;
		/************************/
		private Vector3 canvasPos;
		private bool draging = false;
		private bool notzero = false;
		private Vector2 canvasOffsetPos;
		private Vector2 canvasLastOffset;
		private Vector2 dragstartPos;

		void Start ()
		{
			boundaryImage.transform.SetParent (transform.parent);
			canvasPos = transform.position;
			canvasOffsetPos = Vector2.zero;
			canvasLastOffset = Vector2.zero;
			if (horizontalName != "") {
				Joysticks.RegisterAxis (horizontalName);
				horizontalLock = false;
			}
			if (verticalName != "") {
				Joysticks.RegisterAxis (verticalName);
				verticalLock = false;
			}
		}

		void FixedUpdate ()
		{
			if (draging || notzero) {
				if (!draging) {
					canvasOffsetPos -= Vector2.ClampMagnitude (canvasOffsetPos, 3f);
					notzero = (canvasOffsetPos != Vector2.zero);
				} else {
					notzero = true;
				}
				if (!horizontalLock) {
					Joysticks.UpdateAxis (horizontalName, canvasOffsetPos.x / area);
				}
				if (!verticalLock) {
					Joysticks.UpdateAxis (verticalName, canvasOffsetPos.y / area);
				}
				transform.position = canvasPos + new Vector3 (canvasOffsetPos.x, canvasOffsetPos.y, 0f);
			}
		}

		public void OnBeginDrag (PointerEventData eventData)
		{
			canvasLastOffset = canvasOffsetPos;
			dragstartPos = eventData.position;
			draging = true;
		}

		public void OnDrag (PointerEventData eventData)
		{
			canvasOffsetPos = canvasLastOffset + eventData.position - dragstartPos;
			if (horizontalLock) {
				canvasOffsetPos.x = 0f;
			}
			if (verticalLock) {
				canvasOffsetPos.y = 0f;
			}
			canvasOffsetPos = Vector2.ClampMagnitude (canvasOffsetPos, area);
		}
		
		public void OnEndDrag (PointerEventData eventData)
		{
			draging = false;
		}
	}
}