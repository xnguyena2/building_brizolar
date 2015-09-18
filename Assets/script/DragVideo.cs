using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DragVideo : MonoBehaviour ,IBeginDragHandler,IDragHandler,IEndDragHandler{
	public static GameObject video;
	Vector3 postion;
	Vector3 ofset;

	#region IBeginDragHandler implementation

	public void OnBeginDrag (PointerEventData eventData)
	{
		video = gameObject;
		postion = transform.position;
		ofset = postion - Input.mousePosition;
	}

	#endregion



	#region IDragHandler implementation
	public void OnDrag (PointerEventData eventData)
	{
		transform.position = Input.mousePosition + ofset;
	}
	#endregion

	#region IEndDragHandler implementation

	public void OnEndDrag (PointerEventData eventData)
	{

	}

	#endregion
}
