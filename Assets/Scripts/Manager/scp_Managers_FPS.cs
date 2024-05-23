using UnityEngine;

public class scp_Managers_FPS : MonoBehaviour
{
    public int frameTarget;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = frameTarget;
    }
}
