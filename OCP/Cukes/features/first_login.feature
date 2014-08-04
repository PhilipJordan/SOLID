@withoutPageObject
Feature: Access to the Mission
   
     Just some text about nothing and stuff
   
   @username
   Scenario: Logging in with invalid credentials
	  Given the login page without PageObject
	  When I log in with the wrong user name without PageObject
	  Then an error message "Wrong Password or User Name given" will be shown without PageObject

   @password
   Scenario: Logging in with invalid password
	  Given the login page without PageObject 
	  When I log in with the wrong password without PageObject
	  Then an error message "Wrong Password or User Name given" will be shown without PageObject	  
	  
   Scenario: Missing User Name
      Given the login page without PageObject
	  When I log in without the user name without PageObject
	  Then an error message "The User Name field is required" will be shown without PageObject 

   Scenario: Missing User Name
      Given the login page without PageObject
	  When I log in without the password without PageObject
	  Then an error message "The Password field is required" will be shown without PageObject 

   @tagsAreAwesome
   Scenario: Logging in with valid credentials
      Given the login page without PageObject
	  When I log in with valid credentials without PageObject
	  Then the staging mission page will be shown without PageObject