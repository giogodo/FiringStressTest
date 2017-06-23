using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class JoystickHandler : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler{
	private Image joystickBase;
	private Image joystickMaster;
	[HideInInspector]
	public Vector3 inputDirection;
	[HideInInspector]
	public float inputAngle;
	// Use this for initialization
	void Start () {
		joystickBase = GetComponent<Image> ();
		joystickMaster = transform.GetChild (0).GetComponent<Image> ();
		inputDirection = Vector3.zero;
		inputAngle = 0f;
	}

	public void OnDrag (PointerEventData pointerEventData)
	{
		//get input direction
		Vector2 position = Vector2.zero;
		RectTransformUtility.ScreenPointToLocalPointInRectangle (joystickBase.rectTransform, pointerEventData.position, pointerEventData.pressEventCamera, out position);
		position.x = (position.x / joystickBase.rectTransform.sizeDelta.x);
		position.y = (position.y / joystickBase.rectTransform.sizeDelta.y);
		float x = (joystickBase.rectTransform.pivot.x == 1f) ? position.x*2+1 : position.x*2-1;
		float y = (joystickBase.rectTransform.pivot.y == 1f) ? position.y*2+1 : position.y*2-1;
		inputDirection = new Vector3 (x,y,0);
		inputDirection = (inputDirection.magnitude > 1) ? inputDirection.normalized : inputDirection;
		joystickMaster.rectTransform.anchoredPosition = new Vector3 (inputDirection.x * (joystickBase.rectTransform.sizeDelta.x/3), inputDirection.y * (joystickBase.rectTransform.sizeDelta.y/3));
		//get input angle since 12 O'Clock, in hourly direction
		inputAngle = (inputDirection.x>=0) ? Vector3.Angle(inputDirection, Vector3.up) : 360 - Vector3.Angle(inputDirection, Vector3.up);
		//control
		//print(inputDirection.x + ", " + inputDirection.y + "\t" + inputAngle+" grados");
	}
	public void OnPointerDown (PointerEventData pointerEventData)
	{
		OnDrag (pointerEventData);
	}
	public void OnPointerUp (PointerEventData pointerEventData)
	{
		inputDirection = Vector3.zero;
		//joystickBase.rectTransform.anchoredPosition = new Vector3 (75,75, 0);
		joystickMaster.rectTransform.anchoredPosition = Vector3.zero;
	}
}
