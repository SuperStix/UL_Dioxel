using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIZoomImage : MonoBehaviour
{
    private Vector3 initialScale;

    [SerializeField]
    private float zoomSpeed = 1f;
    [SerializeField]
    private float maxZoom = 10f;
    private float deltaMagnitudeDiff;

    private void Start()
    {
        this.transform.localScale = new Vector3(0.4433602f, 0.2140943f, 0.3495363f);
    }

    private void Awake()
    {
        initialScale = transform.localScale;
        //initialScale = new Vector3(0.4433602f, 0.2140943f, 0.3495363f);
    }

    private void Update()
    {

        if (Input.touchCount == 2)
        {
            // Store both touches.
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            // Find the position in the previous frame of each touch.
            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            // Find the magnitude of the vector (the distance) between the touches in each frame.
            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            // Find the difference in the distances between each frame.
            deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;


            var delta = Vector3.one * (-deltaMagnitudeDiff * zoomSpeed);
            var desiredScale = transform.localScale + delta;

            desiredScale = ClampDesiredScale(desiredScale);

            transform.localScale = desiredScale;
        }
    }

    //public void OnScroll(PointerEventData eventData)
    //{
    //
    //
    //    var delta = Vector3.one * (eventData.scrollDelta.y * zoomSpeed);
    //    var desiredScale = transform.localScale + delta;
    //
    //    desiredScale = ClampDesiredScale(desiredScale);
    //
    //    transform.localScale = desiredScale;
    //
    //    Debug.Log(Vector3.one);
    //    Debug.Log(delta);
    //}

    private Vector3 ClampDesiredScale(Vector3 desiredScale)
    {
        desiredScale = Vector3.Max(initialScale, desiredScale);
        desiredScale = Vector3.Min(initialScale * maxZoom, desiredScale);
        return desiredScale;
    }
}