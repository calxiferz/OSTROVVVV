using UnityEngine;

[CreateAssetMenu (fileName = "NewNPCDialogue", menuName = "NPC Dialogue")]
public class NPCDialogue : ScriptableObject
{
    public string npcName;
    public Sprite npcPortrait;
    public string[] dialogueLines;
    public bool[] autoProgressLines;
    public float autoProgressDelay = 20f;
    public float typingSpeed = 10000000f;
    public AudioClip voiceSound;
    public float voicePitch = 1f;

}
