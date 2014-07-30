                                                                        
Given(/^the Mission page$/) do                                          
	visit(MissionPage)    
end                                                                     
                                                                        
When(/^I get the image at the (center of the map)$/) do |center_of_map|                  
	@map_image = on(MissionPage).get_image_at center_of_map     
end                                                                     
                                                                        
Then(/^it will be the "(.*?)" image$/) do |name|                                
	@map_image.should include name   
end                                                                     
                                                                        																		                                                                      
When(/^I click on the map at (location "(.*?)")$/) do |id, coordinate|             
	on(MissionPage).click_control_at id 
end                                                                   
     
When(/^I click the "(.*?)" button$/) do |button_name|
	@alert_message = on(MissionPage).click_button_with button_name
end
                                                                 
Then(/^the image at (location "(.*?)") will (display an obstacle)$/) do |location, coordinate, image|                      
	(on(MissionPage).get_image_at location).should include image   
end  

Then(/^an alert message with "(.*?)" should be shown$/) do |message|
  @alert_message.should include message
end
                                                        
                                                                            
#Below this are prime candidates for re-factoring. Getting this done for the OCP presentation. Refactor for Code && Beer talk                                                                           

Given(/^(default obstacles) on the map$/) do |blar|
	on(MissionPage).add_default_obstacles
	
end

When(/^I send the forward command$/) do
	on(MissionPage) do |page|
		page.moveForward
		page.sendCommands
	end
end


#When(/^I send the forward command (\d+) times$/) do |number_of_moves|
#  number_of_moves do 
#	on(MissionPage) do |page|
#		page.moveForward
#		page.sendCommands
#	end
#  end
#end

#Then(/^the rover will move forward (\d+) times$/) do |number_of_moves|
#	on(MissionPage) do |page|
#		roverImage = page.get_image_at '25_29'
#		roverImage.should include 'Rover'
#	end
#end



When(/^I send the backward command$/) do
	on(MissionPage) do |page|
		page.moveBackward
		page.sendCommands
	end
end

Then(/^the rover will move (\d+) step to the south$/) do |number_of_steps|
	on(MissionPage) do |page|
		roverImage = page.get_image_at '25_24'
		roverImage.should include 'Rover'
	end
end

Then(/^the rover will move (\d+) step to the north$/) do |number_of_steps| #, north_location|
	on(MissionPage) do |page|
		roverImage = page.get_image_at '25_26'
		roverImage.should include 'Rover'
	end
end           

Then(/^the old position will display ground$/) do 
	on(MissionPage) do |page|
		oldRoverImage = page.get_image_at '25_25'
		oldRoverImage.should include 'Ground'
	end
end   

When(/^I send the turn right command$/) do
	on(MissionPage) do |page|
		page.turnRight
		page.sendCommands
	end
end

Then(/^the rover will be facing East$/) do
	on(MissionPage) do |page|
		roverImage = page.get_image_at '25_25'
		roverImage.should include 'Rover-E'
	end
end
                                                    
When(/^I send the turn left command$/) do
	on(MissionPage) do |page|
		page.turnLeft
		page.sendCommands
	end
end

Then(/^the rover will be facing West$/) do
	on(MissionPage) do |page|
		roverImage = page.get_image_at '25_25'
		roverImage.should include 'Rover-W'
	end
end

Then(/^the rover will still be at the (center of the map)$/) do |center_of_map|                  
	map_image = on(MissionPage).get_image_at center_of_map 
	map_image.should include 'Rover'
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

Then(/^a crater will be formed$/) do
	on(MissionPage) do |page|
		theImage = page.get_image_at '25_35'
		theImage.should include 'crater'
	end
end


Then(/^obstacle is destroyed$/) do
	on(MissionPage) do |page|
		theImage = page.get_image_at '25_26'
		theImage.should include 'Ground'
	end
end

Then(/^a crater will not be formed$/) do
	on(MissionPage) do |page|
		theImage = page.get_image_at '25_35'
		theImage.should_not include 'crater'
	end
end

Given(/^crater exists (\d+) steps to the north$/) do |number_of_steps|
	on(MissionPage) do |page|
		page.fireMissile
		page.sendCommands
	end
end

Then(/^obstacle is not destroyed$/) do
	on(MissionPage) do |page|
		theImage = page.get_image_at '25_35'
		theImage.should include 'crater'
	end
end                                              
                                                                   
Then(/^obstacle is destroyed at (\d+)x(\d+)$/) do |x, y|
	on(MissionPage) do |page|
		theImage = page.get_image_at "#{x}_#{y}"
		theImage.should include 'Ground'
	end
end                                                                

Given(/^the rover moves forward (\d+) steps$/) do |steps|
	steps.to_i.times {
		on(MissionPage).moveForward
	}
	on(MissionPage).sendCommands
end

Then(/^((\d+)x(\d+)) will (display a crater)$/) do |image_location, x_location, y_location, crater_name|
	image = on(MissionPage).get_image_at image_location  
	image.should include crater_name
end


	#puts "image_location is #{image_location}"
	#puts "x_location is #{x_location}"
	#puts "y_location is #{y_location}"
	#puts "crater_name is #{crater_name}"






                                                                                                                                          