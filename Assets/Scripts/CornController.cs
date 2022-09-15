using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornController : MonoBehaviour
{
    public Color[] colorPalette;
    public float height;
    public float growthSpeedPerMinute;
    public Transform player;
    public MeshFilter cornMesh;
    public float startingHeight;

    CameraFader camFader;
    [SerializeField]
    float timer;
    void Start()
    {
        camFader = GetComponent<CameraFader>();
        timer = startingHeight * 60 * growthSpeedPerMinute;
        transform.localScale = new Vector3(startingHeight, startingHeight, startingHeight);
        player.position = new Vector3(player.position.x, GetHighestCornVertex(startingHeight).y, player.position.z);
    }


    void Update()
    {

        if(Input.GetKey(KeyCode.Space)) {
            camFader.FadeOut();
            timer += Time.deltaTime;
            float cornHeight = timer / 60.0f * growthSpeedPerMinute;
            transform.localScale = new Vector3(cornHeight, cornHeight, cornHeight);

            player.position = new Vector3(player.position.x, GetHighestCornVertex(cornHeight).y, player.position.z);
        }
        else {
            camFader.FadeIn();
        }

        
    }    



    Vector3 GetHighestCornVertex(float scale)
    {
        Matrix4x4 localToWorld = transform.localToWorldMatrix;
        Vector3 best = Vector3.negativeInfinity;
        var mesh = cornMesh.mesh;
        foreach(var v in mesh.vertices) {
            Vector3 world_v = localToWorld.MultiplyPoint3x4(v);
            best = world_v.y > best.y ? world_v : best;
        }

        return best;
    }
}
