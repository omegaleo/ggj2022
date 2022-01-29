using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace;
using UnityEngine;

public class SFX : AudioManager
{
    [SerializeField] private List<SFXAssociation> sfxAssociations;

    public static SFX instance;

    private void Awake()
    {
        instance = this;
    }
    
    public void Play(SFXTypes type)
    {
        AudioClip clip = sfxAssociations.Where(x => x.type == type).Select(x => x.clip).FirstOrDefault();

        if (clip != null)
        {
            source.clip = clip;
            source.Play();
        }
    }
}
