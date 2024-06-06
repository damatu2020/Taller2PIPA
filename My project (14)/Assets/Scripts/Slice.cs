using UnityEngine;

public class Slice : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]private Camera mainCamera;
    private bool slicing;
    private Collider bladeCollider;
    private TrailRenderer bladeTrail;
    public Vector3 direction {get; private set; }
    public float minSliceVelocity = 0.01f;
    public float sliceForce = 5f;

    private void Awake()
    {
        bladeCollider = GetComponent<Collider>();
        bladeTrail = GetComponentInChildren<TrailRenderer>();
    }

    private void OnEnable()
    {
        StopSlice();
    }
    // Update is called once per frame
    private void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            StartSlice();
        }else if(Input.GetMouseButtonUp(0)){
            StopSlice();
        }else if(slicing){
            continueSlice();
        }
    }
    private void StartSlice()
    {
        Vector3 newPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = -1f;
        transform.position = newPosition;
        slicing = true;
        bladeCollider.enabled = true;
        bladeTrail.enabled = true;
        bladeTrail.Clear();
    }
    private void StopSlice()
    {
        slicing = false;
        bladeCollider.enabled = false;
        bladeTrail.enabled = false;
    }
    private void continueSlice()
    {
        Vector3 newPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        newPosition.z = -1f;
        direction = newPosition - transform.position;
        float velocity = direction.magnitude / Time.deltaTime;
        bladeCollider.enabled = velocity > minSliceVelocity;
        transform.position = newPosition;
    }
}
