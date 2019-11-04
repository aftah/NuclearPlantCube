//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
//|                                                                             This Library is made by Abdelfetah Hamra                                                                  | 
//|                                                                                                                                                                                       |
//|                                                                                 Copyright Aftah-Games 2019                                                                            | 
//----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------



using UnityEngine;
using UnityEngine.Audio;


namespace AftahGames.NuclearSimulator
{
    public class SoundManager : MonoBehaviour
    {
        private static SoundManager _instance = new SoundManager();



        #region SERIALIZED FIELDS
        [SerializeField]
        private SoundClips[] soundClips;

        #endregion

        #region PRIVATE FIELDS
        #endregion

        #region PUBLIC PROPERTIES

        public static SoundManager Instance
        {
            get
            {
                return _instance;
            }
        }

        #endregion

        #region PUBLIC FUNCTIONS
        #endregion

        #region EVENTS
        #endregion

        #region PRIVATE FUNCTIONS

        private void Awake()
        {
            if (_instance  != null)
            {
                Destroy(this);
            }
            else
            {
                _instance = this;
                DontDestroyOnLoad(this);
               
            }

            for (int i = 0; i < soundClips.Length; i++)
            {
                if (soundClips[i].audioSource == null)
                {
                    GameObject gameObject = new GameObject("soundClip_" + i + "_" + soundClips[i].name);
                    gameObject.transform.SetParent(this.transform);
                    soundClips[i].audioSource = gameObject.AddComponent<AudioSource>();
                    soundClips[i].audioSource.clip = soundClips[i].audioClips;
                    soundClips[i].audioSource.playOnAwake = false;  

                }

                if (soundClips[i].playOnAwake)
                {
                    soundClips[i].Play();
                    return;
                }

            }
        }



        public void PlaySound(string name)
        {

            for (int i = 0; i < soundClips.Length; i++)
            {
                if (soundClips[i].name == name)
                {
                    soundClips[i].Play();
                    return;
                }
            }

            Debug.Log("Sound not found...");

        }

        public void StopSound(string name)
        {

            for (int i = 0; i < soundClips.Length; i++)
            {
                if (soundClips[i].name == name)
                {
                    soundClips[i].Stop();
                    return;
                }
            }

            Debug.Log("Sound not found...");

        }
        #endregion



    }


    [System.Serializable]
    public  class SoundClips
    {
        #region SERIALIZED FIELDS
        #endregion

        #region PRIVATE FIELDS
        #endregion

        #region PUBLIC FIELDS

        public string name;

        public AudioSource audioSource;

        public AudioClip audioClips;

        public AudioMixerGroup outpup;

        [Range(0, 1)]
        public float volume = 1f;


        [Range(0, 3)]
        public float pitch = 1f;


        [Range(-1, 1)]
        public float stereoPan = 0f;




        public bool loop = false;
        public bool mute = false;
        public bool playOnAwake = false;




        #endregion

        #region PUBLIC PROPERTIES
        #endregion

        #region PUBLIC FUNCTIONS

        public void Play()
        {

            audioSource.volume = volume;
            audioSource.pitch = pitch;
            audioSource.panStereo = stereoPan;
            audioSource.loop = loop;
            audioSource.mute = mute;
            audioSource.outputAudioMixerGroup = outpup;

            audioSource.Play();

        }

        public void Stop()
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }

        }
        #endregion

        #region EVENTS
        #endregion

        #region PRIVATE FUNCTIONS

        #endregion


    }
}
