using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MemoryGameController : MonoBehaviour
{
   [Header("Buttons")]
   [SerializeField] private Sprite bgImage;
   public List<Button> btns = new List<Button>();

   [Header("Game 01")]
   public Sprite[] Puzzles01;
   public List<Sprite> GamePuzzles = new List<Sprite>();

   [Header("Logic")] 
   private bool _firstGuess, _secondGuess;

   private int _countGuesses, _countCorrectGuesses, _gameGuesses;
   private int _firstGuessIndex, _secondGuessIndex;
   private string _firstGuessesPuzzle, _secondGuessePuzzle;
   
   private void Awake()
   {
      Puzzles01 = Resources.LoadAll<Sprite>("Art/Sprites/MemoryGame/01CasaFenelon/IMG");
   }

   private void Start()
   {
      GetButtons();
      AddListener();
      AddGamePuzzles();
      Shuffle(GamePuzzles);
      _gameGuesses = GamePuzzles.Count / 2;
   }

   void GetButtons()
   {
      GameObject[] objects = GameObject.FindGameObjectsWithTag("PuzzleMemoryButton");

      for (int i = 0; i < objects.Length; i++)
      {
         btns.Add(objects[i].GetComponent<Button>());
         btns[i].image.sprite = bgImage;
      }
   }

   void AddGamePuzzles()
   {
      int looper = btns.Count;
      int index = 0;
      
      for(int i = 0; i < looper; i++)
      {
         if (index == looper/2)
         {
            index = 0;
         }
         
         GamePuzzles.Add(Puzzles01[index]);

         index++;
      }
   }
   
   void AddListener()
   {
      foreach (Button btn in btns)
      {
         btn.onClick.AddListener(() => PickAPuzzle());
      }
   }
   public void PickAPuzzle()
   {
      string name = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;

      if (!_firstGuess)
      {
         _firstGuess = true;

         _firstGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

         _firstGuessesPuzzle = GamePuzzles[_firstGuessIndex].name;
         
         btns[_firstGuessIndex].image.sprite = GamePuzzles[_firstGuessIndex];
      }
      else if (!_secondGuess)
      {
         _secondGuess = true;
         
         _secondGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
         
         _secondGuessePuzzle = GamePuzzles[_secondGuessIndex].name;

         _countGuesses++;
         
         btns[_secondGuessIndex].image.sprite = GamePuzzles[_secondGuessIndex];

         StartCoroutine(CheckIfThePuzzlesMatch());
      }

      IEnumerator CheckIfThePuzzlesMatch()
      {
         yield return new WaitForSeconds(1f);

         if (_firstGuessesPuzzle == _secondGuessePuzzle)
         {
            yield return new WaitForSeconds(0.5f);
            btns[_firstGuessIndex].interactable = false;
            btns[_secondGuessIndex].interactable = false;

            btns[_firstGuessIndex].image.color = new Color(0, 0, 0, 0);
            btns[_secondGuessIndex].image.color = new Color(0, 0, 0, 0);

         CheckIfTheGameIsFinish();
         }
         else
         {
            yield return new WaitForSeconds(0.5f);
            
            btns[_firstGuessIndex].image.sprite = bgImage;
            btns[_secondGuessIndex].image.sprite = bgImage;
         }

         yield return new WaitForSeconds(0.5f);

         _firstGuess = _secondGuess = false;
      }

      void CheckIfTheGameIsFinish()
      {
         _countCorrectGuesses++;
         if (_countCorrectGuesses == _gameGuesses)
         {
            Debug.Log("Fin del Juego");
            Debug.Log("Lograste completar el juego en " + _countGuesses + " intentos");
            
         }
      }
   }

   void Shuffle(List<Sprite> list)
   {
      for (int i = 0; i < list.Count; i++)
      {
         Sprite temp = list[i];
         int randomIndex = UnityEngine.Random.Range(i, list.Count);
         list[i] = list[randomIndex];
         list[randomIndex] = temp;
      }
   }
}
