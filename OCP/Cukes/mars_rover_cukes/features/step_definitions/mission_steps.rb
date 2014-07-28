                                                                        
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
  
#Added this special method until I figure out how I want to use page.alert feature  
When(/^I click the add button$/) do                                           
            
end                                                                           
                                                                              
                                                                              

Given(/^(default obstacles) on the map$/) do |blar|
	on(MissionPage).add_default_obstacles
	
end

When(/^I send the forward command$/) do
	on(MissionPage) do |page|
		page.moveForward
		page.sendCommands
	end
end

Then(/^the rover will move (\d+) step to the north$/) do |number_of_steps| #, north_location|
	on(MissionPage) do |page|
	sleep 1
	roverImage = page.get_image_at '25_26'
	roverImage.should include 'Rover'
	
	# $("img[src$='Rover.png']")
		# TODO: make method that finds location of Rover by its value
		#(page.get_image_at north_location).should include 
		
	end
end           

Then(/^the old position will display ground$/) do 
	on(MissionPage) do |page|
	sleep 1
		
	oldRoverImage = page.get_image_at '25_25'
	oldRoverImage.should include 'Ground'
	end
end                                                       
#the old position will display ground

















                                                                                                                                          