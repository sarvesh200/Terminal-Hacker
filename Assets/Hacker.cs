using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour {
	//game configuration data
	const string menuhint= "You may type menu at any time";
	string[] level1passwords = {"root","accsess","database","network","power"};
	string[] level2passwords = {"Account","finance","tresury","systemofficer","cashier"};
	string[] level3passwords = {"AccessKey","Astronout","spacesshuttle","blackhole","satellite"};

	// Game State
	int level;
	enum Screen{MainMenu,Password,Win};
	Screen currentScreen = Screen.MainMenu;
	string password;

	void Start () { 

		ShowMainMenu();
	
	}


	void ShowMainMenu(){
		currentScreen = Screen.MainMenu;
		Terminal.ClearScreen ();
		Terminal.WriteLine ("WELCOME TO CTOS");
		Terminal.WriteLine ("What Would you really like to HACK? ");
		Terminal.WriteLine ("we have got three different Systems");
		Terminal.WriteLine ("press 1 To hack into the campusserver");
		Terminal.WriteLine ("press 2 To hack into Baank");
		Terminal.WriteLine ("press 3 To penetrate the NASA security level");
		Terminal.WriteLine ("Enter your Selection:");
	}
	void OnUserInput(string input){
		//we can direclt go to main menu
		if (input == "menu") {

			ShowMainMenu ();
		} else if (currentScreen == Screen.MainMenu) {
			RunMainMenu (input);
		} else if (currentScreen == Screen.Password) {
			CheckPassword (input);
		} else {
			Terminal.WriteLine("please choose a valid level");
		
		}
	}

	void RunMainMenu(string input){
		bool isValidlevNumber = (input == "1" || input == "2"||input == "3");
		if (isValidlevNumber) {
			level = int.Parse (input);
		
		
			AskForPassword ();
		}
		 else {
			Terminal.WriteLine ("choose valid level");
			Terminal.WriteLine(menuhint);
		}
	}

	void AskForPassword(){
		int Index;
		currentScreen = Screen.Password;

		Terminal.ClearScreen ();
		SetRandomPassword ();
		Terminal.WriteLine (" enter your Password, hint: "+ password.Anagram());
		Terminal.WriteLine(menuhint);
		}
	void SetRandomPassword(){
		switch (level) {
		case 1:

			password = level1passwords [Random.Range (0, level1passwords.Length)];
			break;
		case 2:

			password = level2passwords [Random.Range (0, level2passwords.Length)];
			break;
		case 3:
			password = level3passwords [Random.Range (0, level3passwords.Length)];
			break;
		default:
			Debug.LogError ("invalid level number");
			break;
		}
	}


	void CheckPassword(string input){
		if (input == password) {
			DisplayWinScreen();
		} else {
			AskForPassword ();
		}
	}

	void DisplayWinScreen(){

		currentScreen = Screen.Win;
		Terminal.ClearScreen ();

		ShowLevalReward ();
		Terminal.WriteLine (menuhint);
	}

	void ShowLevalReward (){
		switch(level)
		{
		case 1:

			Terminal.WriteLine ("you have got a book!");
			Terminal.WriteLine (@"
	_________		
   /        //
  /________//
 /________//
(________(/                 ");

			Terminal.WriteLine ("Play higher level for more challange");
			break;


		case 2:

			Terminal.WriteLine ("you have got a key to the locker!");
			Terminal.WriteLine (@"
	

 __ 
|0  \_____________
\___/_=' == '=/|\|


   ");

			Terminal.WriteLine ("Play higher level for more challange");
			break;

		case 3:

			Terminal.WriteLine ("you have got NASA Source code!");
			Terminal.WriteLine (@"
	       .._____
  ____     ()____\
  |   |\  /  \
  |   | \/    \
  |   |  \_____\_
  |   |   \     |
           \    |
  |___|     \___| 
 
   ");
			Terminal.WriteLine("You are Lengendary Hacker");
			break;


		default:
			Debug.LogError ("Invalid message");
			break;




	}







}










}





