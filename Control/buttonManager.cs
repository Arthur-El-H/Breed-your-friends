using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonManager : MonoBehaviour
{
    [SerializeField] private GameObject genericButton;
    [SerializeField] public  Canvas canvas;
    [SerializeField] private Camera cam;

    private GameObject workOutBtn;
    private GameObject acquaintancesBtn;
    private GameObject surgeryBtn;
    private GameObject wealthBtn;

    public delegate void marryMe(person personToMarry);
    public delegate void hostAction();

    public void gainWealthButtonClicked()
    {

    }
    
    public void gainAcquaintancesButtonClicked()
    {

    }
    public void workoutButtonClicked()
    {

    }
    public void getPlasticSurgeryButtonClicked()
    {

    }

    public GameObject getButtonForPossibleMate( marryMe methodToCallOnPress, person personToMarry)
    {
        GameObject btn = Instantiate(genericButton, new Vector3(0, 0, 0), Quaternion.identity, canvas.transform);
        btn.GetComponent<Button>().onClick.AddListener(delegate { methodToCallOnPress(personToMarry); });
        return btn;
    }

    internal void initActionBtns(host host)
    {
        hostAction hostAction;
        
        hostAction = host.getPlasticSurgery;
        surgeryBtn = getHostActionButton(hostAction);
        surgeryBtn.name = "surgeryBtn";
        //surgeryBtn.GetComponent<Button>().
        moveBtn(surgeryBtn, cam.WorldToScreenPoint(new Vector3(0,-4,0)));

        hostAction = host.gainWealth;
        wealthBtn = getHostActionButton(hostAction);
        wealthBtn.name = "wealthBtn";
        moveBtn(wealthBtn, cam.WorldToScreenPoint(new Vector3(0, -2, 0)));

        hostAction = host.gainAcquaintances;
        acquaintancesBtn = getHostActionButton(hostAction);
        acquaintancesBtn.name = "acquaintancesBtn";
        moveBtn(acquaintancesBtn, cam.WorldToScreenPoint(new Vector3(0, 0, 0)));

        hostAction = host.workout;
        workOutBtn = getHostActionButton(hostAction);
        workOutBtn.name = "workOutBtn";
        moveBtn(workOutBtn, cam.WorldToScreenPoint(new Vector3(0, 2, 0)));
    }

    public GameObject getHostActionButton(hostAction methodToCallOnPress)
    {
        GameObject btn = Instantiate(genericButton, new Vector3(0, 0, 0), Quaternion.identity, canvas.transform);
        btn.GetComponent<Button>().onClick.AddListener(delegate { methodToCallOnPress(); });
        return btn;
    }

    public static void moveBtn(GameObject btnGameObject, Vector2 targetPos)
    {
        RectTransform btnRect = btnGameObject.GetComponent<RectTransform>();
        RectTransform canvRect = btnGameObject.transform.parent.GetComponent<RectTransform>();
        Camera cam = btnGameObject.transform.parent.GetComponent<Canvas>().worldCamera;

        Vector2 btnPos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvRect, targetPos, cam, out btnPos);
        btnRect.anchoredPosition = btnPos;
    }
}
