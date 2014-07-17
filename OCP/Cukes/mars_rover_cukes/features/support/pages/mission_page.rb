class MissionPage
  include PageObject
  
  page_url("http://localhost:53332/mission/staging")
  h3(:title, :id => "MissionControl")
  button(:addObstacles, :value => 'Add')
  button(:sendCommands, :id => 'sendCommands')
  button(:moveForward, :id => 'forward')
  
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
    defaultObstacles = {:northObstacle => "25_30", :eastObstacle => "30_25", :southObstacle => "25_20", :westObstacle => "20_25"}
    
	@browser.img(:id => defaultObstacles[:northObstacle]).click
	@browser.img(:id => defaultObstacles[:eastObstacle]).click
	@browser.img(:id => defaultObstacles[:southObstacle]).click
	@browser.img(:id => defaultObstacles[:westObstacle]).click
	
	self.addObstacles
  end
  
  def alert_message
	@message
	
	#message = self.alert do
	#	self.addObstacles
	#nd
  
	#p message
  end
  
end