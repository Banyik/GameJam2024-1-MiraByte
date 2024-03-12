using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using Player;
using System.Linq;

public class TriggerVignette : MonoBehaviour
{
    public float vignetteStrengthWithNightVision;
    public float vignetteStrengthWithoutNightVision;
    public VolumeProfile volume;

    public Light2D globalLight;
    public Color nightVision;
    public Color normalVision;
    Vignette vignette;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            volume.TryGet(out vignette);
            if(collision.GetComponent<Inventory>().items.Where(x => x.item == ItemTypes.NightVisionGoogles).ToList().Count > 0)
            {
                vignette.intensity.value = vignetteStrengthWithNightVision;
                globalLight.color = nightVision;
            }
            else
            {
                vignette.intensity.value = vignetteStrengthWithoutNightVision;
                globalLight.color = normalVision;
            }
        }
    }
}
