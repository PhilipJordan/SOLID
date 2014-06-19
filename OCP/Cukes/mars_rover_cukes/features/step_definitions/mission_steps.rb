                                                                        
Given(/^the Mission page$/) do                                          
  visit(MissionPage)    
end                                                                     
                                                                        
When(/^I get the image at the (center of the map)$/) do |center_of_map|                  
  @map_image = on(MissionPage).get_image_at center_of_map     
end                                                                     
                                                                        
Then(/^it will be the "(.*?)" image$/) do |name|                                
  @map_image.should include name   
end                                                                     
                                                                        																		                                                                      
When(/^I add an obstacle to (location "(.*?)")$/) do |id, coordinate|             
  puts "The transformation in the step is #{id}"
  puts "The coordinate in the step is #{coordinate}" 
  #click control to add stuff   
end                                                                   
                                                                      
Then(/^the image at (location "(.*?)") will display an obstacle$/) do |id, coordinate|                      
  puts "The transformation in the step is #{id}"
  puts "The coordinate in the step is #{coordinate}" 
  #check image at the location   
end                                                                   