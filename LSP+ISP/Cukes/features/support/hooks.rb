require 'watir-webdriver'

browser = Watir::Browser.new :firefox #:chrome, :switches => %w[--test-type]# 

Before do
	@browser = browser #Watir::Browser.new :firefox# 
end

After do
	browser.goto "#{$environment}" #/Mission/Index" 
end

at_exit do
	browser.close
end