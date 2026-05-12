using UnityEngine;

public sealed class CameraZClamper : MonoBehaviour
{
    [Header("Batas Ketinggian Tanah (Y)")]
    public float limitY = -0.7669286f; 

    // Subscribe ke event BeforeRender untuk menimpa pergerakan dari VR / XR Device Simulator
    void OnEnable()
    {
        Application.onBeforeRender += ClampCamera;
    }

    void OnDisable()
    {
        Application.onBeforeRender -= ClampCamera;
    }

    void LateUpdate()
    {
        ClampCamera();
    }

    void ClampCamera()
    {
        Vector3 currentPos = transform.position;

        // Cegah kamera tembus ke bawah tanah
        if (currentPos.y < limitY)
        {
            currentPos.y = limitY;
            transform.position = currentPos;
        }
    }
}