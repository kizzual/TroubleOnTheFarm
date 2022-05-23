using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(BoxCollider))] [RequireComponent(typeof(Rigidbody))]
public class Object : MonoBehaviour
{
    [HideInInspector] public Transform _parentWhenMoving;
    private Transform _startPosition;
    public Transform _lastPosition;
    public Object _objectToMerge;
    private string _name;
    private int _price;
    private Sprite _sprite;
    private SellButton _selling;
    [HideInInspector] public int parrentIndex;
    private ParticleSystem particle;
    private bool isDraging;
    public bool CanMove = true;
    public ParticleSystem MergeParticle;
    public void Initialize(string Name, int Price, Sprite Img )
    {
        _name = Name;
        _price = Price;
        _sprite = Img;
        name = _name;
        GetComponent<Image>().sprite = _sprite;
        GetComponent<Image>().SetNativeSize();
    }
    public void TurnOnParticles()
    {
        particle.Play();
    }
    private void OnEnable()
    {
        GetComponent<MoveObject>().onStartDrag += SetStartetPosition;
        GetComponent<MoveObject>().onEndDrag += MoveObject;
        particle = GetComponentInChildren<ParticleSystem>();
        particle.Stop();
    }
    private void OnDestroy()
    {
        GetComponent<MoveObject>().onStartDrag -= SetStartetPosition;
        GetComponent<MoveObject>().onEndDrag -= MoveObject;

    }
    private void SetStartetPosition()
    {
        isDraging = true;
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
                transform.position = transform.parent.position;
                MergeParticle.Play();
                Merge_Tutorial._instanse.SwitchAnimation();

                return;
            }
            else if (!merging)
            {
                _lastPosition = _startPosition;
            }
        }
        if (_selling != null)
        {
            _selling.Selling(_price);
            SoundController._instance.BuySometing();
            Merge_Tutorial._instanse.SwitchAnimation();
            Destroy(gameObject);
        }
        transform.SetParent(_lastPosition);
        transform.position = _lastPosition.position;
        isDraging = false;

    }
    private void OnTriggerEnter(Collider other)
    {
        if (isDraging)
        {
            if (other.TryGetComponent(out Object obj))
            {
                if (name == obj.name)
                {
                    _objectToMerge = obj;
                }
            }
            if (other.TryGetComponent(out ParentGrid par))
            {

                _lastPosition = other.transform;
            }

            if (other.TryGetComponent(out SellButton sellButton))
            {
                _selling = sellButton;
            }
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
