using UnityEngine;

public class SpaceGameController : MonoBehaviour
{
    private GameObject _background;
    private GameObject _secondBg;
    public BgPoolController bgPoolController;
    private float _instantiateDistance;
    private float _height;

    // Start is called before the first frame update
    void Start()
    {
        _background = bgPoolController.GetFirstPooledObject();
        _secondBg = bgPoolController.GetElementOfPoolByIndex(1);
        CalculateWidthAndHeight();
        _secondBg.transform.Translate(new Vector2(_secondBg.transform.position.x, _instantiateDistance));
    }

    private void CalculateWidthAndHeight()
    {
        Vector3 bgCollider = _background.GetComponent<BoxCollider2D>().bounds.size;

        _instantiateDistance = bgCollider.y;
    }

    // Update is called once per frame
    void Update()
    {
        _background.transform.Translate(Vector2.down * Time.deltaTime);
        _secondBg.transform.Translate(Vector2.down * Time.deltaTime);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        GameObject objectThatCollide = other.gameObject;
        if (objectThatCollide == _background && objectThatCollide.CompareTag("Background"))
        {
            objectThatCollide.transform.position = new Vector2(objectThatCollide.transform.position.x,
                _secondBg.transform.position.y + _instantiateDistance);
        }
        else if (objectThatCollide.CompareTag("Background"))
        {
            objectThatCollide.transform.position = new Vector2(objectThatCollide.transform.position.x,
                _background.transform.position.y + _instantiateDistance);
        }
    }
}