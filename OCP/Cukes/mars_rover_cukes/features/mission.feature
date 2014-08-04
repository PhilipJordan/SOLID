
@missionControl
Feature: Beginning the Mission

   As a Rover Commander
   I want a view with controls
   So I can give the rover commands
   
	Scenario: The initial view
		Given the Mission page
		When I get the image at the center of the map
		Then it will be the rover
   
	Scenario: Adding no Obstacles
		Given the Mission page
		When I click the add button
		Then an alert message with "Unable to update obstacles" should be shown
   
	Scenario: Adding an Obstacle
		Given the Mission page
		And I click on the map at 10x10
		When I click the add button
		Then 10x10 will display an obstacle
	
	Scenario: Adding multiple obstacles
		Given the Mission page
		And I click on the map at 5x5  
		And I click on the map at 10x10
		And I click on the map at 15x15
		When I click the add button 
		Then 5x5 will display an obstacle
		And 10x10 will display an obstacle 
		And 15x15 will display an obstacle
	
	Scenario: Giving forward command
		Given the Mission page 
		When I send the forward command
		Then 25x26 will display the rover 
		And 25x25 will display the ground
    
	Scenario: Giving backward command
		Given the Mission page 
		When I send the backward command
		Then 25x24 will display the rover
		And 25x25 will display the ground
	
	Scenario: Turning Right
		Given the Mission page
		When I send the turn right command
		Then the rover will be facing East
	
	Scenario: Turning Left
		Given the Mission page
		When I send the turn left command
		Then the rover will be facing West
 
	Scenario: Obstacles in front of rover
		Given the Mission page
		And I add an obstacle at 25x26
		#And default obstacles on the map
		When I send the forward command
		Then the rover will still be at the center of the map
	
	Scenario: Obstacles behind the rover
		Given the Mission page
		And I add an obstacle at 25x24
		#And default obstacles on the map
		When I send the backward command
		Then the rover will still be at the center of the map 
	 
	Scenario: Firing Rockets without obstacles
		Given the Mission page 
		When I fire a missile
		Then 25x30 will display a crater
	
	Scenario: Firing Rockets with obstacles
		Given the Mission page
		And I add an obstacle at 25x26 	
		When I fire a missile
		Then 25x26 will display the ground
		And 25x30 will not display a crater
		
	Scenario: Firing Rockets at craters
		Given the Mission page
		And I create a crater at maximum distance
		When I fire a missile
		Then 25x30 will display a crater
	
	Scenario: Firing Rockets over craters at obstacles
		Given the Mission page
		And I add an obstacle at 25x31
		And I create a crater at maximum distance
		And the rover moves forward 1 steps
		When I fire a missile
		Then 25x31 will display the ground
		
	Scenario: Firing a Rocket beyond the map border
		Given the Mission page
		And the rover moves forward 25 steps
		When I fire a missile 
		Then 25x4 will display a crater
	
	Scenario: Firing a Mortar beyond the map border
		Given the Mission page
		And the rover moves forward 20 steps
		When I fire a mortar 
		Then 25x4 will display a crater
		
	#Scenario: Firing a Mortar over obstacles at another obstacle
		#Given the Mission page
		
		
	#Scenario: Clicking the send commands button without commands selected
		
	
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		