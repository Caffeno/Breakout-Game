using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
public class AudioParameterUpdater : MonoBehaviour
{
    [FMODUnity.EventRef] public string musicEvent = "";

    FMOD.Studio.EventInstance music;

    FMOD.Studio.PARAMETER_ID bricksBrokeID;
    private void Awake()
    {
        music = RuntimeManager.CreateInstance(musicEvent);
        music.start();

        FMOD.Studio.EventDescription musicDesc;
        music.getDescription(out musicDesc);
        FMOD.Studio.PARAMETER_DESCRIPTION bricksBrokeDesc;
        musicDesc.getParameterDescriptionByName("Bricks Broke",out bricksBrokeDesc);
        bricksBrokeID = bricksBrokeDesc.id;
    }
    // Start is called before the first frame update
    void Start()
    {
        CustomEventManager.instance.tileBreak += OnTileBreak;
    }

    public void OnTileBreak(float progress)
    {
        music.setParameterByID(bricksBrokeID, progress);



    }
}
