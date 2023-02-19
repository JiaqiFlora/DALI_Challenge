using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WobblyText : MonoBehaviour
{
    TMP_Text textComponext;


    // Start is called before the first frame update
    void Start()
    {
        textComponext = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        textComponext.ForceMeshUpdate();
        var textInfo = textComponext.textInfo;

        for (int i = 0; i < textInfo.characterCount; ++i)
        {
            var charInfo = textInfo.characterInfo[i];

            if (!charInfo.isVisible)
            {
                continue;
            }


            var verts = textInfo.meshInfo[charInfo.materialReferenceIndex].vertices;

            for (int j = 0; j < 4; ++j)
            {
                var orig = verts[charInfo.vertexIndex + j];
                verts[charInfo.vertexIndex + j] = orig + new Vector3(0, Mathf.Sin(Time.time * 3f + orig.x * 0.3f) * 1f, 0);
            }
        }

        for (int i = 0; i < textInfo.meshInfo.Length; ++i)
        {
            var meshInfo = textInfo.meshInfo[i];
            meshInfo.mesh.vertices = meshInfo.vertices;
            textComponext.UpdateGeometry(meshInfo.mesh, i);
        }

        
    }
}
