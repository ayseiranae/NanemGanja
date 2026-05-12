using UnityEngine;

public sealed class HandClamper : MonoBehaviour
{
    [Header("Batas Ketinggian Tanah (Y) untuk Tangan")]
    public float limitY = -0.7669286f; // Samakan dengan limit kamera Anda

    // Subscribe ke event BeforeRender untuk menimpa pergerakan dari VR / XR Device Simulator
    void OnEnable()
    {
        Application.onBeforeRender += ClampHand;
    }

    void OnDisable()
    {
        Application.onBeforeRender -= ClampHand;
    }

    void LateUpdate()
    {
        ClampHand();
    }

    void ClampHand()
    {
        // Ambil posisi tangan di dunia (World Space)
        Vector3 currentPos = transform.position;

        // Cegah tangan tembus ke bawah tanah (Sumbu Y)
        if (currentPos.y < limitY)
        {
            currentPos.y = limitY;
            transform.position = currentPos;
        }
    }
}