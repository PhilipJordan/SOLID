class LoginPage
  include PageObject
   
  page_url("http://localhost:53332/")
  text_field(:username, :id => "UserName")
  text_field(:password, :id => "Password")
  button(:login, :value => "Log In")
  
  def login_with username=nil, password=nil
	self.username = username
	self.password = password
	self.login
  end
 
end