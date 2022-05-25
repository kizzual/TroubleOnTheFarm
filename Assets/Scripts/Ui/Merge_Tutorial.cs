using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Merge_Tutorial : MonoBehaviour
{
    public List<GameObject> tutorials;
    public GameObject parentImage;
    public MoveObject img;
    public CreateObject _createObject;
    public static Merge_Tutorial _instanse;
    public BoxCollider col;
    public Button okButton;
    public List<Button> otherButton;
    void Awake()
    {
        _instanse = this;
           tutorials[0].SetActive(true);
        okButton.enabled = false;

    }
    public void SwitchAnimation()
    {
       if(tutorials[0].activeSelf)
        {
            tutorials[0].SetActive(false);
            tutorials[1].SetActive(true);
            OffRaycastImage();
            SwitchMoveGrid(false);
            foreach (var item in otherButton)
            {
                item.enabled = false;
            }

        }
        else if(tutorials[1].activeSelf)
        {
            tutorials[1].SetActive(false);
            tutorials[2].SetActive(true);
            
            _createObject.cells[0].GetComponent<ParentGrid>().IsActive = false;
            _createObject.cells[0].GetComponent<ParentGrid>().BoxOff();
        }
       else if(tutorials[2].activeSelf)
        {
            SwitchMoveGrid(true);
            _createObject.cells[0].GetComponent<ParentGrid>().IsActive = true;
            _createObject.cells[0].GetComponent<ParentGrid>().BoxOn();
            okButton.enabled = true;
            foreach (var item in otherButton)
            {
                item.enabled = true;
            }
            tutorials[2].SetActive(false);
            tutorials[3].SetActive(true);
        }

    } 
    public void CloseTutorial()
    {
 
        gameObject.SetActive(false);
    }
    public void OffRaycastImage()
    {
        img = parentImage.transform.GetChild(0).GetComponent<MoveObject>();
        img.CanMove = false;
    }
    public void SwitchMoveGrid(bool isEnable)
    {
        if(!isEnable)
        {
            for (int i = 0; i < _createObject.cells.Count; i++)
            {
                if (i != 0 && i != 1)
                {
                    _createObject.cells[i].GetComponent<ParentGrid>().IsActive = false;
                    _createObject.cells[i].GetComponent<ParentGrid>().BoxOff();
                }
            }
        }
        else if (isEnable)
        {
            for (int i = 0; i < _createObject.cells.Count; i++)
            {
                if (i != 0 && i != 1)
                {
                    _createObject.cells[i].GetComponent<ParentGrid>().IsActive = true;

                    _createObject.cells[i].GetComponent<ParentGrid>().BoxOn();
                }
            }
        }



    }
}
