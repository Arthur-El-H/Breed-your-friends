using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class possibleMate : MonoBehaviour
{
    private GameObject marryBtn;
    public person person;

    private RectTransform btnRect;
    private RectTransform canvRect;
    private Camera cam;

    public void destroy()
    {
        Destroy(marryBtn);
        Destroy(this.gameObject);
        Destroy(this); //TODO test if still necessary
    }

    public void setUp(GameObject btn, Vector2 pos, person personMateIsBasedOn)
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        marryBtn = btn;
        transform.position = pos;
        person = personMateIsBasedOn;

        //setPositionRelativeToSprite();
        buttonManager.moveBtn(marryBtn, cam.WorldToScreenPoint(transform.position));
    }

    private void setPositionRelativeToSprite()
    {
        btnRect = marryBtn.GetComponent<RectTransform>();
        canvRect = marryBtn.transform.parent.GetComponent<RectTransform>();
        Vector2 btnPos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvRect, cam.WorldToScreenPoint(transform.position), cam, out btnPos);
        btnRect.anchoredPosition = btnPos;
    }
}
