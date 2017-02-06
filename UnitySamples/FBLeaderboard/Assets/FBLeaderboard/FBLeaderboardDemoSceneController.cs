﻿using UnityEngine;
using System.Collections;
using ChilliConnect;

/// The main controller class for the Facebook Leaderboard demo. Creates the systems and handles the main control flow
/// including intialising ChilliConnect.
/// 
/// Demo: 
/// - Creates an anonymous ChilliConnect player
/// - Allows the player to login to Facebook via a button press and associates the Facebook account with ChilliConnect.
/// - Allows the player to post a score to a ChilliConnect leaderboard.
/// - Pulls and displays the player's FB friends scores and profile pictures.
/// 
/// More info on setting up ChilliConnect can be found here: https://docs.chilliconnect.com/guide/setup/
/// 
public class FBLeaderboardDemoSceneController : MonoBehaviour 
{
	//TODO: Revert token
	//TODO: Make leaderboard top aligned
	//TODO: Test with friends
	const string GAME_TOKEN = "KI5EjX8EU65TNM5fTdCmvGKWixMpENtZ";//"Vv7VANzImRtEUeiYaoz4lWKqB6t349iy";

	private ChilliConnectSdk m_chilliConnect = null;
	private AccountSystem m_accountSystem = new AccountSystem();
	private LeaderboardSystem m_leaderboardSystem = new LeaderboardSystem();
	private ProfilePicSystem m_profilePicSystem = new ProfilePicSystem();

	/// Initialised ChilliConnect, create and log in a player.
	/// 
	private void Awake()
	{
		// Initialise ChilliConnect. Game token can be found on the game dashboard of ChilliConnect
		m_chilliConnect = new ChilliConnectSdk(GAME_TOKEN, true); 

		m_accountSystem.Initialise(m_chilliConnect);
		m_leaderboardSystem.Initialise(m_chilliConnect);
		m_profilePicSystem.Initialise();
	}
}