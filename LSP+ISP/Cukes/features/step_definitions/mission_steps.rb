                                                                        
Given(/^the Mission page$/) do 
	#puts 'Given the Mission page'
	#sleep 10
	visit(MissionPage) 
end                                                                     
                                                                        
When(/^I get the image at the (center of the map)$/) do |center_of_map|                  
	@map_image = on(MissionPage).get_image_at center_of_map     
end                                                                     
                                                                        
Then(/^it will be (the rover)$/) do |name|                                
	@map_image.should include name   
end         
   

		#When I click the add button
		#Then 10x10 will display an obstacle   
When(/^I click on the map at ((\d+)x(\d+))$/) do |image_location, x, y|  
	#puts 'And I click on the map at 10x10'
	#sleep 10
	on(MissionPage).click_control_at image_location 
end  

When(/^I click the add button$/) do
	on(MissionPage).addObstacles
end  
                                                                 
Then(/^the image at (location "(.*?)") will (display an obstacle)$/) do |location, coordinate, image|                      
	(on(MissionPage).get_image_at location).should include image   
end  

Then(/^an alert message with "(.*?)" should be shown$/) do |message|
  message = on(MissionPage).get_alert_message
  message.should include message
end
 
When(/^I send the forward command$/) do
	on(MissionPage) do |page|
		page.moveForward
		page.sendCommands
	end
end

When(/^I send the backward command$/) do
	on(MissionPage) do |page|
		page.moveBackward
		page.sendCommands
	end
end

When(/^I send the turn right command$/) do
	on(MissionPage) do |page|
		page.turnRight
		page.sendCommands
	end
end

Then(/^(the rover) will be (facing East)$/) do |rover_name, direction|
	on(MissionPage) do |page|
		roverImage = page.get_image_at '25_25'
		roverImage.should include rover_name   
		roverImage.should include direction
	end
end
                                                    
When(/^I send the turn left command$/) do
	on(MissionPage) do |page|
		page.turnLeft
		page.sendCommands
	end
end

Then(/^(the rover) will be (facing West)$/) do |rover_name, direction|
	on(MissionPage) do |page|
		roverImage = page.get_image_at '25_25'
		roverImage.should include rover_name  
		roverImage.should include direction
	end
end

Then(/^(the rover) will still be at the (center of the map)$/) do |rover_name, center_of_map|                  
	map_image = on(MissionPage).get_image_at center_of_map 
	map_image.should include rover_name 
end  

When(/^I fire a missile$/) do
	on(MissionPage) do |page|
		page.fireMissile
		page.sendCommands
	end
end

When(/^I fire a mortar$/) do
	on(MissionPage) do |page|
		page.fireMortar
		page.sendCommands
	end
end

Then(/^((\d+)x(\d+)) will not (display a crater)$/) do |image_location, x, y, crater_name|
	image = on(MissionPage).get_image_at image_location  
	image.should_not include crater_name
end

Given(/^I create a crater at maximum distance$/) do 
	on(MissionPage) do |page|
		page.fireMissile
		page.sendCommands
	end
end

Given(/^I add an obstacle at ((\d+)x(\d+))$/) do |map_location, x, y|
	on(MissionPage) do |page|
		page.click_control_at map_location
		page.addObstacles
	end
end                                            

Given(/^the rover moves backward ((\d+) steps)$/) do |number_of_steps, number_as_string|
	number_of_steps.times {
		on(MissionPage).moveBackward
	}
	on(MissionPage).sendCommands
end

Given(/^the rover moves forward ((\d+) steps)$/) do |number_of_steps, number_as_string|
	number_of_steps.times {
		on(MissionPage).moveForward
	}
	on(MissionPage).sendCommands
end

Then(/^((\d+)x(\d+)) will (display a crater)$/) do |image_location, x, y, crater_name|
	image = on(MissionPage).get_image_at image_location  
	image.should include crater_name
end

Then(/^((\d+)x(\d+)) will (display the ground)$/) do |image_location, x, y, ground_name|
	image = on(MissionPage).get_image_at image_location  
	image.should include ground_name
end

Then(/^((\d+)x(\d+)) will (display an obstacle)$/) do |image_location, x, y, obstacle_name|
	image = on(MissionPage).get_image_at image_location  
	image.should include obstacle_name
end

Then(/^((\d+)x(\d+)) will display (the rover)$/) do |image_location, x, y, rover_name|
	image = on(MissionPage).get_image_at image_location  
	image.should include rover_name
end







                                                                                                                                          