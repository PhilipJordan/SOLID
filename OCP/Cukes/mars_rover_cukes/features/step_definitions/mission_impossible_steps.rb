

Then(/^I can move off the North edge$/) do
  turnRight
  moveForward
  moveForward
  moveForward
  moveForward
  moveForward
  
  puts "How did I get over here?"
end


Then(/^I can move off the East edge$/) do
	
	
  
  
  
  sleep 10
end

Then(/^I will be free$/) do
  
  sleep 2
  moveForward
  moveForward
  moveForward
  moveForward
  moveForward
  moveForward
  moveForward
  moveForward
  moveForward
  moveForward
  moveForward
  moveForward
  moveForward
  moveForward
  moveForward
  moveForward
  turnLeft
  moveForward
  moveForward
  moveForward
  moveForward
  moveForward
  moveForward
  moveForward
  moveForward
  moveForward
  moveForward
  moveForward
  moveForward
  moveForward
  moveForward
  moveForward
  moveForward
  moveForward
  moveForward
  moveForward
  sleep 5
  
  puts "Here goes nothing!"
  
  
  moveForward
  moveForward
  moveForward
  moveForward
  moveForward
  #turnRight
  #moveForward
  #moveForward
  #moveForward
  
  puts "Where the heck am I?"
  
  
  
end


When(/^I bust a move$/) do



  moveForward
  turnRight
  moveForward
  moveForward
  turnLeft
  moveBackward
  moveBackward
  moveBackward
  turnLeft
  moveForward
  moveForward
  moveForward
  moveForward
  turnRight
  moveForward
  moveForward
  moveForward
  moveForward
  moveForward
  turnLeft
  moveBackward
  moveBackward
  moveBackward
  moveBackward
  moveBackward
  moveBackward
  turnLeft
  moveForward
  moveForward
  moveForward
  moveForward
  moveForward
  moveForward
  moveForward
  turnRight
  moveForward
  moveForward
  moveForward
  moveForward
  moveForward
  moveForward
  moveForward
  moveForward
  turnLeft
  moveBackward
  moveBackward
  moveBackward
  moveBackward
  moveBackward
  moveBackward
  moveBackward
  moveBackward
  moveBackward
  turnLeft
  moveForward
  moveForward
  moveForward
  moveForward
  moveForward
  moveForward
  moveForward
  moveForward
  moveForward
  moveForward
  moveForward
  
  puts "Woot!!! In your face Mars!"
  
end



Given(/^an absurd maze of obstacles$/) do
	on(MissionPage) do |page|
		
		page.click_control_at '20_20'
		page.click_control_at '20_21'
		page.click_control_at '20_22'
		page.click_control_at '20_23'
		page.click_control_at '20_24'
		page.click_control_at '20_25'
		page.click_control_at '20_26'
		page.click_control_at '20_27'
		page.click_control_at '20_28'
		page.click_control_at '20_29'
		page.click_control_at '20_30'
		page.click_control_at '20_31'

		
		page.click_control_at '21_20'
		#page.click_control_at '21_21'
		#page.click_control_at '21_22'
		#page.click_control_at '21_23'
		#page.click_control_at '21_24'
		#page.click_control_at '21_25'
		#page.click_control_at '21_26'
		#page.click_control_at '21_27'
		#page.click_control_at '21_28'
		#page.click_control_at '21_29'
		#page.click_control_at '21_30'
		page.click_control_at '21_31'

		
		page.click_control_at '22_20'
		#page.click_control_at '22_21'
		page.click_control_at '22_22'
		page.click_control_at '22_23'
		page.click_control_at '22_24'
		page.click_control_at '22_25'
		page.click_control_at '22_26'
		page.click_control_at '22_27'
		page.click_control_at '22_28'
		page.click_control_at '22_29'
		#page.click_control_at '22_30'
		page.click_control_at '22_31'

		
		page.click_control_at '23_20'
		#page.click_control_at '23_21'
		page.click_control_at '23_22'
		#page.click_control_at '23_23'
		#page.click_control_at '23_24'
		#page.click_control_at '23_25'
		#page.click_control_at '23_26'
		#page.click_control_at '23_27'
		#page.click_control_at '23_28'
		page.click_control_at '23_29'
		#page.click_control_at '23_30'
		page.click_control_at '23_31'

		
		page.click_control_at '24_20'
		#page.click_control_at '24_21'
		page.click_control_at '24_22'
		#page.click_control_at '24_23'
		page.click_control_at '24_24'
		page.click_control_at '24_25'
		page.click_control_at '24_26'
		page.click_control_at '24_27'
		#page.click_control_at '24_28'
		page.click_control_at '24_29'
		#page.click_control_at '24_30'
		page.click_control_at '24_31'

		
		page.click_control_at '25_20'
		#page.click_control_at '25_21'
		page.click_control_at '25_22'
		#page.click_control_at '25_23'
		page.click_control_at '25_24'
		#page.click_control_at '25_25'
		#page.click_control_at '25_26'
		page.click_control_at '25_27'
		#page.click_control_at '25_28'
		page.click_control_at '25_29'
		#page.click_control_at '25_30'
		page.click_control_at '25_31'

		
		page.click_control_at '26_20'
		#page.click_control_at '26_21'
		page.click_control_at '26_22'
		#page.click_control_at '26_23'
		page.click_control_at '26_24'
		page.click_control_at '26_25'
		#page.click_control_at '26_26'
		page.click_control_at '26_27'
		#page.click_control_at '26_28'
		page.click_control_at '26_29'
		#page.click_control_at '26_30'
		page.click_control_at '26_31'

		
		page.click_control_at '27_20'
		#page.click_control_at '27_21'
		page.click_control_at '27_22'
		#page.click_control_at '27_23'
		#page.click_control_at '27_24'
		#page.click_control_at '27_25'
		#page.click_control_at '27_26'
		page.click_control_at '27_27'
		#page.click_control_at '27_28'
		page.click_control_at '27_29'
		#page.click_control_at '27_30'
		page.click_control_at '27_31'

		
		page.click_control_at '28_20'
		#page.click_control_at '28_21'
		page.click_control_at '28_22'
		page.click_control_at '28_23'
		page.click_control_at '28_24'
		page.click_control_at '28_25'
		page.click_control_at '28_26'
		page.click_control_at '28_27'
		#page.click_control_at '28_28'
		page.click_control_at '28_29'
		#page.click_control_at '28_30'
		page.click_control_at '28_31'

		
		page.click_control_at '29_20'
		#page.click_control_at '29_21'
		#page.click_control_at '29_22'
		#page.click_control_at '29_23'
		#page.click_control_at '29_24'
		#page.click_control_at '29_25'
		#page.click_control_at '29_26'
		#page.click_control_at '29_27'
		#page.click_control_at '29_28'
		page.click_control_at '29_29'
		#page.click_control_at '29_30'
		page.click_control_at '29_31'
		
		page.click_control_at '30_20'
		page.click_control_at '30_21'
		page.click_control_at '30_22'
		page.click_control_at '30_23'
		page.click_control_at '30_24'
		page.click_control_at '30_25'
		page.click_control_at '30_26'
		page.click_control_at '30_27'
		page.click_control_at '30_28'
		page.click_control_at '30_29'
		#page.click_control_at '30_30'
		page.click_control_at '30_31'
	
		page.addObstacles
	end
end

#adding these method calls here because I don't want this junk in the page object

def moveForward
	on(MissionPage) do |page|
		page.moveForward
		page.sendCommands
	end
	#sleep 1
end


def moveBackward
	on(MissionPage) do |page|
		page.moveBackward
		page.sendCommands
	end
	#sleep 1
end

def turnRight
	on(MissionPage) do |page|
		page.turnRight
		page.sendCommands
	end
	#sleep 1
end

def turnLeft
	on(MissionPage) do |page|
		page.turnLeft
		page.sendCommands
	end
	#sleep 1
end





















