
class MissionPage
  include PageObject
  
  page_url $environment 
  h3(:title, :id => "MissionControl")
  button(:addObstacles, :value => 'Add')
  button(:sendCommands, :id => 'sendCommands')
  button(:moveForward, :id => 'forward')
  button(:moveBackward, :id => 'backward')
  button(:turnRight, :id => 'right')
  button(:turnLeft, :id => 'left')
  button(:fireMissile, :id => 'fireMissile')
  button(:fireMortar, :id => 'fireMortar')
  
  def click_button_with name
    @message = self.alert do
		if(name == "Add")
		   self.addObstacles
		end
	end
	@message
  end
  
  def get_image_at image_id
     @browser.img(:id => image_id).src	 
  end
  
  def click_control_at image_id
	@browser.img(:id => image_id).click
  end
  
  def add_default_obstacles  
    defaultObstacles = {:northObstacle => "25_26", :eastObstacle => "26_25", :southObstacle => "25_24", :westObstacle => "24_25"}
    
	@browser.img(:id => defaultObstacles[:northObstacle]).click
	@browser.img(:id => defaultObstacles[:eastObstacle]).click
	@browser.img(:id => defaultObstacles[:southObstacle]).click
	@browser.img(:id => defaultObstacles[:westObstacle]).click
	
	self.addObstacles
  end
  
  def alert_message
	@message
  end
  
end