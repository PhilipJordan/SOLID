
Given(/^the login page without PageObject$/) do
  @browser.goto 'http://localhost:53332/' 
end

When(/^I log in with the wrong user name without PageObject$/) do
  @browser.text_field(:id => 'UserName').set('WrongNameFred')
  @browser.text_field(:id => 'Password').set('Rover123')
  @browser.button(:value => 'Log In').click
end

When(/^I log in with the wrong password without PageObject$/) do
  @browser.text_field(:id => 'UserName').set('Red')
  @browser.text_field(:id => 'Password').set('WrongPassword')
  @browser.button(:value => 'Log In').click
end

Then(/^an error message "(.*?)" will be shown without PageObject$/) do |message|
  @browser.text.should include message  
end

When(/^I log in without the user name without PageObject$/) do
  @browser.text_field(:id => 'Password').set('WrongPasswordToo')
  @browser.button(:value => 'Log In').click
end

When(/^I log in without the password without PageObject$/) do
  @browser.text_field(:id => 'UserName').set('WrongNameFred')
  @browser.button(:value => 'Log In').click
end

When(/^I log in with valid credentials without PageObject$/) do
  @browser.text_field(:id => 'UserName').set('Red')
  @browser.text_field(:id => 'Password').set('Rover123')
  @browser.button(:value => 'Log In').click
  sleep 7
end

Then(/^the staging mission page will be shown without PageObject$/) do
  controlHeading = @browser.h3 :id => 'MissionControl'
  controlHeading.should exist
end