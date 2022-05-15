using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(BoxCollider))] [RequireComponent(typeof(Rigidbody))]
public class Object : MonoBehaviour
{
    [HideInInspector] public Transform _parentWhenMoving;
    private Transform _startPosition;
    private Transform _lastPosition;
    private Object _objectToMerge;
    private string _name;
    private int _price;
    private Sprite _sprite;
    private SellButton _selling;
    [HideInInspector] public int parrentIndex;
    public void Initialize(string Name, int Price, Sprite Img )
    {
        _name = Name;
        _price = Price;
        _sprite = Img;
        name = _name;
        GetComponent<Image>().sprite = _sprite;
        GetComponent<Image>().SetNativeSize();

    }
    private void OnEnable()
    {
        GetComponent<MoveObject>().onStartDrag += SetStartetPosition;
        GetComponent<MoveObject>().onEndDrag += MoveObject;
    }
    private void OnDestroy()
    {
        GetComponent<MoveObject>().onStartDrag -= SetStartetPosition;
        GetComponent<MoveObject>().onEndDrag -= MoveObject;

    }
    private void SetStartetPosition()
    {
        _startPosition = transform.parent;
        _lastPosition = _startPosition;
        transform.SetParent(_parentWhenMoving);
    }
    private void MoveObject()
    {
        if (_objectToMerge != null)
        {
            bool merging;
            merging = MergeMechanic.MergeObjects(this, _objectToMerge);

            if (merging)
            {
                SoundController._instance.Merging();
                transform.position = _lastPosition.position;

                return;
            }
            else if (!merging)
            {
                _lastPosition = _startPosition;
            }
        }
        if(_selling != null)
        {
            _selling.Selling(_price);
            SoundController._instance.BuySometing();
            Destroy(gameObject);
        }
        transform.SetParent(_lastPosition);
        transform.position = _lastPosition.position;
    }
    private void OnTriggerEnter(Collider other)
    {
        _lastPosition = other.transform;
        if(other.TryGetComponent(out Object obj))
        {
            _objectToMerge = obj;
        }
        if(other.TryGetComponent(out SellButton sellButton))
        {
            _selling = sellButton;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (_objectToMerge != null)
        {
            _objectToMerge = null;
        }
        if(_selling != null)
        {
            _selling = null;
        }
        _lastPosition = _startPosition;
    }
    public void GetObjectInfo( out string name, out int price, out int parent)
    {
        name = _name;
        price = _price;
        parent = transform.parent.GetSiblingIndex();
    }

}
