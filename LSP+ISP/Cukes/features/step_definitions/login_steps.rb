                                                                       
Given(/^the login page$/) do                                           
  visit(LoginPage)   
end                                                                    
                                                                       
When(/^I log in with the wrong user name$/) do                         
  on(LoginPage).login_with "WrongUserName", "Rover123"
end    
                                                                       
When(/^I log in with the wrong password$/) do                         
  on(LoginPage).login_with "Red", "WrongPassword"
end                                                                     
                                                                       
Then(/^an error message "(.*?)" will be shown$/) do |message| 
  on(LoginPage).text.should include message    
end                                                                    
                                                                       
When(/^I log in without the user name$/) do                            
  on(LoginPage).login_with nil, "Rover123"   
end                                                                    
                                                                       
When(/^I log in without the password$/) do                             
  on(LoginPage).login_with "Red", nil    
end                                                                    
                                                                       
When(/^I log in with valid credentials$/) do                           
  #puts "The title exists : #{on(MissionPage).title?}"
  
  on(LoginPage).login_with "Red", "Rover123"
end                                                                    
                                                                       
Then(/^the staging mission page will be shown$/) do                    
  #Why don't we need sleep 7 here? (discuss)
  #puts on(MissionPage)
  #puts on(MissionPage).title?
  
  on(MissionPage).title?.should be_true     
end                                                                    
                                                                       