using UnityEngine;  
using System.Collections;  
using UnityEngine.EventSystems;  
using UnityEngine.UI;

public class ButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler,  IPointerDownHandler, IPointerUpHandler {

	public Text theText;
	Color loadColor;

	void Start ()
	{
		loadColor = theText.color;
	}

	// On mouse over button
	// change text color
	// to RED
	public void OnPointerEnter(PointerEventData eventData)
	{
		theText.color = Color.red; //Or however you do your color
	}
	// On mouse exit button
	// change text color
	// back
	public void OnPointerExit(PointerEventData eventData)
	{
		theText.color = loadColor; //Or however you do your color
	}
	// If mouse pressed
	// change text color
	// to GRAY
	public void OnPointerDown(PointerEventData eventData)
	{
		theText.color = Color.gray;
	}

	// Change color back like it was on enter
	public void OnPointerUp(PointerEventData eventData)
	{
		theText.color = Color.red;
	}
}
