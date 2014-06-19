@missionControl
Feature: Beginning the Mission

   As a Rover Commander
   I want a view with controls
   So I can give the rover commands
   
   Scenario: The initial view
     Given the Mission page
     When I get the image at the center of the map
     Then it will be the "Rover" image
   
   Scenario: Adding Obstacles
     Given the Mission page
	 When I add an obstacle to location "25, 25"
	 Then the image at location "25, 25" will display an obstacle