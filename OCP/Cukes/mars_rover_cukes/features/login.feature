@withPageObject
Feature: Access to the Mission
   
   As a user
   I want to gain access to Mission Control
   or know what I did wrong if I can not
   
   @username
   Scenario: Logging in with invalid user name
	  Given the login page 
	  When I log in with the wrong user name
	  Then an error message "Wrong Password or User Name given" will be shown

   @password	  
   Scenario: Logging in with invalid password
	  Given the login page 
	  When I log in with the wrong password
	  Then an error message "Wrong Password or User Name given" will be shown
	  
   Scenario: Missing User Name
      Given the login page
	  When I log in without the user name
	  Then an error message "The User Name field is required" will be shown 

   Scenario: Missing User Name
      Given the login page
	  When I log in without the password
	  Then an error message "The Password field is required" will be shown 

   @tagsAreAwesome
   Scenario: Logging in with valid credentials
      Given the login page
	  When I log in with valid credentials
	  Then the staging mission page will be shown