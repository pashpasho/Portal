using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode]
public class Portal : MonoBehaviour
{
    ParticleSystem ps;

    // these lists are used to contain the particles which match
    // the trigger conditions each frame.
    List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();
    List<ParticleSystem.Particle> inside = new List<ParticleSystem.Particle>();

    void OnEnable()
    {
        ps = GetComponent<ParticleSystem>();
    }

    void OnParticleTrigger()
    {
        int numEnter = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Enter, enter);
        int numInside = ps.GetTriggerParticles(ParticleSystemTriggerEventType.Inside, inside);
        Component component = ps.trigger.GetCollider(0);
        GameObject vb = component.gameObject;
        var markCount = GameObject.FindGameObjectsWithTag("Marker");
        if (markCount.Length == 3 && numEnter > 0 && numInside > 0)
        {
            Destroy(markCount[1]);
            vb.transform.position = markCount[2].transform.position + new Vector3(0, 0.4f, 0); ;
        }
    }
}
