
class MissionPage
  include PageObject
  include RSpec::Matchers
  
  page_url "#{$environment}/Mission/Staging" 
  h3(:title, :id => "MissionControl")
  button(:addObstacles, :value => 'Add')
  button(:sendCommands, :id => 'sendCommands')
  button(:moveForward, :id => 'forward')
  button(:moveBackward, :id => 'backward')
  button(:turnRight, :id => 'right')
  button(:turnLeft, :id => 'left')
  button(:fireMissile, :id => 'fireMissile')
  button(:fireMortar, :id => 'fireMortar')
  
  def get_alert_message_on_button_click 
	
    message = self.alert do
		self.addObstacles
	end
	message
  end
  
  def get_alert_message_on &block 
    message = self.alert do 
		yield
	end
	message
	#puts "#{element}"
  end
  
  def get_alert_message
	message = @browser.alert.text
	@browser.alert.close
	message
  end
  
#  def verifyAlertMessageIsCreatedWith message
#	messageReturned = self.alert do
#		self.addObstacles
#	end
#	
#	messageReturned.should include message
# end
  
  def get_image_at image_id
     @browser.img(:id => image_id).src	 
  end
  
  def click_control_at image_id
	@browser.img(:id => image_id).click
  end
  
  def map_does_not_include image_name
	@browser.imgs().each {|element| "#{element.src.should_not include image_name}"} 
  end
  
  def alert_message
	@message
  end
  
end