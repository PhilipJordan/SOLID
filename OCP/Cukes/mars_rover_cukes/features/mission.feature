
@missionControl
Feature: Beginning the Mission

   As a Rover Commander
   I want a view with controls
   So I can give the rover commands
   
   Scenario: The initial view
     Given the Mission page
     When I get the image at the center of the map
     Then it will be the "Rover" image
   
   Scenario: Adding an Obstacle
     Given the Mission page
	 When I click on the map at location "10, 10"
	 And I click the "Add" button
	 Then the image at location "10, 10" will display an obstacle
	 
   Scenario: Adding multiple obstacles
     Given the Mission page
	 When I click on the map at location "5, 5" 
	 And I click on the map at location "10, 10"
	 And I click on the map at location "15, 15"
	 And I click the "Add" button 
	 Then the image at location "5, 5" will display an obstacle
	 And the image at location "10, 10" will display an obstacle 
	 And the image at location "15, 15" will display an obstacle
	 
   
   Scenario: Giving commands
     Given the Mission page
	 #And default obstacles on the map 
	 When I send the forward command
	 Then the rover will 1 step to the north
	 