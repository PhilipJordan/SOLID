#copy code to here and cleanup real class when done (change names to protect the innocent) 

class DemoLoginPage
  include PageObject
  
  IMA_CONSTANT_VALUE = 1
  IMA_ALSO_CONSTANT = "ARGH!"
  
  #This line
  text_field(:username, :id => "UserName")
  text_field(:password, :id => "Password")
  button(:login, :value => "Log In")
  
  #Discuss arrays and hashes. The above is a hash
  page_url("http://localhost:53332/DarkSideOfTheMoon")
  
  #Does all of this (Is this awesomeness squared or what?! (throw nerf at anyone who says 'what'))
  #def username
  #   @browser.text_field(:id => 'UserName').value
  #end
  #
  #def username=(username)
  #   @browser.text_field(:id => 'UserName').set(username)
  #end
  #
  #def username_element
  #   @browser.text_field(:id => 'UserName')
  #end
  #
  #def username?
  #   @browser.text_field(:id => 'UserName').exists?
  #end
  #
  #Which, assuming an instantiated LoginPage called 'login', allow us to make calls like so 
  #value = login.username
  #login.username = 'some value to set'
  #element = login.username_element
  #itExists = login.username?
  
  def login_with username=nil, password=nil
	self.username = username
	self.password = password
	self.login
  end
  
  def i_can_be_seen()
	return true
  end
  
  private 
  
  def clever_duck()
     anArray = ["a","e","i","o","u"]
	 anArray[-1] #last element of the array
	 
	 aHash = {:alpha => "a", :echo => "e", :indigo => "i", :oscar => "o", :unicorn => "u" }
	 aHash[:unicorn] #an element of the hash
	 
	 aHash.each_key {|key| print key}
	 aHash.each_value {|value| print value}
	 aHash.each {|k,v| puts "#{k} has value of #{v}"}
	 
	 #Also discuss Enumerable class
  end
  
  
  def no_one_can_see_me()
    return true
  end
  
  
  
end