
@missionControl
Feature: Beginning the Mission

   As a Rover Commander
   I want a view with controls
   So I can give the rover commands
   
	Scenario: The initial view
		Given the Mission page
		When I get the image at the center of the map
		Then it will be the "Rover" image
   
	Scenario: Adding no Obstacles
		Given the Mission page
		When I click the "Add" button
		Then an alert message with "Unable to update obstacles" should be shown
   
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
	 
	Scenario: Giving forward command
		Given the Mission page 
		When I send the forward command
		Then the rover will move 1 step to the north
		And the old position will display ground
   
	Scenario: Giving backward command
		Given the Mission page 
		When I send the backward command
		Then the rover will move 1 step to the south
		And the old position will display ground
	 
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
		And default obstacles on the map
		When I send the forward command
		Then the rover will still be at the center of the map
	
	Scenario: Obstacles behind the rover
		Given the Mission page
		And default obstacles on the map
		When I send the backward command
		Then the rover will still be at the center of the map 
	 
	Scenario: Firing Rockets without obstacles
		Given the Mission page 
		When I fire a missile
		Then a crater will be formed
		
	Scenario: Firing Rockets with obstacles
		Given the Mission page
		And default obstacles on the map		
		When I fire a missile
		Then obstacle is destroyed 
		And a crater will not be formed
		
	Scenario: Firing Rockets at craters
		Given the Mission page
		And crater exists 10 steps to the north
		When I fire a missile
		Then obstacle is not destroyed
		
	Scenario: Firing Rockets over craters at obstacles
		Given the Mission page
		And I click on the map at location "25, 36"
		And I click the "Add" button
		And crater exists 10 steps to the north
		And I send the forward command
		When I fire a missile
		Then obstacle is destroyed at 25x36
		
	Scenario: Firing a Rocket beyond the map border
		Given the Mission page
		And the rover moves forward 20 steps
		When I fire a missile 
		Then 25x4 will display a crater
	
	@foo
	Scenario: Firing a Mortar beyond the map border
		Given the Mission page
		And the rover moves forward 10 steps
		When I fire a mortar 
		Then 25x4 will display a crater
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		