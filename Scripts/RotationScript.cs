using UnityEngine;

public class RotationScript : MonoBehaviour
{
    public Transform objectToRevolve;  
    public float revolutionSpeed = 1.0f; 
    public float distanceFromCenter = 3.0f; 

    private float angle;

    void Update()
    {
        angle += Time.deltaTime * revolutionSpeed;

        Matrix4x4 transMat = Matrix4x4.Translate(new Vector3(distanceFromCenter, 0, 0));
        Matrix4x4 rotMat = Matrix4x4.Rotate(Quaternion.Euler(0, angle, 0));
        Vector3 newPosition = rotMat.MultiplyPoint3x4(transMat.MultiplyPoint3x4(Vector3.zero));

        objectToRevolve.position = transform.position + newPosition;
    }
}
